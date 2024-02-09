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
                if (File.Exists(data.sourceRepo))
                {

                    // Copie le fichier source vers la destination
                    File.Copy(data.sourceRepo, data.targetRepo, true);

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
