using ChatClient.Interfaces;
using ChatServer.Interfaces.Users;

namespace ChatServer.Services.Users
{
    //Solid-D principle inject dependencies
    public class UserService: IUserService
    {
        public ICreateUser ICreateUser { get ; set ; }
        public IGetUserName IGetUserName { get ; set ; }
        public IGetAllUsersNamesExceptCurrent IGetAllUsersNamesExceptCurrent { get ; set ; }
        public IGetAllUsersNames IGetAllUsersNames { get ; set ; }
        public IDeleteUser IDeleteUser { get ; set ; }
       
        public UserService()
        {
            ICreateUser = new CreateUserService();
            IGetUserName = new GetUserNameService();
            IGetAllUsersNames = new GetAllUsersNamesService();
            IGetAllUsersNamesExceptCurrent = new GetAllUsersNamesExceptCurrentService();
            IDeleteUser = new DeleteUserService();
        }

       
    }
}
