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
    public partial class home : Form
    { int l ;
        public home(int a)
        {
           
            InitializeComponent();
            lang(a);


        }
        public void  lang(int y)
        {
            l=y;
            if (y==1)
            {
                label1.Text = "           إدارة الصيدلة    ";
                button1.Text = "عرض كل الأدوية";
                button2.Text = "التعديل في مخزن";
                button4.BackColor = Color.MediumTurquoise;
                button3.BackColor = Color.DarkGray;
            }
            else if (y==2)
            {

                label1.Text = "Gestion de Pharmacie ";
                button1.Text = "affiche tous les produit";
                button2.Text = "modifies les produit";
                button3.BackColor = Color.MediumTurquoise;
                button4.BackColor = Color.DarkGray;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 Con = new Form5(l);

            Con.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 Con = new Form3(l);
            Con.Show();
            Close();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Gestion de Pharmacie ";
            button1.Text = "affiche tous les produit";
            button2.Text = "modifies les produit";
            button3.BackColor = Color.MediumTurquoise;
            button4.BackColor = Color.DarkGray;
            l = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "           إدارة الصيدلة    ";
            button1.Text = "عرض كل الأدوية";
            button2.Text = "التعديل في مخزن";
            button4.BackColor = Color.MediumTurquoise;
            button3.BackColor = Color.DarkGray;
            l = 1;
        }
    }
}
