using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models
{
    class ElectronicComponentsTypes
    {
        int id;
        string name;
        public ElectronicComponentsTypes(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int Id
        {
            get
            {
                return id;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
    }
}
