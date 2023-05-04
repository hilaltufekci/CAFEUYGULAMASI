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
    public partial class İcecekler : Form
    {
        public İcecekler()
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
            dataGridView1.Columns["SNo"].Visible = false;


        }
        private void button2_Click(object sender, EventArgs e)
        {
            Listele("select[IcecekNo],[IcecekAdi],[Fiyat],[Adet],[SAdi],s.SNo from  Saticilar s inner join Icecekler t on s.SNo =t.SNo ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into Icecekler (IcecekAdi,Fiyat,Adet,SNo) values (@IcecekAdi,@Fiyat,@Adet,@SNo)", baglan);
            komut.Parameters.AddWithValue("@IcecekAdi", comboBox1.Text);
            komut.Parameters.AddWithValue("@Fiyat", textBox1.Text);
            komut.Parameters.AddWithValue("@Adet", textBox2.Text);
            komut.Parameters.AddWithValue("@SNo", textBox3.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Icecekler");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Icecekler set IcecekAdi='" + comboBox1.Text.ToString() + "',Fiyat='" + textBox1.Text.ToString() + "',Adet='" + textBox2.Text.ToString() + "',SNo='" + textBox3.Text.ToString() + "'where IcecekNo='" + comboBox1.Tag + "'", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Icecekler");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("delete from Icecekler where IcecekNo=@IcecekNo", baglan);
            cmd.Parameters.AddWithValue("IcecekNo", comboBox1.Tag);
            cmd.ExecuteNonQuery();
            baglan.Close();
            Listele("select * from Icecekler");
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
            comboBox1.Tag = satir.Cells["IcecekNo"].Value.ToString();
            comboBox1.Text = satir.Cells["IcecekAdi"].Value.ToString();
            textBox1.Text = satir.Cells["Fiyat"].Value.ToString();
            textBox2.Text = satir.Cells["Adet"].Value.ToString();
            textBox3.Text = satir.Cells["SNo"].Value.ToString();
        }
    }
}
