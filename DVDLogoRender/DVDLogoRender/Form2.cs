using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDLogoRender
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            numericUpDown1.Value = Form1.speed;
            numericUpDown2.Value = Convert.ToInt16(Math.Floor((Form1.dvdlogosize.Width*10.0f)/262));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.speed = Convert.ToInt16(numericUpDown1.Value);
            Form1.dvdlogosize = new Size(Convert.ToInt16(Math.Floor(262 * numericUpDown2.Value/10)), Convert.ToInt16(Math.Floor(115 * numericUpDown2.Value / 10)));
            this.Close();
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void numericUpDown2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
