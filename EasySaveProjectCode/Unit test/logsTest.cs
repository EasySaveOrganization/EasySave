using NUnit.Framework.Internal;
using System.Text.Json;
using EasySaveProject.SaveWorkFolder;
using EasySaveProject.ExecuteFolder;
using EasySaveProject.SaveWork;
using EasySaveProject.LogFolder;
using EasySaveProject.ObserverFolder;


namespace logsTest
{
    public class logsTest
    {
        private logs logsObserver;
        private ExecuteWorkService executeWorkService;

        [SetUp]
        public void Setup()
        {
            // Initialize your Logs class, which is assumed to be the observer.
            logsObserver = new logs();
            observer events = observer.Instance;
        }

        [Test]
        public async Task Logs_ShouldObserveStateChangeAndWriteLog()
        {
            // Arrange
            var workListService = new WorkListService();
            var formatFactory = new FormatLogsFactory();
            var formatStrategyJson = new FormatLogsStrategyJson(workListService);
            var logs = new logs(); // Assuming Logs has a parameterless constructor
            string userName = Environment.UserName;
            string filePath = $"C:\\Users\\{userName}\\Desktop\\logs.json";

            var exampleWork = new SaveWorkModel
            {
                FileSize = 1024,
                FileTransferTime = TimeSpan.FromMinutes(5),
                Time = DateTime.Now,
            };

            // Act
            await formatStrategyJson.Write(exampleWork);

            // Assert
            Assert.IsTrue(File.Exists(filePath), "Log file does not exist after Write operation.");

            string jsonContent = await File.ReadAllTextAsync(filePath);
            var workList = JsonSerializer.Deserialize<List<SaveWorkModel>>(jsonContent);
            Assert.IsNotNull(workList, "Deserialized work list is null.");

            // Teardown: Delete the log file after the test has run to clean up
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }


    }
}
