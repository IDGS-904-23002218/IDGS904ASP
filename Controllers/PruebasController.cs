using IDGS904ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS904ASP.Controllers
{
    public class PruebasController : Controller
    {
        // GET: Pruebas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Nombre = "Juan Carlos López Ruiz";
            ViewBag.Titulo = "IDGS";
            ViewData["Materia"] = "DWI";
            return View();
        }

        public ActionResult Empleado()
        {
            var persona = new Persona()
            {
                Nombre = "Carlos",
                Edad = 21,
                Empleado = false,
                Nacimiento = new DateTime(2005, 1, 1)
            };
            ViewBag.Propiedades = persona;
            return View();
        }
    }
}