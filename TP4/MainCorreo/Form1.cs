using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class Form1 : Form
    {
        Correo miCorreo;

        public Form1()
        {
            InitializeComponent();
            this.miCorreo = new Correo();
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (sender is Exception)
            {
                MessageBox.Show(((Exception)sender).Message, "Error con la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                string datosElemento = elemento.MostrarDatos(elemento);
                // Muestro los datos del elemento por pantalla
                this.rTbMostrar.Text = datosElemento;

                // Guardo los datos del elemento en un archivo
                datosElemento.Guardar("salida.txt");
            }
        }

        private void ActualizarEstados()
        {
            // limpio los listados de estado de los paquetes
            this.lstIngresado.Items.Clear();
            this.lstEnViaje.Items.Clear();
            this.lstEgresado.Items.Clear();



            // Vuelvo a agregar cada paquete al listado correspondiente segun su estado
            foreach (Paquete p in this.miCorreo.Paquetes)
            {
                switch (p.Estado)
                {
                    case EEstado.Ingresado:
                        this.lstIngresado.Items.Add(p);
                        break;
                    case EEstado.EnViaje:
                        this.lstEnViaje.Items.Add(p);
                        break;
                    case EEstado.Entregado:
                        this.lstEgresado.Items.Add(p);
                        break;


                    default:
                        break;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Instancio un nuevo paquete
            Paquete p = new Paquete(this.txtTrackingID.Text, this.txtDireccion.Text);

            // Asocio el metodo paq_InformaEstado al evento InformarEstado del paquete
            p.InformarEstado += paq_InformaEstado;

            // Agrego el paquete al correo
            try
            {
                this.miCorreo += p;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            this.ActualizarEstados();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)miCorreo);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)miCorreo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEgresado.SelectedItem);
        }
       

    }
}
