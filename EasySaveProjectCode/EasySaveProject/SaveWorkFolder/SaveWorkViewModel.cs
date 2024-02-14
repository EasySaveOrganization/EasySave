using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject.SaveWork;

namespace EasySaveProject.SaveWorkFolder
{
    public class SaveWorkViewModel
    {
        private WorkListService workListService = new WorkListService();

        public void AddWork(string name, string target, string source, string type)
        {
            SaveWorkModel saveWorkModel = new SaveWorkModel(name, target, source, type);
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
