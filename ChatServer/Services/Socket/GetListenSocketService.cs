using ChatServer.Bases;
using ChatServer.Interfaces.Socket;
using Fleck;

namespace ChatServer.Services.Socket
{
    //Solid-S, single responability
    public class GetListenSocketService : BaseWebSocket, IGetListenSocket
    {
        public WebSocketServer GetListenSocket()
        {
            return ws;
        }
 
    }
}
