using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace OMS.Classes.DatabaseHandlerClasses
{
    class OracleSQLConnection : OracleSQLConnectionParams, IDisposable
    {
        static IDbConnection instance = null;
        public static IDbConnection GetConnection()
        {
            if (instance == null || instance.State == ConnectionState.Closed)
            {
                OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
                ocsb.DataSource = localDataSource;
                ocsb.UserID = userId;
                ocsb.Password = password;
                ocsb.Pooling = true;
                ocsb.MinPoolSize = 1;
                ocsb.MaxPoolSize = 5;
                ocsb.IncrPoolSize = 3;
                ocsb.ConnectionLifeTime = 5;
                ocsb.ConnectionTimeout = 30;
                instance = new OracleConnection(ocsb.ConnectionString);
            }
            return instance;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (instance != null)
                {
                    instance.Close();
                    instance.Dispose();
                    instance = null;
                }
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
