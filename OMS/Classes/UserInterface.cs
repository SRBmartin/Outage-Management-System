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
            Console.Clear();
            return menuId.ShowCopmonent();
        }
        public static short ShowStartingInterface()
        {
            MainMenu mMenu = new MainMenu();
           return ShowInterface(mMenu);
        }

        public static object ResolveOption(short option)
        {
            switch (option)
            {
                case 1:
                    FaultEntry fEntry = new FaultEntry();
                    return fEntry;
                case 2:
                    AddFaultAction addFault = new AddFaultAction();
                    return addFault;
                case 4:
                    RecordEE rRecord = new RecordEE();
                    return rRecord;
                case 5:
                    ElectronicElementsType electronicalElements = new ElectronicElementsType();
                    return electronicalElements;
                default:
                    Console.WriteLine("Exiting program");
                    return null;


            }
                
        }
        public static object ResolveElementOption(short option)
        {
            switch (option)
            {
                case 1:
                    ShowElectronicElemetsList electircalElemetsList = new ShowElectronicElemetsList();
                    return electircalElemetsList;
                case 2:
                    AddToList aAdd = new AddToList();
                    return aAdd;
                case 3:
                    DeleteFromList deleteFromList = new DeleteFromList();
                    return deleteFromList;
                default:
                    Console.WriteLine("Exiting program");
                    return null;
            }

        }

    }
}
