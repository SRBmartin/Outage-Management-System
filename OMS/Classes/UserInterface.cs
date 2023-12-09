using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.UserInterfaceClasess;

namespace OMS.Classes
{
    class UserInterface
    {
        public static void ShowInterface(IUserInterfaceComponent menuId) {
            menuId.ShowCopmonent();
        }
    }
}
