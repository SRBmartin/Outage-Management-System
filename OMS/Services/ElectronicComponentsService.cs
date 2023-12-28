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
        public static bool DeleteOne(ElectronicComponents toDelete)
        {
            return ecDAO.DeleteOne(toDelete);
        }
        public static ElectronicComponents FindById(int id)
        {
            return ecDAO.FindById(id);
        }
        public static ElectronicComponents FindById(int id, IDbConnection conn)
        {
            return ecDAO.FindById(id, conn);
        }
        public static bool ExistsById(int id)
        {
            return ecDAO.ExistsById(id);
        }
    }
}
