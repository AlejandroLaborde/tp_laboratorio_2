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

        private static double Operar(String numero1, String numero2, String operador)
        {

            return 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Entidades.Numero numero1 = new Entidades.Numero(this.txtNumero1.Text);
            Entidades.Numero numero2 = new Entidades.Numero(this.txtNumero2.Text);
            lblResultado.Text= Entidades.Calculadora.Operar(numero1, numero2, this.cmbOperador.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperador.Text="";
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Entidades.Numero numeroAConvertir = new Entidades.Numero();

            this.lblResultado.Text = Entidades.Numero.DecimalBinario(this.lblResultado.Text);
            
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Entidades.Numero.BinarioDecimal(this.lblResultado.Text);
        }


    }
}
