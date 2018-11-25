using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    /// <summary>
    /// Enumerado con los estados del paquete.
    /// </summary>
    public enum EEstado
    {
        Ingresado,
        EnViaje,
        Entregado
    }

    public class Paquete : IMostrar<Paquete>
    {


        #region atributos.
        EEstado estado;
        string direccionEntrega;
        string trackingID;
        #endregion

        #region Propiedades
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { direccionEntrega = value; }
        }
        public EEstado Estado
        {
            get { return this.estado; }
            set { estado = value; }
        }
        public string TrackingID
        {
            get { return this.trackingID; }
            set { trackingID = value; }
        }
        #endregion


        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;

        #region Metodos y contructores.
        public void MockCicloVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                try
                {
                    // Espera 4 segundos entre estados
                    Thread.Sleep(4000);
                }
                catch (Exception)
                {
                    
                }

                
                switch (this.Estado)
                {
                    case EEstado.Ingresado:
                        this.Estado = EEstado.EnViaje;
                        this.InformarEstado(this, new EventArgs());
                        break;
                    case EEstado.EnViaje:
                        this.Estado = EEstado.Entregado;
                        this.InformarEstado(this, new EventArgs());
                        break;
                    default:
                        break;
                }
            }
            // Al entregar el paquete se inserta en la base de datos.
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                this.InformarEstado(e, new EventArgs());
            }

        }

        /// <summary>
        /// Sobrecarga operador ==. En caso de compartir el mismo "TrackingId" los paquetes seran iguales y retornara true. Caso contrario son distintos y retornara false.
        /// </summary>
        /// <param name="p1">Paquete</param>
        /// <param name="p2">Paquete</param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.TrackingID == p2.TrackingID)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga operador !=. En caso de compartir el mismo "TrackingId" los paquetes seran iguales y retornara true. Caso contrario son distintos y retornara false.
        /// </summary>
        /// <param name="p1">Paquete</param>
        /// <param name="p2">Paquete</param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Metodo que muestra los datos del paquete.
        /// </summary>
        /// <param name="miPaquete">Paquete</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> miPaquete)
        {
            Paquete p = (Paquete)miPaquete;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} para la direccion: {1}", p.TrackingID, p.DireccionEntrega);
            return sb.ToString();
        }

        /// <summary>
        /// Llama al metodo mostrar datos.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Constructor de clase Paquete.
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega.</param>
        /// <param name="trakingId">Identificador de paquete.</param>
        public Paquete(string trackingId, string direccionEntrega)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingId;
            this.Estado = EEstado.Ingresado;
        }

        #endregion

    }
}
