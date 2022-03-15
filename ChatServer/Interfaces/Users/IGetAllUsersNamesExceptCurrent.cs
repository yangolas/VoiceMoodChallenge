using Fleck;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatServer.Interfaces.Users
{
    public  interface IGetAllUsersNamesExceptCurrent
    {
        public List<string> GetAllUsersNamesExceptCurrent(IWebSocketConnection socket);
    }
}
