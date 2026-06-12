using IDGS904ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS904ASP.Controllers
{
    public class ResistenciaController : Controller
    {
        private Dictionary<string, int> ValoresBanda = new Dictionary<string, int>()
        {
            { "Negro",    0 },
            { "Cafe",     1 },
            { "Rojo",     2 },
            { "Naranja",  3 },
            { "Amarillo", 4 },
            { "Verde",    5 },
            { "Azul",     6 },
            { "Violeta",  7 },
            { "Gris",     8 },
            { "Blanco",   9 }
        };

        private Dictionary<string, long> Multiplicadores = new Dictionary<string, long>()
        {
            { "Negro",    1 },
            { "Cafe",     10 },
            { "Rojo",     100 },
            { "Naranja",  1000 },
            { "Amarillo", 10000 },
            { "Verde",    100000 },
            { "Azul",     1000000 },
            { "Violeta",  10000000 },
            { "Gris",     100000000 },
            { "Blanco",   1000000000 }
        };

        private List<SelectListItem> ObtenerColores()
        {
            var lista = new List<SelectListItem>();
            lista.Add(new SelectListItem() { Text = "Negro", Value = "Negro" });
            lista.Add(new SelectListItem() { Text = "Cafe", Value = "Cafe" });
            lista.Add(new SelectListItem() { Text = "Rojo", Value = "Rojo" });
            lista.Add(new SelectListItem() { Text = "Naranja", Value = "Naranja" });
            lista.Add(new SelectListItem() { Text = "Amarillo", Value = "Amarillo" });
            lista.Add(new SelectListItem() { Text = "Verde", Value = "Verde" });
            lista.Add(new SelectListItem() { Text = "Azul", Value = "Azul" });
            lista.Add(new SelectListItem() { Text = "Violeta", Value = "Violeta" });
            lista.Add(new SelectListItem() { Text = "Gris", Value = "Gris" });
            lista.Add(new SelectListItem() { Text = "Blanco", Value = "Blanco" });
            return lista;
        }

        // GET
        public ActionResult Resistencia()
        {
            ViewBag.Colores = ObtenerColores();

            if (Session["Resultados"] == null)
            {
                Session["Resultados"] = new List<ResistenciaResultado>();
            }

            ViewBag.Resultados = Session["Resultados"];
            return View("Resistencia");
        }

        // POST
        [HttpPost]
        public ActionResult Resistencia(Resistencia res)
        {
            ViewBag.Colores = ObtenerColores();

            // Calcular
            int b1 = ValoresBanda[res.Color1];
            int b2 = ValoresBanda[res.Color2];
            long mult = Multiplicadores[res.Color3];

            double valor = (b1 * 10 + b2) * mult;

            double porcentaje = (res.Tolerancia == "Oro") ? 0.05 : 0.10;
            double margen = valor * porcentaje;

            // Crear el resultado nuevo
            var nuevoResultado = new ResistenciaResultado()
            {
                Color1 = res.Color1,
                Color2 = res.Color2,
                Color3 = res.Color3,
                Tolerancia = res.Tolerancia == "Oro" ? "Dorado 5%" : "Plata 10%",
                Valor = valor,
                ValorMax = valor + margen,
                ValorMin = valor - margen
            };

            var lista = (List<ResistenciaResultado>)Session["Resultados"];
            lista.Add(nuevoResultado);
            Session["Resultados"] = lista;

            ViewBag.Resultados = lista;
            return View("Resistencia");
        }
    }
}