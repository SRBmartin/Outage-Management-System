using System;
using OMS.Models.Base;
using OMS.Models;
using OMS.Services;
using System.Data.Common;

namespace OMS.Classes.UserInterfaceClasess
{
    class AddComponent : IUserInterfaceComponent
    { 
        public short ShowCopmonent()
        {
            bool isOk = true;
            int idType;
            ElectronicComponentsTypes type = null;
            string name;
            string tmpId;
            string tmp;
            int x, y;
            string tmpOption;
            short option;
            string voltage_level = "medium voltage";
            Console.WriteLine("--- ADDING ELECTRONIC COMPONENT ---");
            do
            {
                Console.Write("Enter the name of new electronic element: ");
                name = Console.ReadLine();
                if (name.Length == 0)
                {
                    Console.WriteLine("The name is too short.");
                    isOk = false;
                    continue;
                }
                if(name.Length > ElectronicComponents.MAX_NAME_SIZE)
                {
                    Console.WriteLine("The name is too long.");
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
                Console.Write("Enter the id of the electrical element type: ");
                tmpId = Console.ReadLine();
                if (!int.TryParse(tmpId, out idType))
                {
                    Console.WriteLine("ID of type must be a number.");
                    isOk = false;
                    continue;
                }
                if (idType < 0)
                {
                    Console.WriteLine("ID of type must be greater than 0.");
                    isOk = false;
                    continue;
                }
                else
                {
                    if ((type = ElectronicComponentsTypesService.FindById(idType)) == null)
                    {
                        Console.WriteLine("That ID of type does not exist.");
                        isOk = false;
                        continue;
                    }
                    else
                    {
                        isOk = true;
                    }
                }
            } while (!isOk);

            do
            {
                Console.Write("Enter x coordinate: ");
                tmp = Console.ReadLine();
                if (!int.TryParse(tmp, out x))
                {
                    Console.WriteLine("X coordinate must be a number.");
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
                Console.Write("Enter y coordinate: ");
                tmp = Console.ReadLine();
                if (!int.TryParse(tmp, out y))
                {
                    Console.WriteLine("Y coordinate must be a number.");
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
                Console.WriteLine("Please choose option of voltage level: ");
                Console.WriteLine("1.) Low voltage");
                Console.WriteLine("2.) Medium voltage");
                Console.WriteLine("3.) High voltage");
                Console.Write("Enter the option: ");
                tmpOption = Console.ReadLine();
                if (!short.TryParse(tmpOption, out option))
                {
                    Console.WriteLine("Option must be a number.");
                    isOk = false;
                    continue;
                }
                else
                {
                    if(option < 1 || option > 3)
                    {
                        Console.WriteLine("Available options are 1, 2 or 3.");
                        isOk = false;
                        continue;
                    }
                    else
                    {
                        voltage_level = ElectronicComponents.ALLOWED_VOLTAGE_LEVELS[option - 1];
                        isOk = true;
                    }
                }
            } while (!isOk);
            try
            {
                if (ElectronicComponentsService.Save(new ElectronicComponents(
                                ElectronicComponents.NEW_ID,
                                name,
                                type,
                                x,
                                y,
                                voltage_level)))
                {
                    Console.WriteLine("Added new electronic component with success.");
                }
                else
                {
                    Console.WriteLine("An error occured while adding a new electronic component.");
                }
                Console.ReadKey();
            }
            catch (DbException dex)
            {
                Console.WriteLine($"Database exception happened: {dex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception occured: {ex.Message}");
            }
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));
            return 0;
        }
    }
}
