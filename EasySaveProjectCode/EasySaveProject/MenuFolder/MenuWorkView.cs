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
            string translatedText = languageManager.Translate("This is the menu  : 0 to Add work, 1 to Execute work");
            message = translatedText;
        }
        public void show()
        {
            Console.WriteLine(message);
            string inputString = Console.ReadLine();
            int input = int.Parse(inputString);
            menuviewmodel.redirect(input);

        }



    }
}
