using ChatServer.Interfaces.Custom_Message;

namespace ChatServer.Services.Custom_Message
{
    public class DisconnectedUserMessage : ICustomMessage,IUserName
    {
        public string UserName { get; set ; }

        public DisconnectedUserMessage(string userName) => UserName = userName;

        public string CustomMessage()
        {
            return $"Disconnected => {UserName}";
        }
    }
}
