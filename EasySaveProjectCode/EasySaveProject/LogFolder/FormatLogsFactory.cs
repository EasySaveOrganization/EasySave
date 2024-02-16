using EasySaveProject.ExecuteFolder;
using EasySaveProject.SaveWork;

namespace EasySaveProject.LogFolder
{
    public class FormatLogsFactory
    {
        public FormatLogsFactory Factory(WorkListService workListService)
        {
            /*switch ()
            {
                case "json":
                    return new FormatStrategyJson(workListService);
                default:
                    throw new ArgumentException("Unsupported format type.");
            }*/
            return new FormatLogsStrategyXml(workListService);
        }
    }
}
