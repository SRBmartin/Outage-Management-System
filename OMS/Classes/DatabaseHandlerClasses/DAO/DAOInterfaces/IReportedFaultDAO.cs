using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models.Base;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces
{
    interface IReportedFaultDAO : ICRUDDao<ReportedFault, string>
    {
        string Save(ReportedFault newEntity);
        IEnumerable<ReportedFault> FindByDateRange(DateTime startDate, DateTime endDate);
        short FindPriority(ReportedFault toFind);
        bool Update(ReportedFault toUpdate);
    }
}
