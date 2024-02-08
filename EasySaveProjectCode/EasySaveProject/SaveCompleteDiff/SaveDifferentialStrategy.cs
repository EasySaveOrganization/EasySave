using System;
using System.IO;

namespace EasySaveProject.SaveCompleteDiff
{
    public class SaveDifferentialStrategy : Save
    {
        public override void ExecuteSave(SaveWorkModel data)
        {
            try
            {
                // Vérifie si le fichier source existe
                if (File.Exists(data.sourceRepo))
                {
                    // Obtient la date de dernière modification du fichier source
                    DateTime lastModifiedSource = File.GetLastWriteTime(data.sourceRepo);

                    // Obtient le nom du fichier à partir du chemin source
                    string fileName = Path.GetFileName(data.sourceRepo);

                    // Construit le chemin de destination complet
                    string targetRepo = Path.Combine(data.targetRepo, fileName);

                    // Vérifie si le fichier de destination existe
                    if (File.Exists(targetRepo))
                    {
                        // Obtient la date de dernière modification du fichier de destination
                        DateTime lastModifiedDestination = File.GetLastWriteTime(targetRepo);

                        // Compare les dates de dernière modification pour déterminer si le fichier source a été modifié
                        if (lastModifiedSource > lastModifiedDestination)
                        {
                            // Copie le fichier source vers la destination
                            File.Copy(data.sourceRepo, targetRepo, true);
                            Console.WriteLine($"File copied from {data.sourceRepo} to {targetRepo}");
                        }
                        else
                        {
                            Console.WriteLine($"Source file {data.sourceRepo} is not newer than destination file {targetRepo}.");
                        }
                    }
                    else
                    {
                        // Copie le fichier source vers la destination
                        File.Copy(data.sourceRepo, targetRepo, true);
                        Console.WriteLine($"File copied from {data.sourceRepo} to {targetRepo}");
                    }
                }
                else
                {
                    Console.WriteLine($"Source file {data.sourceRepo} does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
