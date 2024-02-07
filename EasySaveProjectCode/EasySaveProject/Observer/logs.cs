using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.Observer
{
    public class logs : Observer
    {
        private readonly FormatFactory _formatFactory;

        public logs (FormatFactory formatFactory, WorkListService workListService)
        {
            _formatFactory = formatFactory;
            _workListService = workListService;
        }

        public void update()
        {
            //create an instance of FormatStrategyJson
            var formatStrategy = _formatFactory.Factory(_workListService);
        }
    }
}
