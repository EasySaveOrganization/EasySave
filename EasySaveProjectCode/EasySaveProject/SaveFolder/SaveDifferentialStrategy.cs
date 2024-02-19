using EasySaveProject.Observer;
using EasySaveProject.ObserverFolder;
using EasySaveProject.SaveFolder;
using System;
using System.IO;

namespace EasySaveProject
{
    class SaveDifferentialStrategy : Save
    {
        observer events = observer.Instance;

        public override void ExecuteSave(SaveWorkModel data)
        {
            string sourcePath = data.sourceRepo;
            string targetPath = data.targetRepo;

            if (File.Exists(sourcePath))
            {
                // The source path points to a file
                string targetFilePath = Path.Combine(targetPath, Path.GetFileName(sourcePath));
                if (File.Exists(targetFilePath))
                {
                    DateTime sourceLastModified = File.GetLastWriteTime(sourcePath);
                    DateTime targetLastModified = File.GetLastWriteTime(targetFilePath);
                    if (sourceLastModified > targetLastModified)
                    {
                        File.Copy(sourcePath, targetFilePath, true);
                        events.NotifyObserver(data);
                        Console.WriteLine("Opération sur le fichier terminée.");
                    }
                    else
                    {
                        Console.WriteLine("Le fichier source n'a pas été modifié depuis la dernière sauvegarde.");
                    }
                }
                else
                {
                    File.Copy(sourcePath, targetFilePath);
                    events.NotifyObserver(data);
                    Console.WriteLine("Opération sur le fichier terminée.");
                }
            }
            else if (Directory.Exists(sourcePath))
            {
                // The source path points to a directory
                DirectoryCopy(sourcePath, targetPath, true);
                events.NotifyObserver(data);
                Console.WriteLine("Opération sur le dossier terminée.");
            }
            else
            {
                Console.WriteLine("Le chemin spécifié n'existe pas.");
            }
        }

        // Method to copy a directory recursively
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
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
                string destFilePath = Path.Combine(destDirName, file.Name);
                if (File.Exists(destFilePath))
                {
                    DateTime sourceLastModified = file.LastWriteTime;
                    DateTime destLastModified = File.GetLastWriteTime(destFilePath);
                    if (sourceLastModified > destLastModified)
                    {
                        file.CopyTo(destFilePath, true);
                    }
                }
                else
                {
                    file.CopyTo(destFilePath);
                }
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
