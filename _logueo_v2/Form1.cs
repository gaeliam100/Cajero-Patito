using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _logueo_v2
{
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            registroU frmabrir = new registroU();
            this.Hide();
            frmabrir.ShowDialog();
            
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            if (txtusuario.Text == string.Empty && txtcontraseña.Text == string.Empty)
            {


                epcampos.SetError(txtusuario, "introduce un usuario");
                epcampos.SetError(txtcontraseña, "introduce la contraseña ");
                MessageBox.Show("llena los campos de validación ", "informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                Usuariosv2 valusuario = new Usuariosv2();
                if (valusuario.validausuario(txtusuario.Text, txtcontraseña.Text))
                {
                    MessageBox.Show("BIENVENIDO AL PROGRAMA: " + txtusuario.Text, "informacion");
                    iniciodesesion frmprincipal = new iniciodesesion();
                    this.Visible = false;
                    frmprincipal.ShowDialog();
                }
                else
                {
                    MessageBox.Show("ususario y/o contraseña incorrecta", "informacion");
                    txtusuario.Clear();
                    txtcontraseña.Clear();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            iniciodesesion frmcerrar = new iniciodesesion();
            frmcerrar.Close();
            registroU frmclose = new registroU();
            frmclose.Close();
        }
    }
}
