using Fleck;

namespace ChatServer.Interfaces.Users
{
    public interface IGetUserName
    {
        public string GetUserName(IWebSocketConnection socket);
    }
}
