using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models.Base
{
    public class FaultAction
    {
        public static readonly int MAX_DESCRIPTION = 256;
        public static readonly int NEW_FAULT_ACTION_ID = -1;
        private int id;
        private DateTime timeOfAction;
        private string description;
        private string fId;
        public FaultAction(int id, DateTime timeOfAction, string description)
        {
            this.id = id;
            this.timeOfAction = timeOfAction;
            this.description = description;
        }
        public FaultAction(int id, DateTime timeOfAction, string description, string fId)
        {
            this.id = id;
            this.timeOfAction = timeOfAction;
            this.description = description;
            this.fId = fId;
        }
        public int Id
        {
            get
            {
                return id;
            }
        }
        public string TimeOfActionS
        {
            get
            {
                return timeOfAction.ToString();
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
        }
        public string FId
        {
            get
            {
                return fId;
            }
        }
    }
}
