using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace OMS.Classes.UserInterfaceClasess
{
    class RecordEE : IUserInterfaceComponent
    {
        private readonly short MAX_SHORT_DESCTRIPTION = 256;
        public short ShowCopmonent()
        {
            bool isOk = true;
            int id;
            int idType;
            string tmpId;
            string shortDestcription;
            string tmp;
            Point xy;
            int x, y;
            string tmpOption;
            short option;
            do
            {
                if (!isOk)
                {
                    Console.WriteLine("Ops you enter something wrong. Please try again");
                    isOk = true;
                }
                Console.WriteLine("----------------------------------------------");
                Console.Write("Enter the id of the electrical element: ");
                tmpId = Console.ReadLine();
                if (!int.TryParse(tmpId, out id) || id < 0)
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
                Console.Write("Enter the name of electrical element: ");
                shortDestcription = Console.ReadLine();
                if (shortDestcription.Length == 0 || shortDestcription.Length > MAX_SHORT_DESCTRIPTION)
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
                Console.Write("Enter the id of the electrical element: ");
                tmpId = Console.ReadLine();
                if (!int.TryParse(tmpId, out idType) || idType < 0)
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
                Console.Write("Enter x coordinate: ");
                tmp = Console.ReadLine();
                if (!int.TryParse(tmp, out x))
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
                Console.Write("Enter y coordinate: ");
                tmp = Console.ReadLine();
                if (!int.TryParse(tmp, out y))
                {
                    isOk = false;
                }
                else
                {
                    isOk = true;
                }
            } while (!isOk);

            xy = new Point(x, y);

            do
            {
                Console.WriteLine("Please choose option of voltage level: ");
                Console.WriteLine("1.) Low voltage");
                Console.WriteLine("2.) Medium voltage");
                Console.WriteLine("3.) High voltage");
                tmpOption = Console.ReadLine();
                if (!short.TryParse(tmpOption, out option))
                {
                    isOk = false;
                }
                else
                {
                    isOk = true;
                }
            } while (!isOk);

            return 0;
        }
    }
}
