using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace OMS.Classes.DatabaseHandlerClasses.ConnectionHandlers.Classes
{
    class OracleSQLCommands : OracleSQLConnection
    {
        IDbCommand command;
        public OracleSQLCommands(string cmd)
        {
            command = Instance.CreateCommand();
            command.CommandText = cmd;
            command.CommandType = CommandType.Text;
        }
        public IDbCommand Command
        {
            get
            {
                return command;
            }
        }

        ~OracleSQLCommands()
        {
            command.Dispose();
        }
    }
}
