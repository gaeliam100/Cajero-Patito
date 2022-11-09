using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calcular_edad
{
    public partial class datosob : Form
    {
        calcuedad mostraer = new calcuedad();
        public datosob()
        {
            InitializeComponent();
        }
        //constructor propio
        public datosob (string edadaños)
        {
            InitializeComponent();
           
        }

        private void datosob_Load(object sender, EventArgs e)
        {

            calcuedad años = new calcuedad();
            txtaños.Text = años.Edadenaños.ToString();
            txtmeses.Text = años.Edadmeses.ToString();
            txtdays.Text = mostraer.Edaddias.ToString();

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            this.Hide();
            primero mostrardenuevo = new primero();
            mostrardenuevo.ShowDialog();
            
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            primero cerrar = new primero();
            cerrar.Close();
        }
    }    
}

