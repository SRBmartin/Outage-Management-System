using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;

namespace OMS.Classes.UserInterfaceClasess
{
    class MainMenu : IUserInterfaceComponent
    {
        enum returnValues{EXIT, FAULT_ENTRY, RECORD_EE, FAILURE_LIST, CREATE_DOCUMENT};
        public short ShowCopmonent()
        {
            short option = -1;
            string tmpOption;
            bool stop = false;
            do {
                Console.WriteLine("--- Welcome to the main menu of Outage Managament System ---");
                Console.WriteLine("Available options are listed above. Please choose and enter number from following list...");
                Console.WriteLine("1.) Fault entry");
                Console.WriteLine("2.) Record of electrical elements");
                Console.WriteLine("3.) Failure list");
                Console.WriteLine("4.) Creating documents");
                Console.WriteLine("0.) Exit");

                tmpOption = Console.ReadLine();
                if (!short.TryParse(tmpOption, out option))
                {
                    break;
                }
                if (option != 1 && option != 2 && option != 3 && option != 4 && option != 0)
                {
                    Console.WriteLine("Wrong option entered, try again.");
                }
                else
                {
                    stop = true;
                }

            } while (!stop);
            return option;
        }

    }
}
