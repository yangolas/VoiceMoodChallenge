using ChatServer.Interfaces.TCP;

namespace ChatServer.Services.TCP
{
    //Solid-D principle inject dependencies
    public class StatePortService : IStatePortService
    {
        public ISetTimerReadStateTcpPort ISetTimerReadStateTcpPort { get; set; }
        public IGetTimerReadStateTcpPort IGetTimerReadStateTcpPort { get; set; }
        public IIsBusyTcpPortOfServer IIsBusyTcpPortOfServer { get; set; }

        public StatePortService()
        {
            ISetTimerReadStateTcpPort = new SetTimerReadStateTcpPortService();
            IGetTimerReadStateTcpPort = new GetTimerReadStateTcpPortService();
            IIsBusyTcpPortOfServer = new IsBusyTcpPortOfServerService();
        }
    }
}
