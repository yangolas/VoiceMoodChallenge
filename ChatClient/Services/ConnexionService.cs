using ChatClient.Interfaces;
using PropertyChanged;
using WebSocketSharp;

namespace ChatClient.Services
{

    [AddINotifyPropertyChangedInterface]
    public class ConnexionService : BaseWebSockect,IConnexionService
    {
        public bool IsUserReady { get; set; } = false;
        public int? Port { get; set; } = null;
        public string? UserName { get; set; } = null;

        public void OnPortChanged()
        {
            //Port = Port == null ? null : UserName;
            IsUserReadyMethod();
        }
        public void OnUserNameChanged()
        {
            UserName = UserName == string.Empty ? null : UserName;
            IsUserReadyMethod();
        }
        public void Connect()
        {
            ws = new WebSocket($"ws://127.0.0.1:{Port}");
            ws.Connect();             
        }
        public bool StatusConnexion()
        {
            if (ws == null) return false;
            return ws.IsAlive;
        }
        public WebSocket GetSocketConnect()
        {
            return ws;
        }
        private void IsUserReadyMethod()
        {
            if (UserName != null && Port != null)
                IsUserReady = true;
            else
                IsUserReady = false;
        }
    }
}
