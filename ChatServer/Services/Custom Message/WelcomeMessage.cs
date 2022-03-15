using ChatServer.Interfaces.Custom_Message;

namespace ChatServer.Services.Custom_Message
{
    public class WelcomeMessage : ICustomMessage
    {
        public string CustomMessage()
        {
            return "Welcome to Local Chat Server Voice Mood Challenge";
        }       
    }
}
