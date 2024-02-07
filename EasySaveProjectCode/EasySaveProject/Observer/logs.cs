using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.Observer
{
<<<<<<< HEAD
    public class logs : observer
    {
        private readonly FormatFactory _formatFactory;
        private readonly WorkListService _workListService;
        public logs (FormatFactory formatFactory, WorkListService workListService)
        {
            _formatFactory = formatFactory;
            _workListService = workListService;
        }

        public void update()
        {
            //create an instance of FormatStrategyJson
            var formatStrategy = _formatFactory.Factory(_workListService);
=======
    internal class logs
    {
        public void update()
        {
            
>>>>>>> d52808d200ff41d3d2ea5d0112b2149d4cacc555
        }
    }
}
