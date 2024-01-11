using System;

namespace OMS.Models.Base
{
    public class ElectronicComponentsTypes : BaseIntKey
    {
        int id;
        string name;
        public ElectronicComponentsTypes(int id, string name)
        {
            if(id < 0 || name == null || name.Length == 0)
            {
                throw new ArgumentException();
            }
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
        public new static string GetFormattedHeader()
        {
            return String.Format("{0, -4}|{1, -8}", "ID", "NAME");
        }
        public override string ToString()
        {
            return String.Format("{0, -4}|{1, -8}", id, name);
        }
    }
}
