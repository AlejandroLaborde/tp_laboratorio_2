using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        #region Propiedad
        public override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigoDeBarras"></param>
        /// <param name="color"></param>
        public Dulce ( EMarca marca, string codigoDeBarras, ConsoleColor color): base(codigoDeBarras,marca,color)
        {
            //Dulce no contiene atributos propios, solo los heredados
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Convierte todos los atributos con sus resultados en string
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("--------------------------------\n");
            return sb.ToString();

        }
        #endregion
    }
}
