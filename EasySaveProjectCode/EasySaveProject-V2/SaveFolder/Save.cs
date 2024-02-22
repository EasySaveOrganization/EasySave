using EasySaveProject_V2.AddWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject_V2.SaveFolder
{
    public abstract class Save
    {
        public abstract void ExecuteSave(SaveWorkModel data);
    }
}
