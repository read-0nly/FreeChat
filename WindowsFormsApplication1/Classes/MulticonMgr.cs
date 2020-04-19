using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumiSoft.Net.STUN.Client;
using LumiSoft.Net.STUN.Message;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;

namespace FreeChat
{
    class MulticonMgr
    {
        public ChatEndpoint self;
        public Dictionary<string,ChatEndpoint> neighbours = new Dictionary<string,ChatEndpoint>();
        public UdpClient inClient;
        public UdpClient outClient;

        public MulticonMgr(int inP, int outP)
        {
            inClient = new UdpClient(new IPEndPoint(IPAddress.Any, inP));
            outClient = new UdpClient(new IPEndPoint(IPAddress.Any, outP));
            self = new ChatEndpoint(getEndpoint(inClient),getEndpoint(outClient));
        }
        public void closeAll()
        {
            inClient.Close();
            outClient.Close();
        }
        public bool getStatus()
        {
            return (
                self.InPoint != null &&
                self.OutPoint != null &&
                neighbours.Count!= 0 &&
                inClient.Client.IsBound &&
                outClient.Client.IsBound );
        }
        public void connectToEndpoint(string s){
            neighbours.Add(s,new ChatEndpoint(s));
        }

        public void tunnelPaths()
        {
            string neighborString = "!:Net:";
            foreach (ChatEndpoint n in neighbours.Values)
            {
                neighborString += n.hexCode + ";";
            }
            foreach (ChatEndpoint n in neighbours.Values)
            {
                sendString(neighborString, n.InPoint, outClient);
                sendString(neighborString, n.OutPoint, inClient);
            }
        }
        public void keepAlive()
        {
            getEndpoint(inClient);
            getEndpoint(outClient);
        }
        public void tunnelPaths(byte[] key, byte[] iv)
        {
            string neighborString = "!:Net:";
            foreach (ChatEndpoint n in neighbours.Values)
            {
                neighborString += n.encodeEndpointAddress() + ";";
            }
            byte[] encPing = MulticonMgr.EncryptStringToBytes(neighborString, key, iv);
            foreach (ChatEndpoint n in neighbours.Values)
            {
                sendBytes(encPing, n.InPoint, outClient);
                sendBytes(encPing, n.OutPoint, inClient);
            }
        }
        public void keepAlive(byte[] key, byte[] iv)
        {
            byte[] encPing = MulticonMgr.EncryptStringToBytes("!:PingPong", key, iv);
            sendBytes(encPing, self.InPoint, outClient);
            sendBytes(encPing, self.OutPoint, inClient);
        }
        IPEndPoint getEndpoint(UdpClient udp)
        {            
            // Query STUN server
            STUN_Result result = STUN_Client.Query("stun.l.google.com", 19302, udp.Client);
            if (result.NetType == STUN_NetType.UdpBlocked)
            {
                // UDP blocked or !!!! bad STUN server
                return null;
            }
            else
            {
                IPEndPoint publicEP = result.PublicEndPoint;
                // Do your stuff
                return publicEP;

            }
        }
        public static IPEndPoint stringToEndpoint(String ep)
        {
            return new IPEndPoint(IPAddress.Parse(ep.Split(':')[0]), int.Parse(ep.Split(':')[1]));
        }

        public static bool sendString(string message, string ep, UdpClient udp)
        {
            IPEndPoint target = stringToEndpoint(ep);
            byte[] byteMsg = ASCIIEncoding.ASCII.GetBytes(message);
            return sendBytes(byteMsg, target, udp);
        }
        public static bool sendString(string message, IPEndPoint ep, UdpClient udp)
        {
            byte[] byteMsg = ASCIIEncoding.ASCII.GetBytes(message);
            return sendBytes(byteMsg, ep, udp);
        }
        public static bool sendBytes(byte[] message, IPEndPoint ep, UdpClient udp)
        {
            try
            {
                // Sends a message to the host to which you have connected.

                udp.Send(message, message.Length, ep);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Console.WriteLine(e.ToString());
                Console.WriteLine("");
            }
            return false;
        }
        public static string generateKey()
        {
            Rijndael rij = Rijndael.Create();
            return(Convert.ToBase64String(rij.Key) + ":" + Convert.ToBase64String(rij.IV));
        }
        public static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        public Packet receiveBytes(UdpClient udp)
        {
            try
            {
                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, self.InPoint.Port);

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = udp.Receive(ref RemoteIpEndPoint);
                Packet p = new Packet(receiveBytes, RemoteIpEndPoint);
                return p;
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.ToString());
                Console.WriteLine();
                return null;
            }

        }

      /*  public string pingPong()
        {
            try
            {
                // Sends a message to the host to which you have connected.
                Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");


                // Sends a message to a different host using optional hostname and port parameters.
                UdpClient udpClientB = new UdpClient(11002);
                udpClientB.Send(sendBytes, sendBytes.Length, Endpoint);

                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);

                // Uses the IPEndPoint object to determine which of these two hosts responded.
                string returnMessage = "This is the message you received " + returnData.ToString() + "<br>" +
                "This message was sent from " + RemoteIpEndPoint.Address.ToString() +
                                            " on their port number " + RemoteIpEndPoint.Port.ToString();

                udpClient.Close();
                udpClientB.Close();
                return returnMessage;
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }*/
    }
}
