using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject.LogFolder
{
    public abstract class FormatLogs
    {
        public abstract Task write(SaveWorkModel data);
    }
}