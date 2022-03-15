using ChatServer.Bases;
using ChatServer.Interfaces.Socket;
using Fleck;

namespace ChatServer.Services.Socket
{
    //Solid-S, single responability
    public class CreateSocketService : BaseWebSocket, ICreateSocket
    {
        //In this case always, I am going to create a socket in my local area, but if you want to extend funcionality in a public area, add the parameter with url
        public void CreateSocket(int port, string url = "ws://127.0.0.1:")
        {
            ws = new WebSocketServer(url+port);            
        }
    }
}
