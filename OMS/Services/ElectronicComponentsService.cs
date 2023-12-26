using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses.DAO.DAOImplementation;
using OMS.Models.Base;

namespace OMS.Services
{
    class ElectronicComponentsService
    {
        private static ElectronicComponentsDAOImpl ecDAO = new ElectronicComponentsDAOImpl();
        public static bool Save(ElectronicComponents newEntity)
        {
            return ecDAO.Save(newEntity);
        }
        public static List<ElectronicComponents> FindAll()
        {
            return ecDAO.FindAll().ToList();
        }
    }
}
