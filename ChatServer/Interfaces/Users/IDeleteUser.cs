using Fleck;


namespace ChatServer.Interfaces.Users
{
    public interface IDeleteUser
    {
        public bool DeleteUser(IWebSocketConnection socket);
    }
}
