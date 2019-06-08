using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;

namespace UnitTestProject1
{
    /// <summary>
    /// Descripción resumida de Test_Profesor
    /// </summary>
    [TestClass]
    public class Test_Profesor
    {

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestConstructoVacio()
        {
            _ = new Profesor();
        }

        [TestMethod]
        
        public void Test_Instancia()
        {
            Profesor i2 = new Profesor(2, "fede", "davila", "32234456", Persona.ENacionalidad.Argentino);
            Assert.AreEqual("fede",i2.Nombre);
            Assert.AreEqual("davila", i2.Apellido);
            Assert.AreEqual(32234456, i2.DNI);
        }
    }
}
