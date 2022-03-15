using Fleck;

namespace ChatServer.Interfaces.Socket
{
    public interface IGetListenSocket
    {
        public WebSocketServer GetListenSocket();
    }
}
