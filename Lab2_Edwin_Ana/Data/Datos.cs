using Lab2_Edwin_Ana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2_Edwin_Ana.Data
{
    public class Datos
    {
        private static Datos instance;
        public static Datos Instance
        {
            get
            {
                if (instance == null) instance = new Datos();
                return instance;
            }
        }

        
        public BibliotecaArbol.Arbol<string> arbol;
        public Datos()
        {
            arbol = new BibliotecaArbol.Arbol<string>();
        }

       
    }
}