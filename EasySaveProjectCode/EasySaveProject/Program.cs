// See https://aka.ms/new-console-template for more information

using EasySaveProject;
using EasySaveProject.SaveWork;



SettingViewModel settingViewModel = new SettingViewModel();
settingViewModel.DisplayLanguageOptions();

MenuWorkView menuworkview = new MenuWorkView();
menuworkview.show();

/*SaveWorkView saveworkview = new SaveWorkView();
saveworkview.Show();*/

/*LanguageManager languageManager = LanguageManager.GetInstance();
languageManager.SwitchLanguages(Languages.FRENCH);
string translatedText = languageManager.Translate("Hello");*/



