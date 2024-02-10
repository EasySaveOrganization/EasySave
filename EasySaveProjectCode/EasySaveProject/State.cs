using EasySaveProject.SaveWork;
namespace EasySaveProject.Observer
{
    public class State : IObserver
    {
        FormatStateFactory _formatStateFactory = new FormatStateFactory();
        WorkListService _workListService = new WorkListService();

        public State ()
        {
        }

       public async void update()
        {
            //create an instance of FormatStrategyJson
            var formatStateStrategy = _formatStateFactory.Factory(_workListService);
            await formatStateStrategy.Write();
        }
    }
}
