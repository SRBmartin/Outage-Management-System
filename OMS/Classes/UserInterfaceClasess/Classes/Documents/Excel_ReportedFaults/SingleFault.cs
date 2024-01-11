using OMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes.UserInterfaceClasess
{
    class SingleFault : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            bool isOk = true;
            string id;
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
                    if (!ReportedFaultService.ExistsById(id))
                    {
                        Console.WriteLine("Fault with the specified ID not found in the database");
                        isOk = false;
                    }
                    else
                    {
                        isOk = true;
                    }
                }

            } while (!isOk);
            return UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
        }
    }
}
