using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EasySaveProject.ExecuteFolder;
using EasySaveProject.LanguageFolder;
using EasySaveProject.SaveWork;
using System.Windows;

namespace EasySaveProject.AddFolder
{
    public class SaveWorkViewModel
    {
        private WorkListService workListService = new WorkListService();
        public ICommand AddWorkCommand { get; private set; }
        public ICommand ExecuteWorkCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }
        public SaveWorkViewModel() {
            //Initialize command
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate());
            ExecuteWorkCommand = new RelayCommand(param => NavigateToExecuteWork(), param => CanNavigate());
            SettingsCommand = new RelayCommand(param => NavigateToSettings(), param => CanNavigate());
        }
        public void AddWork(string name, string target, string source, string type)
        {
            SaveWorkModel saveWorkModel = new SaveWorkModel(name, target, source, type);
            // Initialiser les propriétés de saveWorkModel avec les données nécessaires

            try
            {
                // Ajouter le travail à la liste via le service
                workListService.AddWork(saveWorkModel);
            }
            catch (InvalidOperationException ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }

        //this will determine if the command can be executed
        private bool CanNavigate()
        {
            return true;
        }


        //This method finds the frame and uses it to navigate
        private void NavigateToAddWork()
        {
            // Navigate to the AddWork page
            Application.Current.MainWindow.Content = new AddWorkView();
        }

        private void NavigateToExecuteWork()
        {
            Application.Current.MainWindow.Content = new ExecuteWork();
        }
        private void NavigateToSettings()
        {
            Application.Current.MainWindow.Content = new Settings();
        }
    }


}
