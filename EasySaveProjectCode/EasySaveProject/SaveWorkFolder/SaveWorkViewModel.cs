using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject.SaveWorkFolder;
using EasySaveProject.ExecuteFolder;

namespace EasySaveProject.SaveWorkFolder
{
    public class SaveWorkViewModel
    {
        private WorkListService workListService = new WorkListService();

<<<<<<< HEAD
        public void AddWork(string name, string target, string source, string type, string extenstionFileToCrypt, int logsFormat)
        {
            SaveWorkModel saveWorkModel = new SaveWorkModel(name, target, source, type, extenstionFileToCrypt, logsFormat);
=======
        public void AddWork(string name, string target, string source, string type)
        {
            SaveWorkModel saveWorkModel = new SaveWorkModel(name, target, source, type);
>>>>>>> 7f8ee939f33ec6cf7ce0e8ffe0da01f5e39c4b9e
            // Initialiser les propriétés de saveWorkModel avec les données nécessaires

            try
            {
                // Ajouter le travail à la liste via le service
                workListService.AddWork(saveWorkModel);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


}
