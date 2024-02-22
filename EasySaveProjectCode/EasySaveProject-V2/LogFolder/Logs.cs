using EasySaveProject_V2.ObserverFolder;
using EasySaveProject_V2.AddWork;
using EasySaveProject_V2.ExecuteFolder;

namespace EasySaveProject_V2.LogFolder
{
    public class Logs : IObserver
    {
        FormatLogsFactory _formatFactory = new FormatLogsFactory();
        WorkListService _workListService = new WorkListService();

        public Logs()
        {
        }


        public async void update(SaveWorkModel executedWork)
        {
            //create an instance of FormatStrategyJson
            var formatStrategy = _formatFactory.Factory(executedWork);
            await formatStrategy.write(executedWork);
        }
    }
}
