using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models;
using System.Data;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces
{
    interface IElectronicElementsTypesDAO : ICRUDDao<ElectronicComponentsTypes, int>
    {
        ElectronicComponentsTypes FindById(int id, IDbConnection conn);
    }
}
