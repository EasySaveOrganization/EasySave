using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EasySaveProject_V2.ExecuteFolder;

namespace EasySaveProject_V2.StatusFolder
{
    /// <summary>
    /// Logique d'interaction pour StatusWindow.xaml
    /// </summary>
    public partial class StatusWindow : Page
    {
        public StatusWindow()
        {
            InitializeComponent();
            ExecuteWorkViewModel executeWorkViewModel = new ExecuteWorkViewModel();

            //Set the default object for databinding to the mainViewModel
            this.DataContext = executeWorkViewModel;
        }
    }
}
