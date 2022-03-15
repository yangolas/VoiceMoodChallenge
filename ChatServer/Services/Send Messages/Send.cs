using ChatServer.Bases;
using ChatServer.Interfaces.Send_Message;
using Fleck;
using System.Linq;

namespace ChatServer.Services.Send_Messages
{
    //Solid-I principle segragation, interface
    //Solid-S pinclie Single Responsability
    public class Send : BaseListUsersSockets, ISendService
    {
        public string Message { get; set; }
        public IWebSocketConnection Socket { get ; set; }
        
        public bool IsFromServer { get ; set ; }
        public string USERSERVER { get; set; } = "[Server]: ";

        public Send(IWebSocketConnection socket, string message, bool isFromServer = false)
        {
            Socket = socket;    
            Message = message; 
            IsFromServer = isFromServer;
        }
        public void SendMessage()
        {
            if (IsFromServer)
                Socket.Send(USERSERVER + Message);
            else
            {
                string usernameMessage = ListUsers.FirstOrDefault(x => x.socket.ConnectionInfo.Id == Socket.ConnectionInfo.Id).userName;
                Socket.Send($"[{usernameMessage}]: " + Message);
            }

                

        }       
    }
}
