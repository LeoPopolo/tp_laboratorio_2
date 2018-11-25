using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Realizar test que verifique que la lista de Paquetes del Correo esté instanciada.
        /// </summary>
        [TestMethod]
        public void lstPaquetesInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Realizar test que verifique que no se puedan cargar dos Paquetes con el mismo Tracking ID.
        /// </summary>
        [TestMethod]
        public void TrackingIdRepetido()
        {
            Correo correo = new Correo();
            Paquete paquete1 = new Paquete("Repetido", "453");
            Paquete paquete2 = new Paquete("Repetido", "126");

            correo += paquete1;
            try
            {
                correo += paquete2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrakingIdRepetidoException));
                return;
            }
            Assert.Fail("Sin excepción trackingID repetido: {0}.", paquete2.TrackingID);
        }
    }
}
