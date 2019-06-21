using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace Entidades
{
    
    public enum EEstado {Ingresado ,EnViaje ,Entregado};

    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region "Propiedades"
        public delegate void DelegadoEstado(object sender, EventArgs e);

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }

        }

        #endregion

        #region "Constructor"
        public Paquete(string direccion, string trackingId)
        {
            DireccionEntrega = direccion;
            TrackingID = trackingId;
            Estado = EEstado.Ingresado;
        }
        #endregion


        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return string.Format("{0} para {1} ({2})\n",p.TrackingID, p.DireccionEntrega,p.Estado);
        }

        public void MockCicloDeVida()
        {
            Thread.Sleep(4000);
            this.Estado = EEstado.EnViaje;
            this.InformaEstado.Invoke(this, EventArgs.Empty);
            Thread.Sleep(4000);
            this.Estado = EEstado.Entregado;
            this.InformaEstado.Invoke(this, EventArgs.Empty);
            //PaqueteDAO.Insertar(this);

        }

      
        public event DelegadoEstado InformaEstado;

     
        #region "Sobrecargas"
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.MostrarDatos(this));

            return sb.ToString();
        }

       
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (p1.TrackingID == p2.TrackingID)
            {
                retorno=true;
            }
            return retorno;
        }
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
