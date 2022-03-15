using ChatServer.Bases;
using ChatServer.Interfaces.Send_Message;
using Fleck;
using System.Linq;

namespace ChatServer.Services.Send_Messages
{
    //Solid-I principle segragation, interface
    //Solid-L pinclie Liskov, SendMessageService son of BaseUsersSockets
    //Solid-S pinclie Single Responsability
    public class SendToAllExceptCurrentUser : BaseListUsersSockets, ISendService
    {
        public IWebSocketConnection Socket { get; set; }
        public string Message { get; set; }
        public bool IsFromServer { get ; set ; }
        public string USERSERVER { get; set; } = "[Server]: ";

        public SendToAllExceptCurrentUser(IWebSocketConnection socket, string message, bool isFromServer=false )
        {
            Socket = socket;   
            Message = message;
            IsFromServer = isFromServer;
        }
        public void SendMessage()
        {
            var user = ListUsers.FirstOrDefault(x => x.socket.ConnectionInfo.Id == Socket.ConnectionInfo.Id);
            foreach (var item in ListUsers)
            {
                if (item != user)                    
                    if(IsFromServer)
                        item.socket.Send(USERSERVER + Message);
                    else
                        item.socket.Send($"[{user.userName}]: "+Message);
            }
        }
    }
}
