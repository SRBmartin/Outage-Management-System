using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces;
using OMS.Models.Base;
using System.Data;
using OMS.Services;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOImplementation
{
    class ElectronicComponentsDAOImpl : IElectronicComponentsDAO
    {
        public bool DeleteOne(ElectronicComponents toDelete)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ElectronicComponents> FindAll()
        {
            List<ElectronicComponents> retList = new List<ElectronicComponents>();
            string query = "SELECT ecid, ecname, etype, x, y, voltage_level FROM electronic_components";
            using (IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();
                    using(IDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            retList.Add(new ElectronicComponents(
                                rd.GetInt32(0),
                                rd.GetString(1),
                                ElectronicComponentsTypesService.FindById(rd.GetInt32(2)),
                                rd.GetInt32(3),
                                rd.GetInt32(4),
                                rd.GetString(5)));
                        }
                    }
                }
            }
            return retList;
        }

        public ElectronicComponents FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(ElectronicComponents newEntity)
        {
            throw new NotImplementedException();
        }

        public bool SaveAll(IEnumerable<ElectronicComponents> newEntities)
        {
            throw new NotImplementedException();
        }
    }
}
