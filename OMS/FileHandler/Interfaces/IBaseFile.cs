using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.FileHandler.Interfaces
{
    interface IBaseFile<T>
    {
        void GenerateDocument(IEnumerable<T> objToGenerateFrom);
    }
}
