using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes.UserInterfaceClasess
{
    class FailureList : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            bool isOk = true;
            short option = -1;
            string tmpOption;
            
            do {

                Console.WriteLine("Please select how you want to make a search: ");
                Console.WriteLine("1. Search by date range");
                Console.WriteLine("2. Search by ID of the fault");
                Console.Write("Your option: ");
                tmpOption =Console.ReadLine();
                if (!short.TryParse(tmpOption, out option))
                {
                    Console.WriteLine("Option must be a number.");
                    isOk = false;
                    continue;
                }
                if (option!=1 && option != 2)
                {
                    Console.WriteLine("Ops.You enter somethin wrong!");
                }
               
            } while (!isOk);
            
            return  UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveSearch(option)); 

        }
    }
}
