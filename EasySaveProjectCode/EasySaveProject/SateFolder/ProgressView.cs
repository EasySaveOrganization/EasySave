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
            _progressViewModel.states();

        }

        public void show()
        {
            WorkListService workListService = new WorkListService();
            ProgressViewModel progressViewModel = new ProgressViewModel(workListService);
            ProgressView progressview = new ProgressView(progressViewModel);
            progressview.updateView();
        }
    }
}