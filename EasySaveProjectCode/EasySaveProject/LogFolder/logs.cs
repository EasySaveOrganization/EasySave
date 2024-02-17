using EasySaveProject.ObserverFolder;
using EasySaveProject.SaveWork;

namespace EasySaveProject.LogFolder
{
    public class logs : IObserver
    {
        FormatLogsFactory _formatFactory = new FormatLogsFactory();
        WorkListService _workListService = new WorkListService();

        public logs()
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
