using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces;
using OMS.Models;
using OMS.Classes.DatabaseHandlerClasses.ConnectionHandlers;
using System.Data;
using OMS.Utils;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOImplementation
{
    class ElectronicComponentsTypesDAOImpl : IElectronicElementsTypesDAO
    {
        public bool DeleteOne(ElectronicComponentsTypes toDelete)
        {
            string query = "DELETE FROM electronic_components_types WHERE cid = :pCid";
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pCid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pCid", toDelete.Id);
                    return (command.ExecuteNonQuery() == 1) ? true : false;
                }
            }
        }

        public bool ExistsById(int id)
        {
            return (FindById(id) == null) ? false : true; 
        }

        public IEnumerable<ElectronicComponentsTypes> FindAll()
        {
            List<ElectronicComponentsTypes> retList = new List<ElectronicComponentsTypes>();
            string query = "SELECT cid, cname FROM electronic_components_types";
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
                            retList.Add(new ElectronicComponentsTypes(rd.GetInt32(0), rd.GetString(1)));
                        }
                    }
                }
            }
            return retList;
        }

        public ElectronicComponentsTypes FindById(int id)
        {
            string query = "SELECT cname FROM electronic_components_types WHERE cid = :pCid";
            ElectronicComponentsTypes ret = null;
            using(IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using(IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pCid", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pCid", id);
                    using(IDataReader rd = command.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            ret = new ElectronicComponentsTypes(id, rd.GetString(0));
                        }
                    }
                }
            }
            return ret;
        }
        public ElectronicComponentsTypes FindById(int id, IDbConnection conn)
        {
            string query = "SELECT cname FROM electronic_components_types WHERE cid = :pCid";
            ElectronicComponentsTypes ret = null;
            using (IDbCommand command = conn.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "pCid", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "pCid", id);
                using (IDataReader rd = command.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        ret = new ElectronicComponentsTypes(id, rd.GetString(0));
                    }
                }
            }
            return ret;
        }

        public bool Save(ElectronicComponentsTypes newEntity)
        {
            string query = ExistsById(newEntity.Id) ? "UPDATE electronic_components_types SET cname = :pCname" :
                            "INSERT INTO electronic_components_types (cname) VALUES (:pCname)";
            using (IDbConnection conn = OracleSQLConnection.GetConnection())
            {
                conn.Open();
                using (IDbCommand command = conn.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "pCname", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "pCname", newEntity.Name);
                    return (command.ExecuteNonQuery() == 1) ? true : false;
                }
            }
        }

        public bool SaveAll(IEnumerable<ElectronicComponentsTypes> newEntities)
        {
            throw new NotImplementedException();
        }
    }
}
