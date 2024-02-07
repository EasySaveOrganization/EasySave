using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject
{
    public class WorkListService
    {
        private List<SaveWorkModel> _workList = new List<SaveWorkModel>();

        public void AddWork(SaveWorkModel work)
        {
            _workList.Add(work);
        }

        public void RemoveWork(SaveWorkModel work)
        {
            _workList.Remove(work);
        }

        public List<SaveWorkModel> GetWorkList()
        {
            return _workList;
        }
    }
}
