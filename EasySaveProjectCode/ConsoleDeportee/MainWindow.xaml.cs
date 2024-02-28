using System.Windows;
using System.Windows.Controls;
using ConsoleDeportee.AddWork;
using ConsoleDeportee.ExecuteFolder;
using ConsoleDeportee.MenuFolder;

namespace ConsoleDeportee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NetWorkService _networkService { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = new MenuViewModel();
            //create a single instance of the netWorkService
            _networkService = new NetWorkService();
            //connect to the server
            _networkService.ConnectSocket();
        }

    }
}