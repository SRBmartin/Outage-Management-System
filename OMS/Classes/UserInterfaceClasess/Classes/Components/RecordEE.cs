using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes.UserInterfaceClasess
{
    class RecordEE : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            bool isOk = true;
            char option = '0';
            Console.WriteLine("--- ELECTRONIC COMPONENTS MENU ---");
            do
            {
                Console.WriteLine("1) Show list of all electronic components");
                Console.WriteLine("2) Add a new electronic component");
                Console.WriteLine("3) Delete an existing electronic component");
                Console.Write("Please choose an option: ");
                option = Console.ReadKey().KeyChar;
                if(option != '1' && option != '2' && option != '3')
                {
                    Console.WriteLine("Wrong option. Try again...");
                    continue;
                }
                else
                {
                    isOk = true;
                }
            } while (!isOk);
            return UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveComponentOption((short)(option - '0')));

        }
    }
}
