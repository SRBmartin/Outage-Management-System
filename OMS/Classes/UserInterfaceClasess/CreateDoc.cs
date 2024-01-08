using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes.UserInterfaceClasess
{
    class CreateDoc : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            bool isOk = true;
            short option = 0;
            string tmpOption;
            short option1 = 0;
            do
            {
                Console.WriteLine("Please select format that you want to export data to:");
                Console.WriteLine("1) Excel table");
                Console.Write("Please enter your option: ");
                tmpOption = Console.ReadLine();
                if (!short.TryParse(tmpOption, out option))
                {
                    break;
                }
                if (option != 1)
                {
                    Console.WriteLine("Wrong option entered, try again.");
                    isOk = false;
                }
                else
                {
                    Console.WriteLine("\nPlease select what do you want to export:");
                    Console.WriteLine("\t1) All faults");
                    Console.WriteLine("\t2) Single fault");
                    Console.Write("Please enter your option: ");
                    tmpOption = Console.ReadLine();
                    if (!short.TryParse(tmpOption, out option1))
                    {
                        break;
                    }
                    if (option1 != 1 && option1 != 2)
                    {
                        Console.WriteLine("Wrong option entered, try again.");
                        isOk = false;
                    }
                    else
                    {
                        isOk = true;
                    }
                }

            } while (!isOk);
            return UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveDoc(option1));

        }
    }
}