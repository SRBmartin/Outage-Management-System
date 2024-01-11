using System;

namespace OMS.Classes.UserInterfaceClasess
{
    class ElectronicElementsType : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            bool isOk = true;
            short choice = -1;
            string option;
            do
            {
                
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Show list of electronic element types");
                Console.WriteLine("2. Add to list");
                Console.WriteLine("3. Delete from list");
                option = Console.ReadLine();
                if (!short.TryParse(option, out choice))
                {
                    Console.WriteLine("Option must be a number!");
                    continue;
                }
                if (choice != 1 && choice != 2 && choice != 3)
                {
                    Console.WriteLine("Ops. Not a valid option.");
                    isOk = false;
                }
                else
                {
                    isOk = true;
                }
               
            } while (!isOk);

            return UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveElementOption(choice)); 
        }
    }

}



