using EasySaveProject.LanguageFolder;
using EasySaveProject.SaveWorkFolder;
using System;
using System.Collections.Generic;
using System.IO;

namespace EasySaveProject.SaveFolder
{
    internal class SaveWorkView : View
    {
        public SaveWorkViewModel saveWorkViewModel = new SaveWorkViewModel();

        public void Show()
        {
            LanguageManager languageManager = LanguageManager.GetInstance();
            string translatedText = languageManager.Translate("Welcome to the Save Work view!");
            Console.WriteLine(translatedText);

            // Afficher le menu ou les options de l'interface utilisateur
            // Par exemple, vous pouvez afficher un menu pour ajouter un nouveau travail

            string t2text = languageManager.Translate("Enter the details for the new work:");
            Console.WriteLine(t2text);
            Console.Write("Save Name: ");
            string? saveName = Console.ReadLine();
            Console.Write("Target Repository: ");
            string? targetRepo = Console.ReadLine();
            Console.Write("Source Repository: ");
            string? sourceRepo = Console.ReadLine();
            Console.Write("Save Type: ");
            string? saveType = Console.ReadLine();

            // Ajouter le travail en utilisant le ViewModel
            saveWorkViewModel.AddWork(saveName, targetRepo, sourceRepo, saveType);

        }
    }
}
