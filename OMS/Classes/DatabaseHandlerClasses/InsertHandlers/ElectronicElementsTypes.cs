using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using OMS.Classes.DatabaseHandlerClasses.ConnectionHandlers.Classes;

namespace OMS.Classes.DatabaseHandlerClasses.InsertHandlers
{
    class ElectronicElementsTypes
    {
        public static bool AddNewType(string type)
        {
            try
            {
                OracleSQLCommands cmd = new OracleSQLCommands("INSERT INTO electronic_components_types (cname) VALUES (:pCName)");
                if (cmd.Command.Parameters.Add(new OracleParameter(":pCName", OracleDbType.Varchar2, type, ParameterDirection.Input)) == -1)
                {
                    return false;
                }
                if (cmd.Command.ExecuteNonQuery() != 1)
                {
                    Console.WriteLine("An unexpected error occured.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("ORA-00001"))
                {
                    Console.WriteLine("That type is already added to a database.");
                }
                else
                {
                    Console.WriteLine("The following error occured:\n");
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
                return false;
            }
            return true;
        }
    }
}
