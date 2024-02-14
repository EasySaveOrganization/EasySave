using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject
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
            {"Enter the details for the new work:","Entrez les détails du nouveau travail"}
            // Add more translations here.
        };

            frenchToEnglish = new Dictionary<string, string>
        {
            { "Bonjour", "Hello" },
            { "Au revoir", "Goodbye" },
            {"Bienvenu sur la vue progrés","Welcome to the Progress progress"},
            {"Bonjour ceci est notre menu tapez : 0 pour ajouter un travail, 2 pour la vue progrès, 3 pour les paramètres","Hello world this is the menu type  : 0 to Add work, 1 to Execute work, 2 for the progress View, 3 for the settings " },
            { "Bienvenu sur la vue de sauvegarde de travail","Welcome to the Save Work view!" },
            {"Entrez les détails du nouveau travail","Enter the details for the new work:"}
            
            // Add more translations here.
        };
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

        // Optionally, you can create a property for InfoLanguage if needed.
        // public InfoLanguage Info { get; set; }
    }

    // Usage:
    // LanguageManager languageManager = LanguageManager.GetInstance();
    // languageManager.SwitchLanguages(Languages.FRENCH);
    // string translatedText = languageManager.Translate("Hello")
}
