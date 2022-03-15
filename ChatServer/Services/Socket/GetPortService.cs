using ChatServer.Bases;
using ChatServer.Interfaces.Socket;

namespace ChatServer.Services.Socket
{
    //Solid-S, single responability
    public class GetPortService : BaseWebSocket, IGetPort
    {
        public int GetPort()
        {
            return ws.Port;
        }
    }
}
