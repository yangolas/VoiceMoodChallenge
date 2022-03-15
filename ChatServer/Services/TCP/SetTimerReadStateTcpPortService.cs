using ChatServer.Bases;
using ChatServer.Interfaces.TCP;
using System.Timers;

namespace ChatServer.Services.TCP
{
    //Solid-S, single responability
    public class SetTimerReadStateTcpPortService : BaseTcpPort, ISetTimerReadStateTcpPort
    {       
        public void SetTimerReadStateTcpPort(double interval)
        {
            timer = new Timer(interval * 1000);
            timer.Enabled = true;   
        }        
    }
}
