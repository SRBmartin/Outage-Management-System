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
    class DeleteComponent : IUserInterfaceComponent
    {
        public short ShowCopmonent()
        {
            string idInput;
            int id;
            bool isOk = true;
            try
            {
                do
                {
                    Console.Write("Please enter ID of electronic component you would like to delete: ");
                    idInput = Console.ReadLine();
                    if (!int.TryParse(idInput, out id))
                    {
                        Console.WriteLine("ID must be a number.");
                        isOk = false;
                        continue;
                    }
                    if (id <= 0)
                    {
                        Console.WriteLine("ID must be greater than 0.");
                        isOk = false;
                        continue;
                    }
                    ElectronicComponents toCheck = ElectronicComponentsService.FindById(id);
                    if(toCheck == null)
                    {
                        Console.WriteLine("Couldn't found that electronic component in database.");
                        isOk = false;
                        continue;
                    }
                    char option = 'N';
                    Console.WriteLine("Are you sure you want to delete?\n{0}", toCheck);
                    Console.Write("\nEnter you decision (Y/n): ");
                    option = Char.ToLower(Console.ReadKey().KeyChar);
                    if(option == 'y')
                    {
                        if (ElectronicComponentsService.DeleteOne(toCheck))
                        {
                            Console.WriteLine("\nDelete operation was a success.");
                        }
                        else
                        {
                            Console.WriteLine("\nDelete operation failed.");
                        }
                        isOk = true;
                    }
                    else
                    {
                        Console.WriteLine("\nDelete operation was canceled.");
                        isOk = true;
                    }
                } while (!isOk);
            }catch(DbException dex)
            {
                if (dex.Message.Contains("ORA-02292"))
                {
                    Console.WriteLine("You can't delete that component because at least one fault is assigned to this component.");
                }
                else
                {
                    Console.WriteLine($"Database exception occured: {dex.Message}");
                }
            }catch(Exception ex)
            {
                Console.WriteLine($"An exception occured: {ex.Message}");
            }
            Console.ReadKey();
            return UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
        }
    }
}
