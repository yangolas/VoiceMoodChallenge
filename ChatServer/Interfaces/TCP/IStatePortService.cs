namespace ChatServer.Interfaces.TCP
{
    //Solid-D Depency Inject 
    public interface IStatePortService 
    {
        public ISetTimerReadStateTcpPort ISetTimerReadStateTcpPort { get; set; }
        public IGetTimerReadStateTcpPort IGetTimerReadStateTcpPort { get; set; }
        public IIsBusyTcpPortOfServer IIsBusyTcpPortOfServer { get; set; }
    }

}
