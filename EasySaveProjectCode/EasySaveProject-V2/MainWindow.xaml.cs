using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using EasySaveProject_V2.AddWork;
using EasySaveProject_V2.ObserverFolder;
using EasySaveProject_V2.StateFolder;
using EasySaveProject_V2.LogFolder;
using EasySaveProject_V2.ExecuteFolder;
using EasySaveProject_V2.MenuFolder;
using EasySaveProject_V2.LanguageFolder;

namespace EasySaveProject_V2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NavigationService _navigationService;
        private Mutex _mutex;
        public string errorMessage => LanguageManager.GetInstance().Translate("Une instance de l'application est déjà en cours d'exécution.");

        public MainWindow()
        {
            const string uniqueAppName = "EasySaveProject-V2";

            _mutex = new Mutex(true, uniqueAppName, out bool createdNew);
            if (!createdNew)
            {
                MessageBox.Show(errorMessage, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                _mutex.Dispose();
                Close();
                return;
            }

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

        protected override void OnClosed(EventArgs e)
        {
            _mutex.Dispose();
            base.OnClosed(e);
        }
    }
}
