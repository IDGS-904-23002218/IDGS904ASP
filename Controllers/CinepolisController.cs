using IDGS904ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS904ASP.Controllers
{
    public class CinepolisController : Controller
    {
        // GET: Cinepolis
        public ActionResult Cinepolis()
        {
            return View("Cinepolis");
        }

        [HttpPost]
        public ActionResult Cinepolis(Cinepolis cine)
        {
            double total = 0;
            double precioBoleto = 12;

            // Validar máximo 7 boletos por persona
            if (cine.CantidadBoletos > (cine.CantidadCompradores * 7))
            {
                ViewBag.Error = "No se pueden comprar más de 7 boletos por persona.";
                return View();
            }

            total = cine.CantidadBoletos * precioBoleto;

            // Descuento por cantidad de boletos
            if (cine.CantidadBoletos > 5)
            {
                total = total - (total * 0.15);
            }
            else if (cine.CantidadBoletos >= 3)
            {
                total = total - (total * 0.10);
            }

            // Descuento tarjeta CINECO
            if (cine.Tarjeta == true)
            {
                total = total - (total * 0.10);
            }

            ViewBag.Nombre = cine.Nombre;
            ViewBag.Total = total;

            return View("Cinepolis");
        }
    }
}