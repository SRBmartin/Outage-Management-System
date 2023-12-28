using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces;
using OMS.Models.Base;
using System.Data;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces
{
    interface IElectronicComponentsDAO : ICRUDDao<ElectronicComponents,int>
    {
        ElectronicComponents FindById(int id, IDbConnection conn);
    }
}
