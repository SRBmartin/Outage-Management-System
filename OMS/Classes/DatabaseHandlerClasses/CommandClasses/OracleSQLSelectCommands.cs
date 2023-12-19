using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses.ConnectionHandlers.Classes;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace OMS.Classes.DatabaseHandlerClasses.CommandClasses
{
    class OracleSQLSelectCommands : OracleSQLConnection
    {
        IDbCommand command = null;
        public OracleSQLSelectCommands(string cmd, List<OracleParameter> parameters)
        {
            command = Instance.CreateCommand();
            command.CommandText = cmd;
            while(parameters != null)
            {
                if (parameters.Count != 0)
                {
                    command.Parameters.Add(parameters.First());
                    parameters.RemoveAt(0);
                }
            }
        }
        public IDataReader exeCmd()
        {
            if (command != null)
            {
                return command.ExecuteReader();
            }
            return null;
        }
        public IDbCommand Command
        {
            get
            {
                return command;
            }
        }
        ~OracleSQLSelectCommands()
        {
            command.Dispose();
        }
    }
}
