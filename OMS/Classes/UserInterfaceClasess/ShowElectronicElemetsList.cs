using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;

namespace OMS.Classes.UserInterfaceClasess
{
    class ShowElectronicElemetsList : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("ID | NAME");
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
               

            
        }
    }
}
