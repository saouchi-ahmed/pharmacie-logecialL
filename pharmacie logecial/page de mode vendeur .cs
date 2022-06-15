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
    public partial class Form3 : Form
    {
        
        public Form3(int l)
        {
            nb=l;
            InitializeComponent();
            affichepnrml();
            lang(l);
            panel1.Visible=false;

        }
        private void lang(int l)
        {
            if (l==1)
            {
                label9.Text="        إدارة الصيدلة    ";
                label2.Text="          اسم منتج ";
                label1.Text="  كمية مستهلكة";
                button2.Text = "التعديل في مخزن";
                button1.Text = "استهلاك";
            }

        }
       private void Alart(String m)
        {
            Form4 r = new Form4(m);
            r.ShowDialog();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\skander.mdf;Integrated Security=True;Connect Timeout=30");
        private void affichepdang()
        {

            Con.Open();
            string req = " select * from produitdanger ";
            SqlDataAdapter adapter = new SqlDataAdapter(req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var d = new DataSet();
            adapter.Fill(d);
            Na.DataSource = d.Tables[0];
            Con.Close();


        }
        private void affichepnrml()
        {
          
            Con.Open();
            string req = " select * from TTable ";
            SqlDataAdapter adapter = new SqlDataAdapter(req, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var d = new DataSet();
            adapter.Fill(d);
            Na.DataSource = d.Tables[0];
            Con.Close();
          

        }
        int cle;
        string m ;
        private void  panel()
        {
          
            panel1.Visible=true;

            verifies();
        


        }

        private void recherchepdang()
        {

            if (cle == 0)
            {
                Con.Open();
                string req = " select  * from produitdanger where nom= '" + T.Text + "'";
                SqlCommand cm = new SqlCommand(req, Con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
                if (Quen.Text == "")

                    MessageBox.Show("entre la quentite Svp");

                else if (dr.Read() == false)
                    MessageBox.Show("svp verifiez le nom de produit  ");


                else
                {
                    cle = dr.GetInt32(0);

                    e = dr.GetInt32(3);
                    Con.Close();

                    affichepdang();
                    dang=1;
                }



                dr.Close();
                Con.Close();
            }
        }
        private void recherchepnrml()
        {

            if (cle == 0)
            {
                Con.Open();
                string req = " select  * from TTable where nom= '" + T.Text + "'";
                SqlCommand cm = new SqlCommand(req, Con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();
                if (Quen.Text == "")

                    MessageBox.Show("entre la quentite Svp");

                else if (dr.Read() == false)
                {
                    Con.Close();
                    recherchepdang();
                }


                else
                {
                    cle = dr.GetInt32(0);

                    e = dr.GetInt32(3);
                    Con.Close();
                    affichepnrml();
                }



                dr.Close();
                Con.Close();
            }
        }
        private void Na_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            T.Text = Na.SelectedRows[0].Cells[1].Value.ToString();

            cle = Convert.ToInt32(Na.SelectedRows[0].Cells[0].Value.ToString());

        }
        private void Reinialisation()
        {
            T.Text = "";
            Quen.Text = "";
            e = 0;
            cle = 0;
        }
        int e = 0, q, s;
        private void we()
        {
            if (e == 0)
                e = Convert.ToInt32(Na.SelectedRows[0].Cells[3].Value.ToString());



            q = Convert.ToInt32(Quen.Text);
            s = e - q;
            Quen.Text = s.ToString();
            if (s <= 5)

                m = "Votre produit "+ T.Text+"a atteint la limite maximale,\n vous devez vérifier la quantité du produit .";
                


        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        public void consomq(int a)
        {

            Con.Open();

            DateTime date = DateTime.Now;
            MessageBox.Show(" ;;"+cle);
         
            string Reqq = " Update Tq set  q='" + q + "' ,date ='" + date + "' ,nom='"+T.Text+"' where idd = '" + cle + "' ";
            SqlCommand cmmd = new SqlCommand(Reqq, Con);
            cmmd.ExecuteNonQuery();
            MessageBox.Show(" produit ajoute avec succes");

            Con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            recherchepnrml();
            if (v==0)
            {
                if (cle == 0)
                    MessageBox.Show(" selectionnez un produit  Svp ");
                else
                {
                    if (dang==0)
                    {
                        try
                        {

                            Con.Open();
                            we();

                            if (s < 0)
                                MessageBox.Show("svp verifiez la quentite");
                            else
                            {
                                string Req = " Update TTable set quantité ='" + s + "'  where num ='" + cle + "'  ";
                                SqlCommand cmd = new SqlCommand(Req, Con);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show(" produit modifiez  avec succes nv Q est :" + s);

                                Con.Close();

                                affichepnrml();

                                if (s <= 5)
                                    Alart(m);
                                Reinialisation();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }
                    else
                    {
                        panel();
                        if (att==1)
                        {
                            panel1.Visible=false;
                            try
                            {

                                Con.Open();
                                we();

                                if (s < 0)
                                    MessageBox.Show("svp verifiez la quentite");
                                else
                                {
                                    string Req = " Update TTable set quantité ='" + s + "'  where num ='" + cle + "'  ";
                                    SqlCommand cmd = new SqlCommand(Req, Con);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show(" produit modifiez  avec succes nv Q est :" + s);

                                    Con.Close();

                                    affichepnrml();

                                    if (s <= 5)
                                        Alart(m);
                                    Reinialisation();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);

                            }
                        }
                        else

                            MessageBox.Show("svp verifiez les informations ");


                    }
                }
            }
            else
            {
                if (cle == 0)
                    MessageBox.Show(" selectionnez un produit  Svp ");
                else
                {
                    try
                    {
                        Con.Open();
                        we();

                        if (s < 0)
                            MessageBox.Show("svp verifiez la quentite");
                        else
                        {
                            string Req = " Update produitdanger set quantité ='" + s + "'  where num ='" + cle + "'  ";
                            SqlCommand cmd = new SqlCommand(Req, Con);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show(" produit modifiez  avec succes nv Q est :" + s);

                            Con.Close();

                            affichepdang();

                            if (s <= 5)
                                Alart(m);
                            Reinialisation();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }

            }
               

        }
        int nb;

        private void T_TextChanged(object sender, EventArgs e)
        {

        }
        int b = 0,dang=0;
        string motpass = "null", motpass1 = "nul";
        public void  verifies()
        {
          
            try
            {
                Con.Open();
                string req = " select  nom from client where id= '"+id.Text+"'";
                SqlCommand cm = new SqlCommand(req, Con);
                SqlDataReader dr;
                dr = cm.ExecuteReader();

                if (id.Text == "" || nom.Text == "")

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

                    motpass1=  nom.Text;

               

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
        int v = 0;
        int att=0;
        private void button3_Click(object sender, EventArgs e)
        {
            verifies();
            if (motpass!=motpass1 && b==0)
                MessageBox.Show(" verifies le id   Svp ");
            else if (motpass==motpass1)
            {
                b=0;
                motpass="null";
                motpass1="nul";


                v=1;
                att=1;


            }
        }

        private void kll ( int l)
        {
            Close();
            Form5 con = new Form5(l);
            con.ShowDialog();
           

        }
       private void button2_Click(object sender, EventArgs e)
        {
            kll(nb);
           
        }
    }


}