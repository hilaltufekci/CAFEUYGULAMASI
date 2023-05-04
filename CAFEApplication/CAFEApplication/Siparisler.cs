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
    public partial class Siparisler : Form
    {
        public Siparisler()
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
            dataGridView1.Columns["MusteriNo"].Visible = false;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Listele("select [SiparisNo],[SiparisAdi],[SiparisAdres],[SiparisTarihi],[AdSoyad],m.MusteriNo from Musteri s inner join Siparisler m on s.MusteriNo =m.MusteriNo ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Siparisler set SiparisAdi='" + textBox1.Text.ToString() + "',SiparisAdres='" + textBox2.Text.ToString() + "',SiparisTarihi='" + textBox3.Text.ToString() + "',MusteriNo='" + textBox4.Text.ToString() + "'where SiparisNo='" + textBox1.Tag + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Siparisler");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Siparisler (SiparisAdi,SiparisAdres,SiparisTarihi,MusteriNo) values (@SiparisAdi,@SiparisAdres,@SiparisTarihi,@MusteriNo)", baglan);
            komut.Parameters.AddWithValue("@SiparisAdi", textBox1.Text);
            komut.Parameters.AddWithValue("@SiparisAdres", textBox2.Text);
            komut.Parameters.AddWithValue("@SiparisTarihi", textBox3.Text);
            komut.Parameters.AddWithValue("@MusteriNo", textBox4.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Siparisler");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("delete from Siparisler where SiparisNo=@SiparisNo", baglan);
            cmd.Parameters.AddWithValue("SiparisNo", textBox1.Tag);
            cmd.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Siparisler");

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
            textBox1.Tag = satir.Cells["SiparisNo"].Value.ToString();
            textBox1.Text = satir.Cells["SiparisAdi"].Value.ToString();
            textBox2.Text = satir.Cells["SiparisAdres"].Value.ToString();
            textBox3.Text = satir.Cells["SiparisTarihi"].Value.ToString();
            textBox4.Text = satir.Cells["MusteriNo"].Value.ToString();
        }
    }
}
