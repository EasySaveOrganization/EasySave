using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject_V2.AddWork;
using EasySaveProject_V2.ExecuteFolder;

namespace EasySaveProject_V2.LogFolder
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
