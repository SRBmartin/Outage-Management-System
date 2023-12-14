using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.ElectronicalComponentsClasses;

namespace OMS.Classes.UserInterfaceClasess
{
    class FaultEntry : IUserInterfaceComponent
    {
        private readonly short MAX_SHORT_DESCTRIPTION = 256;
        private readonly short MAX_DESCTRIPTION = 1024;
        public short ShowCopmonent()
        {
            string shortDestcription;
            bool isOk = true;
            string tmpId;
            int id;
            string desctription;
            string tmpActionNum;
            short numAction;
            string actionDestcription;
            FailuresActionsList fActionsList = new FailuresActionsList();
            
            do
            {
                if (!isOk)
                {
                    Console.WriteLine("Ops you enter something wrong. Please try again");
                    isOk = true;
                }
                Console.WriteLine("----------------------------------------------");
                Console.Write("Enter a  short destription of the fault: ");
                shortDestcription = Console.ReadLine();
                if(shortDestcription.Length == 0 || shortDestcription.Length > MAX_SHORT_DESCTRIPTION)
                {
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
                Console.WriteLine("----------------------------------------------");
                Console.Write("Enter the id of the failed element: ");
                tmpId = Console.ReadLine();
                if(!int.TryParse(tmpId, out id) || id < 0)
                {
                    isOk = false;

                }
                else
                {
                    isOk = true;
                } 
               

            } while (!isOk);

            do
            {
                if (!isOk)
                {
                    Console.WriteLine("Ops you enter something wrong. Please try again");
                    isOk = true;
                }
                Console.WriteLine("----------------------------------------------");
                Console.Write("Please add a full desctription: ");
                desctription = Console.ReadLine();
                if(desctription.Length == 0 || desctription.Length > MAX_DESCTRIPTION)
                {
                    isOk = false;
                }
                else
                {
                    isOk = true;
                }
                

            } while (!isOk);

            do
            {

                if (!isOk)
                {
                    Console.WriteLine("Ops you enter something wrong. Please try again");
                    isOk = true;
                }
                Console.WriteLine("----------------------------------------------");
                Console.Write("Please enter the number of undertaken measures: ");
                tmpActionNum = Console.ReadLine();
                if(!short.TryParse(tmpActionNum, out numAction))
                {
                    isOk = false;
                }
                else
                {
                    isOk = true;
                }
                if(numAction < 0)
                {
                    isOk = false;
                }
                else
                {
                    isOk = true;
                }
                
            } while (!isOk);

            if(numAction != 0) {
                for (short i = 0; i < numAction; i++)
                {
                    DateTime actionDate;

                    do
                    {
                        Console.Write("Enter date of action (format: yyyy-MM-dd HH:mm:ss): ");
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
                        Console.Write("Enter a  short destription of action: ");
                        actionDestcription = Console.ReadLine();
                        if (actionDestcription.Length == 0 || actionDestcription.Length > MAX_SHORT_DESCTRIPTION)
                        {
                            isOk = false;
                        }
                    } while (!isOk);
                    fActionsList.addNewAction(new FailuresActions(actionDate, actionDestcription));

                }
            }

            return UserInterface.ShowStartingInterface();
        }
        
    }
}
