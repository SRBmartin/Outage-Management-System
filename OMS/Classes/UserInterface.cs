using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;

namespace OMS.Classes
{
    class UserInterface
    {
        public static short ShowInterface(IUserInterfaceComponent menuId) {
            return menuId.ShowCopmonent();
        }
        public static short ShowStartingInterface()
        {
            MainMenu mMenu = new MainMenu();
           return UserInterface.ShowInterface(mMenu);
        }

        public static object ResolveOption(short option)
        {
            switch (option)
            {
                case 1:
                    FaultEntry fEntry = new FaultEntry();
                    return fEntry;
                case 4:
                    RecordEE rRecord = new RecordEE();
                    return rRecord;
                default:
                    Console.WriteLine("Exiting program");
                    return null;


            }
                
        }

        
    }
}
