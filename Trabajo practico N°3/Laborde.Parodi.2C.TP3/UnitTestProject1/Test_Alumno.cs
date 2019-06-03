using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;

namespace UnitTestProject1
{
    /// <summary>
    /// Descripción resumida de Test_Alumno
    /// </summary>
    [TestClass]
    public class Test_Alumno
    {
      
        [TestMethod]
        public void Test_AlumnoIgualClase()
        {
            Alumno a1 = new Alumno(4, "Alejandro", "Laborde", "38834224", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Assert.IsTrue(a1 == Universidad.EClases.Programacion);

            Alumno a2 = new Alumno(4, "Alejandro", "Laborde", "38834224", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            Assert.IsFalse(a2 == Universidad.EClases.Programacion);

            Alumno a3 = new Alumno(4, "Alejandro", "Laborde", "38834224", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Deudor);
            Assert.IsFalse(a3 == Universidad.EClases.Programacion);

            Alumno a4 = new Alumno(4, "Alejandro", "Laborde", "38834224", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.Deudor);
            Assert.IsTrue(a4 != Universidad.EClases.Programacion);

            Alumno a5 = new Alumno(4, "Alejandro", "Laborde", "38834224", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Deudor);
            Assert.IsFalse(a5 != Universidad.EClases.Programacion);
        }

        [TestMethod]
        public void Test_Valores()
        {
            Alumno a1 = new Alumno(4, "Alejandro", "La65borde", "38834224", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            //SE CARGO NUMEROS EN EL APELLIDO PARA COMPROBAR QUE LA EXPRESION REGULAR FUNCIONE
            Assert.IsTrue(a1.Nombre == "Alejandro");
            Assert.IsFalse(a1.Apellido == "Laborde");
            Assert.IsTrue(a1.DNI == 38834224);
        }

        [TestMethod]
        public void Test_ValoresNulos()
        {
            Alumno a1 = new Alumno(4, "Alejandro", "Laborde", "38834224", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Assert.IsNotNull(a1.Nombre);
            Assert.IsNotNull(a1.Apellido);
            Assert.IsNotNull(a1.DNI);
            Assert.IsNotNull(a1.Nacionalidad);
        }
    }
}
