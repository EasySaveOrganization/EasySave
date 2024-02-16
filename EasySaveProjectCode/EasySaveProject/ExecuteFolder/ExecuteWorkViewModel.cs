using EasySaveProject.AddFolder;
using EasySaveProject.ObserverFolder;
using EasySaveProject.SaveWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EasySaveProject.ExecuteFolder
{
    public class ExecuteWorkViewModel : INotifyPropertyChanged
    {
        private WorkListService workListService = new WorkListService();

        private ExecuteWorkService executeWorkService = new ExecuteWorkService();
        public ObservableCollection<SaveWorkModel> Works { get; private set; }
        
        //a field that will hold the selected work
        private SaveWorkModel _selectedWork;
        public event PropertyChangedEventHandler PropertyChanged;
       

        //constructor
        public ExecuteWorkViewModel()
        {
            Works = new ObservableCollection<SaveWorkModel>(workListService.LoadWorkListFromFile());
        }

        public void ExecuteSelectedWork(SaveWorkModel workToExecute)
        {
            // Assuming you have a method to execute the work
            executeWorkService.executeWork(workToExecute);
            // Optionally, refresh the list or update UI here
        }

        public SaveWorkModel SelectedWork
        {
            get => _selectedWork;
            set
            {
                _selectedWork = value;
                OnPropertyChanged(nameof(SelectedWork));
            }
        }
        
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}