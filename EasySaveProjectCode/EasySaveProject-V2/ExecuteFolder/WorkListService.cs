﻿using EasySaveProject_V2.AddWork;
using System.IO;
using System.Text.Json;

namespace EasySaveProject_V2.ExecuteFolder
{
    public class WorkListService
    {
        public List<SaveWorkModel>? workList;
        public string filePath;

        public WorkListService()
        {
            workList = LoadWorkListFromFile() ?? new List<SaveWorkModel>();
            if (!Directory.Exists("Easysavecontent"))
            {
                Directory.CreateDirectory("Easysavecontent");
            }
            this.filePath = "EasySaveContent\\worklist.json";
        }

        // Méthode pour ajouter un travail
        public void AddWork(SaveWorkModel work)
        {

            workList?.Add(work);
            SaveWorkListToFile();

        }


        // Méthode pour retirer un travail
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

                // Vérifie si le JSON est vide
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    return JsonSerializer.Deserialize<List<SaveWorkModel>>(jsonData);
                }
            }

            // Si le fichier est vide ou n'existe pas, retourne une nouvelle liste vide
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
