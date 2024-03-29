﻿using EasySaveProject.ObserverFolder;
using EasySaveProject.SaveWorkFolder;
using EasySaveProject.ExecuteFolder;

namespace EasySaveProject.LogFolder
{
    public class Logs : IObserver
    {
        FormatFactory _formatFactory = new FormatFactory();
        WorkListService _workListService = new WorkListService();

        public Logs()
        {
        }


        public async void update(SaveWorkModel executedWork)
        {
            //create an instance of FormatStrategyJson
            var formatStrategy = _formatFactory.Factory(_workListService);
            await formatStrategy.Write(executedWork);
            Console.WriteLine("Log file have been updated!");
        }
    }
}
