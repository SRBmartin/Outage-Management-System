using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models.Base;
using OMS.Services;
using System.Data.Common;

namespace OMS.Classes.UserInterfaceClasess
{
    class ChangeReportedFault : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            throw new NotImplementedException();
        }
        public void ShowComponent(ReportedFault toChange)
        {
            Console.Clear();
            char option;
            string change = "";
            Console.WriteLine($"=-=-=-=-= CHANGE OF {toChange.Id} =-=-=-=-=");
            do
            {
                Console.WriteLine("What do you want to change?");
                Console.WriteLine("1) Short description");
                Console.WriteLine("2) Long description");
                Console.Write("Choose your option: ");
                option = Char.ToLower(Console.ReadKey().KeyChar);
            }while(option != '1' && option != '2');
            do
            {
                switch (option)
                {
                    case '1':
                        Console.Write("Enter the new short description: ");
                        change = Console.ReadLine();
                        if (change.Length == 0)
                        {
                            Console.WriteLine("Description must be at least one character long.");
                        }
                        if (change.Length > ReportedFault.MAX_SHORT_DESCRIPTION)
                        {
                            Console.WriteLine("Description is too long.");
                        }
                        toChange.Short_description = change;
                        break;
                    case '2':
                        Console.Write("Enter the new long description: ");
                        if (change.Length == 0)
                        {
                            Console.WriteLine("Description must be at least one character long.");
                        }
                        if (change.Length > ReportedFault.MAX_DESCRIPTION)
                        {
                            Console.WriteLine("Description is too long.");
                        }
                        toChange.Description = change;
                        break;
                }
                try
                {
                    if (ReportedFaultService.Update(toChange))
                    {
                        Console.WriteLine("The update operation was a success.");
                    }
                    else
                    {
                        Console.WriteLine("There was an error while updating.");
                    }
                }catch(DbException dex)
                {
                    Console.WriteLine($"There was a database exception: {dex.Message}");
                }catch(Exception ex)
                {
                    Console.WriteLine($"There was unhandled exception: {ex.Message}");
                }
            } while (change == "");
        }
    }
}
