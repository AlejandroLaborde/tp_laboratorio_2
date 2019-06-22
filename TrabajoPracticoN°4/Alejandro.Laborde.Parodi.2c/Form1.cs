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

namespace Alejandro.Laborde.Parodi._2c
{
    public partial class FrmPpal : System.Windows.Forms.Form
    {
        private Correo correo = new Correo();
        public FrmPpal()
        {
            InitializeComponent();
            
        }

        private void paq_InformaEstado(object sender , EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }



        private void ActualizarEstados()
        {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();


            foreach (Paquete p in correo.Paquetes)
            {

                switch (p.Estado)
                {
                    case EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(p);
                        break;
                    case EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(p);
                        break;
                    case EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(p);
                        break;
                }

            }

        }

      

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            Paquete nuevoPaquete = new Paquete(txtDireccion.Text, mtxtTrakingID.Text);
            nuevoPaquete.InformaEstado += paq_InformaEstado;
            try
            {
                correo=correo + nuevoPaquete;
            }catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        
            this.ActualizarEstados();
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
                this.correo.FinEntregas();

        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                string guardar= elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text = guardar;
                guardar.Guardar("salida.txt");
            }
                   
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void MostrarToolStripMenuItem(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

    }
}
