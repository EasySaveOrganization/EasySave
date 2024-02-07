using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.Observer
{
<<<<<<< HEAD
    public class FormatFactory
    {
        public FormatStrategyJson Factory (WorkListService workListService) 
        {
            /*switch ()
            {
                case "json":
                    return new FormatStrategyJson(workListService);
                default:
                    throw new ArgumentException("Unsupported format type.");
            }*/
            return new FormatStrategyJson(workListService);
=======
    internal class FormatFactory
    {
        public void Factory (WorkListService workListService) 
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
