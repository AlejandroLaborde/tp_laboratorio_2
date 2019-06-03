using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario() { }

        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
            
        }
        
        public override bool Equals(object obj)
        {
            bool esIgual = false;

            if (ReferenceEquals(GetType(), obj.GetType()))
            {       
                esIgual = true;
            }

            return esIgual;
        }

        protected abstract string ParticipaEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();      
            sb.AppendFormat(base.ToString());
            sb.AppendFormat("Legajo: {0}\n", this.legajo);
            return sb.ToString();
        }

        public static bool operator == (Universitario u1, Universitario u2)
        {
            if(u1.legajo == u2.legajo && u1.Equals(u2) || u1.DNI==u2.DNI) //reutilizo la sobrecarga del metodo equals            
            {
                return true;   
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);
        }


    }
}









