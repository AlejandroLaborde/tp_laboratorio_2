using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToScreen();
            
        }
        
        private static void Limpiar()
        {


        }

        private static double Operar(String numero1, String numero2 , String operador)
        {

            return 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
