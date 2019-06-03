using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    
    public sealed class Alumno: Universitario
    {
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno()
        {

        }
        public Alumno(int id,string nombre, string apellido, string dni,ENacionalidad nacionalidad, Universidad.EClases clasesquetoma):base(id,nombre,apellido,dni,nacionalidad)
        {
            claseQueToma = clasesquetoma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesquetoma,EEstadoCuenta estadoCta) : this(id, nombre, apellido, dni, nacionalidad,clasesquetoma)
        {
            estadoCuenta = estadoCta;
        }
        /// <summary>
        /// Muestra los datos de alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(base.MostrarDatos());
            sb.AppendFormat("\tEstado de cuenta: {0}\n", this.estadoCuenta);
            sb.AppendFormat(ParticipaEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// retorna cla clase que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticipaEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\tTOMA CLASE DE: {0}\n\n", claseQueToma);
            return sb.ToString();
        }
        /// <summary>
        /// Hace publico los datos de un alumno
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }
        /// <summary>
        /// Indica si un alumno pertenece a una clase y si su estado es NO deudor
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno alumno, Universidad.EClases clase)
        {
           return (alumno.estadoCuenta != EEstadoCuenta.Deudor && !(alumno !=clase )) ? true : false;
        }

        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {

           return (alumno.claseQueToma == clase)? false : true;
            
        }
    }
}
