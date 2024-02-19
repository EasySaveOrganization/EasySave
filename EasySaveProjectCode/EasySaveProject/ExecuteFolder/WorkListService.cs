using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EasySaveProject.SaveWork
{
    public class WorkListService
    {
        public List<SaveWorkModel>? workList;
        public string filePath;

        public WorkListService()
        {
            // Initialize workList, possibly load data from the file
            workList = LoadWorkListFromFile() ?? new List<SaveWorkModel>();
            string userName = Environment.UserName;
            this.filePath = $"C:\\Users\\{userName}\\Desktop\\worklist.json";
        }

        // Method to add a work
        public void AddWork(SaveWorkModel work)
        {
            if (workList?.Count < 5)
            {
                workList?.Add(work);
                SaveWorkListToFile();
            }
            else
            {
                throw new InvalidOperationException("The work list already contains 5 items.");
            }
        }

        // Method to remove a work
        public void RemoveWork(SaveWorkModel work)
        {
            workList?.Remove(work);
            SaveWorkListToFile();
        }

        public List<SaveWorkModel> LoadWorkListFromFile()
        {
            // Load data from the JSON file
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);

                // Check if the JSON is empty
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    return JsonSerializer.Deserialize<List<SaveWorkModel>>(jsonData);
                }
            }

            // If the file is empty or doesn't exist, return a new empty list
            return new List<SaveWorkModel>();
        }

        private void SaveWorkListToFile()
        {
            // Load existing data from the JSON file, if it exists
            List<SaveWorkModel> existingData = LoadWorkListFromFile() ?? new List<SaveWorkModel>();

            // Merge existing data with the current workList
            if (existingData != null)
            {
                existingData.AddRange(workList);
                workList = existingData;
            }

            // Save data to the JSON file
            string jsonData = JsonSerializer.Serialize(workList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(this.filePath, jsonData);
        }
    }
}
