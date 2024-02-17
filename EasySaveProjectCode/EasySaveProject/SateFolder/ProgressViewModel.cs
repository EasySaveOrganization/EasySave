using EasySaveProject.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EasySaveProject.ExecuteFolder;
using EasySaveProject.SaveWork;

namespace EasySaveProject.SateFolder
{
    public class ProgressViewModel
    {
        WorkListService _workListService;

        public ProgressViewModel(WorkListService workListService)
        {
            _workListService = workListService;
        }

        public void states()
        {
            var workList = _workListService.LoadWorkListFromFile();

            foreach (var work in workList)
            {
                if (work.saveType == "Active")
                {
                    int progress = work.Progress;
                    Console.WriteLine(progress);
                }
                else
                {
                    Console.WriteLine("No work is running");
                }
            }

        }

    }
}