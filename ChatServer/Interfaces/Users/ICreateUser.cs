using Fleck;


namespace ChatServer.Interfaces.Users
{
    public interface ICreateUser
    {
        public bool CreateUser(IWebSocketConnection socket, string userName);
    }
}
