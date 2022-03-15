using ChatClient.Interfaces;
using ChatServer.Interfaces.Socket;
using ChatServer.Interfaces.TCP;
using ChatServer.Services.Custom_Message;
using ChatServer.Services.Notification_Server;
using ChatServer.Services.Send_Messages;
using ChatServer.Services.Socket;
using ChatServer.Services.TCP;
using ChatServer.Services.Users;
using System;



namespace ConsoleApp
{
    
    public class Program
    {        
        private readonly static ISettingsSockectService _settingsSockectService = new SettingsSockectService();
        private readonly static IStatePortService _statePortService = new StatePortService();
        private readonly static IUserService _userService = new UserService();
        private readonly static NotificationServerService _notificationServerService = new NotificationServerService();
        private readonly static CustomMessageService _customMessageService = new CustomMessageService();
        private readonly static SendMessageService _sendMessageService = new SendMessageService();
        public static void Main(string[] args)
        {
            try
            {
                //Check that argument on open console is a number
                var port = Convert.ToInt32(args[0]);
                _settingsSockectService.CreateSocket(port);
            }
            catch (Exception)
            {
                //if isn´t port number exit the program
                _notificationServerService.ShowNotification(new InvalidPortNotification());
                while (Console.ReadKey().Key != ConsoleKey.Enter) ;
                return;
            }
            //Event on Exit
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(ProcessExit);
            _notificationServerService.ShowNotification(new WelcomeNotification());
            _settingsSockectService.GetListenSocket().Start(socket =>
            {
                //User Send a Message
                socket.OnMessage = message =>
                {
                    //If user is not register, then It is the first time that send a message, we expect her/his user name.
                    if (_userService.ICreateUser.CreateUser(socket, message))
                    {   //creating the message for sending
                        var customMessage = _customMessageService.InjectCustomMessage(new ConnectedUserMessage(_userService.IGetUserName.GetUserName(socket)));
                        _notificationServerService.ShowNotification(new NewUserNotification(message));
                        //Server Notify to this user that he/she is connected
                        _sendMessageService.Send(new Send(socket, _customMessageService.InjectCustomMessage(new WelcomeMessage()), true));
                        //Server Notify all the users except him self, that new One is connected
                        _sendMessageService.Send(new SendToAllExceptCurrentUser(socket, customMessage, true));
                    }
                    //rest of the messages sended by user
                    else
                    {
                        //Notify to the Server-console messages that user send
                        _notificationServerService.ShowNotification(new SendMessageNotification(_userService.IGetUserName.GetUserName(socket), message));
                        _sendMessageService.Send(new SendToAll(socket, message));
                        //Notify to the Server-console, all the users that received the message
                        _userService.IGetAllUsersNamesExceptCurrent.GetAllUsersNamesExceptCurrent(socket).
                        ForEach(x => _notificationServerService.ShowNotification(new ReceiveMessageNotification(x, message)));

                    }     
                    
                };
                //User Disconnect
                socket.OnClose = () =>
                {
                    //Check If user, only connected and didn´t send anything(in my client it´is imposible that happen that, but..., never mind)
                    var userName = _userService.IGetUserName.GetUserName(socket);
                    if (userName == string.Empty) return;
                    var customMessage = _customMessageService.InjectCustomMessage(new DisconnectedUserMessage(userName));
                    //Notify to the Server-console, all the users that received the message that user is discconected
                    _notificationServerService.ShowNotification(new DisconnectNotification(userName));                   
                    _sendMessageService.Send(new SendToAllExceptCurrentUser(socket, customMessage, true));
                    //Clean touple Socket and User Name from Server list Users;
                    _userService.IDeleteUser.DeleteUser(socket);
                };
            });
            //When you turn on the server, server check if in the por is ready or busy in the time of 10 sec
            _statePortService.ISetTimerReadStateTcpPort.SetTimerReadStateTcpPort(10);
            _statePortService.IGetTimerReadStateTcpPort.GetTimerReadStateTcpPort().Elapsed += Timer_Tick;
            _statePortService.IGetTimerReadStateTcpPort.GetTimerReadStateTcpPort().Start();
            //When anyone want to turn off the server press Enter, and server shutDown, or close click in the cross
            while (Console.ReadKey().Key != ConsoleKey.Enter) ;


        }
        //try to connect all the time, each 10 seconds read the state the port for checking if port is busy
        //if the port is free notify that the port is free for starting to listen
        private static void Timer_Tick(object sender, EventArgs e)
        {
            if (_statePortService.IIsBusyTcpPortOfServer.IsBusyTcpPortOfServer())
               _notificationServerService.ShowNotification(new BusyPortNotification());              
            else
            {
                _notificationServerService.ShowNotification(new ServerReadyNotification());
                _statePortService.IGetTimerReadStateTcpPort.GetTimerReadStateTcpPort().Stop();
            }
        }
        //before close the server, server, notify to all users  from him discconect
        static void ProcessExit(object sender, EventArgs e)
        {
            if (_settingsSockectService.GetListenSocket() == null) return;
            var customMessage = _customMessageService.InjectCustomMessage(new OffServerMessage());
            _sendMessageService.Send(new SendToAll(customMessage));
            _settingsSockectService.GetListenSocket().Dispose();
        }
    }
}
