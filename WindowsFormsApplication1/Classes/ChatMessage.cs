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
        public bool safe = true;
        public bool whisper = false;

        public ChatMessage(string raw)
        {
            string[] parts = raw.Split(':');
            ownerHex = parts[0];
            owner = System.Net.WebUtility.UrlDecode(parts[1]);
            tickCode = parts[2];
            color = parts[3];
            whisper = (parts.Count() > 5 && (parts[5] == "Whisper;" || parts[5] == "Whisper"));
            setMessage(parts[4]);
        }
        public void setMessage(string s)
        {
            if (safe)
            {
                message = System.Net.WebUtility.HtmlEncode(System.Net.WebUtility.UrlDecode(s));
            }
            else
            {
                message = System.Net.WebUtility.UrlDecode(s);
            }
        }
        public bool compareOwner(string o)
        {
            return (System.Net.WebUtility.UrlDecode(o) == owner);
        }
        public override string ToString()
        {
            return (
                ownerHex + ":" +
                System.Net.WebUtility.UrlEncode(owner) + ":" +
                tickCode + ":" +
                color + ":" +
                System.Net.WebUtility.UrlEncode(message) +
                (whisper?":Whisper":"")+";"
                );
        }
    }
}
