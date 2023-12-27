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
    class ReportedFaultDAOImpl : IReportedFault
    {
        public bool DeleteOne(ReportedFault toDelete)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(string id)
        {
            return (FindById(id) == null) ? false : true;
        }

        public IEnumerable<ReportedFault> FindAll()
        {
            throw new NotImplementedException();
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
                                rd.GetDateTime(0),
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
            /*string query = @"DECLARE
                        last_inserted_fid VARCHAR2(32);
                    BEGIN
                        SELECT TO_CHAR(SYSDATE, 'YYYYMMDDHH24MISS') || '_' || reported_faults_seq.NEXTVAL
                        INTO last_inserted_fid
                        FROM dual;

                        INSERT INTO reported_faults (fshort_desc, ecid, fdesc)
                        VALUES (:pFshort_desc, :pEcid, :pFdesc);

                        :pOutputId := last_inserted_fid;
                    END;";*/
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

        public bool SaveAll(IEnumerable<ReportedFault> newEntities)
        {
            throw new NotImplementedException();
        }

        bool ICRUDDao<ReportedFault, string>.Save(ReportedFault newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
