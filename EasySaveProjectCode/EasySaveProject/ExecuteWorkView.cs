using EasySaveProject.SaveWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject
{
    internal class ExecuteWorkView : View
    {
        public ExecuteWorkViewModel executeWorkViewModel = new ExecuteWorkViewModel();

        public void Show()
        {
            Console.WriteLine("Welcome to the Execute Work view!");
            executeWorkViewModel.chooseSaveWork();
        }
    }
}
