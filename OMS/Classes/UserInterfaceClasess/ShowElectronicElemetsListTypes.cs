using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models.Lists;

namespace OMS.Classes.UserInterfaceClasess
{
    class ShowElectronicElemetsListTypes : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            Console.WriteLine("----------------------------------------------\n");
            Console.WriteLine("ID | NAME");
            ElectronicComponentsTypesList.FetchAndDisplayAllData();
            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
