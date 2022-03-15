using ChatServer.Interfaces.Users;

namespace ChatClient.Interfaces
{
    //Solid-D Depency Inject 
    public interface IUserService
    {
        public ICreateUser ICreateUser { get; set; }
        public IGetUserName IGetUserName { get; set; }
        public IGetAllUsersNamesExceptCurrent IGetAllUsersNamesExceptCurrent { get; set; }
        public IGetAllUsersNames IGetAllUsersNames { get; set; }
        public IDeleteUser IDeleteUser { get; set; }

    }
}
