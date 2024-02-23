using System;
using System.Text.Json;
using EasySaveProject.SaveWorkFolder;
using EasySaveProject.ExecuteFolder;

namespace EasySaveProject.LogFolder
{
    public abstract class FormatLogs
    {
        public abstract Task write(SaveWorkModel data);
    }
}
