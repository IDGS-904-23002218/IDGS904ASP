using System;
using System.IO;
using System.Web;

namespace IDGS904ASP.Servicios
{
    public class CesarService
    {
        private string RutaArchivo()
        {
            return HttpContext.Current.Server.MapPath("~/App_Data/cesar.txt");
        }

        public string Encriptar(string frase, int desplazamiento)
        {
            string resultado = "";

            foreach (char letra in frase)
            {
                if (letra >= 'A' && letra <= 'Z')
                {
                    resultado += (char)(((letra - 'A' + desplazamiento) % 26) + 'A');
                }
                else if (letra >= 'a' && letra <= 'z')
                {
                    resultado += (char)(((letra - 'a' + desplazamiento) % 26) + 'a');
                }
                else
                {
                    resultado += letra;
                }
            }

            return resultado;
        }

        public string Desencriptar(string frase, int desplazamiento)
        {
            return Encriptar(frase, 26 - desplazamiento);
        }

        public void GuardarFrase(string fraseOriginal, string fraseEncriptada, int desplazamiento)
        {
            var datos = fraseOriginal + "," + fraseEncriptada + "," + desplazamiento + Environment.NewLine;
            File.AppendAllText(RutaArchivo(), datos);
        }

        public string[] LeerFrases()
        {
            if (File.Exists(RutaArchivo()))
                return File.ReadAllLines(RutaArchivo());
            return null;
        }
    }
}