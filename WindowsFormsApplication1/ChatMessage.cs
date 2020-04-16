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
        public string tickCode;
        public string color;
        public string message;

        public ChatMessage(string raw)
        {
            string[] parts = raw.Split(':');
            owner = System.Net.WebUtility.UrlDecode(parts[0]);
            tickCode = parts[1];
            color = parts[2];
            message = System.Net.WebUtility.UrlDecode(parts[3]);
        }
    }
}
