using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;

namespace OMS.Classes.UserInterfaceClasess
{
    class DeleteFromList : IUserInterfaceComponent
    {
        private readonly short MAX_SHORT_DESCTRIPTION = 256;
        public short ShowCopmonent()
        {
            bool isOk = true;
            string name;
            do {
                if (!isOk)
                {
                    Console.WriteLine("Ops you enter something wrong. Please try again");
                    isOk = true;
                }
                Console.WriteLine("----------------------------------------------");
                Console.Write("Please enter name of the type of electronic element:");
                name = Console.ReadLine();
                if (name.Length == 0 || name.Length > MAX_SHORT_DESCTRIPTION)
                {
                    isOk = false;
                }
            } while (!isOk);
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
