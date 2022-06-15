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
    public partial class client : Form
    {
        int p;
        public client(int a)
        {
            InitializeComponent();
            Lang(a);
            ss(a);
        }

        private void client_Load(object sender, EventArgs e)
        {

        }

        public void ss(int w)
        {
            p = w;
        }
        private void Lang(int l)
        {
            if (l == 1)
            {
                label1.Text = "       الإتصال   ";

                label2.Text = "        اسم المستخدم";
                label3.Text = "      الرمزالسري ";

                button1.Text = " تسجيل الدخول";

            }
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\skander.mdf;Integrated Security=True;Connect Timeout=30");

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        int b = 0;
        string motpass = "null", motpass1 = "nul";

        public void verifies()
        {
            try
            {
                Con.Open();
                string req = " select  nom from client where id= '"+id.Text+"'";
                SqlCommand cm = new SqlCommand(req, Con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();

                if (id.Text == "" || motspass.Text == "")

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
                    motpass=   dr.GetString(0);

                    motpass1=  motspass.Text;

                }



                dr.Close();
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Con.Close();

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            verifies();


            if (motpass!=motpass1 && b==0)
                MessageBox.Show(" verifies le id   Svp ");
            else if (motpass==motpass1)
            {
                b=0;
                motpass="null";
                motpass1="nul";

            }
        }
    }
}   
    


