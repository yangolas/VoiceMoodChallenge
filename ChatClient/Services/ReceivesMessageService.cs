using ChatClient.Interfaces;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WebSocketSharp;

namespace ChatClient.Services
{
    [AddINotifyPropertyChangedInterface]
    public class ReceivesMessageService : BaseWebSockect,IReceivesMessageService
    {
        public ObservableCollection<string> ListMessages { get; set; } = new ObservableCollection<string>();

        public ReceivesMessageService() => ws.OnMessage += Ws_OnMessage;
        private void Ws_OnMessage(object? sender, MessageEventArgs e)
        {
            App.Current.Dispatcher.Invoke((Action)delegate 
            {
                ListMessages.Add(e.Data.ToString());
            });
        }       
    }
}
