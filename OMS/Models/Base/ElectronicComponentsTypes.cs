﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Models.OracleSQL;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace OMS.Models
{
    public class ElectronicComponentsTypes
    {
        public static readonly int NewElectronicComponentTypeId = -1;
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
        public static string GetFormattedHeader()
        {
            return String.Format("{0, -4}|{1, -8}", "ID", "NAME");
        }
        public override string ToString()
        {
            return String.Format("{0, -4}|{1, -8}", id, name);
        }
    }
}
