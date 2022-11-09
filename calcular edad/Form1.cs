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
    public partial class primero : Form
    {
        public primero()
        {
            InitializeComponent();
        }

        private void btncalcular_Click(object sender, EventArgs e)
        {
            int mes;
            int dias;
            calcuedad fecha = new calcuedad();
            fecha.edad(monthCalendar1.TodayDate.Year-monthCalendar1.SelectionStart.Year);
            mes= (monthCalendar1.TodayDate.Month - monthCalendar1.SelectionStart.Month);
            fecha.restames(mes);
            dias = (monthCalendar1.TodayDate.Day - monthCalendar1.SelectionStart.Day);
            fecha.restadias(dias);
            MessageBox.Show("tu edad ha sido calculada", "hola", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            datosob frmmostrar = new datosob();
            frmmostrar.ShowDialog();
        }
    }
}
