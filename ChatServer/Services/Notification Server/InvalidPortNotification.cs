using ChatClient.Interfaces.Notification_Service;
using System;


namespace ChatServer.Services.Notification_Server
{
    public class InvalidPortNotification : INotification
    {
        public void Text()
        {
            Console.WriteLine($"Invalid port number, please, Execute the program again and type a number port, \"Enter\" for exit");
        }
    }
}
