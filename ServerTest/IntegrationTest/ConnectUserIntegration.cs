using ChatClient.Interfaces;
using ChatServer.Interfaces.Socket;
using ChatServer.Services.Custom_Message;
using ChatServer.Services.Send_Messages;
using ChatServer.Services.Socket;
using ChatServer.Services.Users;
using Moq;
using System;
using WebSocketSharp;
using Xunit;

namespace ServerTest.IntegrationTest
{
    //Stub and Mock aplicability, It is dificult to apply some integration test in this proyect
    //because this system is small...,
    public class ConnectUserIntegration
    {
        private static WebSocket ws { get; set; }
        private const string url = "ws://127.0.0.1:";
        private int port = 7892;
        private string username = "Daniel";

        [Fact]
        public void ClientConnectSendMessageAndReceivedServer()
        {
            //Arrange 
            ws = new WebSocket(url+port);
            //Act
            ISettingsSockectService _settingsSockectService = new SettingsSockectService();
            _settingsSockectService.CreateSocket(port);
            _settingsSockectService.GetListenSocket().Start( socket =>
            {
                socket.OnMessage = message =>
                {
                    //Assert
                    Assert.Equal("Daniel", message);

                };

            });
            //start Client
            ws.Connect();
            ws.Send("Daniel");
        }

        [Fact]
        public void ClientConnectSendMessageAndSendMoqSabotage()
        {
            //Arrange 
            ws = new WebSocket(url + port);            
            Mock<IUserService> UserServiceMock = new Mock<IUserService>();
            Mock<SendMessageService> SendServiceMock = new Mock<SendMessageService>();
            ISettingsSockectService _settingsSockectService = new SettingsSockectService();
            IUserService _userService = new UserService();
            CustomMessageService _customMessageService = new CustomMessageService();
            SendMessageService _sendMessageService = new SendMessageService();
            //Act
            _settingsSockectService.CreateSocket(port);
            _settingsSockectService.GetListenSocket().Start(socket =>
            {
                socket.OnMessage = message =>
                {
                    UserServiceMock.Setup(x => x.ICreateUser.CreateUser(socket, String.Empty)).Returns(true);    
                    if (_userService.ICreateUser.CreateUser(socket, message))
                    {
                        //Assert
                        Assert.Null(_userService.IGetUserName.GetUserName(socket));
                        
                        UserServiceMock.Setup(x => x.IGetUserName.GetUserName(socket)).Returns(username);
                        var customMessage = _customMessageService.InjectCustomMessage(new ConnectedUserMessage(_userService.IGetUserName.GetUserName(socket)));
                        Assert.Equal($"New User Connected => {username}", customMessage);
                        
                        
                        //Server Notify to this user thaht he/she is connected
                        _sendMessageService.Send(new Send(socket, _customMessageService.InjectCustomMessage(new WelcomeMessage()), true));
                        Assert.Equal("Welcome to Local Chat Server Voice Mood Challenge", _customMessageService.InjectCustomMessage(new WelcomeMessage()));
                        //Server Notify all the users except him self, that connected new One
                        
                        _sendMessageService.Send(new SendToAllExceptCurrentUser(socket, customMessage, true));
                        Assert.Equal($"New User Connected => {username}", customMessage);
                        Assert.Equal("", message);
                        UserServiceMock.Verify(x => x.IGetUserName.GetUserName(socket));
                        SendServiceMock.Verify(x => x.Send(new SendToAllExceptCurrentUser(socket, customMessage, true)));
                    }
                   
                };

            });
            //start Client
            ws.Connect();
            ws.Send(username);
        }
    }

}
