using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Services;
using OMS.Models.Base;
using System.Data.Common;

namespace OMS.Classes.UserInterfaceClasess
{
    class ShowComponents : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            try
            {
                var list = ElectronicComponentsService.FindAll();
                if (list.Count == 0)
                {
                    Console.WriteLine("There is no electronic components in database.");
                }
                else
                {
                    Console.WriteLine("--- LIST OF ELECTRONIC COMPONENTS ---");
                    Console.WriteLine(ElectronicComponents.GetFormattedHeader());
                    foreach (ElectronicComponents ec in list)
                    {
                        Console.WriteLine(ec);
                    }
                }
            }
            catch (DbException dex)
            {
                Console.WriteLine($"Database exception occured: {dex.Message}");
            }catch (Exception ex)
            {
                Console.WriteLine($"Exception occured: {ex.Message}");
            }
                Console.ReadKey();
            return UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
        }
    }
}
