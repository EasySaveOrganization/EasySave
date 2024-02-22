using EasySaveProject.ObserverFolder;
using EasySaveProject.SaveWorkFolder;
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
<<<<<<< HEAD

            Console.WriteLine("Choisissez les travaux que vous souhaitez exécuter en utilisant les numéros séparés par des espaces :");
            int i = 1;
=======
            int i = 0;
>>>>>>> 7f8ee939f33ec6cf7ce0e8ffe0da01f5e39c4b9e
            foreach (var work in workList)
            {
                Console.WriteLine(i + " - Name of the save work : " + work.saveName + "\n");
                i += 1;
            }
<<<<<<< HEAD
=======
            string? inputSavework = Console.ReadLine();
            foreach (var work in workList)
            {
                if (work.saveName == inputSavework)
                {
                    executeWorkService.executeWork(work);
                }
            }
>>>>>>> 7f8ee939f33ec6cf7ce0e8ffe0da01f5e39c4b9e

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
