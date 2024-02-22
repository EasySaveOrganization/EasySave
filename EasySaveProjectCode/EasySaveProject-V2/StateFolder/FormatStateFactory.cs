using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject_V2.ExecuteFolder;

namespace EasySaveProject_V2.StateFolder
{
    public class FormatStateFactory
    {
        public FormatStateStrategyJson Factory(WorkListService workListService)
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
        }
    }
}
