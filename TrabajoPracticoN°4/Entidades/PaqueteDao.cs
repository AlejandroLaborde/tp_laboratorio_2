using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        public static bool Insertar(Paquete p)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES ('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingID, "Alejandro Laborde Parodi");
                comando.CommandText = sb.ToString();
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            

            return true;
        }

        static PaqueteDAO()
        {
            //cambiar el Source
            try
            {
                string connectionStr = "Data Source=ALEJANDRO-PC\\SQLEXPRESS;Initial Catalog =correo-sp-2017; Integrated Security = True";
                conexion = new SqlConnection(connectionStr);
                comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;

            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private static void MuestraError(string a)
        {
            MessageBox.Show(a);
            
        }


       
    }
}
