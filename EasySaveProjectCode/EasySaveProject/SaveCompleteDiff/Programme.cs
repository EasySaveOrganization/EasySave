using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.SaveCompleteDiff
{
    using System;

    namespace EasySaveProject
    {
        class Program
        {
            static void Main()
            {
                Console.WriteLine("Début du programme...");

                // Chemin source et répertoire de destination
                string sourceRepo = @"C:\Users\rapha\Documents\test\df.txt";
                string targetRepo = @"C:\Users\rapha\Documents\test1";

                // Demander à l'utilisateur de choisir entre Complete et Differential
                Console.WriteLine("Choisissez le type de sauvegarde :");
                Console.WriteLine("1. Complete");
                Console.WriteLine("2. Differential");
                string choice = Console.ReadLine();

                // Valider l'entrée utilisateur
                string saveType;
                switch (choice)
                {
                    case "1":
                        saveType = "complete";
                        break;
                    case "2":
                        saveType = "differential";
                        break;
                    default:
                        Console.WriteLine("Choix non valide. Veuillez choisir 1 ou 2.");
                        return; // Quitter le programme si le choix n'est pas valide
                }

                // Créer une instance de SaveWorkModel
                SaveWorkModel data = new SaveWorkModel(sourceRepo, targetRepo, saveType);

                // Créer une instance de SaveFactory
                SaveFactory saveFactory = new SaveFactory();

                // Obtenir une instance de Save en fonction du type choisi
                Save save = saveFactory.CreateSave(saveType);

                // Exécuter la sauvegarde en utilisant l'instance de Save créée
                save.ExecuteSave(data);

                Console.WriteLine("Fin du programme. Appuyez sur une touche pour quitter...");
                Console.ReadKey();
            }
        }
    }
}
