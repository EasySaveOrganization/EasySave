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
            // Load the list of save works from file
            var workList = workListService.LoadWorkListFromFile();
            int i = 0;
            foreach (var work in workList)
            {
                // Display the save work names along with their index
                Console.WriteLine(i + " - Name of the save work : " + work.saveName + "\n");
                i += 1;
            }

            // Read user input for choosing a save work
            string? inputSavework = Console.ReadLine();


            foreach (var work in workList)
            {
                if (work.saveName == inputSavework)
                {
                    executeWorkService.executeWork(work);
                }
            }
        }
    }
}
