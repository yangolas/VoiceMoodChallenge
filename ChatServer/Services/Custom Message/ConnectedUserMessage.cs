using ChatServer.Interfaces.Custom_Message;

namespace ChatServer.Services.Custom_Message
{
    public class ConnectedUserMessage : ICustomMessage, IUserName
    {
        public string UserName { get; set; }

        public ConnectedUserMessage(string userName) => UserName = userName;

        public string CustomMessage()
        {
            return $"New User Connected => {UserName}";
        }
    }
}
