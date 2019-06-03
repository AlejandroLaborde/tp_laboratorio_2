using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Abstractas;
using Clases_Instanciables;

namespace UnitTestProject1
{
    /// <summary>
    /// Descripción resumida de Test_Profesor
    /// </summary>
    [TestClass]
    public class Test_Jornada
    {
        [TestMethod]
        public void Test_AgregarAlumnos()
        {
            Alumno a1 = new Alumno(4, "Alejandro", "Laborde", "38834224", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Alumno a2 = new Alumno(5, "daniel", "Laborde", "38834223", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            Profesor i1 = new Profesor(2, "Roberto", "Juarez", "32234456", Persona.ENacionalidad.Argentino);

            Jornada nuevaJornada = new Jornada(Universidad.EClases.Programacion, i1);
            nuevaJornada = nuevaJornada + a1;// agrego alumno
            Assert.AreEqual(nuevaJornada.Alumnos.Count, 1); 
            nuevaJornada = nuevaJornada + a1;// intento agregar el mismo alumno
            Assert.AreEqual(nuevaJornada.Alumnos.Count, 1);
            nuevaJornada = nuevaJornada + a2;//agrego alumno distinto
            Assert.AreEqual(nuevaJornada.Alumnos.Count, 2);
        }

        [TestMethod]
        public void Test_ValoresNulos()
        {
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12234456", Persona.ENacionalidad.Argentino);
            Jornada jornada = new Jornada(Universidad.EClases.Programacion,i1);
            Assert.IsNotNull(jornada.Alumnos);
            Assert.IsNotNull(jornada.Clase);
            Assert.IsNotNull(jornada.Instructor);
        }
    }
}
