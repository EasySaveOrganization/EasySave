using System;
using System.Diagnostics;
using System.Threading;


namespace EasySaveProject.ProgramBlockerFolder
{
    public class ProgramBlockerService
    {
        private string programName;
        private bool isBlocked;


        public ProgramBlockerService(string programName)
        {
            this.programName = programName;
            this.isBlocked = false;
        }


        public void StartMonitoring()
        {
            Thread monitorThread = new Thread(new ThreadStart(MonitorProgram));
            monitorThread.Start();
        }
        private void MonitorProgram()
        {
            while (true)
            {

                var processList = Process.GetProcessesByName(programName);
                if (processList.Length > 0)
                {
                    isBlocked = true;
                    Console.WriteLine($"{programName} is running. Application is blocked.");
                }
                else
                {
                    if (isBlocked)
                    {
                        isBlocked = false;
                        Console.WriteLine($"{programName} is not running. Application is unblocked.");
                    }
                }
                Thread.Sleep(1000); // Check every second
            }
        }

        public bool IsBlocked()
        {
            return isBlocked;
        }
    }
}
