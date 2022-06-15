using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pharmacie_logecial
{
    public partial class conexion : Form
    {
        public conexion()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\skander.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void label2_Click(object sender, EventArgs e)
        {

        }
        int id=0, id1=9,b=0,l=2;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void Id_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = " connexion ";
            label2.Text = " Nom Utilisateur ";
            label3.Text = " Id";
            button1.Text = "connexion";
            button4.BackColor = Color.DarkGray;
            button3.BackColor = Color.MediumSeaGreen;
            l = 2;
        }

        private void conexion_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {   
            label1.Text = "تسجيل الدخول ";
            label2.Text = "                 اسم المستخدم ";
            label3.Text = "رقم التعريف";
            button1.Text = "تسجيل الدخول";
            button3.BackColor = Color.DarkGray;
            button4.BackColor = Color.MediumSeaGreen;
            l = 1;
        }

        public void verifies()
        {
            Con.Open();
            string req = " select  id from lesemployes where nom= '"+Nom.Text+"'";
            SqlCommand cm = new SqlCommand(req, Con);
            SqlDataReader dr;
            dr = cm.ExecuteReader();

            if (Nom.Text == "" || Id.Text == "")

            {
                MessageBox.Show("entre le nom et id slvp");
                b=1;
            }

            else if (dr.Read() == false)
            {
                MessageBox.Show("svp verifiez les informations  ");
                b=1;
            }
            else
            {
                id= dr.GetInt32(0);

                id1=  Convert.ToInt32(Id.Text);

            }



            dr.Close();
            Con.Close();


        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            verifies();
           
           

            if (id!=id1 && b==0)
                MessageBox.Show(" verifies le id   Svp ");
            else if (id == id1)
            {

                b=0;
                id = 0;
                id1 = 9;
                Form1 F = new Form1(l);

                F.Show();

               
               

            }
         

        }

         
        
    }
}
