using OMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models.Base;

namespace OMS.Classes.UserInterfaceClasess
{
    class SingleFault : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            bool isOk = true;
            string id;
            ReportedFault rf = null;
            do
            {
                Console.Write("Please enter the ID of the fault you want to export: ");
                id = Console.ReadLine();
                if (id.Length < 1 || id.Length >= 32)
                {
                    Console.WriteLine("Invalid format of id");
                    isOk = false;
                }
                else
                {
                    if ((rf = ReportedFaultService.FindById(id)) == null)
                    {
                        Console.WriteLine("Fault with the specified ID not found in the database");
                        isOk = false;
                    }
                    else
                    {
                        List<ReportedFault> exportList = new List<ReportedFault>();
                        exportList.Add(rf);
                        ExcelExportService.GenerateDocument(exportList);
                        Console.WriteLine("Your document is exported and saved.");
                        isOk = true;
                    }
                }
            } while (!isOk);
            Console.ReadKey();
            return UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
        }
    }
}
