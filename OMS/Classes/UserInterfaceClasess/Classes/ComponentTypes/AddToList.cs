using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Services;
using OMS.Models.Base;

namespace OMS.Classes.UserInterfaceClasess
{
    class AddToList : IUserInterfaceComponent
    {
        private readonly short MAX_CNAME_SIZE = 32;
        public short ShowCopmonent()
        {
            bool isOk = true;
            string cname;
            do
            {
                if (!isOk)
                {
                    Console.WriteLine("Ops you enter something wrong. Please try again");
                    isOk = true;
                }
                Console.WriteLine("----------------------------------------------");
                Console.Write("Please enter a name of the type of electronic element you want to add: ");
                cname = Console.ReadLine();
                if (cname.Length == 0)
                {
                    Console.WriteLine("Name is too short.");
                    isOk = false;
                }
                else if (cname.Length > MAX_CNAME_SIZE)
                {
                    Console.WriteLine("Name is too long.");
                    isOk = false;
                }
                else
                {
                    if (ElectronicComponentsTypesService.Save(new ElectronicComponentsTypes(ElectronicComponentsTypes.NEW_ID, cname)))
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
