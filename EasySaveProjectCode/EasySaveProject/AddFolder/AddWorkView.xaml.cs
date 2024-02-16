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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using EasySaveProject.AddFolder;
using EasySaveProject.LanguageFolder;
using EasySaveProject.SaveFolder;

namespace EasySaveProject.AddFolder
{
    /// <summary>
    /// Logique d'interaction pour SaveWork.xaml
    /// </summary>
    /// 
    //private SaveWorkViewModel saveWorkViewModel = new SaveWorkViewModel();
    public partial class AddWorkView : Page
    {
        private SaveWorkViewModel saveWorkViewModel;

        public AddWorkView()
        {
            InitializeComponent();
            saveWorkViewModel = new SaveWorkViewModel();
            DataContext = saveWorkViewModel;
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string target = txtTarget.Text;
            string source = txtSource.Text;
            string type = txtType.Text;

            // Appeler la méthode AddWork du ViewModel
            saveWorkViewModel.AddWork(name, target, source, type);

            MessageBox.Show("Les données de sauvegarde ont été validées et ajoutées avec succès.");
        }
    }
}

