using ChatClient.Interfaces.Notification_Service;
using System;

namespace ChatServer.Services.Notification_Server
{

    public class ServerReadyNotification : INotification
    {
        public void Text()
        {
            Console.WriteLine($"Succes, server ready for listening.");
        }

        
    }
}
