using EasySaveProject.ObserverFolder;
using EasySaveProject.SaveWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.ExecuteFolder
{
    public class ExecuteWorkViewModel
    {
        private WorkListService workListService = new WorkListService();

        private ExecuteWorkService executeWorkService = new ExecuteWorkService();

        public void chooseSaveWork()
        {
            var workList = workListService.LoadWorkListFromFile();
            int i = 1;
            foreach (var work in workList)
            {
                Console.WriteLine(i + " - Name of the save work : " + work.saveName + "\n");
                i += 1;
            }
            int selectedIndex;
            while (!int.TryParse(Console.ReadLine(), out selectedIndex) || selectedIndex < 1 || selectedIndex > workList.Count)
            {
                Console.WriteLine("Veuillez entrer un numéro valide.");
                Console.Write("Veuillez entrer le numéro du travail que vous souhaitez exécuter : ");
            }
            // Récupération du travail sélectionné
            SaveWorkModel selectedWork = workList[selectedIndex - 1];
            executeWorkService.executeWork(selectedWork);

        }
    }
}