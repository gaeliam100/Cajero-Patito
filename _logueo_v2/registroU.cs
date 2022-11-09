using
    System;
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
    public partial class registroU : Form
        
    {
        public registroU()
        {
            InitializeComponent();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            Usuariosv2 regis = new Usuariosv2();
            if (txtregusu.Text == string.Empty && txtregistnom.Text == string.Empty && txtregcontra.Text == string.Empty )
            {
                epcampos2.SetError(txtregistnom, "necesitas un nombre");
                epcampos2.SetError(txtregistnom, "necesitas un nombre");
                epcampos2.SetError(txtregcontra, "necesitas una contraseña");
                epcampos2.SetError(txtregusu, "necesitas un usuario");
                epcampos2.SetError(txtconfirmar, "necesitas una contraseña");
                MessageBox.Show("asegurate de que los espacios esten llenos ", "notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //else if ()
            //{
            //    MessageBox.Show("asegurese de que su contraseña sea la misma ");
            //}

            regis.obtenernombres(txtregistnom.Text);
            regis.obtenercontraseña(txtregcontra.Text);
            if (regis.obtenerusuarios(txtregusu.Text))
            {
                MessageBox.Show("Usuario registrado correctamente ", "notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("el ususario ya existe");
            }

            //if (txtregcontra.Text != txtconfirmar.Text)
            //{
            //    MessageBox.Show("asegurese de que su contraseña sea la misma ");
            //}




        }
        

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control txtbox in this.Controls)
            {
                if (txtbox is TextBox)
                {
                    txtbox.Text = string.Empty;
                    txtregistnom.Focus();
                }
            }
        }

        private void btnregresar1_Click(object sender, EventArgs e)
        {
            principal frmregresar = new principal();
            frmregresar.Show();
            this.Hide();
        }
    }
    
}
