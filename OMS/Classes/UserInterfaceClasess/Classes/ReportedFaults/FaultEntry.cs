using System;
using OMS.Models.Base;
using OMS.Services;
using System.Data.Common;

namespace OMS.Classes.UserInterfaceClasess
{
    class FaultEntry : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            string shortDescription;
            bool isOk = true;
            string tmpId;
            int id;
            string description;
            string tmpActionNum;
            short numAction;
            string faultId = "";
            ReportedFault rfNew = null;
            do
            {
                Console.WriteLine("----------------------------------------------");
                Console.Write("Enter a  short destcription of the fault: ");
                shortDescription = Console.ReadLine();
                if(shortDescription.Length == 0)
                {
                    Console.WriteLine("Short description must be at least 1 character long.");
                    isOk = false;
                    continue;
                }
                if(shortDescription.Length > ReportedFault.MAX_SHORT_DESCRIPTION)
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

            do
            {

                Console.WriteLine("----------------------------------------------");
                Console.Write("Enter the id of the failed electronic component: ");
                tmpId = Console.ReadLine();
                if(!int.TryParse(tmpId, out id))
                {
                    Console.WriteLine("ID must be a number.");
                    isOk = false;
                    continue;
                }
                if(id <= 0)
                {
                    Console.WriteLine("ID must be greater than zero.");
                    isOk = false;
                    continue;
                }
                if (!ElectronicComponentsService.ExistsById(id))
                {
                    Console.WriteLine("That electronic component is not found in database.");
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
                Console.WriteLine("----------------------------------------------");
                Console.Write("Please enter a full desctription: ");
                description = Console.ReadLine();
                if(description.Length == 0)
                {
                    Console.WriteLine("Description must be at least one character long.");
                    isOk = false;
                    continue;
                }
                if(description.Length > ReportedFault.MAX_DESCRIPTION)
                {
                    Console.WriteLine("Description is too long.");
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
                rfNew = new ReportedFault(
                        shortDescription,
                        ElectronicComponentsService.FindById(id),
                        description);
                if ((rfNew.Id = ReportedFaultService.Save(rfNew)) != "")
                {
                    Console.WriteLine("Added new fault to a database with success.");
                }
                else
                {
                    Console.WriteLine("Could not add new fault to a database.");
                    Console.ReadKey();
                    return UserInterface.ShowStartingInterface();
                }
            }catch(DbException dex)
            {
                Console.WriteLine($"There was a database exception: {dex.Message}");
                Console.ReadKey();
                return UserInterface.ShowStartingInterface();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"There was an unhandled exception: {ex.Message}");
                Console.ReadKey();
                return UserInterface.ShowStartingInterface();
            }
            do
            {
                Console.WriteLine("----------------------------------------------");
                Console.Write("Please enter the number of undertaken measures for entered fault: ");
                tmpActionNum = Console.ReadLine();
                if(!short.TryParse(tmpActionNum, out numAction))
                {
                    Console.WriteLine("Number of undertaken measures must be a number.");
                    isOk = false;
                    continue;
                }
                if(numAction < 0)
                {
                    Console.WriteLine("Number of undertaken measures can't be less than zero.");
                    isOk = false;
                    continue;
                }
                else
                {
                    isOk = true;
                }
            } while (!isOk);

            if(numAction != 0) {
                Console.WriteLine("You will be transfered to another UI for entering actions for entered new fault.");
                Console.ReadKey();
                AddFaultAction actions = new AddFaultAction();
                actions.ShowComponent(rfNew, numAction);
            }
            else
            {
                Console.WriteLine("You canceled adding actions. You can add them later via menu.");
            }
            Console.ReadKey();
            return UserInterface.ShowStartingInterface();
        }
        
    }
}
