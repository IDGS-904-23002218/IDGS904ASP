using IDGS904ASP.Models;
using IDGS904ASP.Servicios;
using System.Web.Mvc;

namespace IDGS904ASP.Controllers
{
    public class DiccionarioController : Controller
    {
        // GET - Capturar
        public ActionResult Capturar()
        {
            return View("Capturar");
        }

        // POST - Capturar
        [HttpPost]
        public ActionResult Capturar(Palabra palabra)
        {
            if (string.IsNullOrEmpty(palabra.Espanol) || string.IsNullOrEmpty(palabra.Ingles))
            {
                ViewBag.Error = "Debes escribir ambas palabras.";
                return View("Capturar");
            }

            var servicio = new GuardaDiccionarioService();
            servicio.GuardaArchivo(palabra.Espanol, palabra.Ingles);

            ViewBag.Mensaje = "Palabra guardada correctamente.";
            return View("Capturar");
        }

        // GET - Buscar
        public ActionResult Buscar()
        {
            return View("Buscar");
        }

        // POST - Buscar
        [HttpPost]
        public ActionResult Buscar(Busqueda busqueda)
        {
            if (string.IsNullOrEmpty(busqueda.Termino))
            {
                ViewBag.Error = "Escribe una palabra para buscar.";
                return View("Buscar");
            }

            var leer = new LeerDiccionarioService();
            string[] espanol = leer.LeerEspanol();
            string[] ingles = leer.LeerIngles();

            if (espanol == null || ingles == null)
            {
                ViewBag.Error = "No hay palabras guardadas aún.";
                return View("Buscar");
            }

            // for con índice para relacionar los dos archivos
            // línea 1 de espanol.txt corresponde a línea 1 de ingles.txt
            for (int i = 0; i < espanol.Length; i++)
            {
                if (busqueda.Idioma == "Espanol")
                {
                    // Busco en español, devuelvo inglés
                    if (espanol[i].ToLower() == busqueda.Termino.ToLower())
                    {
                        ViewBag.Termino = busqueda.Termino;
                        ViewBag.Resultado = ingles[i];
                        ViewBag.Idioma = busqueda.Idioma;
                        return View("Buscar");
                    }
                }
                else
                {
                    // Busco en inglés, devuelvo español
                    if (ingles[i].ToLower() == busqueda.Termino.ToLower())
                    {
                        ViewBag.Termino = busqueda.Termino;
                        ViewBag.Resultado = espanol[i];
                        ViewBag.Idioma = busqueda.Idioma;
                        return View("Buscar");
                    }
                }
            }

            ViewBag.Error = "Palabra no encontrada.";
            return View("Buscar");
        }
    }
}