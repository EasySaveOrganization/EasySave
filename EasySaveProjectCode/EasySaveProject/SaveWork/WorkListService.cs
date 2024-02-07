using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace EasySaveProject.SaveWork
{
    public class WorkListService
    {
        private readonly string filePath;
        private List<SaveWorkModel> workList;

        public WorkListService(string filePath)
        {
            this.filePath = filePath;
            // Initialize workList, possibly load data from the file
            workList = LoadWorkListFromFile();
        }

        // Méthode pour ajouter un travail
        public void AddWork(SaveWorkModel work)
        {
            workList.Add(work);
            SaveWorkListToFile();
        }

        // Méthode pour retirer un travail
        public void RemoveWork(SaveWorkModel work)
        {
            workList.Remove(work);
            SaveWorkListToFile();
        }

        private List<SaveWorkModel> LoadWorkListFromFile()
        {
            // Load data from the JSON file
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<SaveWorkModel>>(jsonData);
            }
            else
            {
                return new List<SaveWorkModel>();
            }
        }

        private void SaveWorkListToFile()
        {
            // Save data to the JSON file
            string jsonData = JsonSerializer.Serialize(workList);
            File.WriteAllText(filePath, jsonData);
        }
    }
