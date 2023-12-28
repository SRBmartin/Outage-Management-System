using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models.Base
{
    class ReportedFault
    {
        public static readonly int MAX_SHORT_DESCRIPTION = 256;
        public static readonly int MAX_DESCRIPTION = 1024;
        public static readonly string NEW_FAULT_ID = "-1";
        private string id;
        private DateTime creationDate;
        private string status;
        private string short_description;
        ElectronicComponents faultyComponent;
        private string description;
        List<FaultAction> faultActions;
        public ReportedFault(string id, DateTime creationDate, string status, string short_description, ElectronicComponents faultyComponent, string description)
        {
            this.id = id;
            this.creationDate = creationDate;
            this.status = status;
            this.short_description = short_description;
            this.faultyComponent = faultyComponent;
            this.description = description;
        }
        public ReportedFault(string short_description, ElectronicComponents faultyComponent, string description)
        {
            this.short_description = short_description;
            this.faultyComponent = faultyComponent;
            this.description = description;
        }
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Short_description
        {
            get
            {
                return short_description;
            }
        }
        public ElectronicComponents FaultyComponent
        {
            get
            {
                return faultyComponent;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
        }
        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
        }
    }
}
