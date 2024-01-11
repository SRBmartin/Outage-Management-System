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
    class SearchById : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            bool isOk = true;
            string id;
            do
            {
                
                Console.Write("Please enter ID of reported fault to display: ");
                id = Console.ReadLine();
                if(id.Length == 0)
                {
                    Console.WriteLine("ID must be at least one characted long.");
                    isOk = false;
                    continue;
                }
                else
                {
                    isOk = true;
                }
            } while (!isOk);
            try
            {
                ReportedFault target = null;
                char option;
                if( (target = ReportedFaultService.FindById(id)) != null)
                {
                    Console.WriteLine(ReportedFault.GetFormattedHeader());
                    Console.WriteLine(target);
                    Console.Write("Do you want to make a change to this reported fault? (Y/n)");
                    option = Char.ToLower(Console.ReadKey().KeyChar);
                    if(option == 'y')
                    {
                        ChangeReportedFault crf = new ChangeReportedFault();
                        crf.ShowComponent(target);
                    }
                    else
                    {
                        Console.WriteLine("No changes were made.");
                    }
                }
                else
                {
                    Console.WriteLine("Reported fault with that ID couldn't be found.");
                }
            }catch(DbException dex)
            {
                Console.WriteLine($"Database exception occured: {dex.Message}");
            }catch(Exception ex)
            {
                Console.WriteLine($"Unhandled exception occured: {ex.Message}");
            }
            Console.ReadKey();
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
