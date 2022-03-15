using ChatClient.Interfaces;

namespace ChatClient.Services
{
    public class DisconnectService : BaseWebSockect, IDisconnectService
    {
       public void Disconnect()
        {
            ws.Close();
        }
    }
}
