using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace OMS.Classes.DatabaseHandlerClasses
{
    class OracleSQLConnectionParams
    {
        private static readonly string localDataSource = "//localhost:1521/xe";
        private static readonly string userId = "oms_projekat";
        private static readonly string password = "ftn";
        protected static string getConnectionString()
        {
            OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
            ocsb.DataSource = localDataSource;
            ocsb.UserID = userId;
            ocsb.Password = password;
            return ocsb.ConnectionString;
        }
    }
}
