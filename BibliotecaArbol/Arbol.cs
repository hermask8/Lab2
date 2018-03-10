using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaArbol
{
    public class Nodo<T>
    {
        public Nodo<T> izquierdo { get; set; }
        public Nodo<T> derecho { get; set; }
        public T data { get; set; }

        
    }

    public class Arbol<T> where T: IComparable<T>
    {
        List<T> listaRetorno = new List<T>();
        Nodo<T> raiz { get; set; }
        //Nodo<T> ntemp;
        public Arbol()
        {
            raiz = null;
        }
      
       
        public void Insertar(T dtInfo)
        {
            if (dtInfo!=null)
            {
                Nodo<T> ntemp = new Nodo<T>();
                //ntemp = null;
                ntemp.data = dtInfo;
                ntemp.derecho = null;
                ntemp.izquierdo = null;

                if (raiz == null)
                {
                    raiz = ntemp;
                }
                else
                {
                    Nodo<T> nAux = raiz;
                    Nodo<T> nPafre = raiz;
                    bool bDerecha = false;
                    while (nAux != null)
                    {

                        nPafre = nAux;
                        if (dtInfo.CompareTo(nAux.data) == 1)
                        {
                            nAux = nAux.derecho;
                            bDerecha = true;
                        }
                        else
                        {
                            nAux = nAux.izquierdo;
                            bDerecha = false;
                        }
                    }
                    if (bDerecha == true)
                    {
                        nPafre.derecho = ntemp;
                    }
                    else
                    {
                        nPafre.izquierdo = ntemp;
                    }

                }

            }
        }

        //Recorrido en inorden
        private void InOrden(Nodo<T> nAux)
        {
            if (nAux != null)
            {
                InOrden(nAux.izquierdo);
                listaRetorno.Add(nAux.data);
                InOrden(nAux.derecho);
            }
        }

        public void InOrden()
        {
            listaRetorno.Clear();
            InOrden(raiz);
        }

        //Recorrido en postorden
        private void PostOrden(Nodo<T> nAux)
        {
            if (nAux != null)
            {

                PostOrden(nAux.izquierdo);
                PostOrden(nAux.derecho);
                listaRetorno.Add(nAux.data);
            }
        }
        public void PostOrden()
        {
            listaRetorno.Clear();
            PostOrden(raiz);
        }

        //Recorrido preorden
        private void PreOrden(Nodo<T> nAux)
        {
            
            if (nAux != null)
            {

                listaRetorno.Add(nAux.data);
                PreOrden(nAux.izquierdo);
                PreOrden(nAux.derecho);
            }
        }
        public void PreOrden()
        {
            listaRetorno.Clear();
            PreOrden(raiz);
        }

        public List<T> retornarLista()
        {
            PreOrden();
            return listaRetorno;
        }
        public List<T> retornarListaPostOrden()
        {
            PostOrden();
            return listaRetorno;
        }
        public List<T> retornarListaInOrden()
        {
            InOrden();
            return listaRetorno;
        }
        
        internal Nodo<T> BuscaDerecho(ref Nodo<T> nodo)
        {
            if (nodo != null)
            {
                while (nodo.derecho != null)
                {
                    nodo = nodo.derecho;
                }
            }
            return (nodo);
        }
        
        internal Nodo<T> BuscaIzquierda(ref Nodo<T> nodo)
        {
            if (nodo != null)
            {
                while (nodo.izquierdo != null)
                {
                    nodo = nodo.izquierdo;
                }
            }
            return (nodo);
        }

       
    }
}
