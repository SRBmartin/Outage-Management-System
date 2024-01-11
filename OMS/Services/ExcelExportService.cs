using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.FileHandler;
using OMS.Models.Base;
using OMS.FileHandler.Implementations;

namespace OMS.Services
{
    class ExcelExportService
    {
        private static ExcelExport excel = new ExcelExport();        
        public static void GenerateDocument(IEnumerable<ReportedFault> toGenerate)
        {
            excel.GenerateDocument(toGenerate);
        }
    }
}
