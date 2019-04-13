using Entidades;
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

        private  void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperador.Text = "";

        }

        private  double Operar(String numero1, String numero2, String operador)
        {
            Entidades.Numero a = new Entidades.Numero(numero1);
            Entidades.Numero b = new Entidades.Numero(numero2);
            
            return Calculadora.Operar(a, b, this.cmbOperador.Text) ;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
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
