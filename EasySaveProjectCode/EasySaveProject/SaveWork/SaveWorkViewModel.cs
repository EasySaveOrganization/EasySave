using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject.SaveWork;

namespace EasySaveProject.SaveWork
{
    public class SaveWorkViewModel {

            WorkListService workListService = new WorkListService();


        public void AddWork(string name, string target, string source, string type)
        {
            SaveWorkModel saveWorkModel = new SaveWorkModel(name, target, source, type);
            // Initialiser les propriétés de saveWorkModel avec les données nécessaires

            if (saveWorkModel.Validate())
            {
                // Ajouter le travail à la liste via le service
                workListService.AddWork(saveWorkModel);
            }
            else
            {
                Console.WriteLine("Error during the input");
            }
        }

    }
}
