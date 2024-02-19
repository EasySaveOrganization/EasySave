using EasySaveProject.ExecuteFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.ExecuteFolder
{
    
    internal class ExecuteWorkView : View
    {
        // Instance of ExecuteWorkViewModel to interact with the business logic.
        public ExecuteWorkViewModel executeWorkViewModel = new ExecuteWorkViewModel();

        
        public void Show()
        {
            
            Console.WriteLine("Welcome to the Execute Work view!");

            
            executeWorkViewModel.chooseSaveWork();
        }
    }
}
