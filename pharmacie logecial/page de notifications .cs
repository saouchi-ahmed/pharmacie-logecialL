using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pharmacie_logecial
{
    public partial class Form4 : Form
    {
        public Form4(String message )
        {

            InitializeComponent();
                N.Text = message;
      
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Top = 400;
            Left = Screen.PrimaryScreen.Bounds.Width - Width - 20;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void N_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
