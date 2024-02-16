using EasySaveProject.ExecuteFolder;
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
using System.Windows.Shapes;

namespace EasySaveProject
{
    /// <summary>
    /// Logique d'interaction pour ExecuteWorkView.xaml
    /// </summary>
    public partial class ExecuteWorkView : Window
    {
        private ExecuteWorkViewModel executeWorkViewModel;
        public ExecuteWorkView()
        {
            InitializeComponent();
            executeWorkViewModel = new ExecuteWorkViewModel();
            DataContext = executeWorkViewModel;
        }
        

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
