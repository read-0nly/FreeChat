using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat
{
    class ChatReceipt
    {
        public string Hex;
        public string Owner;
        public string Tick;
        public ChatReceipt(string hex, string own, string tck)
        {
            Owner = own;
            Hex = hex;
            Tick = tck;
        }
        public ChatReceipt(string receipt)
        {
            string[] spl = receipt.Split(':');
            Hex = spl[0];
            Owner = spl[1];
            Tick = spl[2];
        }
        public override string ToString()
        {

            return (Hex + ":" + Owner + ":" + Tick);
        }

    }
}
