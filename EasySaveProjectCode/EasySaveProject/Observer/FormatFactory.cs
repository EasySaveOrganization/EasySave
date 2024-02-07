using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.Observer
{
    internal class FormatFactory
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
        }
    }
}
