using System;
using System.Collections.Generic;
using System.IO;

namespace EasySaveProject
{
    internal class SaveWorkView : View
    {
        public SaveWorkViewModel saveWorkViewModel = new SaveWorkViewModel();

        public void Show()
        {
            Console.WriteLine("Welcome to the Save Work view!");

            // Afficher le menu ou les options de l'interface utilisateur
            // Par exemple, vous pouvez afficher un menu pour ajouter un nouveau travail

            Console.WriteLine("Enter the details for the new work:");
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
