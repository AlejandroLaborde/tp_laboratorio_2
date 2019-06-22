using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

      
        string IMostrar<List<Paquete>>.MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete a in ((Correo)elemento).Paquetes)
            {
                sb.Append(string.Format("{0} para {1} ({2})\n", a.TrackingID, a.DireccionEntrega, a.Estado.ToString()));
            }
            
            return sb.ToString();
        }

        public void FinEntregas()
        {
            foreach(Thread a in mockPaquetes)
            {
                if (a.IsAlive)
                {
                    a.Abort();
                }
                
            }
        }
        
        public static Correo operator + (Correo c , Paquete p)
        {
            if (c != p)
            {
                c.Paquetes.Add(p);
                Thread hiloNuevo = new Thread(p.MockCicloDeVida);
                c.mockPaquetes.Add(hiloNuevo);
                hiloNuevo.Start();
            }
            return c;
        }

        /// <summary>
        /// Verifica si un paquete se encuentra dentro de correo
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator ==(Correo c, Paquete p)
        {
           
            foreach(Paquete a in c.Paquetes)
            {
                if (a == p)
                {
                    throw new TrackingIdRepetidoExeption("El paquete con id: " + p.TrackingID + " ya se encuentra en el correo ");
                }
            }
            return false;
        }
        public static bool operator !=(Correo c, Paquete p)
        {
           
            return !(c==p);
        }
    }
}
