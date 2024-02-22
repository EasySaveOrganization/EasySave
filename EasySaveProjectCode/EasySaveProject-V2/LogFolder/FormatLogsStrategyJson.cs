using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading.Tasks;
using EasySaveProject_V2.ExecuteFolder;
using EasySaveProject_V2.AddWork;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EasySaveProject_V2.LogFolder
{
    public class FormatLogsStrategyJson : FormatLogs
    {
        private string logsFilePath;

        //constructor
        public FormatLogsStrategyJson(SaveWorkModel data)
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".json";
            logsFilePath = $"EasySaveContent\\{fileName}";
        }

        public override async Task write(SaveWorkModel data)
        {
            try
            {
                // Vérifie si le status est "END"
                if (data.state != "END" && data.Time != DateTime.MinValue)
                {
                    JArray logsArray;

                    if (File.Exists(logsFilePath))
                    {
                        // Charge le contenu actuel du fichier logs
                        string currentLogs = File.ReadAllText(logsFilePath);

                        // Vérifie si le fichier logs est vide
                        if (string.IsNullOrWhiteSpace(currentLogs))
                        {
                            // Initialise un nouveau tableau JSON
                            logsArray = new JArray();
                        }
                        else
                        {
                            // Essaye de parser le contenu JSON
                            try
                            {
                                logsArray = JArray.Parse(currentLogs);
                            }
                            catch (JsonReaderException)
                            {
                                // En cas d'erreur de parsing, crée un nouveau tableau JSON
                                logsArray = new JArray();
                            }
                        }
                    }
                    else
                    {
                        // Si le fichier logs n'existe pas, créez-le et initialisez un nouveau tableau JSON
                        logsArray = new JArray();
                        File.WriteAllText(logsFilePath, logsArray.ToString());
                    }

                    // Ajoute un nouvel objet JSON à la liste des logs
                    JObject newLog = new JObject(
                        new JProperty("Name", data.saveName),
                        new JProperty("FileSource", data.sourceRepo),
                        new JProperty("FileTarget", data.targetRepo),
                        new JProperty("FileSize", data.FileSize),
                        new JProperty("FileTransferTime", data.FileTransferTime),
                        new JProperty("time", data.Time)
                    );

                    logsArray.Add(newLog);

                    // Écrit le tableau logs dans le fichier logs
                    File.WriteAllText(logsFilePath, logsArray.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur est survenue lors de l'écriture dans le fichier logs : " + ex.Message);
            }
        }
    }
}
