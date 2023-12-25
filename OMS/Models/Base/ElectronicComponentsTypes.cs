using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models.OracleSQL;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using OMS.Classes.DatabaseHandlerClasses.CommandClasses;

namespace OMS.Models
{
    class ElectronicComponentsTypes
    {
        public static readonly int NewElectronicComponentTypeId = -1;
        int id;
        string name;
        public ElectronicComponentsTypes(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int Id
        {
            get
            {
                return id;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public static ElectronicComponentsTypes ReturnElectronicComponentTypeById(int id)
        {
            ElectronicComponentsTypes retType = null;
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter(":pCid", OracleDbType.Int32, id, ParameterDirection.Input));
            OracleSQLSelectCommands selectCmd = new OracleSQLSelectCommands(ElectronicComponentsTypesSQL.GenerateSelectById(), parameters);
            IDataReader rd = selectCmd.exeCmd();
            if(rd != null && rd.Read())
            {
                retType = new ElectronicComponentsTypes(rd.GetInt32(0), rd.GetString(1));
            }
            return retType;
        }
        public static bool DeleteElectronicComponentTypeById(int id)
        {
            List<OracleParameter> parameters = new List<OracleParameter>();
            parameters.Add(new OracleParameter(":pCid", OracleDbType.Int32, id, ParameterDirection.Input));
            OracleSQLDeleteCommands deleteCmd = new OracleSQLDeleteCommands(ElectronicComponentsTypesSQL.GenerateDeleteById(), parameters);
            if(deleteCmd.executeDelete() != 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string GetFormattedHeader()
        {
            return String.Format("{0, -4}|{1, -8}", "ID", "NAME");
        }
        public override string ToString()
        {
            return String.Format("{0, -4}|{1, -8}", id, name);
        }
    }
}
