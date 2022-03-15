using ChatServer.Interfaces.Send_Message;

namespace ChatServer.Services.Send_Messages
{
    //Solid-O principle open-close, SendService basicaly need two parameters except for SendToAll, for the last case called Quit Dependency ISendSocket
    //Solid-S pinclie Single Responsability
    public class SendMessageService 
    {          
        public void Send(ISendService sendService)
        {
            sendService.SendMessage();
        }

        
    }
}
