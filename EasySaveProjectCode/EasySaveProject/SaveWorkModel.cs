using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject
{
    public class SaveWorkModel
    {
        public string SaveName { get; set; } // The name or identifier of the save operation
        public string SourceRepo { get; set; } // The source directory or file path
        public string TargetRepo { get; set; } // The target directory or file path where files will be saved
        public long FileSize { get; set; } // The total size of the files to be saved
        public TimeSpan FileTransferTime { get; set; } // The time taken to transfer the files
        public DateTime Time { get; set; } // The timestamp when the save operation was executed
        public int totalFilesToCopy { get; set; } //total files 
        public int bFilesLeftToDo { get; set; } // files left to copy
        public int progression { get; set; } // progression of the save work 
        public string state { get; set; } // le status 

    }
}
