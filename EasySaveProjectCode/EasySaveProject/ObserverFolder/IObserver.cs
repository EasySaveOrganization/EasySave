using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.ObserverFolder
{
    public interface IObserver
    {
        void update(SaveWorkModel executedWork);
    }

}
