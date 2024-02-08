using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySaveProject
{
    public class SaveFactory
    {
        public Save factory(string saveType)
        {
            switch (saveType)
            {
                case "Complete":
                    return new SaveCompleteStrategy();
                // Ajoutez d'autres cas pour d'autres types de stratégie si nécessaire
                default:
                    throw new ArgumentException("Invalid strategy type");
            }
        }
    }

}
