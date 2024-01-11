using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces;
using OMS.Models.Base;
using System.Data;
using OMS.Utils;
using OMS.Services;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOImplementation
{
    class ReportedFaultDAOImpl : IReportedFaultDAO
    {
        public bool DeleteOne(ReportedFault toDelete)
        {
            string query = "DELETE FROM reported_faults WHERE fid = :pFid";
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pFid", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pFid", toDelete.Id);
                    return (command.ExecuteNonQuery() == 1) ? true : false;
                }
            }
        }

        public bool ExistsById(string id)
        {
            return (FindById(id) == null) ? false : true;
        }

        public IEnumerable<ReportedFault> FindAll()
        {
            string query = @"SELECT fid, date_of_fault, fstatus, fshort_desc, ecid, fdesc 
                            FROM reported_faults";
            List<ReportedFault> retList = new List<ReportedFault>();
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
                            retList.Add(new ReportedFault(
                                rd.GetString(0),
                                DateTime.ParseExact(rd.GetString(1), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                                rd.GetString(2),
                                rd.GetString(3),
                                ElectronicComponentsService.FindById(rd.GetInt32(4), conn),
                                rd.GetString(5)
                                ));
                        }
                    }
                }
            }
            return retList;
        }

        public IEnumerable<ReportedFault> FindByDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT fid, date_of_fault, fstatus, fshort_desc, ecid, fdesc
                            FROM reported_faults
                            WHERE date_of_fault BETWEEN :pStartDate AND :pEndDate";
            List<ReportedFault> retList = new List<ReportedFault>();
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pStartDate", DbType.String);
                    ParameterUtil.AddParameter(command, "pEndDate", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pStartDate", startDate.ToString("yyyy-MM-dd"));
                    ParameterUtil.SetParameterValue(command, "pEndDate", endDate.ToString("yyyy-MM-dd"));
                    using(IDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            retList.Add(new ReportedFault(
                                rd.GetString(0),
                                DateTime.ParseExact(rd.GetString(1), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                                rd.GetString(2),
                                rd.GetString(3),
                                ElectronicComponentsService.FindById(rd.GetInt32(4),conn),
                                rd.GetString(5)
                                ));
                        }
                    }
                }
            }
            return retList;
        }

        public ReportedFault FindById(string id)
        {
            string query = "SELECT date_of_fault, fstatus, fshort_desc, ecid, fdesc FROM reported_faults WHERE fid = :pFid";
            ReportedFault ret = null;
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pFid", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pFid", id);
                    using(IDataReader rd = command.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            ret = new ReportedFault(
                                id,
                                DateTime.ParseExact(rd.GetString(0),"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                                rd.GetString(1),
                                rd.GetString(2),
                                ElectronicComponentsService.FindById(rd.GetInt32(3), conn),
                                rd.GetString(4)
                           );
                        }
                    }
                }
            }
            return ret;
        }

        public string Save(ReportedFault newEntity)
        {
            string query = @"INSERT INTO reported_faults (fshort_desc, ecid, fdesc)
                        VALUES (:pFshort_desc, :pEcid, :pFdesc)
                        RETURNING fid INTO :pOutputId";
            if (ExistsById(newEntity.Id))
            {
                return "";
            }
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pFshort_desc", DbType.String);
                    ParameterUtil.AddParameter(command, "pEcid", DbType.Int32);
                    ParameterUtil.AddParameter(command, "pFdesc", DbType.String);
                    ParameterUtil.AddParameter(command, "pOutputId", DbType.String, ParameterDirection.Output, 33);
                    ParameterUtil.SetParameterValue(command, "pFshort_desc", newEntity.Short_description);
                    ParameterUtil.SetParameterValue(command, "pEcid", newEntity.FaultyComponent.Id);
                    ParameterUtil.SetParameterValue(command, "pFdesc", newEntity.Description);
                    command.Prepare();
                    if(command.ExecuteNonQuery() == 1)
                    {
                        return ParameterUtil.GetParameterValue(command, "pOutputId").ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }
        public bool Update(ReportedFault toUpdate)
        {
            string query = @"UPDATE reported_faults SET fstatus = :pFstatus, fshort_desc = :pFshort_desc, fdesc = :pFdesc
                            WHERE fid = :pFid";
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pFstatus", DbType.String);
                    ParameterUtil.AddParameter(command, "pFshort_desc", DbType.String);
                    ParameterUtil.AddParameter(command, "pFdesc", DbType.String);
                    ParameterUtil.AddParameter(command, "pFid", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pFstatus", toUpdate.Status);
                    ParameterUtil.SetParameterValue(command, "pFshort_desc", toUpdate.Short_description);
                    ParameterUtil.SetParameterValue(command, "pFdesc", toUpdate.Description);
                    ParameterUtil.SetParameterValue(command, "pFid", toUpdate.Id);
                    return (command.ExecuteNonQuery() == 1) ? true : false;
                }
            }
        }
        public short FindPriority(ReportedFault toFind)
        {
            short ret = 0;
            string query_rf = @"SELECT TRUNC(SYSDATE) - TRUNC(TO_DATE(date_of_fault, 'YYYY-MM-DD'))
                                FROM reported_faults WHERE fid = :pFid";
            string query_fa = @"SELECT count(*) * 0.5 FROM fault_actions WHERE fid = :pFid";
            using (IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using (IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query_rf;
                    ParameterUtil.AddParameter(command, "pFid", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pFid", toFind.Id);
                    ret += Convert.ToInt16(command.ExecuteScalar());
                }
                using (IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query_fa;
                    ParameterUtil.AddParameter(command, "pFid", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pFid", toFind.Id);
                    ret += Convert.ToInt16(command.ExecuteScalar());
                }
            }
            return ret;
        }

        bool ICRUDDao<ReportedFault, string>.Save(ReportedFault newEntity)
        {
            return (Save(newEntity).Length != 0) ? true : false;
        }
    }
}
