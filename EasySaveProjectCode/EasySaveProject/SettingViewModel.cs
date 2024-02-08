using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject
{
    internal class SettingViewModel
    {
        private readonly LanguageManager languageManager;

        public SettingViewModel()
        {
            // Get the instance of the LanguageManager when the view is created.
            languageManager = LanguageManager.GetInstance();
        }

        public void DisplayLanguageOptions()
        {
            // Display language options to the user.
            Console.WriteLine("Select your language:");
            Console.WriteLine("1: English");
            Console.WriteLine("2: French");

            // Read user input.
            string input = Console.ReadLine();

            // Set the language based on user input.
            switch (input)
            {
                case "1":
                    languageManager.SwitchLanguages(Languages.ENGLISH);
                    Console.WriteLine("Language set to English.");
                    break;
                case "2":
                    languageManager.SwitchLanguages(Languages.FRENCH);
                    Console.WriteLine("Language set to French.");
                    break;
                default:
                    Console.WriteLine("Invalid selection. Language set to English by default.");
                    languageManager.SwitchLanguages(Languages.ENGLISH);
                    break;
            }

            // Optionally, after switching languages, you could refresh the view to show translated texts.
            RefreshView();
        }

        private void RefreshView()
        {
            // This method would update all display elements with the appropriate language.
            // For example:
            Console.WriteLine(languageManager.Translate("Hello"));
            // ... Update other UI elements as needed.
        }
    }
}
