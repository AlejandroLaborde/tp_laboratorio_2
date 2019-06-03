using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;
using Excepciones;

namespace UnitTestProject1
{

    [TestClass]
    public class Test_Universidad
    {
      
        [TestMethod]
        public void Test_UigualA()
        {
            Alumno a1 = new Alumno(4, "Alejandro", "Laborde", "38834224", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(5, "daniel", "Laborde", "38834223", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.Deudor);
            Profesor i1 = new Profesor(2, "Roberto", "Juarez", "32234456", Persona.ENacionalidad.Argentino);
            Universidad gim = new Universidad();
            Assert.IsFalse(gim == a1);

            gim += a1;// agrego alumno a la universidad
            Assert.IsTrue(gim == a1);

            Assert.IsFalse(gim == i1);// profesor no cargado
            gim += i1;
            Assert.IsTrue(gim == i1);   
        }

        [TestMethod]
        public void Test_Agregar()
        {
            Alumno a1 = new Alumno(4, "Alejandro", "Laborde", "38834224", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(5, "daniel", "Laborde", "38834223", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.Deudor);
            Profesor i1 = new Profesor(2, "Roberto", "Juarez", "32234456", Persona.ENacionalidad.Argentino);
            Universidad gim = new Universidad();

            gim += a1;
            try
            {
                Assert.ThrowsException<AlumnoRepetidoException>(() => gim += a1);// agrego dos veces el mismo para comprobar que no se agrega si ya se encuentra en la universidad
            }
            catch(AlumnoRepetidoException e) { }
            gim += a2;
            try
            {
                Assert.ThrowsException<AlumnoRepetidoException>(() => gim += a2);// agrego dos veces el mismo para comprobar que no se agrega si ya se encuentra en la universidad
            }
            catch (AlumnoRepetidoException e) { }

            Assert.AreEqual(gim.Alumnos.Count, 2);
        }
    }
}
