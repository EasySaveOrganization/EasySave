using EasySaveProject.ObserverFolder;
using EasySaveProject.SaveFolder;
using EasySaveProject.AddFolder;
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

            // Utilisez la méthode statique CreateSave pour obtenir une instance de Save
            string? saveType = work?.saveType;
            Save save = saveFactory.CreateSave(saveType);
            save.ExecuteSave(work);

        }


    }
}
