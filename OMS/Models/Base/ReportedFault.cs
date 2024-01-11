using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Services;

namespace OMS.Models.Base
{
    public class ReportedFault : BaseStringKey
    {
        public static readonly int MAX_SHORT_DESCRIPTION = 256;
        public static readonly int MAX_DESCRIPTION = 1024;
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
            status = "Unconfirmed";
        }
        public List<FaultAction>FaultActions
        {
            get
            {
                return faultActions;
            }
            set
            {
                faultActions = value;
            }
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
            set
            {
                short_description = value;
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
            set
            {
                description = value;
            }
        }
        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
        public new static string GetFormattedHeader()
        {
            return String.Format("{0, -16} | {1, -10} | {2, -16} | {3, -4} | {4, -4}",
                                "ID", "DATE", "SHORT DESCRIPTION", "STATUS", "PRIORITY");
        }
        public override string ToString()
        {
            return String.Format("{0, -16} | {1, -8} | {2, -16} | {3, -4} | {4, -4}",
                                    id,
                                    creationDate.ToString("yyyy-MM-dd"),
                                    short_description,
                                    status,
                                    (status == "In service") ? ReportedFaultService.FindPriority(this) : -1);
        }
    }
}
