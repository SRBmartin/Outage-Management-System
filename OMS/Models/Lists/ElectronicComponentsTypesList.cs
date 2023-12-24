using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models;
using OMS.Classes.DatabaseHandlerClasses.CommandClasses;
using OMS.Models.OracleSQL;
using System.Data;

namespace OMS.Models.Lists
{
    class ElectronicComponentsTypesList
    {
        private static List<ElectronicComponentsTypes> types = new List<ElectronicComponentsTypes>(); //always used for temporary storing and will be deleted soon

        private static void FetchAllData()
        {
            OracleSQLSelectCommands selectCmd = new OracleSQLSelectCommands(ElectronicComponentsTypesSQL.GeneratePlainSelect(), null);
            IDataReader rd = selectCmd.exeCmd();
            while (rd.Read())
            {
                types.Add(new ElectronicComponentsTypes(rd.GetInt32(0), rd.GetString(1)));
            }
        }
        public static void FetchAndDisplayAllData()
        {
            FetchAllData();
            while (types.Count != 0)
            {
                Console.WriteLine($"{types.First().Id} | {types.First().Name}");
                types.RemoveAt(0);
            }
        }
    }
}
