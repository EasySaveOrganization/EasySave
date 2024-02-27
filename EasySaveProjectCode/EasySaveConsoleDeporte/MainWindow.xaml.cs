using System.Windows;
using System.Windows.Controls;
using EasySaveConsoleDeporte.AddWork;
using EasySaveConsoleDeporte.ExecuteFolder;
using EasySaveConsoleDeporte.MenuFolder;

namespace EasySaveConsoleDeporte
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainViewModel = new MenuViewModel(); // Pass it to the ViewModel
        }
    }
}