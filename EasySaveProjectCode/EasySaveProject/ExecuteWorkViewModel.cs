using EasySaveProject.SaveWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject
{
    public class ExecuteWorkViewModel
    {
        private WorkListService workListService = new WorkListService();
        private ExecuteWorkService executeWorkService = new ExecuteWorkService();

        public void chooseSaveWork()
        {
            var workList = workListService.LoadWorkListFromFile();
            int i = 0;
            foreach (var work in workList)
            {
                Console.WriteLine(i + " - Name of the save work : " + work.saveName + "\n");
                i += 1;
            }
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