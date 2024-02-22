using EasySaveProject.Observer;
using EasySaveProject.ObserverFolder;
using System;
using System.Diagnostics;
using System.IO;

namespace EasySaveProject.SaveFolder
{
    class SaveCompleteStrategy : Save
    {
        observer events = observer.Instance;
        public override void ExecuteSave(SaveWorkModel data)
        {
            string? sourcePath = data.sourceRepo;
            string? targetPath = data.targetRepo;
            string? extenstionFileToCrypt = data.extenstionFileToCrypt;

            // Définir les informations de progression initiales
            data.totalFilesToCopy = GetTotalFileCount(sourcePath); // Obtenir le nombre total de fichiers à copier
            data.totalFilesSize = GetFileSize(sourcePath); // Obtenir la taille du fichier/dossier source
            data.nbFilesLeftToDo = data.totalFilesToCopy; // Définir le nombre initial de fichiers restants à copier
            data.Progress = 0; // Définir le pourcentage d'avancement à 0%
            data.state = "ACTIVE"; // Définir le statut sur "Actif"

            try
            {

                if (File.Exists(sourcePath))
                {
                    DateTime startTime = DateTime.Now;
                    string[] arguments = new string[] { sourcePath, Path.Combine(targetPath, Path.GetFileName(sourcePath)) };
                    if (ShouldEncryptFile(sourcePath, extenstionFileToCrypt))
                    {
                        using (File.Create(targetPath)) { }
                        DateTime startEncryptTime = DateTime.Now;
                        ExecuteCryptoSoft("..\\..\\..\\..\\Cryptosoft\\bin\\Release\\net8.0\\win-x64\\Cryptosoft.exe", arguments);
                        data.encryptFileTime = DateTime.Now - startEncryptTime;
                    }
                    else
                    {
                        File.Copy(sourcePath, Path.Combine(targetPath, Path.GetFileName(sourcePath)));
                    }
                    // Le chemin source pointe vers un fichier
                    data.FileTransferTime = DateTime.Now - startTime; // Calculer le temps de transfert
                    data.Time = DateTime.Now; // Enregistrer l'heure à laquelle la sauvegarde s'est terminée
                    data.nbFilesLeftToDo = 0; // Aucun fichier restant à copier
                    data.Progress = 100; // Avancement à 100% car un seul fichier est copié
                    data.state = "END"; // Marquer la sauvegarde comme terminée
                    events.NotifyObserver(data);

                    Console.WriteLine("Fichier copié avec succès.");
                }
                else if (Directory.Exists(sourcePath))
                {
                    events.NotifyObserver(data);
                    // Le chemin source pointe vers un répertoire
                    DirectoryCopy(sourcePath, Path.Combine(targetPath, Path.GetFileName(sourcePath)), true, data, this);
                    data.state = "END"; // Marquer la sauvegarde comme terminée
                    events.NotifyObserver(data);

                    Console.WriteLine("Répertoire copié avec succès.");
                }
                else
                {
                    Console.WriteLine("Le chemin spécifié n'existe pas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la sauvegarde : " + ex.Message);
            }
        }

        // Méthode pour obtenir la taille du fichier/dossier source
        private long GetFileSize(string sourcePath)
        {
            if (File.Exists(sourcePath))
            {
                return new FileInfo(sourcePath).Length;
            }
            else if (Directory.Exists(sourcePath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(sourcePath);
                return CalculateDirectorySize(dirInfo);
            }
            else
            {
                throw new ArgumentException("Le chemin spécifié n'existe pas ou n'est pas valide.");
            }
        }

        // Méthode récursive pour calculer la taille d'un répertoire
        private long CalculateDirectorySize(DirectoryInfo directory)
        {
            long size = 0;

            // Ajouter la taille de chaque fichier dans le répertoire
            foreach (FileInfo file in directory.GetFiles())
            {
                size += file.Length;
            }

            // Appeler récursivement la méthode pour chaque sous-répertoire
            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                size += CalculateDirectorySize(subDirectory);
            }

            return size;
        }

        // Méthode pour copier un répertoire récursivement
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, SaveWorkModel data, SaveCompleteStrategy saveStrategy)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Le répertoire source n'existe pas ou ne peut pas être trouvé : " + sourceDirName);
            }

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();


            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                DateTime startTime = DateTime.Now; // Marquer le début du processus de copie du fichier
                string[] arguments = new string[] { file.FullName, tempPath };
                if (saveStrategy.ShouldEncryptFile(file.FullName, data.extenstionFileToCrypt))
                {
                    DateTime startEncryptTime = DateTime.Now;
                    saveStrategy.ExecuteCryptoSoft("..\\..\\..\\..\\Cryptosoft\\bin\\Release\\net8.0\\win-x64\\Cryptosoft.exe", arguments);
                    data.encryptFileTime = DateTime.Now - startEncryptTime;
                }
                else
                {
                    file.CopyTo(tempPath, false);
                }
                
                TimeSpan transferTime = DateTime.Now - startTime; // Calculer le temps de transfert du fichier

                // Mettre à jour les informations de progression
                data.nbFilesLeftToDo--; // Décrémenter le nombre de fichiers restants à copier
                data.Progress = (int)(((double)(data.totalFilesToCopy - data.nbFilesLeftToDo) / data.totalFilesToCopy) * 100);

                // Informer l'observateur du fichier copié avec ses détails
                data.saveName = data.saveName;
                data.sourceRepo = file.FullName;
                data.targetRepo = Path.Combine(destDirName, file.Name);
                data.FileSize = file.Length;
                data.FileTransferTime = transferTime;
                data.Time = DateTime.Now;

                saveStrategy.events.NotifyObserver(data);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs, data, saveStrategy);
                }
            }
        }


        // Méthode pour obtenir le nombre total de fichiers à copier
        private int GetTotalFileCount(string sourceDir)
        {
            if (File.Exists(sourceDir))
            {
                return 1;
            }
            else if (Directory.Exists(sourceDir))
            {
                return Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories).Length;
            }
            else
            {
                throw new ArgumentException("Le chemin spécifié n'existe pas ou n'est pas valide.");
            }
        }
        private bool ShouldEncryptFile(string filePath, string? fileExtensionCrypt)
        {
            if (!string.IsNullOrEmpty(fileExtensionCrypt))
            {
                return Path.GetExtension(filePath) == fileExtensionCrypt;
            }
            return false;
        }

        private void ExecuteCryptoSoft(string cryptosoftPath, string[] args)
        {
            string sourceFilePath = args[0];
            string destinationFilePath = args[1];

            // Vérifier si le fichier de destination existe, sinon le créer
            if (!File.Exists(destinationFilePath))
            {
                // Créer un fichier vide
                using (File.Create(destinationFilePath)) { }
            }

            // Exécuter cryptosoft.exe
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = cryptosoftPath;
            startInfo.Arguments = $"\"{sourceFilePath}\" \"{destinationFilePath}\"";
            Process.Start(startInfo)?.WaitForExit();
        }
    }
}