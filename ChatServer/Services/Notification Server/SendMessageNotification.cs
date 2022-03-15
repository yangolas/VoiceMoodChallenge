using ChatClient.Interfaces.Notification_Service;
using ChatServer.Interfaces.Custom_Message;
using System;

namespace ChatServer.Services.Notification_Server
{
    public class SendMessageNotification : INotification, IUserName, IMessage
    {
        public string Message { get; set; }
        public string UserName { get; set; }
        public SendMessageNotification(string userName, string text)
        {
            UserName = userName;
            Message = text;
        }
        public void Text()
        {
            Console.WriteLine($"[{UserName}] Send: {Message}");
        }
    }
}
