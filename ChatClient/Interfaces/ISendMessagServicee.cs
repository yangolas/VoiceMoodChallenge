using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace ChatClient.Interfaces
{
    public interface ISendMessagServicee
    {
        public string Message { get; set; }
        public void Send(string text = "");

    }
}
