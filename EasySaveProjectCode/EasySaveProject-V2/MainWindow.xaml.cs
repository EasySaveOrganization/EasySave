using System.Windows;
using System.Windows.Controls;
using EasySaveProject_V2.AddWork;
using EasySaveProject_V2.ObserverFolder;
using EasySaveProject_V2.StateFolder;
using EasySaveProject_V2.LogFolder;
using EasySaveProject_V2.ExecuteFolder;
using EasySaveProject_V2.MenuFolder;
using EasySaveProject_V2.ProgramBlockerFolder;
using System.Diagnostics;
using System.Windows.Threading;
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

            ProgramBlockerService monitor = new ProgramBlockerService("CalculatorApp");
            monitor.StartMonitoring();

            _navigationService = new NavigationService(Main);
            var mainViewModel = new MenuViewModel(); // Pass it to the ViewModel
            this.DataContext = mainViewModel;

            // Subscribe the log and state
            Observer events = Observer.Instance;
            Logs logs = new Logs();
            State state = new State();
            events.Subscribe(logs);
            events.Subscribe(state);

            SetupNavigation();

            SetupAppAccessibilityMonitoring();
        }

        private void SetupAppAccessibilityMonitoring()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Check every second
            timer.Tick += (sender, e) => CheckCalculatorApp();
            timer.Start();
        }

        private void CheckCalculatorApp()
        {
            // Adjust the process name if necessary, "Calculator" is just an example
            bool isCalculatorRunning = Process.GetProcessesByName("Calculator").Any();

            if (isCalculatorRunning)
            {
                // Disable the main window
                this.IsEnabled = false;
            }
            else
            {
                // Enable the main window
                this.IsEnabled = true;
            }
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