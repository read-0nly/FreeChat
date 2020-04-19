using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat
{
    class Packet
    {
        public byte[] bytes;
        public System.Net.IPEndPoint sender;

        public Packet(byte[] b, System.Net.IPEndPoint ep)
        {
            bytes = b;
            sender = ep;
        }
    }
}
