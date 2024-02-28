using System.Windows;
using System.Windows.Controls;
using ConsoleDeportee.MenuFolder;

namespace ConsoleDeportee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NetWorkService _networkService;
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = new MenuViewModel();
            //Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _networkService = new NetWorkService();
            _networkService.ConnectSocket();
        }
    }
}