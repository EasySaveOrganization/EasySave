using System;
using System.Text.Json;
using EasySaveProject.SaveWork;

namespace EasySaveProject.Observer
{
  public class FormatStrategyJson
    {
        private readonly WorkListService _workListService;

        //constructor
        public FormatStrategyJson(WorkListService workList) 
        {
            _workListService = workList;
        }

        public async Task Write(SaveWorkModel executedWork)
        {
            //retriever the work list 
            var workList = _workListService.LoadWorkListFromFile();

           //Add time
          /* foreach (var work in workList)
            {
                work.Time = DateTime.Now;
            }*/
          workList.Add(executedWork);

            //create a file + give it a json extension
            string FileName = DateTime.Now.ToString("yyyy-MM-dd") + ".json";
            string userName = Environment.UserName;
            string filePath = $"C:\\Users\\{userName}\\Desktop\\logs.json";

            //list to have the have the existant informations + the new ones 
            List<SaveWorkModel> allWorks = new List<SaveWorkModel>();

            //check if the fie already exists 
            if (File.Exists(filePath))
            {
                //if the file exists deserialize it and read it
                string existingJson = await File.ReadAllTextAsync(filePath);
                allWorks = JsonSerializer.Deserialize<List<SaveWorkModel>>(existingJson) ?? new List<SaveWorkModel>();
            }

            //Add the new information to the list
            allWorks.Add(executedWork);

            //JsonSerializer method to convert the informations into JSON
            // new JsonSerializerOptions { WriteIndented = true } to make the JSON format more readable 
            string jsonFile = JsonSerializer.Serialize(allWorks, new JsonSerializerOptions { WriteIndented = true });

            //Writing the json in the file 
            File.WriteAllText(filePath, jsonFile);
        }
    }
}
