using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes.ElectronicalComponentsClasses
{
    class FailuresActionsList
    {
        List<FailuresActions> fActionList;
        FailuresActionsList()
        {
            fActionList = new List<FailuresActions>();
        }
        public void addNewAction(FailuresActions fAction)
        {
            fActionList.Add(fAction);
        }
        public List<FailuresActions> returnAllActions()
        {
            return fActionList;
        }
    }
}
