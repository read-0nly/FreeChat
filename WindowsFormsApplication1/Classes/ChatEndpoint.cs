using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace FreeChat
{
    class ChatEndpoint
    {
        public IPEndPoint InPoint;
        public IPEndPoint OutPoint;
        public string nickname = "anonymous";
        public bool online = false;
        public string hexCode;
        public ArrayList ReceivedStack = new ArrayList();
        public ArrayList MsgStack = new ArrayList();
        public DateTime lastSeen = new DateTime();

        public ChatEndpoint(string s)
        {
            loadEndpointPair(ChatEndpoint.decodeEndpointAddress(s));
            hexCode = s;
            lastSeen = DateTime.Now;
            online = true;
        }
        public ChatEndpoint(IPEndPoint inP, IPEndPoint outP)
        {
            InPoint = inP;
            OutPoint = outP;
            hexCode = encodeEndpointAddress();
            lastSeen = DateTime.Now;
            online = true;
        }
        public static string encodeEndpointAddress(IPEndPoint inPoint, IPEndPoint outPoint)
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
        public string encodeEndpointAddress()
        {
            string encodedAddress = "";
            foreach (byte adrB in InPoint.Address.GetAddressBytes())
            {
                encodedAddress += ((int)adrB).ToString("X2");
            }
            encodedAddress += InPoint.Port.ToString("X4");
            encodedAddress += OutPoint.Port.ToString("X4");
            return encodedAddress;

        }
        public static IPEndPoint[] decodeEndpointAddress(string endPoint)
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
        public void loadEndpointPair(IPEndPoint[] epPair)
        {
            InPoint = epPair[0];
            OutPoint = epPair[1];
        }

        public override string ToString()
        {
            if(online){return nickname;}
            else{return "- "+nickname+" -";}
        }
    }
}
