using ChatClient.Interfaces;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace ChatClient.Services
{
    [AddINotifyPropertyChangedInterface]
    public class SendMessageService : BaseWebSockect,ISendMessagServicee
    {
        public string Message { get; set; }  
        public void Send(string text = "")
        {
            if (text != string.Empty)
                ws.Send(text);
            else
                ws.Send(Message);
            Message = string.Empty;

        }
    }
}
