using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using ConsoleDeportee.AddWork;
using ConsoleDeportee.ExecuteFolder;

namespace ConsoleDeportee.LanguageFolder
{
    public class SettingViewModel : INotifyPropertyChanged
    {
        private readonly LanguageManager languageManager;
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand SwitchToFrenchCommand { get; private set; }
        public ICommand SwitchToEnglishCommand { get; private set; }

        public ICommand AddWorkCommand { get; private set; }
        public ICommand ExecuteWorkCommand { get; private set; }
        public SettingViewModel()
        {
            // Get the instance of the LanguageManager when the view is created.
            languageManager = LanguageManager.GetInstance();
            SwitchToFrenchCommand = new RelayCommand(_ => SwitchLanguage(Languages.FRENCH), param => CanTranslate());
            SwitchToEnglishCommand = new RelayCommand(_ => SwitchLanguage(Languages.ENGLISH), param => CanTranslate());

            //Initialize command
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate());
            ExecuteWorkCommand = new RelayCommand(param => NavigateToExecuteWork(), param => CanNavigate());
        }

        private bool CanTranslate()
        {
            return true;
        }
        public string TranslatedText
        {
            get => languageManager.Translate("Hello");
        }

        private void SwitchLanguage(Languages language)
        {
            languageManager.SwitchLanguages(language);
            // Notify the View that the language has changed
            OnPropertyChanged(nameof(TranslatedText));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string LocalizedWelcomeMessage => languageManager.Translate("WelcomeMessageKey");
        private void RefreshView()
        {

            OnPropertyChanged(nameof(LocalizedWelcomeMessage));

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
    }
}
