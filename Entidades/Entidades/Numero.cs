using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
      
        private double numero;


        /// <summary>
        /// Numero: inicializa el objeto en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Numero: inicializa el  numero con el valor pasado, previa validacion, en caso de no ser numerico asignara 0
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(String strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Numero: inicializa el objeto con el valor pasado
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }


        /// <summary>
        /// Valida el valor recibido y lo asigna a numero
        /// </summary>
        /// s
        public String SetNumero { set => numero = ValidarNumero(value); }

      



        /// <summary>
        /// ValidarNumero: Valida que el string recibido sea un numero, de ser asi lo retorna en formato double,
        /// caso contrario retornara 0.
        /// </summary>
        /// <param name="strNumero">String a validar si su contenido es un numero</param>
        /// <returns></returns>
        private double ValidarNumero(String strNumero)
        {
            double numeroValidado = 0;

            Double.TryParse(strNumero, out numeroValidado);

            return numeroValidado;
        }

        /// <summary>
        /// realiza la suma de ambos numeros
        /// </summary>
        /// <param name="n1">numero a sumar 1</param>
        /// <param name="n2">numero a sumar 2</param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2){


            return n1.numero + n2.numero;
            //return Calculadora.Operar(n1, n2, "+");

        }

        /// <summary>
        /// realiza la resta de ambos numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
            //return Calculadora.Operar(n1, n2, "-");
        }

        /// <summary>
        /// realiza la multiplicacion de ambos numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
            //return Calculadora.Operar(n1, n2, "*");
        }

        /// <summary>
        /// realiza la division de ambos numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
            //return Calculadora.Operar(n1, n2, "/");
        }

        /// <summary>
        /// El numero que recibe por parametro lo retorna convertido en binario
        /// </summary>
        /// <param name="numero">numero a pasar a binario</param>
        /// <returns></returns>
        public static String DecimalBinario(String numero)
        {
            String numeroConvertido;
            try
            {
                double doubleNumero = double.Parse(numero);
                numeroConvertido = Entidades.Numero.DecimalBinario(doubleNumero);
            }
            catch
            {
                numeroConvertido = "Valor invalido";
            }
            
            return numeroConvertido;
        }
        /// <summary>
        /// El numero que recibe por parametro lo retorna convertido en binario
        /// </summary>
        /// <param name="numero">numero a pasar a binario</param>
        /// <returns></returns>
        public static String DecimalBinario(double numero)
        {
            String numeroConvertido= "";
            int intNumero = (int)numero;
            if (intNumero > 0)
            {
              
                while (intNumero > 0)
                {
                    if (intNumero % 2 == 0)
                    {
                        numeroConvertido = "0" + numeroConvertido;
                    }
                    else
                    {
                        numeroConvertido = "1" + numeroConvertido;
                    }
                    intNumero = (int)(intNumero / 2);
                }
            }
            else if(intNumero==0)
            {
                numeroConvertido = "0";
            }else
            {
                numeroConvertido = "Valor inválido";
            }

            return numeroConvertido;
        }

        /// <summary>
        /// El String recibido por parametro lo convierte en decimal
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns></returns>
        public static String BinarioDecimal(String numero)
        {
            String numeroConvertido= "Valor inválido";


            char[] arrayNumero = numero.ToCharArray();
            // invertimos ya que los valores van incrementandose de derecha a izquierda: 16-8-4-2-1
            Array.Reverse(arrayNumero);
            int sum = 0;

            for (int i = 0; i < arrayNumero.Length; i++)
            {
                if (arrayNumero[i] == '1')
                {
                    // Usamos la potencia de 2, según la posición
                    sum += (int)Math.Pow(2, i);
                }
            }
            numeroConvertido = sum.ToString();

            return numeroConvertido;
        }

    }
}
