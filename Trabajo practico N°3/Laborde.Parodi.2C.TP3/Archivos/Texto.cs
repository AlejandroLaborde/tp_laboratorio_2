using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<String>
    {
        /// <summary>
        /// Guarda los datos recibidos en el archivo indicado, (DENTRO DE DATA, EN LA CARPETA DEL PROGRAMA)
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, String datos)
        {
            try
            {
                File.WriteAllText(GeneraPath(archivo), datos);
                
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }

        /// <summary>
        /// Devuelve los datos leidos del archivo recibido
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out String datos)
        {
           

            try
            {
                datos = File.ReadAllText(archivo);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
            
        }

        private string GeneraPath(string nombre)
        {
            StringBuilder rutaArchivo = new StringBuilder();
            string[] aux = Regex.Split(Directory.GetCurrentDirectory(), "Laborde.Parodi.2C.TP3");

            rutaArchivo.Append(aux[0]);
            rutaArchivo.Append("Laborde.Parodi.2C.TP3\\Data\\");
            rutaArchivo.Append(nombre);
            return rutaArchivo.ToString();
        }
    }
}
