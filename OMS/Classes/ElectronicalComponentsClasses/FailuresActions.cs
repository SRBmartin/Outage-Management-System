using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes.ElectronicalComponentsClasses
{
    class FailuresActions
    {
        DateTime timeOfAction;
        string shortDescription;
        FailuresActions(DateTime timeOfAction, string shortDescription)
        {
            this.timeOfAction = timeOfAction;
            this.shortDescription = shortDescription;
        }
    }
}
