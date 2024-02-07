using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EasySaveProject
{
    public class WorkListService
    {
        public List<SaveWorkModel>? workList;
        public string filePath = "PathToYourProject/worklist.json";

        public WorkListService()
        {
            // Initialize workList, possibly load data from the file
            workList = LoadWorkListFromFile() ?? new List<SaveWorkModel>();
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
            // Save data to the JSON file
            string jsonData = JsonSerializer.Serialize(workList);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
