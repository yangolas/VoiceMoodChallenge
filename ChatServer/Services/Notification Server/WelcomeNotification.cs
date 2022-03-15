using ChatClient.Interfaces.Notification_Service;
using System;

namespace ChatServer.Services.Notification_Server
{
    public class WelcomeNotification : INotification
    {
        public void Text()
        {
            Console.WriteLine("Welcome to Local Chat Server Voice Mood Challenge");
        }
    }
}
