﻿using System;
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
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source =DESKTOP-K4EVO3J; Initial Catalog=CAFEApplication;Integrated Security=true;");
        public void Listele(string komutkod)
        {
            SqlDataAdapter dr = new SqlDataAdapter(komutkod, baglan);
            DataTable doldur = new DataTable();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            Listele("select * from Musteri");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Musteri (AdSoyad,Telefon,Email,Yas) values (@AdSoyad,@Telefon,@Email,@Yas)", baglan);
            komut.Parameters.AddWithValue("@AdSoyad", textBox1.Text);
            komut.Parameters.AddWithValue("@Telefon", textBox2.Text);
            komut.Parameters.AddWithValue("@Email", textBox3.Text);
            komut.Parameters.AddWithValue("@Yas", textBox4.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Musteri");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Musteri set AdSoyad='" + textBox1.ToString() + "',Telefon='" + textBox2.Text.ToString() + "',Email='" + textBox3.Text.ToString() + "',Yas='" + textBox4.Text.ToString() + "'where MusteriNo='" + textBox1.Tag + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Musteri");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sekmeler go = new Sekmeler();
            go.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("delete from Musteri where MusteriNo= @MusteriNo", baglan);
            cmd.Parameters.AddWithValue("MusteriNo", textBox1.Tag);
            cmd.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Musteri");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["MusteriNo"].Value.ToString();
            textBox1.Text = satir.Cells["AdSoyad"].Value.ToString();
            textBox2.Text = satir.Cells["Telefon"].Value.ToString();
            textBox3.Text = satir.Cells["Email"].Value.ToString();
            textBox4.Text = satir.Cells["Yas"].Value.ToString();
        }
    }
}
