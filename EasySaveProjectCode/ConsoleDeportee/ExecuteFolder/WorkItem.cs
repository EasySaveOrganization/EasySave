using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDeportee.ExecuteFolder
{
    public class WorkItem
    {
        public string? saveName { get; set; }
        public string? targetRepo { get; set; }
        public string? sourceRepo { get; set; }
        public string? saveType { get; set; }
        public string? extenstionFileToCrypt { get; set; }
        public TimeSpan? encryptFileTime { get; set; }
        public int? logsFormat { get; set; }
        public TimeSpan FileTransferTime { get; set; }
        public DateTime Time { get; set; }
        public int totalFilesToCopy { get; set; }
        public long totalFilesSize { get; set; }
        public int nbFilesLeftToDo { get; set; }
        public int Progress { get; set; }
        public string state { get; set; }
        public long FileSize { get; set; }

        public WorkItem(string name, string target, string source, string type, string fileToEncrypt, int logs)
        {
            saveName = name;
            targetRepo = target;
            sourceRepo = source;
            saveType = type;
            extenstionFileToCrypt = fileToEncrypt;
            logsFormat = logs;
        }
        public WorkItem() { }
        public bool Validate()
        {
            // Implémentation de la logique de validation en utilisant les propriétés de l'objet instancié
            if (this.saveName != null && this.targetRepo != null && this.sourceRepo != null && this.saveType != null && this.extenstionFileToCrypt != null && this.logsFormat != null)
            {
                return true;
            }
            else
            {
                Console.WriteLine("One or more input values are null. Unable to add work.");
                return false;
            }
        }
    }

}
