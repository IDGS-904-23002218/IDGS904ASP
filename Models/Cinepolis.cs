using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS904ASP.Models
{
    public class Cinepolis
    {
        public string Nombre { get; set; }
        public int CantidadCompradores { get; set; }
        public int CantidadBoletos { get; set; }
        public bool Tarjeta { get; set; }
    }
}