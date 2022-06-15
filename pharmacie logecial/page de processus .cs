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
    public partial class Form1 : Form
    {
        int kk;
        public Form1(int p )
        {
            InitializeComponent();
           

            lang(p);
        }
        public void lang(int k)
        {
            kk=k;
            if(k==1)
                l.Text = "          إدارة الصيدلة ";
            else if (k==2)
            l.Text = "Gestion de Pharmacie ";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int pdd;
        private void timer1_Tick(object sender, EventArgs e)
        {
            pdd += 4;
            BaredeProgression.Value = pdd;
            if(BaredeProgression.Value ==100)
            { BaredeProgression.Value = 0;
                timer1.Stop();
                home mycon = new home(kk);
                mycon.Show();
                this.Hide();
                    
                    }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BaredeProgression_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
