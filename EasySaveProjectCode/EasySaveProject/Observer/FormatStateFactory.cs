using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.Observer
{
<<<<<<< HEAD
    public class FormatStateFactory
    {
        public FormatStateStrategyJson Factory (WorkListService workListService)
        {
            /*switch ()
            {
                case "json":
                    return new FormatStateStrategyJson(workListService);
                // Extend with other cases for different formats, e.g., XML
                default:
                    throw new ArgumentException("Unsupported format type.");
            }*/
            return new FormatStateStrategyJson(workListService);
=======
    internal class FormatStateFactory
    {
        public void Factory(WorkListService workListService)
        {
            switch ()
            {
                case "json":
                    return new FormatStrategyJson(workListService);
                // Extend with other cases for different formats, e.g., XML
                default:
                    throw new ArgumentException("Unsupported format type.");
            }
>>>>>>> d52808d200ff41d3d2ea5d0112b2149d4cacc555
        }
    }
}
