using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

namespace IDGS904ASP.Servicios
{
    public class LeerService
    {
        public Array LeerArchivo()
        {
            Array userData = null;
            var dataFile = HttpContext.Current.Server.MapPath("~/App_Data/datos.txt");
            if (File.Exists(dataFile))
            {
                userData = File.ReadAllLines(dataFile);
            }
            return userData;
        }
    }

    public class LeerDiccionarioService
    {
        public string[] LeerEspanol()
        {
            var ruta = HttpContext.Current.Server.MapPath("~/App_Data/espanol.txt");
            if (File.Exists(ruta))
                return File.ReadAllLines(ruta);
            return null;
        }

        public string[] LeerIngles()
        {
            var ruta = HttpContext.Current.Server.MapPath("~/App_Data/ingles.txt");
            if (File.Exists(ruta))
                return File.ReadAllLines(ruta);
            return null;
        }
    }
}