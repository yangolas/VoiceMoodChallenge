using ChatClient.Interfaces.Notification_Service;
using System;

namespace ChatServer.Services.Notification_Server
{
    public class BusyPortNotification : INotification
    {
        public void Text()
        {
            Console.WriteLine($"Waiting..., port is being used by other aplication...");
        }       
    }
}
