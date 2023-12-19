using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models.OracleSQL
{
    class ElectronicComponentsTypesSQL
    {
        public static string GeneratePlainSelect()
        {
            return "SELECT * FROM electronic_components_types";
        }
        public static string GenerateInsert()
        {
            return "INSERT INTO electronic_components_types (cname) VALUES (:pCName)";
        }
    }
}
