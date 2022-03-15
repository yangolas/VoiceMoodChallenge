using Fleck;

namespace ChatServer.Bases
{
    //Solid-L This class is the parent of: ServiceSettingsSocket and ServiceStatePort. for ServiceSettingsSocket is a direct inheritance, but for ServiceStatePort is the grandparent inheritance
    //that´s why ServiceSettingsSocket only need the socket, but ServiceSettingsSocket need the socket, timer and Tcp connexions, so I needed two inheritance using the principle of Liskov

    public class BaseWebSocket
    {
        protected static WebSocketServer ws;
    }
}
