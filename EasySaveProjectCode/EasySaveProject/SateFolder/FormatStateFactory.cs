using EasySaveProject.SateFolder;
using EasySaveProject.SaveWork;

namespace EasySaveProject.Observer
{
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
        }
    }
}
