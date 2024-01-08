using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Models.Base
{
    public class ElectronicComponents
    {
        public static readonly int MAX_NAME_SIZE = 256;
        public static readonly string[] ALLOWED_VOLTAGE_LEVELS = { "low voltage", "medium voltage", "high voltage" };
        public static readonly int NEW_ELECTRONIC_COMPONENT_ID = -1;
        private int id;
        private string name;
        private ElectronicComponentsTypes type;
        private int x;
        private int y;
        private string voltage_level;
        public ElectronicComponents() //added for testing other classes (Unit tests)
        {

        }
        public ElectronicComponents(int id, string name, ElectronicComponentsTypes type, int x, int y, string voltage_level)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.x = x;
            this.y = y;
            this.voltage_level = voltage_level;
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
        public ElectronicComponentsTypes Type
        {
            get
            {
                return type;
            }
        }
        public int X
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
        }
        public string Voltage_level
        {
            get
            {
                return voltage_level;
            }
        }
        public static string GetFormatedHeader()
        {
            return String.Format("{0, -4} | {1, -8} | {2, -8} | {3, -4} | {4, -4} | {5, -8}", "ID", "NAME", "[ID|TYPE NAME]", "X", "Y", "VOLTAGE LEVEL");
        }
        public override string ToString()
        {
            return String.Format("{0, -4} | {1, -8} | {2, -14} | {3, -4} | {4, -4} | {5, -8}",
                                id, name,
                                " [" + type.Id + "|" + type.Name + "] ",
                                x, y, voltage_level);
        }
    }
}
