using EasySaveProject_V2.AddWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject_V2.LogFolder
{
    public abstract class FormatLogs
    {
        public abstract Task write(SaveWorkModel data);
    }
}
