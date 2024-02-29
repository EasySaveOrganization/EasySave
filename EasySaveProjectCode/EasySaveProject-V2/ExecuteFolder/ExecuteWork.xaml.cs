using EasySaveProject_V2.AddWork;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Windows;
using System.Windows.Controls;
using System.IO;
namespace EasySaveProject_V2.ExecuteFolder
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
        static void LogMessage(string logFile, string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFile, true))
                {
                    writer.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'écriture dans le fichier de journal : {ex.Message}");
            }
        }
        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ExecuteWorkViewModel;
            var works = ExecuteWorkList.SelectedItems;

            int counter = 0;

            foreach (SaveWorkModel work in works) 
            { 
                //Creer un if pour savoir si il le fichier est prioritaire si le work est prioritaire isBool = true
                counter++;
                LogMessage("logile.txt", $"Pre If : {work.savePriorityFile}");

                if (Path.GetExtension(work.sourceRepo) == work.savePriorityFile)
                {
                    LogMessage("logile.txt", $"After If : {work.savePriorityFile}");
                    work.isPriority = true;
                }
            }

            //Recupérer la priorité    

            if (viewModel != null)
            {
                foreach (SaveWorkModel work in works) { viewModel.ExecuteSelectedWork(work,counter); }
                //Executer le work 
                
                MessageBox.Show("The work has been successfully executed.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
