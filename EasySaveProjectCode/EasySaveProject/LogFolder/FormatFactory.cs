using EasySaveProject.ExecuteFolder;

namespace EasySaveProject.LogFolder
{
    public class FormatFactory
    {
        public FormatStrategyJson Factory(WorkListService workListService)
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
