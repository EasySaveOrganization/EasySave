using ConsoleDeportee.ExecuteFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ConsoleDeportee.StatusFolder
{
    /// <summary>
    /// Logique d'interaction pour StatusWindow.xaml
    /// </summary>
    public partial class StatusWindow : Page
    {
        public StatusWindow()
        {
            InitializeComponent();
            //get the netWorkService instance
            var mainWindow = Application.Current.MainWindow as MainWindow;
            var networkService = mainWindow?._networkService;

            //create a new instance of the ExecuteWorkViewModel
            //this instance contain the data we will bind to the view
            ExecuteWorkViewModel executeWorkViewModel = new ExecuteWorkViewModel(networkService);
            //Set the default object for databinding to the mainViewModel
            this.DataContext = executeWorkViewModel;
        }
    }
}
