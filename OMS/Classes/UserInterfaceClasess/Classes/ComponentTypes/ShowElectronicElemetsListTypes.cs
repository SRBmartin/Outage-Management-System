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
    class ShowElectronicElemetsListTypes : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            try
            {
                List<ElectronicComponentsTypes> list = ElectronicComponentsTypesService.FindAll();
                Console.WriteLine("----------------------------------------------\n");
                if (list.Count > 0)
                {
                    Console.WriteLine(ElectronicComponentsTypes.GetFormattedHeader());
                    foreach (ElectronicComponentsTypes ect in list)
                    {
                        Console.WriteLine(ect);
                    }
                }
                else
                {
                    Console.WriteLine("There is no electronic components types in database.");
                }
            }catch(DbException dex)
            {
                Console.WriteLine($"There was an error with database: {dex.Message}");
            }catch(Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }
            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
