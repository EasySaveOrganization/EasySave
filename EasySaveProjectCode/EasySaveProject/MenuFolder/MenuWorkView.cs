using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject.LanguageFolder;

namespace EasySaveProject.MenuFolder
{
   
    internal class MenuWorkView : View
    {
        // Instance of MenuViewModel to interact with the business logic.
        public MenuViewModel menuviewmodel = new MenuViewModel();

      
        public string message { get; set; }

 
        public MenuWorkView()
        {
            // Get an instance of the LanguageManager to manage language translations.
            LanguageManager languageManager = LanguageManager.GetInstance();

          
            string translatedText = languageManager.Translate("Hello world this is the menu type  : 0 to Add work, 1 to Execute work, 2 for the progress View, 3 for the settings ");
            message = translatedText;
        }

        // Method to display the menu and handle user input.
        public void show()
        {
           
            Console.WriteLine(message);

           
            string inputString = Console.ReadLine();
            int input = int.Parse(inputString);

         
            menuviewmodel.redirect(input);
        }
    }
}
