using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;

namespace OMS.Classes.UserInterfaceClasess
{
    class ChangeFaultStatus : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
           
            bool isOk = true;
            string faultIdNum;
            do
            { 
                Console.WriteLine("------------------------------------");
                Console.Write("Please enter the fault identification number to change it's status: ");
                faultIdNum = Console.ReadLine();
                    if (faultIdNum.Length < 11 || faultIdNum.Length > 32)
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                        isOk = false;
                    }
                    else
                    {
                    isOk = true;
                    }

            } while (!isOk);

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Current status { ...}. Please select new status(status can't be returned to 'Unconfirmed'");
            Console.WriteLine("1. In service");
            Console.WriteLine("2. Testing");
            Console.WriteLine("3. Closed");
            Console.Write("Your option: ");
            string newStatusOption = Console.ReadLine();

            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
