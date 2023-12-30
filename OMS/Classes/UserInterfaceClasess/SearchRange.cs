﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                if (DateTime.TryParseExact(inputDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out startDate))
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
                if (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out endDate) && endDate > startDate)
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
            Console.WriteLine("# | ID | DATE | SHORT DESCRIPTION | STATUS");
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
