using System;

namespace EasySaveProject.ObserverFolder
{
    public class observer
    {
        private static observer _instance;
        private List<IObserver> _observers;

        public observer()
        {
            _observers = new List<IObserver>();
        }

        public static observer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new observer();
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
