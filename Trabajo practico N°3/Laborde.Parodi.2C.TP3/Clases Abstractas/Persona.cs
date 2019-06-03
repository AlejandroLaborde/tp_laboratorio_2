using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace Clases_Abstractas
{
   

    public abstract class Persona
    {

        public enum ENacionalidad { Argentino, Extranjero }
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        
        

        #region Constructores

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            //VALIDAR daTOS
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni ,ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni;
        }
        #endregion

        #region Propiedades

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.apellido = value;
                }
                
            }
        }
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(Nacionalidad, value);
            }
        }
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.nombre = value;
                }

            }
        }
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(Nacionalidad, value);
            }
        }

        #endregion


        #region
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\t{0} {1} DNI: {2} Nacionalidad: {3} ", Nombre, Apellido, DNI, Nacionalidad);
            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            int dniValidado=0;
            
            if(dato<1 || dato > 99999999)
            {
                throw new DniInvalidoException();
            }

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                    {
                        dniValidado = dato;
                    }else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;

                default:
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        dniValidado = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
            }

            return dniValidado;
        }


        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            bool aux;
            int dniValidado=0;
            aux = int.TryParse(dato,out dniValidado);

            if (aux)
            {
                dniValidado = ValidarDni(nacionalidad, dniValidado);
            }else
            {
                throw new DniInvalidoException();
            }
            return dniValidado;
        }



        private string ValidarNombreApellido(string dato)
        {
            string expresionRegular = "^[a-zA-Z]+$";
            if(Regex.IsMatch(dato, expresionRegular))
            {
               
                return dato;
            }
            else
            {
                return null;
            }

        }
        #endregion



    }
}
