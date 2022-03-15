using ChatClient.Interfaces;
using Fleck;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatServer.Interfaces.Send_Message
{
    public interface ISendService
    {
        public IWebSocketConnection Socket { get; set; }
        public  string USERSERVER { get; set; }
        public bool IsFromServer { get; set; }
        public string Message { get; set; }
        public void SendMessage();
    }
}
