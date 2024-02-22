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

            Console.WriteLine("Choisissez les travaux que vous souhaitez exécuter en utilisant les numéros séparés par des espaces :");
            int i = 1;
            foreach (var work in workList)
            {
                Console.WriteLine(i + " - Name of the save work : " + work.saveName + "\n");
                i += 1;
            }

            string selectedIndexInput = Console.ReadLine();
            string[] selectedIndexStrings = selectedIndexInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<int> selectedIndices = new List<int>();

            foreach (var indexStr in selectedIndexStrings)
            {
                if (int.TryParse(indexStr, out int index))
                {
                    if (index >= 1 && index <= workList.Count)
                    {
                        selectedIndices.Add(index);
                    }
                    else
                    {
                        Console.WriteLine($"L'indice {index} est invalide. Il sera ignoré.");
                    }
                }
                else
                {
                    Console.WriteLine($"L'entrée {indexStr} n'est pas un nombre valide. Elle sera ignorée.");
                }
            }

            foreach (var selectedIndex in selectedIndices)
            {
                SaveWorkModel selectedWork = workList[selectedIndex - 1];
                executeWorkService.executeWork(selectedWork);
            }
        }
    }
}
