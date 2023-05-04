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

namespace CAFEApplication
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source =DESKTOP-K4EVO3J; Initial Catalog=CAFEApplication;Integrated Security=true;");
        private void groupBox1_Enter(object sender, EventArgs e)
        {
         
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "KullaniciGiris";
            komut.Parameters.AddWithValue("KullaniciAdi", textBox1.Text);
            komut.Parameters.AddWithValue("Sifre", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Hoşgeldiniz.");
                Sekmeler go = new Sekmeler();
                go.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız.Lütfen tekrar deneyiniz.");
                textBox1.Clear();
                textBox2.Clear();
            }
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            Sekmeler go = new Sekmeler();
            go.Show();
            this.Hide();
        }
    }
}
