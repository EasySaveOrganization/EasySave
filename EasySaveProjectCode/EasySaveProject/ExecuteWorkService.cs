using EasySaveProject.SaveCompleteDiff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EasySaveProject
{
    public class ExecuteWorkService
    {
        public SaveWorkModel work;

        public void executeWork(SaveWorkModel work)
        {
            SaveFactory saveFactory = new SaveFactory();

            // Utilisez la méthode statique CreateSave pour obtenir une instance de Save
            Save save = saveFactory.CreateSave(work.saveType);
        }


    }
}