using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes.UserInterfaceClasess.Classes.Base
{
    class ExitProgram : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            Console.WriteLine("Exiting the program...");
            return -1;
        }
    }
}
