using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models.Base
{
    public class FaultAction : BaseIntKey
    {
        public static readonly int MAX_DESCRIPTION = 256;
        private int id;
        private DateTime timeOfAction;
        private string description;
        private string fId;
        public FaultAction(int id, DateTime timeOfAction, string description)
        {
            if (id < 0 || timeOfAction == null || description == null || description.Length == 0 || description.Length > MAX_DESCRIPTION)
            {
                throw new ArgumentException();
            }
            this.id = id;
            this.timeOfAction = timeOfAction;
            this.description = description;
        }
        public FaultAction(int id, DateTime timeOfAction, string description, string fId)
        {
            if (id < 0 || timeOfAction == null || description == null || description.Length == 0 || description.Length > MAX_DESCRIPTION || fId == null || fId.Length == 0)
            {
                throw new ArgumentException();
            }
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
        public DateTime TimeOfAction
        {
            get
            {
                return timeOfAction;
            }
        }
        public string TimeOfActionS
        {
            get
            {
                return timeOfAction.ToString("yyyy-MM-dd HH:mm:ss");
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
