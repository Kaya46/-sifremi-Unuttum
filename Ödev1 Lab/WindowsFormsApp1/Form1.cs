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
using System.Net;
using System.Net.Mail;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init_Data();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=.; initial catalog = tablo; integrated security=true");
            SqlCommand cmd = new SqlCommand("select*from kullanici", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            bool sonuc = false;
            string kullaniciAdi = textBox1.Text;
            string parola = textBox2.Text;

            while (dr.Read())
            {
                
                    if (dr["kullaniciAdi"].ToString().Trim() == kullaniciAdi && dr["parola"].ToString().Trim() == parola)
                    {
                        sonuc = true;
                        Save_Data();
                        break;
                    }
                    
                
               

            }
            if (sonuc)
            {
                MessageBox.Show("Giriş Başarılı", "Giriş Ekranı");
                sonuc = false;
                con.Close();
            }
            else {

                MessageBox.Show("Giriş Başarısız !", "Giriş Ekranı");

                con.Close();
            }
                


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 gecis = new Form2();
                gecis.Show();
              //this.Hide();
              

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void  Init_Data()
        {
            if (Properties.Settings.Default.Username != String.Empty)
            {
                if (Properties.Settings.Default.Remember == true)
                {

                    textBox1.Text = Properties.Settings.Default.Username;
                    textBox2.Text = Properties.Settings.Default.Password;
                    checkBox1.Checked = true;

                }
                else
                {
                    textBox2.Text = Properties.Settings.Default.Password;

                }
            }
        }
        private void Save_Data()
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.Username = textBox1.Text;
                Properties.Settings.Default.Password = textBox2.Text;
                Properties.Settings.Default.Remember = true;
                Properties.Settings.Default.Save();
            }
            else {
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Remember = false;
                Properties.Settings.Default.Save();

            }
          

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
