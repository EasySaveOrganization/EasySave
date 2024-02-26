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
    public partial class MainWindow : Page
    {
        private NavigationService _navigationService;
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = new MenuViewModel(); // Pass it to the ViewModel
            

            //subscribe the log and state
            Observer events = Observer.Instance;
            Logs logs = new Logs();
            State state = new State();
            events.Subscribe(logs);
            events.Subscribe(state);
        }

        public void NavigateHome(Page page)
        {
           
        }

        private void SetupNavigation()
        {
            _navigationService.RegisterPage("AddWork", () => new AddWorkView());
            _navigationService.RegisterPage("ExecuteWork", () => new ExecuteWork());
        }
    }
}