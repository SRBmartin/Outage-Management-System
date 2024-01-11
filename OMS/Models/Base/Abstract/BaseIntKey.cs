using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models.Base.Abstract;

namespace OMS.Models.Base
{
    public abstract class BaseIntKey : BaseAbstract
    {
        public readonly static int NEW_ID = -1;
    }
}
