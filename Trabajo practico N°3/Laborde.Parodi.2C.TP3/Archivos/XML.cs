using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;



namespace Archivos
{
    public class XML<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda los datos recibidos en el archivo indicado, (DENTRO DE DATA, EN LA CARPETA DEL PROGRAMA)
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo , T dato)
        {
            try
            {
                string path = GeneraPath(archivo);
                FileStream fs = new FileStream(path, FileMode.Create);
                XmlSerializer datoXml = new XmlSerializer(dato.GetType());
                datoXml.Serialize(fs, dato);
                fs.Close();
            }catch(Exception e)
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
        public bool Leer(string archivo, out T datos)
        {

            try
            {
                string path = GeneraPath(archivo);
                FileStream fs = new FileStream(path, FileMode.Open);
                XmlSerializer datoXml = new XmlSerializer(typeof (T) );
                datos = (T)datoXml.Deserialize(fs);
                fs.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return true;
        }

        /// <summary>
        /// Genera de forma dinamica el path de ruta del archivo a leer/ escribir, sin importar en donde se este ejecutando
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
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
