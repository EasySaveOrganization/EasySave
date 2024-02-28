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

namespace ConsoleDeportee.AddWork
{
    /// <summary>
    /// Logique d'interaction pour AddWorkView.xaml
    /// </summary>
    public partial class AddWorkView : Page
    {
        private SaveWorkViewModel saveWorkViewModel;
        private NetWorkService _netWorkService;
        public AddWorkView()
        {
            InitializeComponent();
            saveWorkViewModel = new SaveWorkViewModel(_netWorkService);
            DataContext = saveWorkViewModel;
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string target = txtTarget.Text;
            string source = txtSource.Text;
            string type = txtType.Text;
            string extenstionFileToCrypt = txtCrypt.Text;
            int logsFormat = 1;
            if (radioLogFormat1.IsChecked == true)
            {
                logsFormat = 1;
            }
            else if (radioLogFormat2.IsChecked == true)
            {
                logsFormat = 2;
            }

            // Appeler la méthode AddWork du ViewModel
           

            MessageBox.Show("Les données de sauvegarde ont été validées et ajoutées avec succès.");
        }
    }
}
