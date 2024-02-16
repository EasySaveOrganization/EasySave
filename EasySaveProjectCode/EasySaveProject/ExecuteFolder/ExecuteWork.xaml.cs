using EasySaveProject.MenuFolder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EasySaveProject.ExecuteFolder
{
    /// <summary>
    /// Logique d'interaction pour ExecuteWork.xaml
    /// </summary>
    public partial class ExecuteWork : Page
    {
        public ObservableCollection<SaveWorkModel> Works { get; private set; }

        public ExecuteWork()
        {
            InitializeComponent();

            //create a new instance of the ExecuteWorkViewModel
            //this instance contain the data we will bind to the view
            ExecuteWorkViewModel executeWorkViewModel = new ExecuteWorkViewModel();

            //Set the default object for databinding to the mainViewModel
            this.DataContext = executeWorkViewModel;
    }
    private void BtnExecute_Click(object sender, RoutedEventArgs e)
    {
            var viewModel = DataContext as ExecuteWorkViewModel;
            if (viewModel?.SelectedWork != null)
            {
                //Executer le work 
                viewModel.ExecuteSelectedWork(viewModel.SelectedWork);
                //Afficher un message d'erreur 
                MessageBox.Show("The work has been successfully executed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
}
}
