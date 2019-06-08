using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            RamdomClases();
        }

        public Profesor():this(0,"","","",ENacionalidad.Argentino)
        {
            
        }
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Retorna un mensaje indicando las clases que dicta
        /// </summary>
        /// <returns></returns>
        protected override string ParticipaEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\tCLASES DEL DIA:\n");
            foreach (Universidad.EClases clases in clasesDelDia)
            {
                sb.AppendFormat("\t{0}\n", clases);
            }
            sb.AppendLine();
            return sb.ToString();
        }

        /// <summary>
        /// Retorna todos los datos de profesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendFormat(ParticipaEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Hace publicos los datos de profesor
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// Retorna TRUE si el profesor dicta esa clase
        /// </summary>
        /// <param name="profesor"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor profesor, Universidad.EClases clase)
        {
            bool daEsaClase = false;
            foreach (Universidad.EClases clasesProfesor in profesor.clasesDelDia)
            {
                if (clase == clasesProfesor)
                {
                    daEsaClase = true;
                }
            }
            return daEsaClase;
        }
       
        public static bool operator !=(Profesor profesor, Universidad.EClases clase)
        {
            return !(profesor == clase);
        }

        /// <summary>
        /// Asigna de forma random dos clases al profesor
        /// </summary>
        private void RamdomClases()
        {

            for (int i = 0; i < 2; i++)
            {
                int opcion=random.Next(0, 3);//3 son la cantidad de clases disponibles
                //Console.WriteLine("Random: " + opcion);
                switch (opcion)
                {

                    case 0:
                        clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 1:
                        clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 2:
                        clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    default:
                        clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }

            }
            //Console.WriteLine("SE ASIGNARON CLASE: " + clasesDelDia.Count + clasesDelDia.ElementAt(0) + clasesDelDia.ElementAt(1));
        }
    }
}
