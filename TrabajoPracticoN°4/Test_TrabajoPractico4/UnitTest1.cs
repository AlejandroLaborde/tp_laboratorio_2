using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test_TrabajoPractico4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerificaInstanciaCorreo()
        {
            Correo nuevoCorreo = new Correo();
            Assert.IsNotNull(nuevoCorreo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoExeption))]
        public void VerificaTrackingIdRepetidoException()
        {
            Correo nuevoCorreo = new Correo();
            Paquete p1 = new Paquete("utn fra", "123-456-1234");
            Paquete p2 = new Paquete("utnfra", "123-456-1234");
            nuevoCorreo += p1;
            nuevoCorreo += p2;
        }


    }
}
