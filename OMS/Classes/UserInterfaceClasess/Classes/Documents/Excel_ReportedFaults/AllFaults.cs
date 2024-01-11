using OMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes.UserInterfaceClasess
{
    class AllFaults : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            ExcelExportService.GenerateDocument(ReportedFaultService.FindAll());
            Console.WriteLine("Your document is exported.");
            Console.ReadKey();
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;

        }
    }
}
