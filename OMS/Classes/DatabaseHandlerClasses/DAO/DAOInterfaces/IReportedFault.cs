using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models.Base;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces
{
    interface IReportedFault : ICRUDDao<ReportedFault, string>
    {
        string Save(ReportedFault newEntity);
    }
}
