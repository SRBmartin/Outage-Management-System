using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;

namespace OMS.Classes.UserInterfaceClasess
{
    class AddToList : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            bool isOk = true;
            string tmpId;
            int id; 
            do
            {
                if (!isOk)
                {
                    Console.WriteLine("Ops you enter something wrong. Please try again");
                    isOk = true;
                }
                Console.WriteLine("----------------------------------------------");
                Console.Write("Please enter an ID of the type of electronic element you want to delete:");
                tmpId = Console.ReadLine();
                if (!int.TryParse(tmpId, out id) || id < 0)
                {
                    isOk = false;

                }
                else
                {
                    isOk = true;
                }

            } while (!isOk);

            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
