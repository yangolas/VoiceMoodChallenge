using Fleck;

namespace ChatServer.Bases
{
    public class BaseUser
    {
        public string userName;
        public IWebSocketConnection socket;
    }
}
