using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumiSoft.Net.STUN.Client;
using LumiSoft.Net.STUN.Message;
using System.Net.Sockets;
using System.Net;

namespace FreeChat
{
    class ConnectionManager
    {
        public IPEndPoint selfInPoint;
        public IPEndPoint selfOutPoint;
        public IPEndPoint remoteInPoint;
        public IPEndPoint remoteOutPoint;
        public UdpClient inClient;
        public UdpClient outClient;

        public ConnectionManager(int inP, int outP)
        {
            inClient = new UdpClient(new IPEndPoint(IPAddress.Any, inP));
            outClient = new UdpClient(new IPEndPoint(IPAddress.Any, outP));
            selfInPoint = getEndpoint(inClient);
            selfOutPoint = getEndpoint(outClient);
        }
        public bool getStatus()
        {
            return (
                selfInPoint != null &&
                selfOutPoint != null &&
                remoteInPoint != null &&
                remoteOutPoint != null &&
                inClient.Client.IsBound &&
                outClient.Client.IsBound );
        }
        public void connectToEndpoint(IPAddress endpoint, int inport, int outport){
            remoteInPoint = new IPEndPoint(endpoint,inport);
            remoteOutPoint = new IPEndPoint(endpoint,outport);

        }
        public string encodeEndpointAddress(IPEndPoint inPoint, IPEndPoint outPoint)
        {
            string encodedAddress = "";
            foreach (byte adrB in inPoint.Address.GetAddressBytes())
            {
                encodedAddress += ((int)adrB).ToString("X2");
            }
            encodedAddress += inPoint.Port.ToString("X4");
            encodedAddress += outPoint.Port.ToString("X4");
            return encodedAddress;

        }
        public IPEndPoint[] decodeEndpointAddress(string endPoint)
        {
            IPEndPoint[] encodedAddress = new IPEndPoint[2];
            string ip = Int32.Parse(endPoint.Substring(0, 2), System.Globalization.NumberStyles.HexNumber).ToString() + "." +
                Int32.Parse(endPoint.Substring(2, 2), System.Globalization.NumberStyles.HexNumber).ToString() + "." +
                Int32.Parse(endPoint.Substring(4, 2), System.Globalization.NumberStyles.HexNumber).ToString() + "." +
                Int32.Parse(endPoint.Substring(6, 2), System.Globalization.NumberStyles.HexNumber).ToString();
            int inPortI = Int32.Parse(endPoint.Substring(8, 4), System.Globalization.NumberStyles.HexNumber);
            int outPortI = Int32.Parse(endPoint.Substring(12, 4), System.Globalization.NumberStyles.HexNumber);
            encodedAddress[0] = new IPEndPoint(IPAddress.Parse(ip), inPortI);
            encodedAddress[1] = new IPEndPoint(IPAddress.Parse(ip), outPortI);
            return encodedAddress;

        }
        public void loadRemoteEndpointPair(IPEndPoint[] epPair)
        {
            remoteInPoint = epPair[0];
            remoteOutPoint = epPair[1];
        }

        public void tunnelPaths()
        {
            sendString("!:PingPong", remoteInPoint, outClient);
            sendString("!:PingPong", remoteOutPoint, inClient);
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
        public IPEndPoint stringToEndpoint(String ep)
        {
            return new IPEndPoint(IPAddress.Parse(ep.Split(':')[0]), int.Parse(ep.Split(':')[1]));
        }

        public bool sendString(string message, string ep, UdpClient udp)
        {
            IPEndPoint target = stringToEndpoint(ep);
            byte[] byteMsg = ASCIIEncoding.ASCII.GetBytes(message);
            return sendBytes(byteMsg, target, udp);
        }
        public bool sendString(string message, IPEndPoint ep, UdpClient udp)
        {
            byte[] byteMsg = ASCIIEncoding.ASCII.GetBytes(message);
            return sendBytes(byteMsg, ep, udp);
        }
        public bool sendBytes(byte[] message, IPEndPoint ep, UdpClient udp)
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
        public byte[] receiveBytes(UdpClient udp)
        {
            try
            {
                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = udp.Receive(ref remoteOutPoint);
                return receiveBytes;
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
