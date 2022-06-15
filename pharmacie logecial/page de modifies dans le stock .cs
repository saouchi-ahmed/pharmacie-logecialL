using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
    
using System.Windows.Forms;

namespace pharmacie_logecial
{
    public partial class Form2 : Form
    {
        public Form2(int a)
        {
            InitializeComponent();
            affichepnrml();
            Lang(a);
            visible(1);
        }
        private void visible(int l)
        {
            if (l == 1)
            {
                label1.Visible=false;
                label2.Visible=false;
                label3.Visible=false;
                b2.Visible=false;
                b1.Visible=false;
                b3.Visible=false;
                checkBox1.Checked=false;
                b1.Text="";
                b2.Text="";
                b3.Text="";
            }
            else
            {
                
                label1.Visible=true;
                label2.Visible=true;
                label3.Visible=true;
                b2.Visible=true;
                b1.Visible=true;
                b3.Visible=true;


            }
        }
        private void Lang(int l)
        {
            if (l == 1)
            {
                l1.Text = "           إدارة الصيدلة    ";

                l2.Text = "          رقم المنتج";
                l3.Text = "          اسم منتج ";
                l4.Text = "           كيفية تخزين ";
                l5.Text = "      سعر";
                l6.Text = "        كمية   ";
                l7.Text = "        قابلة للاسترداد ";
                l8.Text = "          تاريخ اشتراء منتج ";
                l9.Text = "       تاريخ انتهاء صلاحية المنتج";
                button1.Text = "     اضافة";
                button2.Text = "     تحديث";
                button3.Text = "    حذف";
                button4.Text = "    اعادة تعيين";
            }
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\skander.mdf;Integrated Security=True;Connect Timeout=30");
         private void Reinialisation()
        { 
            NumTb.Text = "";
            NomTb.Text = "";
            PrixTb.Text = "";
            QuentiteTb.Text = "";
            remborsableTb.Text = "";
            T2.Text = "";
            T1.Text = "";
            etatstockTb.Text = "";
            cle = 0;
            visible(1);
         
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
        public void insert (int g)
        {
            Con.Open();
            DateTime date = DateTime.Now;

            string Reqqa = " insert into vente values( '"+g +"','" + date+ "','"+g+ "') ";
            SqlCommand cmdd = new SqlCommand(Reqqa, Con);
            cmdd.ExecuteNonQuery();
            Con.Close();
           
        }
        string g;
        int entie;
        public void ajautpr()
            {

            Con.Open();


            string Req = " insert into TTable values('" + NumTb.Text + "','" + NomTb.Text + "','" + PrixTb.Text + "','" + QuentiteTb.Text + "','" + etatstockTb.Text + "','" + remborsableTb.Text + "','" + T2.Value + "','" + T1.Value + "') ";
            SqlCommand cmd = new SqlCommand(Req, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" produit ajoute avec succes.");
            Con.Close();

        }
        public void ajautprdang()
        {

            Con.Open();


            string Req = " insert into produitdanger values('" + NumTb.Text + "','" + NomTb.Text + "','" + PrixTb.Text + "','" + QuentiteTb.Text + "','" + etatstockTb.Text + "','" + remborsableTb.Text + "','" + T2.Value + "','" + T1.Value + "','" + b1.Text + "','" + b2.Text + "','" + b3.Text + "') ";
            SqlCommand cmd = new SqlCommand(Req, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" produit dange ajoute avec succes.");
            Con.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked== false   && (NomTb.Text == "" || PrixTb.Text == "" || NumTb.Text == "" || QuentiteTb.Text == "" ||  remborsableTb.Text == "" || T2.Text == "" ||T1.Text == "" || etatstockTb.Text == ""))
                MessageBox.Show("Complitez les informations Svp ");
            else
       if (checkBox1.Checked== true  && (b1.Text == ""|| b2.Text == ""|| b3.Text == ""|| NomTb.Text == "" || PrixTb.Text == "" || NumTb.Text == "" || QuentiteTb.Text == "" ||  remborsableTb.Text == "" || T2.Text == "" ||T1.Text == "" || etatstockTb.Text == ""))
                MessageBox.Show("Complitez les informations de produit danger Svp ");
            else
            if (checkBox1.Checked==true)
            {  
                try 
                {
                    ajautprdang();

                   Reinialisation();
                    affichepdang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();

                }

            }
            else
            {
                try
                {
                    ajautpr();

                    Reinialisation();
                    affichepnrml();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reinialisation();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        int cle;
        private void Na_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                  NumTb.Text =Na.SelectedRows[0].Cells[0].Value.ToString();
                  NomTb.Text = Na.SelectedRows[0].Cells[1].Value.ToString();  
                 PrixTb.Text = Na.SelectedRows[0].Cells[2].Value.ToString();
             QuentiteTb.Text = Na.SelectedRows[0].Cells[3].Value.ToString(); 
            etatstockTb.Text = Na.SelectedRows[0].Cells[4].Value.ToString();
          remborsableTb.Text = Na.SelectedRows[0].Cells[5].Value.ToString();
                    T1.Text = Na.SelectedRows[0].Cells[6].Value.ToString();
                    T2.Text = Na.SelectedRows[0].Cells[7].Value.ToString();
            if (checkBox1.Checked==true)
            {
                b1.Text = Na.SelectedRows[0].Cells[8].Value.ToString();
                b2.Text = Na.SelectedRows[0].Cells[9].Value.ToString();
                b3.Text = Na.SelectedRows[0].Cells[10].Value.ToString();
            }
            if (NumTb.Text == "")
                cle = 0;
            else
            {
                cle = Convert.ToInt32(Na.SelectedRows[0].Cells[0].Value.ToString());
            }

        }
        public void supprimerpnrml()
        {
            Con.Open();


            string Req = " delete from TTable where num ="+cle+"  ";
            SqlCommand cmd = new SqlCommand(Req, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" produit supprime  avec succes");

            Con.Close();
        }
        public void supprimerpdang()
        {
            Con.Open();


            string Req = " delete from produitdanger where num ="+cle+"  ";
            SqlCommand cmd = new SqlCommand(Req, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" produit supprime  avec succes");

            Con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {

            if (cle == 0)
                MessageBox.Show("selectionnez un produit  Svp ");
            else
            if(checkBox1.Checked==true)
            {
                try
                {
                    supprimerpdang();

                    Reinialisation();
                    affichepdang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();

                }

            }
            else
            {
                try
                {
                    supprimerpnrml();

                    Reinialisation();
                    affichepnrml();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Con.Close();

                }
            }
        }
        public void modifiespnrml()
        {
            Con.Open();


            string Req = " Update TTable set num ='" + NumTb.Text + "', nom ='" + NomTb.Text + "', prix ='" + PrixTb.Text + "', quantité ='" + QuentiteTb.Text + "', stockage ='" + etatstockTb.Text + "' , remboursable ='" + remborsableTb.Text + "', date_d_achat ='" + T1.Value + "', Date_d_expiration='" + T2.Value + "' where num ='" + cle + "' ";
            SqlCommand cmd = new SqlCommand(Req, Con);
            cmd.ExecuteNonQuery();

            MessageBox.Show(" produit modifiez avec succes");

            Con.Close();
        }
        public void modifiespdang()
        {
            Con.Open();


            string Req = " Update produitdanger set num ='" + NumTb.Text + "', nom ='" + NomTb.Text + "', prix ='" + PrixTb.Text + "', quantité ='" + QuentiteTb.Text + "', stockage ='" + etatstockTb.Text + "' , remboursable ='" + remborsableTb.Text + "', date_d_achat ='" + T1.Value + "', Date_d_expiration='" + T2.Value + "' where num ='" + cle + "' ";
            SqlCommand cmd = new SqlCommand(Req, Con);
            cmd.ExecuteNonQuery();

            MessageBox.Show(" produit modifiez avec succes");

            Con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked== false   && (NomTb.Text == "" || PrixTb.Text == "" || NumTb.Text == "" || QuentiteTb.Text == "" ||  remborsableTb.Text == "" || T2.Text == "" ||T1.Text == "" || etatstockTb.Text == ""))
                MessageBox.Show("Complitez les informations Svp ");
            else
      if (checkBox1.Checked== true  && (b1.Text == ""|| b2.Text == ""|| b3.Text == ""|| NomTb.Text == "" || PrixTb.Text == "" || NumTb.Text == "" || QuentiteTb.Text == "" ||  remborsableTb.Text == "" || T2.Text == "" ||T1.Text == "" || etatstockTb.Text == ""))
                MessageBox.Show("Complitez les informations de produit danger Svp ");
            else
            if ( checkBox1.Checked==true)
            {
                try
                {
                    modifiespdang();

                    Reinialisation();
                    affichepdang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
            else
            {
                try
                {
                    modifiespnrml();

                    Reinialisation();
                    affichepnrml();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }



            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void l5_Click(object sender, EventArgs e)
        {

        }
        int num, prix, Quentitee;

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ajent a = new ajent();
            a.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                visible(2);
                affichepdang();
            }
            if (checkBox1.Checked==false)
            {
                visible(1);
                affichepnrml();
            }
        }
    
        private void recherchepdang()
        {
            if (NomTb.Text!=""||NumTb.Text!="")
            {
                if (NumTb.Text=="")
                {
                    try
                    {
                        Con.Open();
                        string rq = " select  * from produitdanger where nom= '" + NomTb.Text + "'";
                        SqlCommand cm = new SqlCommand(rq, Con);
                        SqlDataReader dr;
                        dr = cm.ExecuteReader();
                        if (dr.Read() == false)
                        {

                            MessageBox.Show("svp verifiez le nom de produit  ");
                        }
                        else
                        {
                            int v;
                            num= dr.GetInt32(0);
                            NumTb.Text=Convert.ToString(num);
                            cle =dr.GetInt32(0);
                            NomTb.Text= dr.GetString(1);

                            prix= dr.GetInt32(2);
                            PrixTb.Text=Convert.ToString(prix);
                            Quentitee= dr.GetInt32(3);
                            QuentiteTb.Text=Convert.ToString(Quentitee);

                            etatstockTb.Text= dr.GetString(4);
                            remborsableTb.Text = dr.GetString(5);

                            T1.Value = dr.GetDateTime(6);
                            T2.Value = dr.GetDateTime(7);
                            v= dr.GetInt32(8);
                            b1.Text=Convert.ToString(v);
                            v= dr.GetInt32(9);
                            b2.Text=Convert.ToString(v);
                            v= dr.GetInt32(10);
                            b3.Text=Convert.ToString(v);
                          
                            visible(2);
                            Con.Close();
                            affichepdang();
                            checkBox1.Checked=true;
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
                if (NomTb.Text=="")
                {
                    try
                    {
                        Con.Open();
                        string reqhq = " select  * from produitdanger where num= '" + NumTb.Text + "'";
                        SqlCommand cm = new SqlCommand(reqhq, Con);
                        SqlDataReader dr;
                        dr = cm.ExecuteReader();
                        if (dr.Read() == false)
                            MessageBox.Show("svp verifiez le num de produit  ");
                        else
                        {
                            int v;
                            num= dr.GetInt32(0);
                            NumTb.Text=Convert.ToString(num);
                            cle =dr.GetInt32(0);
                            NomTb.Text= dr.GetString(1);

                            prix= dr.GetInt32(2);
                            PrixTb.Text=Convert.ToString(prix);
                            Quentitee= dr.GetInt32(3);
                            QuentiteTb.Text=Convert.ToString(Quentitee);

                            etatstockTb.Text= dr.GetString(4);
                            remborsableTb.Text = dr.GetString(5);

                            T1.Value = dr.GetDateTime(6);
                            T2.Value = dr.GetDateTime(7);
                            v= dr.GetInt32(8);
                            b1.Text=Convert.ToString(v);
                            v= dr.GetInt32(9);
                            b2.Text=Convert.ToString(v);
                            v= dr.GetInt32(10);
                            b3.Text=Convert.ToString(v);
                            
                            visible(2);
                           
                            Con.Close();
                            affichepdang();
                            checkBox1.Checked=true;

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


            }
            else
                MessageBox.Show("svp entre  le nom de produit ou numero de  id   ");

        }

        private void PrixTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuentiteTb_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void NumTb_TextChanged(object sender, EventArgs e)
        {
            Focus();
        }

        private void recherche()
        {
            if (NomTb.Text!=""||NumTb.Text!="")
            {
                if (NumTb.Text=="")
                {
                    try
                    {
                        Con.Open();
                        string rq = " select  * from TTable where nom= '" + NomTb.Text + "'";
                        SqlCommand cm = new SqlCommand(rq, Con);
                        SqlDataReader dr;
                        dr = cm.ExecuteReader();
                        if (dr.Read() == false)
                        {
                            Con.Close();
                            recherchepdang();
                            
                            
                        }
                        else
                        {
                            num= dr.GetInt32(0);
                            NumTb.Text=Convert.ToString(num);
                            cle =dr.GetInt32(0);
                            NomTb.Text= dr.GetString(1);

                            prix= dr.GetInt32(2);
                            PrixTb.Text=Convert.ToString(prix);
                            Quentitee= dr.GetInt32(3);
                            QuentiteTb.Text=Convert.ToString(Quentitee);

                            etatstockTb.Text= dr.GetString(4);
                            remborsableTb.Text = dr.GetString(5);

                            T1.Value = dr.GetDateTime(6);
                            T2.Value = dr.GetDateTime(7);
                            visible(1);

                            Con.Close();
                            affichepnrml();
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
                if (NomTb.Text=="")
                {
                    try
                    {
                        Con.Open();
                        string reqhq = " select  * from TTable where num= '" + NumTb.Text + "'";
                        SqlCommand cm = new SqlCommand(reqhq, Con);
                        SqlDataReader dr;
                        dr = cm.ExecuteReader();
                        if (dr.Read() == false)
                        {
                            Con.Close();
                            recherchepdang();
                        }
                        else
                        {
                           num= dr.GetInt32(0);
                            NumTb.Text=Convert.ToString(num);
                            cle =dr.GetInt32(0);
                            NomTb.Text= dr.GetString(1);

                            prix= dr.GetInt32(2);
                            PrixTb.Text=Convert.ToString(prix);
                            Quentitee= dr.GetInt32(3);
                            QuentiteTb.Text=Convert.ToString(Quentitee);

                            etatstockTb.Text= dr.GetString(4);
                            remborsableTb.Text = dr.GetString(5);

                            T1.Value = dr.GetDateTime(6);
                            T2.Value = dr.GetDateTime(7);
                            visible(1);

                            Con.Close();
                            affichepnrml();
                            
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

             
            }
            else
                MessageBox.Show("svp entre  le nom de produit ou numero de  id   ");

        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (NumTb.Text=="" && NomTb.Text=="")
            {
                button7.BackColor = Color.DarkGray;
                cle =0;
                MessageBox.Show("Vous devez remplir la case nom ou numéro  ");
            }
            else if (NumTb.Text!="" && NomTb.Text!="")
            {
                button7.BackColor = Color.DarkGray;
                cle=0;
                MessageBox.Show("L'une des cases Nom ou Numéro doit être vide pour terminer le processus de recherche  ");
            }
            else
            {
                recherche();
                button7.BackColor =Color.WhiteSmoke;
            }
        }
    }
}
