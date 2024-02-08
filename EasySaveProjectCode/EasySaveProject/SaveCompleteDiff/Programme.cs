using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.SaveCompleteDiff
{
    class Program
    {
        static void Main()
        {
            // Créez ici une instance de votre SaveManager et exécutez votre programme
            Console.WriteLine("Début du programme...");

            // Chemin source et répertoire de destination
            string sourceRepo = @"C:\Users\rapha\Documents\test\df.txt";
            string targetRepo = @"C:\Users\rapha\Documents\test1";
            string saveType = "Complete";

            // Exemple d'utilisation :
            SaveWorkModel data = new SaveWorkModel(sourceRepo, targetRepo, saveType);

            // Créez une instance de SaveFactory
            SaveFactory saveFactory = new SaveFactory();

            // Utilisez la méthode statique CreateSave pour obtenir une instance de Save
            Save save = saveFactory.CreateSave(saveType);

            // Exécutez la sauvegarde en utilisant l'instance de Save créée
            save.ExecuteSave(data);

            Console.WriteLine("Fin du programme. Appuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
    }
}