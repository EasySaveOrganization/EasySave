using System.Windows;
using System.Windows.Controls;
using ConsoleDeportee.MenuFolder;

namespace ConsoleDeportee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = new MenuViewModel();
        }
    }
}