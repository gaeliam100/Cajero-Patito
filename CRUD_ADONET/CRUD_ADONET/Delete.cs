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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            try
            {
                CRUD opread = new CRUD();
                dataGridView1.DataSource = opread.Read();

            }
            catch(Exception ex)
            {
                MessageBox.Show("error:" + ex.Message, "aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbole.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                CRUD opdelete = new CRUD();
                if (opdelete.delete(int.Parse(txtbole.Text)) == 1)
                    MessageBox.Show("registro eliminado", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("no se pudo eliminar el registro", "aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
                MessageBox.Show("error:" + ex.Message, "aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
