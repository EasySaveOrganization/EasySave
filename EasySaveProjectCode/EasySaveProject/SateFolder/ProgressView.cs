using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject.ExecuteFolder;
using EasySaveProject.ObserverFolder;
using EasySaveProject.SaveWork;

namespace EasySaveProject.SateFolder
{
    internal class ProgressView
    {
        private ProgressViewModel _progressViewModel;
        public ProgressView(ProgressViewModel progressViewModel)
        {
            _progressViewModel = progressViewModel;
        }

        public void updateView()
        {
            Console.WriteLine("Update called on ProgressView.");

            // Call the states method of ProgressViewModel.
            _progressViewModel.states();
        }

        public void show()
        {
            // Create an instance of WorkListService.
            WorkListService workListService = new WorkListService();

            // Create an instance of ProgressViewModel with WorkListService.
            ProgressViewModel progressViewModel = new ProgressViewModel(workListService);

            // Create an instance of ProgressView with ProgressViewModel.
            ProgressView progressview = new ProgressView(progressViewModel);

         
            progressview.updateView();
        }
    }
}

