using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models;

namespace OMS.Classes.DatabaseHandlerClasses.DAO.DAOInterfaces
{
    public interface ICRUDDao<T, ID>
    {
        IEnumerable<T> FindAll();
        T FindById(ID id);
        bool ExistsById(ID id);
        bool DeleteOne(T toDelete);
        bool Save(T newEntity);
    }
}
