using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models.Base;
using System.Data;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces
{
    public interface IReportedFaultDAO : ICRUDDao<ReportedFault, string>
    {
        string Save(ReportedFault newEntity);
        IEnumerable<ReportedFault> FindByDateRange(DateTime startDate, DateTime endDate);
        IEnumerable<ReportedFault> FindByDateRange(DateTime startDate, DateTime endDate, IDbConnection conn);
        short FindPriority(ReportedFault toFind);
        bool Update(ReportedFault toUpdate);
    }
}
