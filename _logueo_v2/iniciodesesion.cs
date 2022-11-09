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
    public partial class iniciodesesion : Form
    {
        public iniciodesesion()
        {
            InitializeComponent();
        }
        //public string user
        //{
        //    get => user;
        //    set
        //    {
        //        user = value;
        //       label2.Text = user;
        //    }
        //}

        private void btnregresar_Click(object sender, EventArgs e)
        {
            principal frmvolver = new principal();
            frmvolver.Show();
            this.Hide();
        
        }
        private void iniciodesesion_Load(object sender, EventArgs e)
        {
            Usuariosv2 datos = new Usuariosv2();
            listBox1.DataSource = datos.mostrar();
        }
    }
}
