using System;
using System.Collections.Generic;
using System.Text;

namespace ChatServer.Interfaces.Users
{
    public  interface IGetAllUsersNames
    {
        public List <string> GetAllUsersNames(); 
    }
}
