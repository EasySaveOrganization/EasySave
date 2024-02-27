using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ConsoleDeportee.AddWork;
using ConsoleDeportee.LanguageFolder;

namespace ConsoleDeportee.ExecuteFolder
{
    public class ExecuteWorkViewModel : INotifyPropertyChanged
    {
       

        //Navigation Commands
        public ICommand AddWorkCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }


        public event PropertyChangedEventHandler? PropertyChanged;

       

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //constructor
        public ExecuteWorkViewModel()
        {
            
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate());
            SettingsCommand = new RelayCommand(param => NavigateToSettings(), param => CanNavigate());
            
        }


        //Navigation parts
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

        private void NavigateToSettings()
        {
            Application.Current.MainWindow.Content = new Settings();
        }
    }
}
