using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using directorios = System.IO;
using Lab2_Edwin_Ana.Models;
using Lab2_Edwin_Ana.Data;
using System.Data;

namespace Lab2_Edwin_Ana.Controllers
{
    public class ArbolesController : Controller
    {

        // GET: Lista Arboles pais en odenes
        public ActionResult RetornoInOrdenPais()
        {
            List<Pais> miLista = new List<Pais>();
            miLista = Data.DatosPaises.Instance.arbol.retornarListaInOrden();
            return View("Listado",miLista);
        }
        public ActionResult RetornoPostOrdenPais()
        {
            List<Pais> miLista = new List<Pais>();
            miLista = Data.DatosPaises.Instance.arbol.retornarListaPostOrden();
            return View("Listado", miLista);
        }
        public ActionResult RetornoPreOrdenPais()
        {
            List<Pais> miLista = new List<Pais>();
            miLista = Data.DatosPaises.Instance.arbol.retornarLista();
            return View("Listado", miLista);
        }

        // GET: Lista Arboles string en odenes
        public ActionResult RetornoInOrdenString()
        {
            List<string> miLista = new List<string>();
            miLista = Data.Datos.Instance.arbol.retornarListaInOrden();
            return View("Listado2", miLista);
        }
        public ActionResult RetornoPostOrdenString()
        {
            List<string> miLista = new List<string>();
            miLista = Data.Datos.Instance.arbol.retornarListaPostOrden();
            return View("Listado2", miLista);
        }
        public ActionResult RetornoPreOrdenString()
        {
            List<string> miLista = new List<string>();
            miLista = Data.Datos.Instance.arbol.retornarLista();
            return View("Listado2", miLista);
        }

        // GET: Lista Arboles enteros en odenes
        public ActionResult RetornoInOrdenInt()
        {
            List<int> miLista = new List<int>();
            miLista = Data.DatosEnteros.Instance.arbol.retornarListaInOrden();
            return View("Listado3", miLista);
        }
        public ActionResult RetornoPostOrdenInt()
        {
            List<int> miLista = new List<int>();
            miLista = Data.DatosEnteros.Instance.arbol.retornarListaPostOrden();
            return View("Listado3", miLista);
        }
        public ActionResult RetornoPreOrdenInt()
        {
            List<int> miLista = new List<int>();
            miLista = Data.DatosEnteros.Instance.arbol.retornarLista();
            return View("Listado3", miLista);
        }

        //Listado de elementos de tipo pais
        public ActionResult Listado()
        {
            return View();
        }
        //Listado de elementos de tipo cadena 
        public ActionResult Listado2()
        {
            return View();
        }
        //Listados de elementos de tipo int
        public ActionResult Listado3()
        {
            return View();
        }
        //Ingreso de cadenas de fora automatica con json
        public ActionResult IngresoString()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IngresoString(HttpPostedFileBase Archivo)
        {
            string pathArchivo = string.Empty;
            if (Archivo != null)
            {
                
                var json = directorios.File.ReadAllText(Archivo.FileName);
                var archivoJson = JsonConvert.DeserializeObject<IngresoCadena2>(json);
                agregar2(archivoJson);
            }

            List<string> miLista = new List<string>();
            miLista = Data.Datos.Instance.arbol.retornarLista();
            return View("Listado2", miLista);
        }
        //Funcion eliminar
        public ActionResult Eliminar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Eliminar(FormCollection eliminarDato)
        {
            string dato = eliminarDato["Nombre"];
           // Datos.Instance.arbol.EliminarNodo(eliminarDato);
            return View();
        }
        //Ingresar enteros de forma automatica con json
        public ActionResult IngresoEntero()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IngresoEntero(HttpPostedFileBase archivo)
        {
            string pathArchivo = string.Empty;
            if (archivo != null)
            {
                var json = directorios.File.ReadAllText(archivo.FileName);
                var archivoJson = JsonConvert.DeserializeObject<IngresoEntero2>(json);
                agregar3(archivoJson);
            }

            List<int> miLista = new List<int>();
            miLista = Data.DatosEnteros.Instance.arbol.retornarLista();
            return View("Listado3", miLista);
        }
        //Ingreso de paises de forma automatica con json
        public ActionResult IngresoPais()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IngresoPais(HttpPostedFileBase archivo)
        {
            string pathArchivo = string.Empty;
            if (archivo != null)
            {
                var json = directorios.File.ReadAllText(archivo.FileName);
                var archivoJson = JsonConvert.DeserializeObject<pais2>(json);
                agregar(archivoJson);
            }

            List<Pais> miLista = new List<Pais>();
            miLista.Clear();
            miLista = Data.DatosPaises.Instance.arbol.retornarLista();
            return View("Listado",miLista);
        }

        //Hacer recorridos para agregar al arbol
        public void agregar(pais2 elementos)
        {
            if (elementos!=null)
            {
                Data.DatosPaises.Instance.arbol.Insertar(elementos.valor);
                agregar(elementos.izquierdo);
                agregar(elementos.derecho);
            }
        }
        public void agregar2(IngresoCadena2 elementos)
        {
            if (elementos != null)
            {
                Data.Datos.Instance.arbol.Insertar(elementos.valor);
                agregar2(elementos.izquierdo);
                agregar2(elementos.derecho);
            }
        }
        public void agregar3(IngresoEntero2 elementos)
        {
            if (elementos != null)
            {
                Data.DatosEnteros.Instance.arbol.Insertar(elementos.valor);
                agregar3(elementos.izquierdo);
                agregar3(elementos.derecho);
            }
        }
        public ActionResult IngresoPaisManual()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IngresoPaisManual(FormCollection ingreso)
        {
            var model = new Pais
            {
                Nombre = ingreso["Nombre"],
                Grupo = ingreso["Grupo"]
            };
            Data.DatosPaises.Instance.arbol.Insertar(model);
            List<Pais> MiLista = new List<Pais>();
            MiLista = Data.DatosPaises.Instance.arbol.retornarLista();
            return View("Listado",MiLista);
        }

        public ActionResult IngresoStringManual()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IngresoStringManual(string Nombre)
        {
            string nuevo = Nombre;
            Data.Datos.Instance.arbol.Insertar(nuevo);
            List<string> MiLista = new List<string>();
            MiLista = Data.Datos.Instance.arbol.retornarLista();
            return View("Listado2", MiLista);
        }

        public ActionResult IngresoIntManual()
        {

            return View();
        }
        [HttpPost]
        public ActionResult IngresoIntManual(string ingreso)
        {
            int valor = int.Parse(ingreso);
            Data.DatosEnteros.Instance.arbol.Insertar(valor);
            List<int> MiLista = new List<int>();
            MiLista = Data.DatosEnteros.Instance.arbol.retornarLista();
            return View("Listado3", MiLista);
        }

    }
}
