using ChatServer.Bases;
using ChatServer.Interfaces.Users;
using Fleck;
using System.Collections.Generic;
using System.Linq;

namespace ChatServer.Services.Users
{
    //Solid-S => Single responsability
    //Solid-L => Barbara Liskov principle, Son Class can replace at all the parent class..., in this case the list of WebSocket of Fleck is using for this service plus the current user socket
    public class GetAllUsersNamesExceptCurrentService : BaseListUsersSockets, IGetAllUsersNamesExceptCurrent
    {
        public List<string> GetAllUsersNamesExceptCurrent (IWebSocketConnection socket)
        {            
            var listUsersNames = new List<string>();
            ListUsers.Where(x => x.socket.ConnectionInfo.Id != socket.ConnectionInfo.Id).ToList().ForEach(x => listUsersNames.Add(x.userName));
            return listUsersNames;
        }
    }
}
