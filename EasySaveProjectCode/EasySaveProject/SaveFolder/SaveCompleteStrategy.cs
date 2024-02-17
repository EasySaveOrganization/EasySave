using EasySaveProject.Observer;
using EasySaveProject.ObserverFolder;
using System;
using System.IO;

namespace EasySaveProject.SaveFolder
{
    class SaveCompleteStrategy : Save
    {
        observer events = observer.Instance;
        public override void ExecuteSave(SaveWorkModel data)
        {
            string sourcePath = data.sourceRepo;
            string targetPath = data.targetRepo;

            if (File.Exists(sourcePath))
            {
                // Le chemin source pointe vers un fichier
                File.Copy(sourcePath, Path.Combine(targetPath, Path.GetFileName(sourcePath)));
                events.NotifyObserver(data);
                Console.WriteLine("Fichier copié avec succès.");
            }
            else if (Directory.Exists(sourcePath))
            {
                // Le chemin source pointe vers un répertoire
                DirectoryCopy(sourcePath, Path.Combine(targetPath, Path.GetFileName(sourcePath)), true);
                events.NotifyObserver(data);
                Console.WriteLine("Répertoire copié avec succès.");
            }
            else
            {
                Console.WriteLine("Le chemin spécifié n'existe pas.");
            }
        }

        // Méthode pour copier un répertoire récursivement
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
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
                file.CopyTo(tempPath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }
    }
}