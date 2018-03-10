using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab2_Edwin_Ana.Models;

namespace Lab2_Edwin_Ana.Data
{
    public class DatosPaises
    {
        private static DatosPaises instance;
        public static DatosPaises Instance
        {
            get
            {
                if (instance == null) instance = new DatosPaises();
                return instance;
            }
        }

        
        public BibliotecaArbol.Arbol<Pais> arbol;
        public DatosPaises()
        {
            arbol = new BibliotecaArbol.Arbol<Pais>();
        }
       
    }
}