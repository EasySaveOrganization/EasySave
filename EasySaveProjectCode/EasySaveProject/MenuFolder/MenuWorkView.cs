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
        public MenuViewModel menuviewmodel = new MenuViewModel();

        public string message { get; set; }

        public MenuWorkView()
        {
            LanguageManager languageManager = LanguageManager.GetInstance();
            string translatedText = languageManager.Translate("Hello world this is the menu type  : 0 to Add work, 1 to Execute work, 2 for the progress View, 3 for the settings ");
            message = translatedText;
        }
        public void show()
        {
            Console.WriteLine(message);

            string inputString = Console.ReadLine();
            if (string.IsNullOrEmpty(inputString))
            {
                // Handle the case where inputString is null or empty.
                // You might want to prompt the user again or return a default value.
            }
            else
            {
                int input = int.Parse(inputString);
                menuviewmodel.redirect(input);
            }

        }



    }
}
