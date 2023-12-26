using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces;
using OMS.Models.Base;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces
{
    interface IElectronicComponentsDAO : ICRUDDao<ElectronicComponents,int>
    {
    }
}
