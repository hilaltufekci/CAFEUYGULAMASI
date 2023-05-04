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
    public partial class Satıcılar : Form
    {
        public Satıcılar()
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
            Listele("select * from Saticilar");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Saticilar (SAdi,SAdres,Il,Urun,CalisanSayisi) values (@SAdi,@SAdres,@Il,@Urun,@CalisanSayisi)", baglan);
            komut.Parameters.AddWithValue("@SAdi", textBox1.Text);
            komut.Parameters.AddWithValue("@SAdres", textBox2.Text);
            komut.Parameters.AddWithValue("@Il", textBox3.Text);
            komut.Parameters.AddWithValue("@Urun", textBox4.Text);
            komut.Parameters.AddWithValue("@CalisanSayisi", textBox5.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Saticilar");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Saticilar set SAdi='" + textBox1.Text.ToString() + "',SAdres='" + textBox2.Text.ToString() + "',Il='" + textBox3.Text.ToString() + "',Urun='" + textBox4.Text.ToString() + "',CalisanSayisi='" + textBox5.Text.ToString() + "'where SNo='" + textBox1.Tag + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Saticilar");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("delete from Saticilar where SNo=@SNo", baglan);
            cmd.Parameters.AddWithValue("SNo", textBox1.Tag);
            cmd.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Saticilar");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sekmeler go = new Sekmeler();
            go.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Tag = satir.Cells["SNo"].Value.ToString();
            textBox1.Text = satir.Cells["SAdi"].Value.ToString();
            textBox2.Text = satir.Cells["SAdres"].Value.ToString();
            textBox3.Text = satir.Cells["Il"].Value.ToString();
            textBox4.Text = satir.Cells["Urun"].Value.ToString();
            textBox5.Text = satir.Cells["CalisanSayisi"].Value.ToString();
        }
    }
}
