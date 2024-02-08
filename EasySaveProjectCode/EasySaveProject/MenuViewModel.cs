using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EasySaveProject.MenuRouteur;

namespace EasySaveProject
{
    internal class MenuViewModel
    {
        public enum Menu
        {
            AddWork = 0,
            ExecuteWork = 1,
            ProgressView = 2,
            Settings = 3,
        }
        public void redirect(int input)
        {
            // Convert the integer input to a Menu enum value
            Menu menuOption = (Menu)input;
            // Get the singleton instance of MenuRouter
            MenuRouter menuRouter = MenuRouter.Instance;

            // Use the instance to call methods on it
            menuRouter.redirect(menuOption);
        }

    }
}
