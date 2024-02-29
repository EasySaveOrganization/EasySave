using EasySaveProject_V2.AddWork;
using EasySaveProject_V2.ExecuteFolder;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace EasySaveProject_V2.LanguageFolder
{
    public class SettingViewModel : INotifyPropertyChanged
    {
        private readonly LanguageManager languageManager;
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand SwitchToFrenchCommand { get; private set; }
        public ICommand SwitchToEnglishCommand { get; private set; }

        public ICommand AddWorkCommand { get; private set; }
        public ICommand ExecuteWorkCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }
        public string Settings => LanguageManager.GetInstance().Translate("Settings");
        public string AddWork => LanguageManager.GetInstance().Translate("Add work");
        public string ExecuteWork => LanguageManager.GetInstance().Translate("Execute work");
        public string French => LanguageManager.GetInstance().Translate("French");
        public string English => LanguageManager.GetInstance().Translate("English");

        public SettingViewModel()
        {
            // Get the instance of the LanguageManager when the view is created.
            languageManager = LanguageManager.GetInstance();
            SwitchToFrenchCommand = new RelayCommand(_ => SwitchLanguage(Languages.FRENCH), param => CanTranslate());
            SwitchToEnglishCommand = new RelayCommand(_ => SwitchLanguage(Languages.ENGLISH), param => CanTranslate());

            //Initialize command
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate());
            ExecuteWorkCommand = new RelayCommand(param => NavigateToExecuteWork(), param => CanNavigate());

            LanguageManager.LanguageChanged += OnLanguageChanged;
        }

        private bool CanTranslate()
        {
            return true;
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Settings));
            OnPropertyChanged(nameof(AddWork));
            OnPropertyChanged(nameof(ExecuteWork));
            OnPropertyChanged(nameof(French));
            OnPropertyChanged(nameof(English));
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
        private void NavigateToSettings()
        {
            Application.Current.MainWindow.Content = new Settings();
        }
    }
}
