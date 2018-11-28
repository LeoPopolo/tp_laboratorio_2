using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_abstractas;
using Clases_instanciables;
using Excepciones;

namespace Test_Unitarios
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestNull()
        {
            Profesor profesor = new Profesor(1, "Juanito", "Alcachofa", null, Persona.ENacionalidad.Extranjero);
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestNacionalidad()
        {
            Alumno uno = new Alumno(2, "Your", "Mother", "123456", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
        }

        [TestMethod]
        public void TestValorNumerico()
        {
            Alumno alumno = new Alumno(3, "Bill", "Gates", "112233", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsInstanceOfType(alumno.DNI, typeof(int));
        }
    }
}
