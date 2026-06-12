using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS904ASP.Models
{
    public class Encriptar
    {
        public string Frase { get; set; }
        public int Desplazamiento { get; set; }
    }

    public class Desencriptar
    {
        public string FraseEncriptada { get; set; }
        public int Desplazamiento { get; set; }
    }
}