using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes;
using OMS.Classes.UserInterfaceClasess;

namespace OMS
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface.ShowInterface((IUserInterfaceComponent)UserInterface.ResolveOption(UserInterface.ShowStartingInterface()));   
        }
    }
}
