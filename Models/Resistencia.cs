using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS904ASP.Models
{
    public class Resistencia
    {
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Color3 { get; set; }
        public string Tolerancia { get; set; }
    }

    // Este modelo representa una fila de la tabla
    public class ResistenciaResultado
    {
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Color3 { get; set; }
        public string Tolerancia { get; set; }
        public double Valor { get; set; }
        public double ValorMax { get; set; }
        public double ValorMin { get; set; }
    }
}