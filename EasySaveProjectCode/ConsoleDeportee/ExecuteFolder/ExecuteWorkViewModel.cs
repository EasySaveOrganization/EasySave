using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ConsoleDeportee.AddWork;
using ConsoleDeportee.LanguageFolder;
using Newtonsoft.Json;
using ConsoleDeportee.StatusFolder;

namespace ConsoleDeportee.ExecuteFolder
{
    public class ExecuteWorkViewModel : INotifyPropertyChanged
    {
        private NetWorkService _netWorkService;
        public ObservableCollection<WorkItem> Works { get; private set; }

        //Navigation Commands
        public ICommand AddWorkCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }
        public ICommand StatusCommand { get; private set; }
        public ICommand ExecuteWorkCommand { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;
       
        public string WorkList => LanguageManager.GetInstance().Translate("Work List");
        public string ExecuteButton => LanguageManager.GetInstance().Translate("Execute");
        public string BackupName => LanguageManager.GetInstance().Translate("Backup Name");
        public string TargetDirectory => LanguageManager.GetInstance().Translate("Target Directory");
        public string SourceDirectory => LanguageManager.GetInstance().Translate("Source Directory");
        public string AddWork => LanguageManager.GetInstance().Translate("Add work");
        public string Settings => LanguageManager.GetInstance().Translate("Settings");
        public string ExecuteWork => LanguageManager.GetInstance().Translate("Execute work");

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //constructor
        public ExecuteWorkViewModel(NetWorkService netWorkService)
        {
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate());
            StatusCommand = new RelayCommand(param => NavigateToStatus(), param => CanNavigate());
            ExecuteWorkCommand = new RelayCommand(param => NavigateToExecuteWork(), param => CanNavigate());
            SettingsCommand = new RelayCommand(param => NavigateToSettings(), param => CanNavigate());
            _netWorkService = netWorkService;
            Works = new ObservableCollection<WorkItem>();
            LoadWorkList();
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

        //send a request to get the list of works 
        private async void LoadWorkList()
        {
            //creating a request
            var request = new Dictionary<string, string>
            {
                { "type", "obtainBackupList" }
            };

            try
            {
                var response = await _netWorkService.SendRequest(request);

                // Access the response directly from the dictionary
                var responseData = response["response"];

                // Deserialize the response data to get the list of works
                var worksList = JsonConvert.DeserializeObject<List<WorkItem>>(responseData);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Works.Clear();
                    foreach (var work in worksList)
                    {
                        //foreach work we find we aded to our works 
                        Works.Add(work);
                    }
                    OnPropertyChanged(nameof(Works));
                });
            }
            catch (Exception ex)
            {
                //in case of error show a message
                MessageBox.Show($"An error occurred while obtaining the backup list: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //send a request to execute the work
        public async Task ExecuteSelectedWork(WorkItem work)
        {
            //serialize the work 
            string workJson = JsonConvert.SerializeObject(work);
            //create the request
            var request = new Dictionary<string, string>
            {
                { "type", "executeBackup" },
                { "Data", workJson }
            };
            MessageBox.Show($"prepared the request", "success", MessageBoxButton.OK, MessageBoxImage.Information);
            try
            {
                MessageBox.Show($"Hello", "success", MessageBoxButton.OK, MessageBoxImage.Information);
                //send the request and wait for the response
                var response = await _netWorkService.SendRequest(request);
                MessageBox.Show($"sended request", "success", MessageBoxButton.OK, MessageBoxImage.Information);

                var responseMessage = response["response"];
                //show a success message
                MessageBox.Show(responseMessage, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                //in case of an error show an error message 
                MessageBox.Show($"An error occurred while executing the backup: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void NavigateToStatus()
        {
            Application.Current.MainWindow.Content = new StatusWindow();
        }

        private void NavigateToExecuteWork()
        {
            Application.Current.MainWindow.Content = new ExecuteWork();
        }
    }
}
