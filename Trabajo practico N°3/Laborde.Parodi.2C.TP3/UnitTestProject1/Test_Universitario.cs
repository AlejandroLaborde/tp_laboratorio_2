using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;

namespace UnitTestProject1
{
    [TestClass]
    public class Test_Universitario
    {
        [TestMethod]
        public void Test_Ecuals()
        {

            Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            Alumno a5 = new Alumno(5, "Carlos", "Gonzalez", "12236456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12234456", Persona.ENacionalidad.Argentino);
            Alumno a7 = new Alumno(4, "Carlos", "Gonzalez", "12236456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Assert.IsFalse(a4.Equals(i1));
            Assert.IsTrue(a4.Equals(a5));
            Assert.IsTrue(a4.Equals(a7));
        }


        [TestMethod]
        public void Test_Igual()
        {

            Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            Alumno a6 = new Alumno(4, "Miguel", "Hernandez", "99999991", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            Alumno a5 = new Alumno(5, "Carlos", "Gonzalez", "12236456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Alumno a7 = new Alumno(4, "Carlos", "Gonzalez", "12236456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12234456", Persona.ENacionalidad.Argentino);
            Assert.IsFalse(a4==a5);
            Assert.IsFalse(a4 == i1);
            Assert.IsTrue(a4==a6);
            Assert.IsTrue(a4 == a7);
        }
    }
}
