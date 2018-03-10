using Lab2_Edwin_Ana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Edwin_Ana.Data
{
    public class DatosEnteros
    {
        private static DatosEnteros instance;
        public static DatosEnteros Instance
        {
            get
            {
                if (instance == null) instance = new DatosEnteros();
                return instance;
            }
        }


        public BibliotecaArbol.Arbol<int> arbol;
        public DatosEnteros()
        {
            arbol = new BibliotecaArbol.Arbol<int>();
        }
    }
}