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
            Console.Write("Save Type ('Complete' or 'Differential') : ");
            string? saveType = Console.ReadLine();
            Console.Write("Which file extension do you wish to crypt, you can write as many as you wnat but have to split them with a space (json txt pdf)");
            string? extenstionFileToCrypt = Console.ReadLine();
            Console.Write("Logs format (1 - Xml or 2 - Json): ");
            string input = Console.ReadLine();
            int logsFormat;
            if (int.TryParse(input, out logsFormat))
            {
                // Vérifiez si l'entrée correspond à 1 ou 2
                if (logsFormat == 1 || logsFormat == 2)
                {
                    // Ajoutez le travail en utilisant le ViewModel
                    saveWorkViewModel.AddWork(saveName, targetRepo, sourceRepo, saveType, extenstionFileToCrypt, logsFormat);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 for XML or 2 for JSON.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}