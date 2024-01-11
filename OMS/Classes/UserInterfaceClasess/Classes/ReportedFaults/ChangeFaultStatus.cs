using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;
using OMS.Models.Base;
using OMS.Services;
using System.Data.Common;

namespace OMS.Classes.UserInterfaceClasess
{
    class ChangeFaultStatus : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
           
            bool isOk = true;
            string faultIdNum;
            char option;
            ReportedFault target = null;
            do
            { 
                Console.WriteLine("------------------------------------");
                Console.Write("Please enter the fault identification number to change it's status: ");
                faultIdNum = Console.ReadLine();
                    if (faultIdNum.Length < 11 || faultIdNum.Length > 32)
                    {
                        Console.WriteLine("Invalid ID format. Please try again.");
                        isOk = false;
                    }
                    else
                    {
                        isOk = true;
                    }
            } while (!isOk);
            try
            {
                if ((target = ReportedFaultService.FindById(faultIdNum)) != null)
                {
                    Console.WriteLine($"------------- {target.Id} -------------");
                    Console.WriteLine($"Current status {target.Status}. Please select new status (status can't be returned to 'Unconfirmed')");
                    do
                    {
                        Console.WriteLine("1. Testing");
                        Console.WriteLine("2. Closed");
                        Console.Write("Your option: ");
                        option = Char.ToLower(Console.ReadKey().KeyChar);
                        if (option != '1' && option != '2')
                        {
                            Console.WriteLine("Wrong option number entered. Try again..");
                            isOk = false;
                            continue;
                        }
                        else
                        {
                            isOk = true;
                        }
                    } while (!isOk);
                    switch (option)
                    {
                        case '1':
                            if (FaultActionService.FindAllByFaultId(faultIdNum).Count == 0)
                            {
                                Console.WriteLine("\nIn order for reported fault to be in 'Testing' status it must have at least one action.");
                            }
                            else
                            {
                                if (target.Status != "Testing")
                                {
                                    target.Status = "Testing";
                                    if (ReportedFaultService.Update(target))
                                    {
                                        Console.WriteLine($"\nSuccessfully updated the status of {target.Id} to {target.Status}.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nUpdate operation failed.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nThis reported fault is alredy in 'Testing' state.");
                                }
                            }
                            break;
                        case '2':
                            if (target.Status != "Closed")
                            {
                                target.Status = "Closed";
                                if (ReportedFaultService.Update(target))
                                {
                                    Console.WriteLine($"\nSuccessfully updated the status of {target.Id} to {target.Status}.");
                                }
                                else
                                {
                                    Console.WriteLine("\nUpdate operation failed.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nThis reported fault is already in 'Closed' status.");
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Reported fault with given ID couldn't be found.");
                }
            }
            catch (DbException dex)
            {
                Console.WriteLine($"Database exception occured: {dex.Message}");
            }catch(Exception ex)
            {
                Console.WriteLine($"An unhandled exception occured: {ex.Message}");
            }
            Console.ReadKey();
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
