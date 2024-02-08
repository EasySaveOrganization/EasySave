using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.Observer
{
    public class observer
    {
        private List<IObserver> _observers;

        public observer()
        {
            _observers = new List<IObserver>();
        }
        public void Subscribe(IObserver observer)
        {  
            _observers.Add(observer); 
        }

        public void Detach (IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObserver() 
        {
            _observers.ForEach(observ =>
            {
                observ.update();
            });
        }
    }
}
