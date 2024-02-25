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

namespace EasySaveProject_V2
{
    /// <summary>
    /// Logique d'interaction pour LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (rbLocal.IsChecked == true)
            {
                // Logic to run the app locally
            }
            else if (rbRemote.IsChecked == true)
            {
                string ipAddress = txtIpAddress.Text;
            }
        }
    }
}
