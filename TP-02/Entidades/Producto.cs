using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{

    /// <summary>
    /// La clase Producto no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto
    {

        public enum EMarca
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }

        protected string codigoDeBarras;
        protected ConsoleColor colorPrimarioEmpaque;
        public EMarca marca;

        #region propiedad
        /// <summary>
        /// ReadOnly: Retornará la cantidad de calorias del producto
        /// </summary>
        public abstract short CantidadCalorias
        {
            get;
        }
        #endregion

        /// <summary>
        /// Constructor de producto
        /// </summary>
        /// <param name="codigoDeBarras"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Producto(string codigoDeBarras, EMarca marca, ConsoleColor color)
        {
            this.codigoDeBarras = codigoDeBarras;
            this.marca = marca;
            this.colorPrimarioEmpaque = color;
        }

        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public abstract string Mostrar();
       



        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("MARCA : {0}\r\n", p.marca);
            sb.AppendFormat("COLOR EMPAQUE : {0}\r\n", p.colorPrimarioEmpaque);
            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p.codigoDeBarras);
            sb.AppendLine("--------------------------------\n");
            sb.AppendFormat("CANTIDAD DE CALORIAS: {0}\r", p.CantidadCalorias);
            return sb.ToString();
        }


        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras == v2.codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return (v1.codigoDeBarras != v2.codigoDeBarras);
        }
    }
}
