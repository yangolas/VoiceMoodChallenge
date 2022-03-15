using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Timers;

namespace ChatServer.Bases
{
    //Parent Class
    public class BaseTcpPort:BaseWebSocket
    {
        protected static List<TcpConnectionInformation> TcpConnexionsOpens;
        protected static Timer timer;
    }
}
