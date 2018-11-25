using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    /// <summary>
    /// Clase Correo, implementa interface de IMostrar.
    /// </summary>
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> MockPaquetes;
        List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get { return paquetes; }
            set { paquetes = value; }
        }

        /// <summary>
        /// Constructor por defecto que instancia la lista de MockPaquetes.
        /// </summary>
        public Correo()
        {
            MockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        /// <summary>
        /// En caso de haber un hilo vivo en la lista de hilos se frenara.
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread t in this.MockPaquetes)
            {
                if (t.IsAlive)
                    t.Abort();
            }
        }

        /// <summary>
        /// Sobrecarga operador +. Agrega un paquete al correo. En caso de existir lanza excepcion TrakingIdRepetidoException.
        /// En caso de no existir agrega el paquete al correo.
        /// Crea un hilo MockCicloVida. Y lo agrega a la lista de hilos MockPaquetes.
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    throw new TrakingIdRepetidoException("Ya existe un paquete con ese id.");
                }

            }
            c.Paquetes.Add(p);
            Thread hiloMock = new Thread(p.MockCicloVida);
            c.MockPaquetes.Add(hiloMock);
            hiloMock.Start();
            return c;
        }

        /// <summary>
        /// Metodo utilizado para mostrar la informacion del paquete.
        /// </summary>
        /// <param name="miPaquete">Paquete</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> miPaquete)
        {
            StringBuilder sb = new StringBuilder();
            if (miPaquete.GetType() == typeof(Correo))
            {
                foreach (Paquete p in ((Correo)miPaquete).Paquetes)
                {
                    sb.AppendFormat("Tracking id: {0} Direccion {1} (estado {2}) \r\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
                }
            }
            return sb.ToString();
        }


    }
}
