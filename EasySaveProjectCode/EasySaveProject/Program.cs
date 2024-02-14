// See https://aka.ms/new-console-template for more information


using EasySaveProject.SaveWorkFolder;
using EasySaveProject.LanguageFolder;
using EasySaveProject.MenuFolder;
using EasySaveProject.SateFolder;
using EasySaveProject.LogFolder;
using EasySaveProject.ObserverFolder;

observer events = observer.Instance;
logs logs = new logs(); 
State state = new State();
events.Subscribe(logs);
events.Subscribe(state);

SettingViewModel settingViewModel = new SettingViewModel();
settingViewModel.DisplayLanguageOptions();

MenuWorkView menuworkview = new MenuWorkView();
menuworkview.show();

