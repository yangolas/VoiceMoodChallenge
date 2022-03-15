
using ChatServer.Interfaces.Custom_Message;

namespace ChatServer.Services.Custom_Message
{
    public class OffServerMessage : ICustomMessage
    {

        public string CustomMessage()
        {
            return "Server off";
        }        
    }
}
