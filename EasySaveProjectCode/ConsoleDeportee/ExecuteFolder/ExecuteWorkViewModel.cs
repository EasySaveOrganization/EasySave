using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using ConsoleDeportee.AddWork;
using ConsoleDeportee.LanguageFolder;
using Newtonsoft.Json;

namespace ConsoleDeportee.ExecuteFolder
{
    public class ExecuteWorkViewModel : INotifyPropertyChanged
    {
        private readonly NetWorkService _netWorkService;
        public ObservableCollection<dynamic> Works { get; private set; }

        //Navigation Commands
        public ICommand AddWorkCommand { get; private set; }
        public ICommand SettingsCommand { get; private set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //constructor
        public ExecuteWorkViewModel()
        {
            AddWorkCommand = new RelayCommand(param => NavigateToAddWork(), param => CanNavigate());
            SettingsCommand = new RelayCommand(param => NavigateToSettings(), param => CanNavigate());
            _netWorkService = new NetWorkService();
            Works = new ObservableCollection<dynamic>();
            LoadWorkList();
        }

        private async void LoadWorkList()
        {
            var request = new Dictionary<string, string>
        {
            { "requestType", "obtainBackupList" }
        };

            try
            {
                var response = await _netWorkService.SendRequest(request);

                if (response.TryGetValue("type", out var responseType) && responseType == "response")
                {
                    // Parse the JSON response into a dynamic object
                    var worksList = JsonConvert.DeserializeObject<List<dynamic>>(response["message"]);

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Works.Clear();
                        foreach (var work in worksList)
                        {
                            Works.Add(work);
                        }
                    });
                }
                else if (responseType == "error")
                {
                    MessageBox.Show(response["message"], "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while obtaining the backup list: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}
