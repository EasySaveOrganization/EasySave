using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject_V2.AddWork;
using EasySaveProject_V2.ExecuteFolder;
using EasySaveProject_V2.ObserverFolder;

namespace EasySaveProject_V2.StateFolder
{
    public class State : IObserver
    {
        FormatStateFactory _formatStateFactory = new FormatStateFactory();
        WorkListService _workListService = new WorkListService();

        public State()
        {
        }

        public async void update(SaveWorkModel executedWork)
        {
            //create an instance of FormatStrategyJson
            var formatStateStrategy = _formatStateFactory.Factory(_workListService);
            await formatStateStrategy.Write(executedWork);
        }
    }
}
