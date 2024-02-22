using EasySaveProject_V2.AddWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject_V2.SaveFolder;

namespace EasySaveProject_V2.ExecuteFolder
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
