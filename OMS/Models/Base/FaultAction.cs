using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models.Base
{
    class FaultAction
    {
        public static readonly int MAX_DESCRIPTION = 256;
        private int id;
        private DateTime timeOfAction;
        private string description;
        public FaultAction(int id, DateTime timeOfAction, string description)
        {
            this.id = id;
            this.timeOfAction = timeOfAction;
            this.description = description;
        }
    }
}
