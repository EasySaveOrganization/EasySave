using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject_V2.ExecuteFolder;
using EasySaveProject_V2.StateFolder;

namespace EasySaveProject_V2.MenuFolder
{
    public class MenuRouteur
    {
        public class MenuRouter
        {
            // Singleton instance
            private static MenuRouter _instance;

            // Lock synchronization object
            private static readonly object _lock = new object();



            // Private constructor
            private MenuRouter()
            {


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




            private void ProgressView()
            {
                WorkListService workListService = new WorkListService();
                ProgressViewModel progressViewModel = new ProgressViewModel(workListService);
            }

        }
    }
}
