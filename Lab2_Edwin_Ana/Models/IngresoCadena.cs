using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Edwin_Ana.Models
{
    public class IngresoCadena: IComparable<IngresoCadena>
    {
        public string Ingreso { get; set; }
        
        public int CompareTo(IngresoCadena other)
        {
            return Ingreso.CompareTo(other.Ingreso);
        }
    }
}