using ChatClient.Interfaces.Notification_Service;
using ChatServer.Interfaces.Custom_Message;
using System;


namespace ChatServer.Services.Notification_Server
{
    public class ErrorServiceNotification : INotification, IMessage
    {
        public string Message { get; set; }

        public ErrorServiceNotification(string text) => Message = text;

        public void Text()
        {
            Console.WriteLine($"Server Error: {Message}");
        }
    }
}
