using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EasySaveProject.MenuViewModel;

namespace EasySaveProject
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
                    // Handle the case where there is no action associated with the menu
                }
            }
            private void AddWork()
            {
                Console.WriteLine("Adding work...");
                // Code to add work
            }

            private void ProgressView()
            {
                Console.WriteLine("Progress View...");
                // Code to progress view work
            }

            private void Settings()
            {
                Console.WriteLine("Settings View...");
                // Code to settings
            }

            private void ExecuteWork()
            {
                Console.WriteLine("Executing work...");
                // Code to execute work
            }
        }


    }
}
