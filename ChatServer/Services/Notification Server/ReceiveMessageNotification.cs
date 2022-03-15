using ChatClient.Interfaces.Notification_Service;
using ChatServer.Interfaces.Custom_Message;
using System;

namespace ChatServer.Services.Notification_Server
{
    public class ReceiveMessageNotification : INotification, IUserName, IMessage
    {
        public string UserName { get; set; }
        public string Message { get; set; }

        public ReceiveMessageNotification(string userName, string text)
        {
            UserName = userName;
            Message = text;
        }
        public void Text()
        {
            Console.WriteLine($"Received for => [{UserName}]: {Message}");
        }
    }
}
