using EasySaveProject.SaveWork;

namespace EasySaveProject.Observer
{
    public class logs : IObserver
    {
        FormatFactory _formatFactory = new FormatFactory();
        WorkListService _workListService = new WorkListService();

        public logs()
        {
        }


        public async void update()
        {
            //create an instance of FormatStrategyJson
            var formatStrategy = _formatFactory.Factory(_workListService);
            await formatStrategy.Write();
            Console.WriteLine("Log file have been updated!");
        }
    }
}
