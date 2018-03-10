using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;

namespace Lab2_Edwin_Ana.Models
{
    public class Pais: IComparable<Pais>
    {
        public string Nombre { get; set; }
        public string Grupo { get; set; }


        public int CompareTo(Pais other)
        {
           return this.Nombre.CompareTo(other.Nombre);
        }

       
        //public string Grupo { get; set; }
    }
}