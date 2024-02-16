using System;
using System.IO;
using System.Xml.Linq;
using EasySaveProject.SaveWork;

namespace EasySaveProject.LogFolder
{
    public class FormatLogsStrategyXml
    {
        private string logsFilePath;

        // Constructeur
        public FormatLogsStrategyXml(WorkListService workList)
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".xml";
            string userName = Environment.UserName;
            logsFilePath = $"C:\\Users\\{userName}\\Desktop\\EasySaveContent\\{fileName}";
        }

        public async Task Write(SaveWorkModel data)
        {
            try
            {
                // Vérifie si le statut est "END"
                if (data.state != "END" && data.Time != DateTime.MinValue)
                {
                    XElement logsRoot;

                    if (File.Exists(logsFilePath))
                    {
                        // Charge le contenu actuel du fichier logs XML
                        logsRoot = XElement.Load(logsFilePath);
                    }
                    else
                    {
                        // Si le fichier logs n'existe pas, créez-le avec un élément racine
                        logsRoot = new XElement("Logs");
                    }

                    // Crée un nouvel élément pour le nouveau log
                    XElement newLog = new XElement("Log",
                        new XElement("Name", data.saveName),
                        new XElement("FileSource", data.sourceRepo),
                        new XElement("FileTarget", data.targetRepo),
                        new XElement("FileSize", data.FileSize),
                        new XElement("FileTransferTime", data.FileTransferTime),
                        new XElement("Time", data.Time)
                    );

                    // Ajoute le nouvel élément à la racine
                    logsRoot.Add(newLog);

                    // Écrit le contenu dans le fichier logs XML
                    logsRoot.Save(logsFilePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur est survenue lors de l'écriture dans le fichier logs : " + ex.Message);
            }
        }
    }
}
