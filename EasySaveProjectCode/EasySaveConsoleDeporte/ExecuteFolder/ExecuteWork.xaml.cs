using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace EasySaveConsoleDeporte.ExecuteFolder
{
    /// <summary>
    /// Logique d'interaction pour ExecuteWork.xaml
    /// </summary>
    public partial class ExecuteWork : Page
    {
       

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
            var works = ExecuteWorkList.SelectedItems;
            if (viewModel != null)
            {
                //Executer le work 
                
                MessageBox.Show("The work has been successfully executed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
