using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using OMS.Services;
using OMS.Models.Base;

namespace OMS.Classes.UserInterfaceClasess
{
    class SearchRange : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            bool isOk;
            DateTime startDate;
            DateTime endDate;

            do
            {
                Console.Write("Please enter starting date (format: yyyy-MM-dd): ");
                string inputDate = Console.ReadLine();

                if (!DateTime.TryParseExact(inputDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out startDate))
                {
                    Console.WriteLine("Invalid date format. Please try again.");
                    isOk = false;
                    continue;
                }
                else
                {
                    isOk = true;
                }
            } while (!isOk);

            do
            {
                Console.Write("Please enter ending date (yyyy-MM-dd): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out endDate))
                {
                    Console.WriteLine("Invalid date format. Please try again.");
                    isOk = false;
                    continue;
                }
                if(endDate < startDate)
                {
                    Console.WriteLine("Ending date can't be lower than the starting date.");
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
                List<ReportedFault> faults;
                if ((faults = ReportedFaultService.FindByDateRange(startDate, endDate)).Count != 0)
                {
                    Console.WriteLine(ReportedFault.GetFormattedHeader());
                    foreach(ReportedFault rf in faults)
                    {
                        Console.WriteLine(rf);
                    }
                }
                else
                {
                    Console.WriteLine("No faults found for given date range.");
                }
            }
            catch (DbException dex)
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
