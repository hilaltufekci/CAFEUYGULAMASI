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
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source =DESKTOP-K4EVO3J; Initial Catalog=CAFEApplication;Integrated Security=true;");
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label3.Visible = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select Count (*) from Saticilar", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label3.Text = dr[0].ToString();
            }
            baglan.Close();
        }

        private void Raporlar_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label4.Visible = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select Count (*) from Saticilar where Il ='İstanbul'", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0].ToString();
            }
            baglan.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label1.Visible = true;
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("select * from Saticilar  where CalisanSayisi=(select MAX(CalisanSayisi ) from Saticilar)", baglan);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                label1.Text = dr2["SAdi"].ToString();
            }
            baglan.Close();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label5.Visible = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Tatlılar where Adet =(select MAX(Adet) from Tatlılar )", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label5.Text = dr["TatlıAdi"].ToString();
            }
            baglan.Close();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label2.Visible = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Tatlılar where Fiyat =(select MAX(Fiyat) from Tatlılar )", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label2.Text = dr["TatlıAdi"].ToString();
            }
            baglan.Close();
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label9.Visible = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Siparisler where SiparisAdi =(select MAX(SiparisAdi) from Siparisler )", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label9.Text = dr["SiparisAdi"].ToString();
            }
            baglan.Close();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label7.Visible = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Icecekler where Adet =(select MAX(Adet) from Icecekler )", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label7.Text = dr["IcecekAdi"].ToString();
            }
            baglan.Close();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label6.Visible = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Icecekler where Fiyat =(select MAX(Fiyat) from Icecekler )", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label6.Text = dr["IcecekAdi"].ToString();
            }
            baglan.Close();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label8.Visible = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select Count (*) from Musteri", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label8.Text = dr[0].ToString();
            }
            baglan.Close();
        }
    }
}
