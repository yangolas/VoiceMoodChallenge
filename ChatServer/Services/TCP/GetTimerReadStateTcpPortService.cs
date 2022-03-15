using ChatServer.Bases;
using ChatServer.Interfaces.TCP;
using System.Timers;

namespace ChatServer.Services.TCP
{
    //Solid-S, single responability
    public class GetTimerReadStateTcpPortService : BaseTcpPort, IGetTimerReadStateTcpPort
    {       
        public Timer GetTimerReadStateTcpPort()
        {
            return timer;
        }              
    }
}
