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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=.; initial catalog = tablo; integrated security=true");
        private void button1_Click(object sender, EventArgs e)
        {
            String kullanıcı, güvenlik, yenisifre;

            kullanıcı = txt_kullanici.Text;
            güvenlik = txt_güvenlik.Text;
            yenisifre = txt_yenisifre.Text;
            con.Open();
            String query = "SELECT * FROM kullanici WHERE kullaniciAdi = '" + kullanıcı + "' AND güvenlikSorusu = '" + güvenlik + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable dtable = new DataTable();
            sda.Fill(dtable);
            if (dtable.Rows.Count > 0)
            {
                String updateQuery = "UPDATE kullanici SET parola = '" + yenisifre + "' WHERE kullaniciAdi = '" + kullanıcı + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Şifre başarıyla güncellendi!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Şifre güncelleme hatalı!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            con.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {


        }
    }
}
