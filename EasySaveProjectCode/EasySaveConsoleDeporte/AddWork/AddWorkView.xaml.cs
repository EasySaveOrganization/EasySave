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

namespace EasySaveConsoleDeporte.AddWork
{
    /// <summary>
    /// Logique d'interaction pour AddWorkView.xaml
    /// </summary>
    public partial class AddWorkView : Page
    {

        public AddWorkView()
        {
            InitializeComponent();
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


            MessageBox.Show("Les données de sauvegarde ont été validées et ajoutées avec succès.");
        }
    }
}
