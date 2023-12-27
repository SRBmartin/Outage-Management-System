using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models.Base;
using OMS.Classes.DatabaseHandlerClasses.DAO.DAOImplementation;

namespace OMS.Services
{
    class ReportedFaultService
    {
        private static ReportedFaultDAOImpl rfDAO = new ReportedFaultDAOImpl();
        public static string Save(ReportedFault newEntity)
        {
            return rfDAO.Save(newEntity);
        }
    }
}
