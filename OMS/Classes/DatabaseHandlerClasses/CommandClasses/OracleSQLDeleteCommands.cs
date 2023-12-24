using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace OMS.Classes.DatabaseHandlerClasses.CommandClasses
{
    class OracleSQLDeleteCommands : OracleSQLConnection
    {
        IDbCommand command = null;        
        public OracleSQLDeleteCommands(string cmd, List<OracleParameter> param)
        {
            command = Instance.CreateCommand();
            command.CommandText = cmd;
            while(param.Count != 0)
            {
                command.Parameters.Add(param.First());
                param.RemoveAt(0);
            }
        }
        public int executeDelete()
        {
            if(command != null)
            {
                int returnValue = -1;
                try
                {
                    returnValue = command.ExecuteNonQuery();
                }catch(Exception ex)
                {
                    Console.WriteLine("Following exception happened: ");
                    Console.WriteLine(ex.Message);
                }
                return returnValue;
            }
            else
            {
                return -1;
            }
        }
        ~OracleSQLDeleteCommands()
        {
            command.Dispose();
        }
    }
}
