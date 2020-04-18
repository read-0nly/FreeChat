using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FreeChat
{
    class ChatMessage
    {
        public string owner;
        public string ownerHex;
        public string tickCode;
        public string color;
        public string message;

        public ChatMessage(string raw)
        {
            string[] parts = raw.Split(':');
            ownerHex = parts[0];
            owner = System.Net.WebUtility.UrlDecode(parts[1]);
            tickCode = parts[2];
            color = parts[3];
            message = System.Net.WebUtility.UrlDecode(parts[4]);
        }

        public override string ToString()
        {
            return (
                ownerHex + ":" +
                System.Net.WebUtility.UrlEncode(owner) + ":" +
                tickCode + ":" +
                color + ":" +
                System.Net.WebUtility.UrlEncode(message) +";"
                );
        }
    }
}
