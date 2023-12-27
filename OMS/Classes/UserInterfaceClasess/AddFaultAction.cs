using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;
using OMS.Models.Base;

namespace OMS.Classes.UserInterfaceClasess
{
    class AddFaultAction : IUserInterfaceComponent
    {
        private readonly short MAX_SHORT_DESCTRIPTION = 256;

        public short ShowCopmonent()
        {
            bool isOk = true;
            string actionDestcription;
            DateTime actionDate;

            do
            {
                Console.WriteLine("--------------------------------------");
                Console.Write("Please enter the date and time when the action has taken place (format: yyyy-MM-dd HH:mm:ss): ");
                string inputDate = Console.ReadLine();

                if (DateTime.TryParseExact(inputDate, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out actionDate))
                {
                    isOk = true;
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please try again.");
                    isOk = false;
                }

            } while (!isOk);

            do
            {
                if (!isOk)
                {
                    Console.WriteLine("Ops you enter something wrong. Please try again");
                    isOk = true;
                }
                Console.Write("Enter a  short destcription of taken action: ");
                actionDestcription = Console.ReadLine();
                if (actionDestcription.Length == 0 || actionDestcription.Length > MAX_SHORT_DESCTRIPTION)
                {
                    isOk = false;
                }
            } while (!isOk);
            return UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
        }
        public short ShowComponent(ReportedFault toCheck, int num_of_actions)
        {
            Console.WriteLine($"--- FAULT ACTIONS FOR FAULT [ ID: {toCheck.Id} ] ---");
            while(num_of_actions-- > 0)
            {
                bool isOk = true;
                string actionDestcription;
                DateTime actionDate;

                do
                {
                    Console.WriteLine("--------------------------------------");
                    Console.Write("Please enter the date and time when the action has taken place (format: yyyy-MM-dd HH:mm:ss): ");
                    string inputDate = Console.ReadLine();

                    if (DateTime.TryParseExact(inputDate, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out actionDate))
                    {
                        isOk = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                        isOk = false;
                    }
                } while (!isOk);

                do
                {
                    Console.Write("Enter a  short description of taken action: ");
                    actionDestcription = Console.ReadLine();
                    if (actionDestcription.Length == 0)
                    {
                        Console.WriteLine("Short description must be at least one character long.");
                        isOk = false;
                        continue;
                    }
                    if(actionDestcription.Length > FaultAction.MAX_DESCRIPTION)
                    {
                        Console.WriteLine("Short description is too long.");
                        isOk = false;
                        continue;
                    }
                    else
                    {
                        isOk = true;
                    }
                } while (!isOk);
            }
            return 0;
        }

    }
}
