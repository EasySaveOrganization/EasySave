// See https://aka.ms/new-console-template for more information
/*using System;
using EasySaveProject.Observer;

Console.WriteLine("Hello, World!");*/
using System;
using System.Threading.Tasks;
using EasySaveProject;
using EasySaveProject.Observer;

class Program
{
    static async Task Main()
    {
        // Créer une instance de votre service de liste de travaux
        WorkListService workListService = new WorkListService();

        // Créer des instances de vos observateurs
        FormatFactory formatFactory = new FormatFactory();
        FormatStrategyJson formatStrategyJson = new FormatStrategyJson(workListService);

        // Créer un exemple de travail et l'ajouter à la liste de travaux
        SaveWorkModel exampleWork = new SaveWorkModel
        {
            SaveName = "ExampleSave",
            SourceRepo = @"C:\Users\MALEK\Desktop\Prépa intégrée\3A\PS",
            TargetRepo = @"C:\Users\MALEK\Desktop\Prépa intégrée\3A\PS",
            FileSize = 1024, // Exemple de taille de fichier en bytes
            FileTransferTime = TimeSpan.FromMinutes(5), // Exemple de temps de transfert
            Time = DateTime.Now,
            totalFilesToCopy = 10,
            nbFilesLeftToDo = 5,
            progression = 50,
            state = "InProgress"
        };

        // Afficher les informations du travail
        Console.WriteLine("Informations du travail :");
        Console.WriteLine($"Nom de la sauvegarde : {exampleWork.SaveName}");
        Console.WriteLine($"Répertoire source : {exampleWork.SourceRepo}");
        Console.WriteLine($"Répertoire cible : {exampleWork.TargetRepo}");
        Console.WriteLine($"Taille du fichier : {exampleWork.FileSize} bytes");
        Console.WriteLine($"Temps de transfert du fichier : {exampleWork.FileTransferTime}");
        Console.WriteLine($"Temps d'exécution : {exampleWork.Time}");
        Console.WriteLine($"Nombre total de fichiers à copier : {exampleWork.totalFilesToCopy}");
        Console.WriteLine($"Nombre de fichiers restants à copier : {exampleWork.nbFilesLeftToDo}");
        Console.WriteLine($"Progression : {exampleWork.progression}%");
        Console.WriteLine($"État : {exampleWork.state}");

        // Ajouter le travail à la liste
        workListService.AddWork(exampleWork);

        // Appeler la méthode write() de FormatStrategyJson
        await formatStrategyJson.Write();

        Console.WriteLine("Tests terminés.");
    }
}
