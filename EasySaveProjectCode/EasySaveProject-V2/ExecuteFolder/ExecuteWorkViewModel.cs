using EasySaveProject_V2.AddWork;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using EasySaveProject_V2.LanguageFolder;

namespace EasySaveProject_V2.ExecuteFolder
{
    public class ExecuteWorkViewModel : INotifyPropertyChanged
    {
        private WorkListService workListService = new WorkListService();

        private ExecuteWorkService executeWorkService = new ExecuteWorkService();
        public ObservableCollection<SaveWorkModel> Works { get; private set; }

        //Navigation Commands
        public ICommand AddWorkCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public string WorkList => LanguageManager.GetInstance().Translate("Work List");
        public string ExecuteButton => LanguageManager.GetInstance().Translate("Execute");
        public string BackupName => LanguageManager.GetInstance().Translate("Backup Name");
        public string TargetDirectory => LanguageManager.GetInstance().Translate("Target Directory");
        public string SourceDirectory => LanguageManager.GetInstance().Translate("Source Directory");
        public string AddWork => LanguageManager.GetInstance().Translate("Add work");
        public string Settings => LanguageManager.GetInstance().Translate("Settings");

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //constructor
        public ExecuteWorkViewModel()
        {
            Works = new ObservableCollection<SaveWorkModel>(workListService.LoadWorkListFromFile());
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate());
            SettingsCommand = new RelayCommand(param => NavigateToSettings(), param => CanNavigate());
            LanguageManager.LanguageChanged += OnLanguageChanged;
        }
        private void OnLanguageChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(WorkList));
            OnPropertyChanged(nameof(ExecuteButton));
            OnPropertyChanged(nameof(BackupName));
            OnPropertyChanged(nameof(TargetDirectory));
            OnPropertyChanged(nameof(SourceDirectory));
            OnPropertyChanged(nameof(AddWork));
            OnPropertyChanged(nameof(Settings));
        }

        public void ExecuteSelectedWork(SaveWorkModel workToExecute)
        {
            executeWorkService.executeWork(workToExecute);
        }


        //Navigation parts
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

        private void NavigateToSettings()
        {
            Application.Current.MainWindow.Content = new Settings();
        }
    }
}
