using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace ChatClient.Interfaces
{
    public interface IReceivesMessageService
    {
        public ObservableCollection<string> ListMessages { get; set; }
    }
}
