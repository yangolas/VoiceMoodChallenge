﻿using ChatServer.Bases;
using ChatServer.Interfaces.Users;
using Fleck;
using System.Linq;

namespace ChatServer.Services.Users
{
    //Solid-S => Single responsability
    //Solid-L => Barbara Liskov principle, Son Class can replace at all the parent class..., in this case the list of WebSocket of Fleck is using for this service plus the current user socket
    public class GetUserNameService : BaseListUsersSockets, IGetUserName
    {        
        public string GetUserName(IWebSocketConnection socket)
        {
            if (socket == null) return null;
            string username = ListUsers.Where(x => x.socket.ConnectionInfo.Id == socket.ConnectionInfo.Id).FirstOrDefault().userName;
            return username == string.Empty ? null : username;
        }                  
    }
 
}
