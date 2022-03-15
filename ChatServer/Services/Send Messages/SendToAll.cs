using ChatServer.Bases;
using ChatServer.Interfaces.Send_Message;
using Fleck;
using System.Linq;

namespace ChatServer.Services.Send_Messages
{
    //Solid-I principle segragation, interface
    //Solid-L pinclie Liskov, SendMessageService son of BaseUsersSockets
    //Solid-S pinclie Single Responsability
    public class SendToAll : BaseListUsersSockets, ISendService
    {
        public string Message { get; set; }
        public bool IsFromServer { get ; set; }
        public string USERSERVER { get; set; } = "[Server]: ";
        public IWebSocketConnection Socket { get; set; } = null;
        public SendToAll(string message) => Message = message;  
        public SendToAll(IWebSocketConnection socket, string message, bool isFromServer = false)
        {
            Message = message;  
            IsFromServer = isFromServer;
            Socket = socket;
        } 
       
        public void SendMessage()
        {
            if(Socket != null)
            {
                var userName = ListUsers.FirstOrDefault(x => x.socket.ConnectionInfo.Id == Socket.ConnectionInfo.Id).userName;
                if (IsFromServer)
                    ListUsers.ForEach(x => x.socket.Send(USERSERVER + Message));
                else
                    ListUsers.ForEach(x => x.socket.Send($"[{userName}]: " + Message));
            }
            else
            {
                ListUsers.ForEach(x => x.socket.Send(USERSERVER + Message));
            }
            
        }
    }
}
