using ChatServer.Bases;
using ChatServer.Interfaces.Socket;
using Fleck;

namespace ChatServer.Services.Socket
{
    //Solid-I principle segragation, interface => ISettingsSockectService : ICreateSocket, IGetListenSocket, IGetPort
    //Solid-L pinclie Liskov, BaseSettingsSockets => SettingsSockectService: BaseSettingsSockets
    //If I would want, I can use Solid-D (in fact, there are ready the service inject: Services =>  CreateSocketService, GetListenSocketSErvice, GetPortService)
    //But I want to show the different concept of Solid-I and Solid-D
    public class SettingsSockectService : BaseWebSocket, ISettingsSockectService
    {

        public void CreateSocket(int port, string url = "ws://127.0.0.1:")
        {
            ws = new WebSocketServer(url + port);
        }

        public WebSocketServer GetListenSocket()
        {
            return ws;
        }
 
        public int GetPort()
        {
            return ws.Port;
        }
        
    }
}
