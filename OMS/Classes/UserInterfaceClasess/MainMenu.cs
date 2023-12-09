using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes.UserInterfaceClasess
{
    class MainMenu : IUserInterfaceComponent
    {
        public void ShowCopmonent()
        {
            short option = -1;
            bool stop = false;
            do {
                Console.WriteLine("--- Welcome to the main menu of Outage Managament System ---");
                Console.WriteLine("Available options are listed above. Please choose and enter number from following list...");
                Console.WriteLine("1.) Fault entry");
                Console.WriteLine("2.) Recod of electrical elements");
                Console.WriteLine("3.) Failure list");
                Console.WriteLine("4.) Creating documents");
                Console.WriteLine("0.) Exit");

                option = Convert.ToInt16(Console.ReadLine());
                if(option != 1 && option != 2 && option != 3 && option != 4 && option != 0)
                {
                    Console.WriteLine("Wrong option entered, try again.");
                }
                else
                {
                    stop = true;
                }
            } while (!stop);
        }

        
    }
}
