using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models.Base;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces
{
    interface IFaultActionDAO : ICRUDDao<FaultAction, int>
    {
        IEnumerable<FaultAction> FindAllByFaultId(string targetId);
    }
}
