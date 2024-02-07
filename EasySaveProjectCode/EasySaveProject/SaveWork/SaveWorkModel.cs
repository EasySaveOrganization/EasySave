using System;

public class SaveWorkModel
{
    public string saveName { get; set; }
    public string targetRepo { get; set; }
    public string sourceRepo { get; set; }
    public string saveType { get; set; }

    public SaveWorkModel(string name, string target, string source, string type)
    {
        saveName = name;
        targetRepo = target;
        sourceRepo = source;
        saveType = type;
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
            return false;
        }
    }
}