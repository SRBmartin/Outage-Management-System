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
                instance.Open();
            }
            else
            {
                throw new Exception("Already connected to a database.");
            }
        }
        protected IDbConnection Instance
        {
            get
            {
                return instance;
            }
        }
        ~OracleSQLConnection()
        {
            if (instance != null)
            {
                instance.Close();
                instance.Dispose();
            }
        }

    }
}
