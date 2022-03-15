using ChatServer.Bases;
using ChatServer.Interfaces.Users;
using Fleck;
using System.Linq;

namespace ChatServer.Services.Users
{
    //Solid-S => Single responsability
    //Solid-L => Barbara Liskov principle, Son Class can replace at all the parent class..., in this case the list of WebSocket of Fleck is using for this service plus the current user socket
    public class CreateUserService : BaseListUsersSockets, ICreateUser
    {        

        //It´s enough inteligent for knowing if it must add the a new user or it is a user register.
        public bool CreateUser(IWebSocketConnection socket, string username)
        {   
            if (socket != null && username != string.Empty && ListUsers.Where(x => x.socket.ConnectionInfo.Id == socket.ConnectionInfo.Id).FirstOrDefault() == null)
            {
                ListUsers.Add(new Users(socket, username));
                return true;
            }
            else           
                return false;
        }                  
    }
 
}
