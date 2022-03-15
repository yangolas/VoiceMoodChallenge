using Fleck;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatServer.Interfaces.Send_Message
{
    public interface ISendSocket
    {
        public IWebSocketConnection Socket { get; set; }
    }
}
