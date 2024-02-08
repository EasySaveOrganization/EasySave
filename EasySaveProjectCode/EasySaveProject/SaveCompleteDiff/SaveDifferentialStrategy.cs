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
                // Vérifie si le répertoire source et le répertoire de destination existent
                if (Directory.Exists(data.SourceDirectory) && Directory.Exists(data.DestinationDirectory))
                {
                    // Obtient tous les fichiers dans le répertoire source
                    string[] sourceFiles = Directory.GetFiles(data.SourceDirectory);

                    foreach (string sourceFile in sourceFiles)
                    {
                        // Obtient le nom du fichier
                        string fileName = Path.GetFileName(sourceFile);

                        // Construit le chemin complet du fichier de destination

                        // Vérifie si le fichier existe déjà dans le répertoire de destination
                        if (File.Exists(destinationFilePath))
                        {
                            // Obtient la date de dernière modification du fichier dans le répertoire de destination
                            DateTime lastModifiedDestination = File.GetLastWriteTime(destinationFilePath);

                            // Obtient la date de dernière modification du fichier source
                            DateTime lastModifiedSource = File.GetLastWriteTime(sourceFile);

                            // Compare les dates de dernière modification pour déterminer si le fichier source a été modifié
                            if (lastModifiedSource > lastModifiedDestination)
                            {
                                // Copie le fichier source vers le répertoire de destination
                                File.Copy(sourceFile, destinationFilePath, true);
                                Console.WriteLine($"File copied from {sourceFile} to {destinationFilePath}");
                            }
                        }
                        else
                        {
                            // Copie le fichier source vers le répertoire de destination s'il n'existe pas déjà
                            File.Copy(sourceFile, destinationFilePath);
                            Console.WriteLine($"File copied from {sourceFile} to {destinationFilePath}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Source or destination directory does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
