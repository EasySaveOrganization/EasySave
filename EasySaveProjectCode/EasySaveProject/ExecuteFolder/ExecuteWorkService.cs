using EasySaveProject.ObserverFolder;
using EasySaveProject.SaveFolder;
using EasySaveProject.SaveWorkFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EasySaveProject.ExecuteFolder
{
    public class ExecuteWorkService
    {
    
        public void executeWork(SaveWorkModel work)
        {
           
            SaveFactory saveFactory = new SaveFactory();

            // Use the static CreateSave method to get an instance of Save.
            string? saveType = work?.saveType;
            Save save = saveFactory.CreateSave(saveType);

            
            save.ExecuteSave(work);
        }
    }
}
