using ChatClient.Interfaces.Notification_Service;
using ChatServer.Interfaces.Custom_Message;
using System;


namespace ChatServer.Services.Notification_Server
{
    public class DisconnectNotification : INotification, IUserName
    {
        public string UserName { get; set; }
        public DisconnectNotification(string userName) => UserName = userName;

        public void Text()
        {
            Console.WriteLine($"Disconnect: {UserName}");
        }
    }
}
