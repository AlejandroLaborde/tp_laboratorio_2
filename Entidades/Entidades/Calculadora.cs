using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Calculadora
    {
        /// <summary>
        /// realiza la operacion correspondiente
        /// </summary>
        /// <param name="num">operandor uno</param>
        /// <param name="num2">operador dos</param>
        /// <param name="operador">operador con el que se va a realizar la operacion, en caso de ser invalido se asignara una  + </param>
        /// <returns></returns>
        public static double Operar(Numero num, Numero num2, String operador)
        {
            Double resultado=0;
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    resultado = num + num2;
                    break;
                case "-":
                    resultado = num - num2;
                    break;
                case "*":
                    resultado = num * num2;
                   break;
                case "/":
                    try
                    {
                        resultado = num / num2;
                    }
                    catch
                    {
                        resultado = double.MinValue;
                    }
                   
                    break;

            }//No utilizo default ya que contemplo los 4 casos en los case, y facilita la lectura del codigo

            return resultado;
        }

        /// <summary>
        /// ValidarOperador: valida que el valor recibido sea un operador valido (*,/,-,+) y lo retorna.
        /// En caso de no ser valido retornara la operacion suma ( + )
        /// </summary>
        /// <param name="operador">operador a ser validado</param>
        /// <returns>
        /// 
        /// </returns>
        private static String ValidarOperador(String operador)
        {

            String operadorRetorno= operador;
   
            if(operador!="*" && operador != "/" && operador != "-" && operador != "+")
            {
                operadorRetorno = "+";
            }

            return operadorRetorno;
        }


    }
}
