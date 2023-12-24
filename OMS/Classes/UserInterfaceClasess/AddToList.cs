using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses.InsertHandlers;

namespace OMS.Classes.UserInterfaceClasess
{
    class AddToList : IUserInterfaceComponent
    {
        private readonly short MAX_CNAME_SIZE = 32;
        public short ShowCopmonent()
        {
            bool isOk = true;
            string tmpId;
            do
            {
                if (!isOk)
                {
                    Console.WriteLine("Ops you enter something wrong. Please try again");
                    isOk = true;
                }
                Console.WriteLine("----------------------------------------------");
                Console.Write("Please enter a name of the type of electronic element you want to add: ");
                tmpId = Console.ReadLine();
                if (tmpId.Length == 0)
                {
                    Console.WriteLine("Name is too short.");
                    isOk = false;
                }
                else if (tmpId.Length > MAX_CNAME_SIZE)
                {
                    Console.WriteLine("Name is too long.");
                    isOk = false;
                }
                else
                {
                    if (ElectronicElementsTypes.AddNewType(tmpId))
                    {
                        Console.WriteLine("Added a new type with success.");
                        Console.ReadKey();
                        isOk = true;
                    }
                    else
                    {
                        continue;
                    }
                }
            } while (!isOk);

            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
