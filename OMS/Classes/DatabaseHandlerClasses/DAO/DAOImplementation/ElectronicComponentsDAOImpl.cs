using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces;
using OMS.Models.Base;
using System.Data;
using OMS.Services;
using OMS.Utils;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOImplementation
{
    class ElectronicComponentsDAOImpl : IElectronicComponentsDAO
    {
        public bool DeleteOne(ElectronicComponents toDelete)
        {
            string query = "DELETE FROM electronic_components WHERE ecid = :pEcid";
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pEcid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pEcid", toDelete.Id);
                    return (command.ExecuteNonQuery() == 1) ? true : false;
                }
            }
        }

        public bool ExistsById(int id)
        {
            return (FindById(id) == null) ? false : true;
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
                                ElectronicComponentsTypesService.FindById(rd.GetInt32(2),conn),
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
            ElectronicComponents ret = null;
            string query = "SELECT ecid, ecname, etype, x, y, voltage_level FROM electronic_components WHERE ecid = :pEcid";
            using (IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using (IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pEcid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pEcid", id);
                    using (IDataReader rd = command.ExecuteReader())
                    {
                        if(rd.Read())
                        {
                            ret = new ElectronicComponents(
                                rd.GetInt32(0),
                                rd.GetString(1),
                                ElectronicComponentsTypesService.FindById(rd.GetInt32(2), conn),
                                rd.GetInt32(3),
                                rd.GetInt32(4),
                                rd.GetString(5));
                        }
                    }
                }
            }
            return ret;
        }

        public bool Save(ElectronicComponents newEntity)
        {
            string query;
            if (!ExistsById(newEntity.Id))
            {
                query = "INSERT INTO electronic_components (ecname, etype, x, y, voltage_level) VALUES (:pEcname, :pEtype, :pX, :pY, :pVoltage_level)";
            }
            else
            {
                return false;
            }
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pEcname", DbType.String);
                    ParameterUtil.AddParameter(command, "pEtype", DbType.Int32);
                    ParameterUtil.AddParameter(command, "pX", DbType.Int32);
                    ParameterUtil.AddParameter(command, "pY", DbType.Int32);
                    ParameterUtil.AddParameter(command, "pVoltage_level", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pEcname", newEntity.Name);
                    ParameterUtil.SetParameterValue(command, "pEtype", newEntity.Type.Id);
                    ParameterUtil.SetParameterValue(command, "pX", newEntity.X);
                    ParameterUtil.SetParameterValue(command, "pY", newEntity.Y);
                    ParameterUtil.SetParameterValue(command, "pVoltage_level", newEntity.Voltage_level);
                    return (command.ExecuteNonQuery() == 1) ? true : false;
                }
            }
        }

        public bool SaveAll(IEnumerable<ElectronicComponents> newEntities)
        {
            throw new NotImplementedException();
        }
    }
}
