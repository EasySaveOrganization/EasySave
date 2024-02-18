using EasySaveProject.LanguageFolder;
using EasySaveProject.MenuFolder;
using System.Windows;
using System;
using System.Windows.Controls;
using EasySaveProject.AddFolder;
using EasySaveProject.ObserverFolder;

using EasySaveProject.SateFolder;
using EasySaveProject.LogFolder;

namespace EasySaveProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            observer events = observer.Instance;
            logs logs = new logs();
            State state = new State();
            events.Subscribe(logs);
            events.Subscribe(state);
            MessageBox.Show($"Subscription added for observer of type: {events.SubscriberCount}");
        }

        public void NavigateHome(Page page)
        {
            Main.Navigate(page);
        }
    }
}
