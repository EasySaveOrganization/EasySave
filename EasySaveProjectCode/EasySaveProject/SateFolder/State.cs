using EasySaveProject.Observer;
using EasySaveProject.SaveWork;
namespace EasySaveProject.SateFolder
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
            Console.WriteLine("State file has been updated");
        }
    }
}
