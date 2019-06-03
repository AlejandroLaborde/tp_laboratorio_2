using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }
            set
            {
               alumnos = value;
            }
        }
        public Universidad.EClases Clase
        {
            get
            {
                return clase;
            }
            set
            {
                clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return instructor;
            }
            set
            {
                instructor = value;
            }
        }

        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            Clase = clase;
            Instructor = instructor;
        }

        /// <summary>
        /// retorna si el alumno participa o no en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool participa = false;
            foreach(Alumno alumnosJ in j.Alumnos)
            {
                if (a == alumnosJ)
                {
                    participa = true;
                }
            }
            return participa;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// agrega un alumno a la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j == a))
            {
                j.alumnos.Add(a);
            }
            return j;
        }
        /// <summary>
        /// hace publicos los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\n------------------------------------------\n");
            sb.AppendFormat("\nCLASE DE {0}: \n", Clase);
            sb.AppendLine("PROFESOR:");
            sb.Append(instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno a in Alumnos)
            {
                sb.Append(a.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Guarda la jornada en un archivo de datos con formato XML (Universidad.xml)
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                XML<Jornada> salvarDatos = new XML<Jornada>();
                salvarDatos.Guardar("Universidad.xml", jornada);
            }catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            
           
            return true;
        }
        /// <summary>
        /// lee los datos de un archivo
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            XML<Jornada> salvarDatos = new XML<Jornada>();
            Jornada jornada = new Jornada();
            salvarDatos.Leer("Universidad.xml",out jornada);
            return jornada.ToString();
        }

    }
}
