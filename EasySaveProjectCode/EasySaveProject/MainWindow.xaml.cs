using EasySaveProject.LanguageFolder;
using EasySaveProject.MenuFolder;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using EasySaveProject.AddFolder;
using EasySaveProject.ObserverFolder;
using EasySaveProject.SateFolder;
using EasySaveProject.LogFolder;
using System.Windows.Navigation;
using EasySaveProject.ExecuteFolder;

namespace EasySaveProject
{
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
            observer events = observer.Instance;
            logs logs = new logs();
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
