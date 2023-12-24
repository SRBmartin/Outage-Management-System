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
        protected static readonly string localDataSource = "//localhost:1521/xe";
        protected static readonly string userId = "oms_projekat";
        protected static readonly string password = "ftn";
    }
}
