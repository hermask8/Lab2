using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace Lab2_Edwin_Ana.Models
{
    public class IngresoEntero: IComparable<IngresoEntero>
    {
        public int Valor { get; set; }

        public int CompareTo(IngresoEntero other)
        {
            return Valor.CompareTo(other.Valor);
        }
    }
}