using System.Windows;
using System.Windows.Controls;
using EasySaveProject_V2.AddWork;
using EasySaveProject_V2.ObserverFolder;
using EasySaveProject_V2.StateFolder;
using EasySaveProject_V2.LogFolder;
using EasySaveProject_V2.ExecuteFolder;
using EasySaveProject_V2.MenuFolder;

namespace EasySaveProject_V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NavigationService _navigationService;
        public MainWindow()
        {
            InitializeComponent();
            _navigationService = new NavigationService(Main);
            var mainViewModel = new MenuViewModel(); // Pass it to the ViewModel
            this.DataContext = mainViewModel;

            //subscribe the log and state
            Observer events = Observer.Instance;
            Logs logs = new Logs();
            State state = new State();
            events.Subscribe(logs);
            events.Subscribe(state);

            SetupNavigation();
        }

        public void NavigateHome(Page page)
        {
            Main.Navigate(page);
        }

        private void SetupNavigation()
        {
            _navigationService.RegisterPage("AddWork", () => new AddWorkView());
            _navigationService.RegisterPage("ExecuteWork", () => new ExecuteWork());
        }
    }
}