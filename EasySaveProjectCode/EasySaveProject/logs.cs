using EasySaveProject.SaveWork;

namespace EasySaveProject.Observer
{
    public class logs : IObserver
    {
        FormatStateFactory _formatFactory = new FormatStateFactory();
        WorkListService _workListService = new WorkListService();

        public logs()
        {
        }


        public async void update()
        {
            //create an instance of FormatStrategyJson
            var formatStrategy = _formatFactory.Factory(_workListService);
            await formatStrategy.Write();
        }
    }
}
