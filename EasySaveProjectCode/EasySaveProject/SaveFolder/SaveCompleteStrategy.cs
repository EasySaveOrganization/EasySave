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
                // The source path points to a file
                File.Copy(sourcePath, Path.Combine(targetPath, Path.GetFileName(sourcePath)));
                events.NotifyObserver(data);
                Console.WriteLine("File copied successfully.");
            }
            else if (Directory.Exists(sourcePath))
            {
                // The source path points to a directory
                DirectoryCopy(sourcePath, Path.Combine(targetPath, Path.GetFileName(sourcePath)), true);
                events.NotifyObserver(data);
                Console.WriteLine("Directory copied successfully.");
            }
            else
            {
                Console.WriteLine("The specified path does not exist.");
            }
        }

        // Method to copy a directory recursively
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("The source directory does not exist or could not be found: " + sourceDirName);
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
