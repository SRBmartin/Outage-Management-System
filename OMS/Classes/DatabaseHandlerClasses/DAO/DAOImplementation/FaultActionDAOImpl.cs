using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces;
using System.Data;
using OMS.Models.Base;
using OMS.Utils;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOImplementation
{
    class FaultActionDAOImpl : IFaultActionDAO
    {
        public bool DeleteOne(FaultAction toDelete)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FaultAction> FindAll()
        {
            throw new NotImplementedException();
        }

        public FaultAction FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(FaultAction newEntity)
        {
            string query = @"INSERT INTO fault_actions (date_of_action, adesc, fid)
                            VALUES (:pDate_of_action, :pAdesc, :pFid)";
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pDate_of_action", DbType.String);
                    ParameterUtil.AddParameter(command, "pAdesc", DbType.String);
                    ParameterUtil.AddParameter(command, "pFid", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pDate_of_action", newEntity.TimeOfActionS);
                    ParameterUtil.SetParameterValue(command, "pAdesc", newEntity.Description);
                    ParameterUtil.SetParameterValue(command, "pFid", newEntity.FId);
                    return (command.ExecuteNonQuery() == 1) ? true : false;
                }
            }
        }

        public bool SaveAll(IEnumerable<FaultAction> newEntities)
        {
            throw new NotImplementedException();
        }
    }
}
