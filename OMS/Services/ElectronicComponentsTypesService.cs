using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses.DAO.DAOImplementation;
using OMS.Models.Base;
using System.Data;

namespace OMS.Services
{
    class ElectronicComponentsTypesService
    {
        private static ElectronicComponentsTypesDAOImpl ectDAO = new ElectronicComponentsTypesDAOImpl();

        public static List<ElectronicComponentsTypes> FindAll()
        {
            return ectDAO.FindAll().ToList();
        }
        public static bool Save(ElectronicComponentsTypes newEntity)
        {
            return ectDAO.Save(newEntity);
        }
        public static bool ExistsById(int id)
        {
            return ectDAO.ExistsById(id);
        }
        public static ElectronicComponentsTypes FindById(int id)
        {
            return ectDAO.FindById(id);
        }
        public static ElectronicComponentsTypes FindById(int id, IDbConnection conn)
        {
            return ectDAO.FindById(id, conn);
        }
        public static bool DeleteOne(ElectronicComponentsTypes toDelete)
        {
            return ectDAO.DeleteOne(toDelete);
        }
    }
}
