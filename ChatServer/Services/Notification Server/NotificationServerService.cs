using ChatClient.Interfaces.Notification_Service;

namespace ChatServer.Services.Notification_Server
{
    //Solid-O Open close principle, when you have got always the same action, but you need use diferent categories
    //you can use this principle for extending the funcionality of the main class. 

    //Solid-I with public class NotificationServerService(): IShowNotificationServerType
    public class NotificationServerService
    {
        public void ShowNotification(INotification notificationServer)
        {
            notificationServer.Text();
        }

        
        //public class NotificationServerService(): IShowNotificationServerType
        //{

        //public void ShowNotificationServerType (NotificationServerType notification, string username = "", string text = "")
        //{
        //    switch (notification)
        //    {
        //        case NotificationServerType.Welcome:
        //            Console.WriteLine("Welcome to Local Chat Server Voice Mood Challenge");
        //            break;
        //        case NotificationServerType.NewUser:
        //            Console.WriteLine($"Connected: {username}");
        //            break;
        //        case NotificationServerType.ReceiveMessage:
        //            Console.WriteLine($"{username} said: {text}");
        //            break;
        //        case NotificationServerType.SendMessage:
        //            Console.WriteLine($"Sending to others users: {text}");
        //            break;
        //        case NotificationServerType.Warning:
        //            Console.WriteLine($"{text}");
        //            break;
        //        case NotificationServerType.Error:
        //            Console.WriteLine($"Server Error: {text}");
        //            break;
        //        case NotificationServerType.Disconnect:
        //            Console.WriteLine($"Disconnect: {username}");
        //            break;
        //        case NotificationServerType.InvalidPort:
        //            Console.WriteLine($"Invalid port number, please, Execute the program again and type again the number port");
        //            break;
        //        case NotificationServerType.BusyPort:
        //            Console.WriteLine($"Waiting..., port is being used by other aplication...");
        //            break;
        //        case NotificationServerType.ServerReady:
        //            Console.WriteLine($"Succes, server ready for listening.");
        //            break;
        //        default:
        //            break;
        //    }
        //}
        //}
    }
}
