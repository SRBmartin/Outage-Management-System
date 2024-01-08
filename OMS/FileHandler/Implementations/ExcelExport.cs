using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.FileHandler.Interfaces;
using OMS.Models.Base;
using System.Data;
using System.IO;
using ClosedXML.Excel;

namespace OMS.FileHandler.Implementations
{
    class ExcelExport : IExcelExport
    {
        public void GenerateDocument(IEnumerable<ReportedFault> objToGenerateFrom)
        {
            List<ReportedFault> toExport = objToGenerateFrom.ToList();
            using (var workbook = new XLWorkbook())
            {
                // Add the first sheet
                var sheet1 = workbook.Worksheets.Add("List of faults");

                // Add columns to the first sheet
                sheet1.Cell(1, 1).Value = "Fault ID";
                sheet1.Cell(1, 2).Value = "Name of element";
                sheet1.Cell(1, 3).Value = "Voltage level";
                int row1 = 2;
                List<IXLWorksheet> sheets = new List<IXLWorksheet>();
                foreach(ReportedFault rf in toExport)
                {
                    sheet1.Cell(row1, 1).Value = rf.Id;
                    sheet1.Cell(row1, 2).Value = rf.FaultyComponent.Name;
                    sheet1.Cell(row1, 3).Value = rf.Id;
                    if (rf.FaultActions.Count != 0)
                    {
                        var tmpSheet = workbook.Worksheets.Add(rf.Id);
                        tmpSheet.Cell(1, 1).Value = "Action ID";
                        tmpSheet.Cell(1, 2).Value = "Date of action";
                        tmpSheet.Cell(1, 3).Value = "Description";
                        int rowfa = 2;
                        foreach(FaultAction fa in rf.FaultActions)
                        {
                            tmpSheet.Cell(rowfa, 1).Value = fa.Id;
                            tmpSheet.Cell(rowfa, 2).Value = fa.TimeOfActionS;
                            tmpSheet.Cell(rowfa, 3).Value = fa.Description;
                            rowfa++;
                        }
                    }
                    row1++;
                }
                workbook.SaveAs("output.xlsx");
            }
        }
    }
}
