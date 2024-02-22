using System;
using System.Reflection;

public class SaveWorkModel
{
    public string? saveName { get; set; }
    public string? targetRepo { get; set; }
    public string? sourceRepo { get; set; }
    public string? saveType { get; set; }
<<<<<<< HEAD
    public string? extenstionFileToCrypt { get; set; }
    public TimeSpan? encryptFileTime { get; set; }
    public int? logsFormat { get; set; }
=======
>>>>>>> 7f8ee939f33ec6cf7ce0e8ffe0da01f5e39c4b9e
    public TimeSpan FileTransferTime { get; set; } 
    public DateTime Time { get; set; } 
    public int totalFilesToCopy { get; set; } 
    public int nbFilesLeftToDo { get; set; } 
    public int Progress { get; set; } 
    public string state { get; set; }
    public long FileSize { get; set; }


<<<<<<< HEAD
    public SaveWorkModel(string name, string target, string source, string type, string fileToEncrypt, int logs)
=======
    public SaveWorkModel(string name, string target, string source, string type)
>>>>>>> 7f8ee939f33ec6cf7ce0e8ffe0da01f5e39c4b9e
    {
        saveName = name;
        targetRepo = target;
        sourceRepo = source;
        saveType = type;
<<<<<<< HEAD
        extenstionFileToCrypt = fileToEncrypt;
        logsFormat = logs;
=======
>>>>>>> 7f8ee939f33ec6cf7ce0e8ffe0da01f5e39c4b9e
    }
    public SaveWorkModel()
    {
        // Ne fait rien, mais nécessaire pour la désérialisation
    }
    // Méthode pour valider les données de sauvegarde
    public bool Validate()
    {
        // Implémentation de la logique de validation en utilisant les propriétés de l'objet instancié
<<<<<<< HEAD
        if (this.saveName != null && this.targetRepo != null && this.sourceRepo != null && this.saveType != null && this.extenstionFileToCrypt != null && this.logsFormat != null)
=======
        if (this.saveName != null && this.targetRepo != null && this.sourceRepo != null && this.saveType != null)
>>>>>>> 7f8ee939f33ec6cf7ce0e8ffe0da01f5e39c4b9e
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
