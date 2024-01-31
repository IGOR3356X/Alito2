using System.Windows;
using System.Windows.Media.Animation;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace Alito
{


    public partial class MainWindow : Window
    {
        private static ITelegramBotClient _botClient;
        private static ReceiverOptions _receiverOptions;
        public MainWindow()
        {
            InitializeComponent();
            _botClient = new TelegramBotClient("6719677792:AAHNkG5A943qr_if48dwEd0sLP8NmLut0zI");


        }

        void skrit()
        {
            FIRST.Visibility = Visibility.Hidden;
            SECOND.Visibility = Visibility.Hidden;
            THIRD.Visibility = Visibility.Hidden; 
            FOURTH.Visibility = Visibility.Hidden;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CreateACC_Click(object sender, RoutedEventArgs e)
        {
            skrit();
            FIRST.Visibility= Visibility.Visible;
        }

        private void CreateTask_Click(object sender, RoutedEventArgs e)
        {
            skrit();
            THIRD.Visibility = Visibility.Visible;
            
        }

        private void DelTask_Click(object sender, RoutedEventArgs e)
        {
            skrit();
            SECOND.Visibility = Visibility.Visible;
        }

        private void StudentBTN_Click(object sender, RoutedEventArgs e)
        {
            skrit();
            FOURTH.Visibility = Visibility.Visible;
        }
    }
}
