using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Abstractas;
using Clases_Instanciables;

namespace UnitTestProject1
{
    /// <summary>
    /// Descripción resumida de UnitTest1
    /// </summary>
    [TestClass]
    public class Test_Excepciones
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void Test_DniValidoException()
        {
            Alumno a1 = new Alumno(1, "Alejandro", "Laborde", "1236544gg", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);// 
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void Test_NacionalidadInvalidaException()
        {
            Alumno a1 = new Alumno(1, "Alejandro", "Laborde", "99999999", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);// 
        }

     
    }
}
