using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_ADONET
{
    public partial class create : Form
    {
        public create()
        {
            InitializeComponent();
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
           try
            {
                CRUD opcreate = new CRUD();
                Alumno createalumno = new Alumno(txtboleta.Text,txtnombre.Text);
                if (opcreate.create(createalumno) == 1)
                {
                    MessageBox.Show("alumno agregado corectamente", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("no se pudo agregar el alumno", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception Ex)
            {
                MessageBox.Show("error" + Ex, "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
