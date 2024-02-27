using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using ConsoleDeportee.AddWork;
using ConsoleDeportee.ExecuteFolder;
using ConsoleDeportee.LanguageFolder;

namespace ConsoleDeportee.MenuFolder
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public ICommand AddWorkCommand { get; private set; }
        public ICommand ExecuteWorkCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }
        public ICommand MenuCommand { get; private set; }

      
        public event PropertyChangedEventHandler? PropertyChanged;



        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MenuViewModel()
        {
            //Initialize command
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate());
            ExecuteWorkCommand = new RelayCommand(param => NavigateToExecuteWork(), param => CanNavigate());
            SettingsCommand = new RelayCommand(param => NavigateToSettings(), param => CanNavigate());
            MenuCommand = new RelayCommand(param => NavigateToMenu(), param => CanNavigate());
           

        }

        //this will determine if the command can be executed
        private bool CanNavigate()
        {
            return true;
        }


        //This method finds the frame and uses it to navigate
        private void NavigateToAddWork()
        {
            // Navigate to the AddWork page
            Application.Current.MainWindow.Content = new AddWorkView();
        }

        private void NavigateToExecuteWork()
        {
            Application.Current.MainWindow.Content = new ExecuteWork();
        }
        private void NavigateToSettings()
        {
            Application.Current.MainWindow.Content = new Settings();
        }
        private void NavigateToMenu()
        {
            Application.Current.MainWindow.Content = new MainWindow();
        }

    }
}
