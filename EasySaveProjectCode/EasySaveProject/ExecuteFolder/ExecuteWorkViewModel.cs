using EasySaveProject.AddFolder;
using EasySaveProject.ObserverFolder;
using EasySaveProject.SaveWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EasySaveProject.ExecuteFolder
{
    public class ExecuteWorkViewModel
    {
        private WorkListService workListService = new WorkListService();

        private ExecuteWorkService executeWorkService = new ExecuteWorkService();
        public ObservableCollection<SaveWorkModel> Works { get; private set; }
       

        //constructor
        public ExecuteWorkViewModel()
        {
            Works = new ObservableCollection<SaveWorkModel>(workListService.LoadWorkListFromFile());
        }


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