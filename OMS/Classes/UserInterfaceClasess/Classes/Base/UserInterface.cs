﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;
using OMS.Classes.UserInterfaceClasess.Classes.Base;

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
                case 3:
                    ChangeFaultStatus changeFault = new ChangeFaultStatus();
                    return changeFault;
                case 4:
                    RecordEE rRecord = new RecordEE();
                    return rRecord;
                case 5:
                    ElectronicElementsType electronicalElements = new ElectronicElementsType();
                    return electronicalElements;
                case 6:
                    FailureList failureList = new FailureList();
                    return failureList;
                case 7:
                    CreateDoc createDoc = new CreateDoc();
                    return createDoc;
                default:
                    ExitProgram ep = new ExitProgram();
                    return ep;
            }

        }
        public static object ResolveElementOption(short option)
        {
            switch (option)
            {
                case 1:
                    ShowElectronicElemetsListTypes electronicElemetsList = new ShowElectronicElemetsListTypes();
                    return electronicElemetsList;
                case 2:
                    AddToList aAdd = new AddToList();
                    return aAdd;
                case 3:
                    DeleteFromList deleteFromList = new DeleteFromList();
                    return deleteFromList;
                default:
                    ExitProgram ep = new ExitProgram();
                    return ep;
            }

        }
        public static object ResolveComponentOption(short option)
        {
            switch (option)
            {
                case 1:
                    ShowComponents sc = new ShowComponents();
                    return sc;
                case 2:
                    AddComponent ac = new AddComponent();
                    return ac;
                case 3:
                    DeleteComponent dc = new DeleteComponent();
                    return dc;
                default:
                    ExitProgram ep = new ExitProgram();
                    return ep;
            }
        }

        public static object ResolveSearch(short option)
        {
            switch (option)
            {
                case 1:
                    SearchRange searchRange = new SearchRange();
                    return searchRange;
                case 2:
                    SearchById searchById = new SearchById();
                    return searchById;

                default:
                    ExitProgram ep = new ExitProgram();
                    return ep;
            }
        }

        public static object ResolveDoc(short option)
        {
            switch (option)
            {
                case 1:
                    AllFaults allFault = new AllFaults();
                    return allFault;
                case 2:
                    SingleFault singleFault = new SingleFault();
                    return singleFault;
                default:
                    ExitProgram ep = new ExitProgram();
                    return ep;

            }
        }

    }
}
