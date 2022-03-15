using ChatClient.Interfaces;
using ChatClient.Services;
using PropertyChanged;
using System.Windows.Input;
using Utils.Core;

namespace ChatClient.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class ChatClientViewModel
    {

        public bool StartChat { get; set; } = false;
        public bool NotStartChat { get; set; } = true;
        public ICommand ConnectCommand { get; }
        public ICommand SendCommand { get; }
        public IConnexionService ConnexionService { get; set; } = new ConnexionService();
        public ISendMessagServicee SendMessageService { get; set; } = new SendMessageService();
        public IReceivesMessageService ReceiveMessageService { get; set; }
        public IDisconnectService _disconnectService = new DisconnectService();
        public ChatClientViewModel()
        {
            ConnectCommand = new RelayCommand(o => OnConnect() , o => (ConnexionService.IsUserReady));
            SendCommand = new RelayCommand(o => SendMessageService.Send() , o => (SendMessageService.Message != string.Empty));           
        }        
        public void OnConnect()
        {
            ConnexionService.Connect();
            ReceiveMessageService = new ReceivesMessageService();
            SendMessageService.Send(ConnexionService.UserName);
            StartChat = true;
            NotStartChat = !StartChat;
        }
        public void OnClosing()
        {
            if(ConnexionService.StatusConnexion())
                _disconnectService.Disconnect();
        }
    }
}
