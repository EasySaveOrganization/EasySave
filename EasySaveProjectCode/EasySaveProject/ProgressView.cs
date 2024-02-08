using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject.Observer;

namespace EasySaveProject
{
    internal class ProgressView : IObserver
    {
        public void update()
        {
            Console.WriteLine("Update called on ProgressView.");
        }
        public void show()
        {
            LanguageManager languageManager = LanguageManager.GetInstance();
            string translatedText = languageManager.Translate("Welcome to the Progress View");
            Console.WriteLine(translatedText);
            
        }
    }
}
