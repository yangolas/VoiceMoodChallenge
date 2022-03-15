using Fleck;
using System.Collections.Generic;

namespace ChatServer.Bases
{
    //Parent Class
    public class BaseListUsersSockets
    {
        protected static List<Users> ListUsers  = new List<Users>();

        public class Users : BaseUser
        {           
            public Users(IWebSocketConnection socket, string userName)
            {
                this.socket = socket;
                this.userName = userName;
            }

        }
    }
}
