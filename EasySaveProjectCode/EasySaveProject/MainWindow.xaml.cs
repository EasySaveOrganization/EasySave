using EasySaveProject.LanguageFolder;
using EasySaveProject.MenuFolder;
using System.Windows;
using System;
using System.Windows.Controls;
using EasySaveProject.AddFolder;

namespace EasySaveProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void NavigateHome(Page page)
        {
            // Assuming 'MainFrame' is the name of your Frame control in MainWindow.xaml
            Main.Navigate(page);
        }
    }
}
