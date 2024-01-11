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
            string query = "DELETE FROM fault_actions WHERE faid = :pFaid";
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pFaid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pFaid", toDelete.Id);
                    return (command.ExecuteNonQuery() == 1) ? true : false;
                }
            }
        }

        public bool ExistsById(int id)
        {
            return (FindById(id) != null) ? true : false;
        }

        public IEnumerable<FaultAction> FindAll()
        {
            List<FaultAction> retList = new List<FaultAction>();
            string query = "SELECT faid, date_of_action, adesc, fid FROM fault_actions";
            using (IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using (IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();
                    using (IDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            retList.Add(new FaultAction(
                                rd.GetInt32(0),
                                DateTime.ParseExact(rd.GetString(1), "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None),
                                rd.GetString(2),
                                rd.GetString(3)));
                        }
                    }
                }
            }
            return retList;
        }
        public IEnumerable<FaultAction> FindAllByFaultId(string targetId)
        {
            List<FaultAction> retList = new List<FaultAction>();
            string query = "SELECT faid, date_of_action, adesc FROM fault_actions where fid = :pFid";
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pFid", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pFid", targetId);
                    using(IDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            retList.Add(new FaultAction(
                                rd.GetInt32(0),
                                DateTime.ParseExact(rd.GetString(1), "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None),
                                rd.GetString(2),
                                targetId));
                        }
                    }
                }
            }
            return retList;
        }

        public FaultAction FindById(int id)
        {
            FaultAction fa = null;
            string query = "SELECT date_of_action, adesc, fid FROM fault_actions WHERE faid = :pFaid";
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pFaid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pFaid", id);
                    using(IDataReader rd = command.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            fa = new FaultAction(
                                    id,
                                    DateTime.ParseExact(rd.GetString(0), "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None),
                                    rd.GetString(1),
                                    rd.GetString(2)
                                );
                        }
                    }
                }
            }
            return fa;
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
    }
}
