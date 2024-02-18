using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.LanguageFolder
{
    public enum Languages
    {
        ENGLISH = 0,
        FRENCH = 1
    }
    public class LanguageManager
    {
        private static LanguageManager instance;
        private Languages currentLanguage;
        private Dictionary<string, string> englishToFrench;
        private Dictionary<string, string> frenchToEnglish;
        //public delegate void LanguageChangedEventHandler();
        public static event EventHandler LanguageChanged;

        // Private constructor to prevent instantiation from outside the class.
        public LanguageManager()
        {
            // Initialize with default language, English.
            currentLanguage = Languages.ENGLISH;

            // Initialize dictionaries with translations.
            englishToFrench = new Dictionary<string, string>
        {
            { "Hello", "Bonjour" },
            { "Goodbye", "Au revoir" },
            {"Welcome to the Progress View","Bienvenu sur la vue progress"},
            {"Hello world this is the menu type  : 0 to Add work, 1 to Execute work, 2 for the progress View, 3 for the settings ","Bonjour ceci est notre menu tapez : 0 pour ajouter un travail, 2 pour la vue progrès, 3 pour les paramètres" },
            {"Welcome to the Save Work view!", "Bienvenu sur la vue de sauvegarde de travail" },
            {"Enter the details for the new work:","Entrez les détails du nouveau travail"},
            { "BackupName", "Nom de la sauvegarde" },
            { "TargetDirectory", "Répertoire cible" },
            { "SourceDirectory", "Répertoire source" },
            { "BackupType", "Type de sauvegarde" },
            {"Validate", "Valider" },
            {"Work List", "Liste de travail" },
            {"Execute", "Executer" },
            {"Add work", "Ajouter un travail" },
            {"Execute work", "Executer un travail" },
            {"Settings", "Reglages" },
        };

            frenchToEnglish = new Dictionary<string, string>
        {
            { "Bonjour", "Hello" },
            { "Au revoir", "Goodbye" },
            {"Bienvenu sur la vue progrés","Welcome to the Progress progress"},
            {"Bonjour ceci est notre menu tapez : 0 pour ajouter un travail, 2 pour la vue progrès, 3 pour les paramètres","Hello world this is the menu type  : 0 to Add work, 1 to Execute work, 2 for the progress View, 3 for the settings " },
            { "Bienvenu sur la vue de sauvegarde de travail","Welcome to the Save Work view!" },
            {"Entrez les détails du nouveau travail","Enter the details for the new work:"},
            { "Nom de la sauvegarde", "BackupName" },
            { "Répertoire cible", "TargetDirectory" },
            { "Répertoire source" , "SourceDirectory" },
            { "Type de sauvegarde" , "BackupType" },
            {"Valider" , "Validate" },   
            {"Liste de travail" , "Work List" },
            {"Executer" , "Execute" },
            { "Ajouter un travail","Add work" },
            {"Executer un travail","Execute work"},
            {"Reglages" , "Settings" },
        };
        }

        protected void OnLanguageChanged()
        {
            LanguageChanged?.Invoke(this, EventArgs.Empty);
        }

        // Method to get the instance of the singleton.
        public static LanguageManager GetInstance()
        {
            if (instance == null)
            {
                instance = new LanguageManager();
            }
            return instance;
        }

        // Method to get the list of available languages.
        public Languages[] GetLanguagesList()
        {
            return (Languages[])Enum.GetValues(typeof(Languages));
        }

        // Method to switch the current language.
        public void SwitchLanguages(Languages language)
        {
            currentLanguage = language;
            OnLanguageChanged();
            // Optionally, add logic to handle the UI update or other necessary operations when the language changes.
        }

        // Method to get the current language.
        public Languages GetCurrentLanguage()
        {
            return currentLanguage;
        }

        // Method to translate text based on the current language.
        public string Translate(string text)
        {
            if (currentLanguage == Languages.ENGLISH && frenchToEnglish.TryGetValue(text, out string translationEn))
            {
                return translationEn;
            }
            else if (currentLanguage == Languages.FRENCH && englishToFrench.TryGetValue(text, out string translationFr))
            {
                return translationFr;
            }

            // If the text is not found in the dictionary, return the original text.
            return text;
        }
    }

    // Usage:
    // LanguageManager languageManager = LanguageManager.GetInstance();
    // languageManager.SwitchLanguages(Languages.FRENCH);
    // string translatedText = languageManager.Translate("Hello")
}
