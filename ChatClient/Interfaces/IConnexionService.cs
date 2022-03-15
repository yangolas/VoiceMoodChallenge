using WebSocketSharp;

namespace ChatClient.Interfaces
{   
    public interface IConnexionService
    {
        public bool IsUserReady { get; set; }
        public string? UserName { get; set; }
        public int? Port { get; set; }   
        public void Connect();
        public bool StatusConnexion();
        public WebSocket GetSocketConnect();
    }
}
