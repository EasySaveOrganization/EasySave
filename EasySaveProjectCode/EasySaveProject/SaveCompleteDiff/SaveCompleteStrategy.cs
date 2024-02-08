using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.SaveCompleteDiff
{
    public class SaveCompleteStrategy : Save
    {
        public override void ExecuteSave(SaveWorkModel data)
        {
            try
            {
                // Vérifie si le fichier source existe
                if (File.Exists(data.SourceFilePath))
                {
                    // Obtient le nom du fichier à partir du chemin source
                    string fileName = Path.GetFileName(data.SourceFilePath);

                    // Construit le chemin de destination complet
                    string targetrepo = Path.Combine(data.DestinationDirectory, fileName);

                    // Copie le fichier source vers la destination
                    File.Copy(data.SourceFilePath, targetrepo, true);

                    Console.WriteLine($"File copied from {data.SourceFilePath} to {destinationFilePath}");
                }
                else
                {
                    Console.WriteLine($"Source file {data.SourceFilePath} does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
