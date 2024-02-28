using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ConsoleDeportee.ExecuteFolder
{
    /// <summary>
    /// Logique d'interaction pour ExecuteWork.xaml
    /// </summary>
    public partial class ExecuteWork : Page
    {
        public ExecuteWork()
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
        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ExecuteWorkViewModel;
            var works = ExecuteWorkList.SelectedItems.OfType<WorkItem>().ToList(); 

            if (viewModel != null)
            {
                foreach (var work in works)
                {
                    Task.Run(() => viewModel.ExecuteSelectedWork(work)); 
                }
            }
        }
    }
}
