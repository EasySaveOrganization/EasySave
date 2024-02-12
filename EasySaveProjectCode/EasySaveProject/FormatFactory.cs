using EasySaveProject.SaveWork;

namespace EasySaveProject.Observer
{
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
        }
    }
}
