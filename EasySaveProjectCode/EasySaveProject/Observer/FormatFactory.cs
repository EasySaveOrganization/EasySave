using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.Observer
{
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
        }
    }
}
