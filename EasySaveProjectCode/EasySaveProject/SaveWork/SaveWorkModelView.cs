using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject.SaveWork;

namespace EasySaveProject.SaveWork
{
    public class SaveWorkViewModel
    {
        private WorkListService workListService;

        public SaveWorkViewModel(string filePath)
        {
            workListService = new WorkListService(filePath);
        }

        public void AddWork(string saveName, string targetRepo, string sourceRepo, string saveType)
        {
            SaveWorkModel saveWorkModel = new SaveWorkModel();
            // Initialiser les propriétés de saveWorkModel avec les données nécessaires
            saveWorkModel.saveName = saveName;
            saveWorkModel.targetRepo = targetRepo;
            saveWorkModel.sourceRepo = sourceRepo;
            saveWorkModel.saveType = saveType;

            if saveWorkModel.Validate(){
                // Ajouter le travail à la liste via le service
                workListService.AddWork(saveWorkModel);
            }
            else
            {
                Console.WriteLine("Error during the input")
            }


        }
    }
}
