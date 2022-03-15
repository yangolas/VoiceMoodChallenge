using ChatServer.Bases;
using ChatServer.Interfaces.TCP;
using System.Linq;
using System.Net.NetworkInformation;

namespace ChatServer.Services.TCP
{
    //Solid-S, single responability
    public class IsBusyTcpPortOfServerService: BaseTcpPort, IIsBusyTcpPortOfServer
    {       
        public bool IsBusyTcpPortOfServer()
        {
            TcpConnexionsOpens = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections().ToList();
            if (TcpConnexionsOpens.Where(x => x.LocalEndPoint.Port == ws.Port).FirstOrDefault() != null)
                return true;
            else
                return false;           
        }

        
    }
}
