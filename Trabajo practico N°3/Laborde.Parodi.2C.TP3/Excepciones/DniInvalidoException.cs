using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        public DniInvalidoException():base("Error: el dni ingresado es invalido") { }
        public DniInvalidoException(Exception e)
        {
            this.mensajeBase = e.Message;
        }
        public DniInvalidoException(string mensaje)
        {
            this.mensajeBase = mensaje;
        }
        public DniInvalidoException(string mensaje, Exception e):base(mensaje,e)
        {

        }
    }
}
