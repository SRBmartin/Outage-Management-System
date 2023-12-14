using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace OMS.Classes.DatabaseHandlerClasses
{
    class OracleSQLConnection : OracleSQLConnectionParams
    {
        private IDbConnection instance = null;
        public OracleSQLConnection()
        {
            if(instance == null || instance.State == ConnectionState.Closed)
            {
                instance = new OracleConnection(getConnectionString());
            }
            else
            {
                throw new Exception("Already connected to a database.");
            }
        }
    }
}
