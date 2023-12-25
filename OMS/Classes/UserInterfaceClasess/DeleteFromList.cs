﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;
using OMS.Models;
using OMS.Services;

namespace OMS.Classes.UserInterfaceClasess
{
    class DeleteFromList : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            bool isOk = true;
            string cidStr;
            int cid;
            ElectronicComponentsTypes toDelete = null;
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
                    continue;
                }
                if ((toDelete = ElectronicComponentsTypesService.FindById(cid)) != null)
                {
                    char option = 'N';
                    Console.Write($"Are you sure you want to delete [ID: {toDelete.Id}, NAME: {toDelete.Name}]? (Y/n)");
                    option = Char.ToLower(Console.ReadKey().KeyChar);
                    if (option != 'y')
                    {
                        Console.WriteLine("\nAborting delete operation. Press any key to return to main menu...");
                    }
                    else
                    {
                        Console.Write("\n");
                        if (ElectronicComponentsTypesService.DeleteOne(toDelete))
                        {
                            Console.WriteLine("Delete was a success. Returning to main menu...");
                        }
                        else
                        {
                            Console.WriteLine("Deleting failed. Try again later. Returning to main menu...");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ID you have entered is not found in database.");
                }
                Console.ReadKey();
            } while (!isOk);
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
