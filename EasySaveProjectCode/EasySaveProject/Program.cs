// See https://aka.ms/new-console-template for more information


using EasySaveProject.SaveWorkFolder;
using EasySaveProject.LanguageFolder;
using EasySaveProject.MenuFolder;
using EasySaveProject.SateFolder;
using EasySaveProject.LogFolder;
using EasySaveProject.ObserverFolder;
using EasySaveProject.ProgramBlockerFolder;

ProgramBlockerService monitor = new ProgramBlockerService("Calculator");
monitor.StartMonitoring();

while (true)
{
    if (monitor.IsBlocked())
    {
        // Block user interaction here
        Console.WriteLine("User interaction is blocked.");
    }
    else
    {
        // Your application logic here
        Console.WriteLine("Your application is running normally.");
        observer events = observer.Instance;
        logs logs = new logs();
        State state = new State();
        events.Subscribe(logs);
        events.Subscribe(state);

        SettingViewModel settingViewModel = new SettingViewModel();
        settingViewModel.DisplayLanguageOptions();

        MenuWorkView menuworkview = new MenuWorkView();
        menuworkview.show();
    }
    Thread.Sleep(1000);
}


