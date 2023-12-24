using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;
using OMS.Models;

namespace OMS.Classes.UserInterfaceClasess
{
    class DeleteFromList : IUserInterfaceComponent
    {
        private readonly short MAX_SHORT_DESCTRIPTION = 256;
        public short ShowCopmonent()
        {
            bool isOk = true;
            string cidStr;
            int cid;
            do {
                if (!isOk)
                {
                    Console.WriteLine("Ops you enter something wrong. Please try again");
                    isOk = true;
                }
                Console.WriteLine("----------------------------------------------");
                Console.Write("Please enter id of the type of electronic element you want to delete: ");
                cidStr = Console.ReadLine();
                if (!int.TryParse(cidStr, out cid))
                {
                    isOk = false;
                }
                ElectronicComponentsTypes deleteTarget = ElectronicComponentsTypes.ReturnElectronicComponentTypeById(cid);
                if(deleteTarget != null)
                {
                    char option = 'N';
                    Console.Write("Are you sure you want to delete [ID: {0}, NAME: {1}]? (Y/n)", deleteTarget.Id, deleteTarget.Name);
                    option = Char.ToLower(Console.ReadKey().KeyChar);
                    if(option != 'y')
                    {
                        Console.WriteLine("\nAborting delete operation. Press any key to return to main menu...");
                    }
                    else
                    {
                        Console.Write("\n");
                        if (ElectronicComponentsTypes.DeleteElectronicComponentTypeById(cid))
                        {
                            Console.WriteLine("Delete was a success. Return to main menu...");
                        }
                        else
                        {
                            Console.WriteLine("Deleting failed. Try again later. Returning to main menu...");
                        }
                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("The given id doesn't exists.");
                    Console.ReadKey();
                    continue;
                }
            } while (!isOk);
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
