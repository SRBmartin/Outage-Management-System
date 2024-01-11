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
            char option;

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
                    int counter = 0;
                    Console.Write("# | ");
                    Console.WriteLine(ReportedFault.GetFormattedHeader());
                    foreach(ReportedFault rf in faults)
                    {
                        Console.Write($"{++counter} | ");
                        Console.WriteLine(rf);
                    }
                    Console.WriteLine("Do you want make change to one of these faults? (Y/n): ");
                    option = Char.ToLower(Console.ReadKey().KeyChar);
                    if(option == 'y')
                    {
                        int changeIndex = -1;
                        do
                        {
                            Console.Write("Enter the # of the reported fault you want to change: ");
                            if(!int.TryParse(Console.ReadLine(), out changeIndex))
                            {
                                changeIndex = -1;
                                Console.WriteLine("# must be a number.");
                            }
                            if(changeIndex <= 0 || changeIndex > counter)
                            {
                                Console.WriteLine("Index is out of range.");
                            }
                        } while (changeIndex <= 0 || changeIndex > counter);
                        ChangeReportedFault crf = new ChangeReportedFault();
                        crf.ShowComponent(faults[changeIndex - 1]);
                    }
                    else
                    {
                        Console.WriteLine("No changes were made.");
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
