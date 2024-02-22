using EasySaveProject_V2.AddWork;

namespace EasySaveProject_V2.ObserverFolder
{
    public class Observer
    {
        private static Observer? _instance;
        private List<IObserver> _observers;

        public Observer()
        {
            _observers = new List<IObserver>();
        }

        public static Observer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Observer();
                }
                return _instance;
            }
        }


        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObserver(SaveWorkModel executedWork)
        {
            _observers.ForEach(observ =>
            {
                observ.update(executedWork);
            });
        }
    }
}
