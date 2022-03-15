using ChatClient.Interfaces;
using ChatServer.Interfaces.Users;
using ChatServer.Services.Users;
using Xunit;

namespace ServerTest.UnitTest.UserServiceTest
{
    //I could make a lot of Test more with a differents behavior
    //and for the differents services of Server that they are all decoupled,
    //but for showing  you the main idea of UNITS TEST is enough, if you want same especific test,
    // let me know

    public class UserTest
    {
        [Fact]
        public void CreateUserNullSocketEmptyUserName()
        {
            ICreateUser createUserService = new CreateUserService();

            Assert.Equal(false, createUserService.CreateUser(null, string.Empty));
        }
        [Fact]
        public void DeleteUserNullSocket()
        {
            IDeleteUser deleteUserService = new DeleteUserService();

            Assert.Equal(false, deleteUserService.DeleteUser(null));
        }

        [Fact]
        public void GetUserNameNullSocket()
        {
            IGetUserName GetUserNameService = new GetUserNameService();
            Assert.Null( GetUserNameService.GetUserName(null));
        }
        [Fact]
        public void GetAllUsersNames()
        {
            //Arrange
            IGetAllUsersNames GetAllUsersNamesServices = new GetAllUsersNamesService();
            //Act
            var userNames = GetAllUsersNamesServices.GetAllUsersNames();
            //Assert
            Assert.Equal(0, userNames.Count);              
        }
        [Fact]
        public void GetAllUserNamesServices()
        {
            IGetAllUsersNamesExceptCurrent createUserService = new GetAllUsersNamesExceptCurrentService();
            var userNames = createUserService.GetAllUsersNamesExceptCurrent(null);
            Assert.Equal(0, userNames.Count);
        }

        [Fact]
        public void UserServicesAllDependenciesNullOrEmpty()
        {
            IUserService userService = new UserService();
            Assert.Equal(false, userService.ICreateUser.CreateUser(null, string.Empty));
            Assert.Equal(false, userService.IDeleteUser.DeleteUser(null));
            Assert.Null(userService.IGetUserName.GetUserName(null));
            var userNamesAll = userService.IGetAllUsersNames.GetAllUsersNames();
            Assert.Equal(0, userNamesAll.Count);
            var userNamesExcept = userService.IGetAllUsersNamesExceptCurrent.GetAllUsersNamesExceptCurrent(null);
            Assert.Equal(0, userNamesExcept.Count);
        }
    }
}
