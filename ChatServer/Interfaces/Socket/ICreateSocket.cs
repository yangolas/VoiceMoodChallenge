namespace ChatServer.Interfaces.Socket
{
    public interface ICreateSocket
    {
        public void CreateSocket(int port, string url = "ws://127.0.0.1:");
    }
}
