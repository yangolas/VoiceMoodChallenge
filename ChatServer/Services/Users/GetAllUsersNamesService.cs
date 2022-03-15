using ChatServer.Bases;
using ChatServer.Interfaces.Users;
using System.Collections.Generic;

namespace ChatServer.Services.Users
{
    //Solid-S => Single responsability
    //Solid-L => Barbara Liskov principle, Son Class can replace at all the parent class..., in this case the list of WebSocket of Fleck is using for this service plus the current user socket
    public class GetAllUsersNamesService : BaseListUsersSockets, IGetAllUsersNames
    {
        public List<string> GetAllUsersNames()
        {
            var listUsersNames = new List<string>();    
            ListUsers.ForEach(x => listUsersNames.Add(x.userName));
            return listUsersNames;  
        }
    }
}
