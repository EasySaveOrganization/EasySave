using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject
{
    public class SaveCompleteStrategy : Save
    {
        public override void ExecuteSave(SaveWorkModel data)
        {
            try
            {
                // Vérifie si le fichier source existe
                if (File.Exists(data.sourceRepo))
                {
                    // Obtient le nom du fichier à partir du chemin source
                    string fileName = Path.GetFileName(data.sourceRepo);

                    // Construit le chemin de destination complet
                    string targetrepo = Path.Combine(data.targetRepo, fileName);

                    // Copie le fichier source vers la destination
                    File.Copy(data.sourceRepo, targetrepo, true);

                    Console.WriteLine($"File copied from {data.sourceRepo} to {data.targetRepo}");
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
