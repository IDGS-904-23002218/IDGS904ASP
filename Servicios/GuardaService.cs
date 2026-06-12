using IDGS904ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace IDGS904ASP.Servicios
{
    public class GuardaService
    {
        public void GuardaArchivo(Alumno alum)
        {
            var nombre = alum.Nombre;
            var apaterno = alum.Apaterno;
            var amaterno = alum.Amaterno;
            var email = alum.Email;
            var datos = nombre + "," + apaterno + "," + amaterno + "," + email + Environment.NewLine;

            var archivo = HttpContext.Current.Server.MapPath("~/App_Data/datos.txt");
            // File.WriteAllText(@archivo, datos);
            File.AppendAllText(@archivo, datos);
        }
    }

    public class GuardaDiccionarioService
    {
        public void GuardaArchivo(string espanol, string ingles)
        {
            // Guarda en archivos separados, misma línea = misma palabra
            var rutaEspanol = HttpContext.Current.Server.MapPath("~/App_Data/espanol.txt");
            var rutaIngles = HttpContext.Current.Server.MapPath("~/App_Data/ingles.txt");

            File.AppendAllText(rutaEspanol, espanol + Environment.NewLine);
            File.AppendAllText(rutaIngles, ingles + Environment.NewLine);
        }
    }
}