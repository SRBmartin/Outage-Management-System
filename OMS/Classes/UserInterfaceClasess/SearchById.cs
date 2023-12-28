using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Classes.UserInterfaceClasess
{
    class SearchById : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            bool isOk = true;
            string idTmp;
            int id;
            do
            {
                
                Console.Write("Please enter id: ");
                idTmp = Console.ReadLine();
                if (!int.TryParse(idTmp, out id))
                {
                    isOk = false;
                    Console.WriteLine("Id must be number.");
                }
                else
                {
                    isOk = true;
                }
            } while (!isOk);
            Console.WriteLine("ID | DATE | SHORT DESCRIPTION | STATUS | PRIORITY");
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
