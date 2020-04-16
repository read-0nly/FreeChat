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
        IPEndPoint selfInPoint;
        IPEndPoint selfOutPoint;
        IPEndPoint remoteInPoint;
        IPEndPoint remoteOutPoint;
        UdpClient inClient;
        UdpClient outClient;

        public ConnectionManager(int inP, int outP)
        {
            inClient = new UdpClient(new IPEndPoint(IPAddress.Any, inP));
            outClient = new UdpClient(new IPEndPoint(IPAddress.Any, outP));
            selfInPoint = getEndpoint(inClient);
            selfOutPoint = getEndpoint(outClient);
        }
        public void connectToEndpoint(IPAddress endpoint, int inport, int outport){
            remoteInPoint = new IPEndPoint(endpoint,inport);
            remoteOutPoint = new IPEndPoint(endpoint,outport);

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

        public bool sendString(string message, string ep)
        {
            IPEndPoint target = stringToEndpoint(ep);
            byte[] byteMsg = ASCIIEncoding.ASCII.GetBytes(message);
            return sendBytes(byteMsg, target);
        }
        public bool sendBytes(byte[] message, IPEndPoint ep)
        {
            try
            {
                // Sends a message to the host to which you have connected.

                outClient.Send(message, message.Length, ep);

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
        public byte[] receiveBytes()
        {
            try
            {
                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = inClient.Receive(ref RemoteIpEndPoint);
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
