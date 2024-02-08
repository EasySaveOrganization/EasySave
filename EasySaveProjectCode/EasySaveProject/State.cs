using EasySaveProject.SaveWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.Observer
{
    public class State : observer
    {
        private readonly FormatStateFactory _formatStateFactory;
        private readonly WorkListService _workListService;

        public State (FormatStateFactory formatStateFactory, WorkListService workListService)
        {
            _formatStateFactory = formatStateFactory;
            _workListService = workListService;
        }

       public void update()
        {
            //create an instance of FormatStrategyJson
            var formatStateStrategy = _formatStateFactory.Factory(_workListService);
        }
    }
}
