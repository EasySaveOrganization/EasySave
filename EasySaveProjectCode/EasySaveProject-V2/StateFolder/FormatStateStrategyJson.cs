using System.IO;
using EasySaveProject_V2.ExecuteFolder;
using EasySaveProject_V2.AddWork;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace EasySaveProject_V2.StateFolder
{
    public class FormatStateStrategyJson
    {

        private string stateFilePath;

        //constructor
        public FormatStateStrategyJson(WorkListService workList)
        {
            this.stateFilePath = $"EasySaveContent\\State.json";
        }


        public async Task Write(SaveWorkModel data)
        {
            try
            {
                JObject stateObject;

                if (File.Exists(stateFilePath))
                {
                    // Charge le contenu actuel du fichier state
                    string currentState = File.ReadAllText(stateFilePath);

                    // Vérifie si le fichier state est vide
                    if (string.IsNullOrWhiteSpace(currentState))
                    {
                        // Initialise un nouvel objet JObject
                        stateObject = new JObject();
                    }
                    else
                    {
                        // Essaye de parser le contenu JSON
                        try
                        {
                            stateObject = JObject.Parse(currentState);
                        }
                        catch (JsonReaderException)
                        {
                            // En cas d'erreur de parsing, crée un nouvel objet JObject
                            stateObject = new JObject();
                        }
                    }
                }
                else
                {
                    // Si le fichier state n'existe pas, crée un nouvel objet JObject
                    stateObject = new JObject();
                }

                // Recherche le travail de sauvegarde correspondant
                JToken existingToken;
                if (stateObject.TryGetValue(data.saveName, out existingToken))
                {
                    // Si le travail de sauvegarde existe, met à jour ses propriétés
                    existingToken["SourceFilePath"] = data.sourceRepo;
                    existingToken["TargetFilePath"] = data.targetRepo;
                    existingToken["State"] = data.state;
                    existingToken["TotalFilesToCopy"] = data.totalFilesToCopy;
                    existingToken["TotalFilesSize"] = data.FileSize;
                    existingToken["NbFilesLeftToDo"] = data.nbFilesLeftToDo;
                    existingToken["Progression"] = data.Progress;

                    // Si l'état du travail est "END", vide toutes les informations sauf le nom du travail
                    if (data.state == "END")
                    {
                        existingToken["SourceFilePath"] = "";
                        existingToken["TargetFilePath"] = "";
                        existingToken["TotalFilesToCopy"] = 0;
                        existingToken["TotalFilesSize"] = 0;
                        existingToken["NbFilesLeftToDo"] = 0;
                        existingToken["Progression"] = 0;
                    }
                }
                else
                {
                    // Si le travail de sauvegarde n'existe pas, l'ajoute à l'objet state
                    stateObject[data.saveName] = new JObject(
                        new JProperty("SourceFilePath", data.sourceRepo),
                        new JProperty("TargetFilePath", data.targetRepo),
                        new JProperty("State", data.state),
                        new JProperty("TotalFilesToCopy", data.totalFilesToCopy),
                        new JProperty("TotalFilesSize", data.FileSize),
                        new JProperty("NbFilesLeftToDo", data.nbFilesLeftToDo),
                        new JProperty("Progression", data.Progress)
                    );
                }

                // Écrit l'objet state dans le fichier state
                File.WriteAllText(stateFilePath, stateObject.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur est survenue lors de l'écriture dans le fichier state : " + ex.Message);
            }
        }

    }
}
