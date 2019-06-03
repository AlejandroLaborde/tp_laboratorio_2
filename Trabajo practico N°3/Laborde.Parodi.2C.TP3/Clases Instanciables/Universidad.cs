using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    
    public class Universidad
    {
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public Universidad() {
            alumnos = new List<Alumno>();
            jornadas = new List<Jornada>();
            profesores = new List<Profesor>();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }
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
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        public Jornada this[ int i]
        {
            get
            {
                return jornadas.ElementAt(i);
            }
            set
            {
                this.jornadas[i] = value;
            }
        }
        /// <summary>
        /// Indica si un alumno pertenece a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool seEncuentraEnUniversidad = false;
            if (object.ReferenceEquals(g.Alumnos,null))
            {
                return seEncuentraEnUniversidad;
            }
                foreach (Alumno alumnoG in g.Alumnos)
                {
                    if (alumnoG == a)
                    {
                        seEncuentraEnUniversidad = true;
                    }
                }
            
            return seEncuentraEnUniversidad;
        }
        /// <summary>
        /// indica si un profesor pertenece a la universidad
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool seEncuentraEnUniversidad = false;
            foreach (Profesor profeG in g.Instructores)
            {
                if (i == profeG)
                {
                    seEncuentraEnUniversidad = true;
                }
            }
            return seEncuentraEnUniversidad;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {
            Profesor profeAsignado = null;
            foreach (Profesor p in g.Instructores)
            {
                if (p == clase)
                {
                    profeAsignado = p;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }
            return profeAsignado;
        }
        public static Profesor operator !=(Universidad g, Universidad.EClases clase)
        {
            Profesor profeAsignado=null;
            foreach (Profesor p in g.Instructores)
            {
                if (p != clase)
                {
                    profeAsignado= p;
                    break;// corta la ejecucion cuando encuentra el primero
                }
                else
                {
                    throw new SinProfesorException();
                }

            }
            return profeAsignado;
        }

        /// <summary>
        /// Hace publicos los datos de la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad u)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat("\n\n*************** UNIVERSIDAD****************\n\n");

            sb.AppendFormat("ALUMNOS: \n");
            foreach(Alumno a in u.Alumnos)
            {
                sb.AppendFormat(a.ToString());
            }
            sb.AppendFormat("PROFESORES: \n");
            foreach (Profesor a in u.Instructores)
            {
                sb.AppendFormat(a.ToString());
            }
            sb.AppendFormat("JORNADAS: \n");
            foreach (Jornada a in u.Jornadas)
            {
                sb.AppendFormat(a.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Asigna una clase a la universidads
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, EClases clase)
        {
            Profesor profeAsignado = (u==clase);
            
            Jornada nuevaJornada = new Jornada(clase, profeAsignado);
            foreach (Alumno a in u.Alumnos)
            {
                if (a == clase)
                {
                    nuevaJornada = nuevaJornada + a;
                }
            }
            u.jornadas.Add(nuevaJornada);
            return u;
        }
        /// <summary>
        /// agrega un alumno a la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u == a)
            {
                throw new AlumnoRepetidoException();

            }else
            {
                u.Alumnos.Add(a);
            }
            return u;
        }

        /// <summary>
        /// agrega un profesor a la universidad
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }else
            {
               // preguntar si aca mando excepcion 
            }
            return u;
        }

        /// <summary>
        /// Guarda los datos de la universidad en un archivo txt
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Texto salvarDatos = new Texto();
            salvarDatos.Guardar("Jornada.txt", uni.ToString());
            return true;
        }

        

    }
}
