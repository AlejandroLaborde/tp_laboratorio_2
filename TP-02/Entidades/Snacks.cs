using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades_2018
{
    public class Snacks : Producto
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigoDeBarras"></param>
        /// <param name="color"></param>
        public Snacks( EMarca marca, string codigoDeBarras, ConsoleColor color) : base( codigoDeBarras , marca, color )
        {
            //Snack no contiene atributos propios, solo los heredados
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// Los snacks tienen 104 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 104;
            }
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
            sb.AppendLine("SNACK");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("--------------------------------\n");
            return sb.ToString();

        }
        #endregion
    }

}
