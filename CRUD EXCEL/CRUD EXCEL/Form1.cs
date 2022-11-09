using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_EXCEL
{
    public partial class Form1 : Form
    {
        CRUD nvaOperacion = new CRUD();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnconsultar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvAlumnos.DataSource = nvaOperacion.consultarAlumnos2();
                MessageBox.Show("Consulta exitosa", "NOTIFICACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

        }
    }
}
