using EasySaveProject.ExecuteFolder;
using EasySaveProject.LanguageFolder;
using EasySaveProject.SaveWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EasySaveProject.MenuFolder.MenuViewModel;

namespace EasySaveProject.MenuFolder
{
    internal class MenuRouteur
    {
        public class MenuRouter
        {
            // Singleton instance
            private static MenuRouter _instance;

            // Lock synchronization object
            private static readonly object _lock = new object();

            // Dictionary to map Menu enums to actions
            public Dictionary<Menu, Action> map;

            // Private constructor
            private MenuRouter()
            {
                map = new Dictionary<Menu, Action>();
                // Initialize map with Menu actions
                map.Add(Menu.AddWork, AddWork);
                map.Add(Menu.ExecuteWork, ExecuteWork);
                map.Add(Menu.ProgressView, ProgressView);
                map.Add(Menu.Settings, Settings);
            }

            // Public static property to get the singleton instance
            public static MenuRouter Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        lock (_lock)
                        {
                            if (_instance == null)
                            {
                                _instance = new MenuRouter();
                            }
                        }
                    }
                    return _instance;
                }
            }

            // Method to redirect to the action associated with a Menu enum
            public void redirect(Menu menu)
            {
                if (map.TryGetValue(menu, out Action action))
                {
                    action?.Invoke();
                }
                else
                {
                    Console.WriteLine("Probleme dans la création");
                }
            }
            private void AddWork()
            {
                SaveWorkView saveworkview = new SaveWorkView();
                saveworkview.Show();
            }

            private void ProgressView()
            {
                WorkListService workListService = new WorkListService();
                ProgressViewModel progressViewModel = new ProgressViewModel(workListService);
                ProgressView progressview = new ProgressView(progressViewModel);
                progressview.show();
            }

            private void Settings()
            {
                SettingView settingView = new SettingView();

                settingView.show();
            }

            private void ExecuteWork()
            {
                ExecuteWorkView savecompleteview = new ExecuteWorkView();
                savecompleteview.Show();

                // Code to execute work
            }
        }


    }
}
