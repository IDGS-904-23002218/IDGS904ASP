using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS904ASP.Models
{
    public class Palabra
    {
        public string Espanol { get; set; }
        public string Ingles { get; set; }
    }

    public class Busqueda
    {
        public string Termino { get; set; }
        public string Idioma { get; set; }
    }
}