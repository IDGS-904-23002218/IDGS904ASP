using IDGS904ASP.Models;
using IDGS904ASP.Servicios;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IDGS904ASP.Controllers
{
    public class CesarController : Controller
    {
        public ActionResult Menu()
        {
            return View("Menu");
        }

        public ActionResult Encriptar()
        {
            return View("Encriptar");
        }

        [HttpPost]
        public ActionResult Encriptar(Encriptar enc)
        {
            if (string.IsNullOrEmpty(enc.Frase))
            {
                ViewBag.Error = "Escribe una frase.";
                return View("Encriptar");
            }

            if (enc.Desplazamiento <= 0)
            {
                ViewBag.Error = "El desplazamiento debe ser un número positivo.";
                return View("Encriptar");
            }

            var servicio = new CesarService();
            string fraseEncriptada = servicio.Encriptar(enc.Frase, enc.Desplazamiento);
            servicio.GuardarFrase(enc.Frase, fraseEncriptada, enc.Desplazamiento);

            ViewBag.FraseOriginal = enc.Frase;
            ViewBag.FraseEncriptada = fraseEncriptada;
            ViewBag.Mensaje = "Frase guardada correctamente.";

            return View("Encriptar");
        }

        public ActionResult Desencriptar()
        {
            var servicio = new CesarService();
            var lineas = servicio.LeerFrases();

            var lista = new List<SelectListItem>();

            if (lineas != null)
            {
                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split(',');
                    lista.Add(new SelectListItem()
                    {
                        Text = partes[1],
                        Value = linea
                    });
                }
            }

            ViewBag.Frases = lista;
            return View("Desencriptar");
        }

        [HttpPost]
        public ActionResult Desencriptar(Desencriptar des)
        {
            var servicio = new CesarService();
            var lineas = servicio.LeerFrases();

            var lista = new List<SelectListItem>();
            if (lineas != null)
            {
                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split(',');
                    lista.Add(new SelectListItem()
                    {
                        Text = partes[1],
                        Value = linea
                    });
                }
            }
            ViewBag.Frases = lista;

            if (des.Desplazamiento <= 0)
            {
                ViewBag.Error = "El desplazamiento debe ser un número positivo.";
                return View("Desencriptar");
            }

            string[] datos = des.FraseEncriptada.Split(',');
            string fraseOriginal = datos[0];
            string fraseEncriptada = datos[1];

            string fraseDesencriptada = servicio.Desencriptar(fraseEncriptada, des.Desplazamiento);

            ViewBag.FraseDesencriptada = fraseDesencriptada;
            ViewBag.FraseOriginal = fraseOriginal;

            if (fraseDesencriptada.ToLower() == fraseOriginal.ToLower())
            {
                ViewBag.Correcto = "Desencriptación correcta";
            }
            else
            {
                ViewBag.Incorrecto = "Desencriptación incorrecta, verifica el desplazamiento.";
            }

            return View("Desencriptar");
        }
    }
}