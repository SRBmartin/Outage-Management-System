using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses.DAO.DAOImplementation;
using OMS.Models.Base;

namespace OMS.Services
{
    class FaultActionService
    {
        private static FaultActionDAOImpl faDAO = new FaultActionDAOImpl();
        public static bool Save(FaultAction newEntity)
        {
            return faDAO.Save(newEntity);
        }
    }
}
