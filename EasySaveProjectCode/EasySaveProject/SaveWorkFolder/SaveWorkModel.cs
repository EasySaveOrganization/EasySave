using System;
using System.Reflection;

public class SaveWorkModel
{
    public string? saveName { get; set; }
    public string? targetRepo { get; set; }
    public string? sourceRepo { get; set; }
    public string? saveType { get; set; }
    public TimeSpan FileTransferTime { get; set; } 
    public DateTime Time { get; set; } 
    public int totalFilesToCopy { get; set; }
    public long totalFilesSize { get; set; }
    public int nbFilesLeftToDo { get; set; } 
    public int Progress { get; set; } 
    public string state { get; set; }
    public long FileSize { get; set; } 


    public SaveWorkModel(string name, string target, string source, string type)
    {
        saveName = name;
        targetRepo = target;
        sourceRepo = source;
        saveType = type;
    }
    public SaveWorkModel()
    {
        // Ne fait rien, mais nécessaire pour la désérialisation
    }
    // Méthode pour valider les données de sauvegarde
    public bool Validate()
    {
        // Implémentation de la logique de validation en utilisant les propriétés de l'objet instancié
        if (this.saveName != null && this.targetRepo != null && this.sourceRepo != null && this.saveType != null)
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
