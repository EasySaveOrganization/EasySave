using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq; 
using EasySaveProject.LogFolder; 

namespace logsTest
{
    public class logsTest
    {
        private FormatLogsStrategyJson formatLogsStrategyJson;

        [SetUp]
        public void Setup()
        {
            SaveWorkModel dummyData = new SaveWorkModel(); // Provide necessary initial data
            formatLogsStrategyJson = new FormatLogsStrategyJson(dummyData);
        }

        [Test]
        public async Task Logs_ShouldObserveStateChangeAndWriteLog()
        {
            // Arrange
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".json";
            string userName = Environment.UserName;
            string workspace = Environment.GetEnvironmentVariable("WORKSPACE") ?? Directory.GetCurrentDirectory();
            string filePath = Path.Combine(workspace, "EasySaveContent", fileName);

            SaveWorkModel exampleWork = new SaveWorkModel
            {
                saveName = "TestSave",
                sourceRepo = "C:\\source",
                targetRepo = "C:\\target",
                FileSize = 1024,
                FileTransferTime = TimeSpan.FromSeconds(1),
                encryptFileTime = TimeSpan.FromSeconds(0.5),
                Time = DateTime.Now
            };

            // Act
            await formatLogsStrategyJson.write(exampleWork);

            // Assert
            //Assert.IsTrue(File.Exists(filePath), "Log file does not exist after Write operation.");

            string jsonContent = await File.ReadAllTextAsync(filePath);
            JArray logsArray = JArray.Parse(jsonContent);
            Assert.IsNotNull(logsArray, "Deserialized log array is null.");
            Assert.IsTrue(logsArray.Count > 0, "Log array should contain at least one entry.");

            JObject lastLogEntry = (JObject)logsArray[logsArray.Count - 1];
            Assert.AreEqual(exampleWork.saveName, lastLogEntry["Name"].ToString(), "Log entry saveName does not match.");

            // Teardown: Delete the log file after the test has run to clean up
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
