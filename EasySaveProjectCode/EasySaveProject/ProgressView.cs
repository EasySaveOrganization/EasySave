using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject.Observer;

namespace EasySaveProject
{
    internal class ProgressView : IObserver
    {
        private ProgressViewModel _progressViewModel;

        public ProgressView(ProgressViewModel progressViewModel)
        {
            _progressViewModel = progressViewModel;
        }

        public void update()
        {
            Console.WriteLine("Update called on ProgressView.");
            _progressViewModel.states();

        }
    }
}
