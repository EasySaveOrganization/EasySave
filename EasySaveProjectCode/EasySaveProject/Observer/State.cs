using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Runtime.Serialization;
=======
>>>>>>> d52808d200ff41d3d2ea5d0112b2149d4cacc555
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.Observer
{
<<<<<<< HEAD
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
=======
    internal class State
    {
        public void update () { }
>>>>>>> d52808d200ff41d3d2ea5d0112b2149d4cacc555
    }
}
