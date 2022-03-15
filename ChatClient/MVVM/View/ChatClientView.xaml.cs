using ChatClient.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatClient.MVVM.View
{
    /// <summary>
    /// Interaction logic for ChatClientView.xaml
    /// </summary>
    public partial class ChatClientView : Window
    {
        private TextBox textBoxPort;
        private ChatClientViewModel ChatClientVieModel;
        public ChatClientView()
        {
            InitializeComponent();
            ChatClientVieModel = this.DataContext as ChatClientViewModel;
            textBoxPort = this.FindName("Text_Port") as TextBox;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ChatClientVieModel.OnClosing();
        }

        private void TextBoxPort_KeyUp(object sender, KeyEventArgs e)
        {
            if (!textBoxPort.Text.All(char.IsDigit)) 
            { 
                ChatClientVieModel.ConnexionService.Port = null;
                return;
            }

            if (e.Key == Key.Enter)
            {
                if(ChatClientVieModel.ConnectCommand.CanExecute(null) == false)
                    return;
                ChatClientVieModel.ConnectCommand.Execute(null);            
            }
        }

        private void TextBoxSend_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (ChatClientVieModel.SendCommand.CanExecute(null) == false)
                    return;
                ChatClientVieModel.SendCommand.Execute(null);
            }
        }
    }
}
