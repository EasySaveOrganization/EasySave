// See https://aka.ms/new-console-template for more information

using EasySaveProject;
using EasySaveProject.SaveCompleteDiff;
using EasySaveProject.SaveWork;
using EasySaveProject.Observer;

observer events = observer.Instance;
logs logs = new logs(); 
State state = new State();
events.Subscribe(logs);
events.Subscribe(state);

SettingViewModel settingViewModel = new SettingViewModel();
settingViewModel.DisplayLanguageOptions();

MenuWorkView menuworkview = new MenuWorkView();
menuworkview.show();

