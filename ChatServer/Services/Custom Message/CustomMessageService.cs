
using ChatServer.Interfaces.Custom_Message;

namespace ChatServer.Services.Custom_Message
{
    //Solid-D inject dependencies
    public class CustomMessageService
    {
        public string InjectCustomMessage(ICustomMessage customMessage)
        {
            return customMessage.CustomMessage();
        }
    }
}
