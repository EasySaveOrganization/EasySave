using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace EasySaveProject.LanguageFolder
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        private readonly LanguageManager languageManager;
        public Settings()
        {
            InitializeComponent();
            languageManager = LanguageManager.GetInstance();
            this.DataContext = new SettingViewModel();
        }
    } 
       
}
