using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;
using OMS.Models.Base;
using System.Data.Common;
using OMS.Services;

namespace OMS.Classes.UserInterfaceClasess
{
    class AddFaultAction : IUserInterfaceComponent
    {

        public short ShowCopmonent()
        {
            bool isOk = true;
            string actionDestcription;
            string faultId;
            DateTime actionDate;
            ReportedFault rf = null;
            do
            {
                Console.Write("Please enter the ID of fault: ");
                faultId = Console.ReadLine();
                if(faultId.Length == 0)
                {
                    Console.WriteLine("ID must be at least one character long.");
                    isOk = false;
                    continue;
                }
                if ((rf = ReportedFaultService.FindById(faultId)) == null)
                {
                    Console.WriteLine("The fault with that ID does not exist in database.");
                    isOk = false;
                    continue;
                }
                else
                {
                    isOk = true;
                }
            } while (!isOk);
            if (rf.Status != "Closed")
            {
                do
                {
                    Console.WriteLine("--------------------------------------");
                    Console.Write("Please enter the date and time when the action has taken place (format: yyyy-MM-dd HH:mm:ss): ");
                    string inputDate = Console.ReadLine();

                    if (!DateTime.TryParseExact(inputDate, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out actionDate))
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                        isOk = false;
                        continue;
                    }
                    if (actionDate < rf.CreationDate)
                    {
                        Console.WriteLine("Action cannot be taken before the fault happened.");
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
                    Console.Write("Enter a short destcription of taken action: ");
                    actionDestcription = Console.ReadLine();
                    if (actionDestcription.Length == 0)
                    {
                        Console.WriteLine("Description must be at least one character long.");
                        isOk = false;
                        continue;
                    }
                    if (actionDestcription.Length > FaultAction.MAX_DESCRIPTION)
                    {
                        Console.WriteLine("Description is too long.");
                        isOk = false;
                        continue;
                    }
                } while (!isOk);
                try
                {
                    if (FaultActionService.Save(new FaultAction(FaultAction.NEW_FAULT_ACTION_ID, actionDate, actionDestcription, faultId)))
                    {
                        Console.WriteLine("The new action was saved with success.");
                        if(rf.Status == "Unconfirmed")
                        {
                            rf.Status = "In service";
                            if (!ReportedFaultService.Update(rf))
                            {
                                Console.WriteLine("Couldn't automatically update the status of fault.");
                            }
                            else
                            {
                                Console.WriteLine("Reported fault status was automatically updated to 'In service'.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("There was an error while saving new action for fault.");
                    }
                }
                catch (DbException dex)
                {
                    Console.WriteLine($"Database exception occured: {dex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unhandled exception occured: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Reported fault status is set to 'Closed' so it doesn't accept any new actions.");
            }
            Console.ReadKey();
            return UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
        }
        public short ShowComponent(ReportedFault toCheck, int num_of_actions)
        {
            Console.Clear();
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

                    if (!DateTime.TryParseExact(inputDate, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out actionDate))
                    {
                        Console.WriteLine("Invalid date format. Please try again.");
                        isOk = false;
                        continue;
                    }
                    if (actionDate < ReportedFaultService.FindById(toCheck.Id).CreationDate)
                    {
                        Console.WriteLine("Action cannot be taken before the fault happened.");
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
                try
                {
                    if (FaultActionService.Save(new FaultAction(
                        FaultAction.NEW_FAULT_ACTION_ID, actionDate, actionDestcription, toCheck.Id)
                        ))
                    {
                        Console.WriteLine("Action is saved with success.");
                        if (toCheck.Status == "Unconfirmed")
                        {
                            toCheck.Status = "In service";
                            if (!ReportedFaultService.Update(toCheck))
                            {
                                Console.WriteLine("Couldn't automatically update the status of fault.");
                            }
                            else
                            {
                                Console.WriteLine("Reported fault status was automatically updated to 'In service'.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Could not save new action for selected fault. Aborting...");
                        Console.ReadKey();
                        return 0;
                    }
                }catch(DbException dex)
                {
                    Console.WriteLine($"Database exception occured: {dex.Message}");
                }catch(Exception ex)
                {
                    Console.WriteLine($"An unhandled exception occured: {ex.Message}");
                }
                Console.ReadKey();
            }
            return 0;
        }

    }
}
