using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EasySaveProject.LanguageFolder
{
    internal class SettingViewModel : INotifyPropertyChanged
    {
        private readonly LanguageManager languageManager;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SwitchToFrenchCommand { get; private set; }
        public ICommand SwitchToEnglishCommand { get; private set; }

        public SettingViewModel()
        {
            // Get the instance of the LanguageManager when the view is created.
            languageManager = LanguageManager.GetInstance();
            SwitchToFrenchCommand = new RelayCommand(_ => SwitchLanguage(Languages.FRENCH), param => CanTranslate());
            SwitchToEnglishCommand = new RelayCommand(_ => SwitchLanguage(Languages.ENGLISH), param => CanTranslate());
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
    }
}
