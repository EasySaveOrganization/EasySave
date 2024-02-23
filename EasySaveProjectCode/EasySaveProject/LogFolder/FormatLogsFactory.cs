using EasySaveProject.ExecuteFolder;
using EasySaveProject.SaveWork;

namespace EasySaveProject.LogFolder
{
    public class FormatLogsFactory
    {
        public FormatLogs Factory(SaveWorkModel executedWork)
        {
            switch (executedWork.logsFormat)
            {
                case 1: // Xml case
                    return new FormatLogsStrategyXml(executedWork);
                case 2: // Json case
                    return new FormatLogsStrategyJson(executedWork);
                default:
                    throw new ArgumentException("Unsupported format type.");
            }

        }
    }
}