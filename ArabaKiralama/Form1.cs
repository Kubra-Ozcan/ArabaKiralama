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


namespace ArabaKiralama
{
    public partial class Form1 : Form
    {
      
        SqlConnection con = new SqlConnection("server = LAPTOP-CH16DCVB\\SQLEXPRESS01; initial catalog = otoKiraDB ; integrated security =sspi");
        SqlCommand cmd;
        SqlDataAdapter da;

        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            pictureBox1.ImageLocation = "";


        }


         void listele()
        {
            da  = new SqlDataAdapter("select * from arabalar ", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand(" UPDATE  arabalar  SET plaka= '" + textBox1.Text + "', marka = '" + textBox2.Text + "', model= '" + textBox3.Text + "', uretimYili= '" + int.Parse(textBox4.Text) + "', km= '" + int.Parse(textBox5.Text) + "', renk= '" + textBox6.Text + "', yakitTuru= '" + textBox7.Text + "', KiraUcreti = '" + textBox8.Text + "',durum= '" + comboBox1.Text + "', resim= '" + pictureBox1.ImageLocation + "'  where id = '" + int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()) + "'       ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("kayit guncellendi. .");
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand(" DELETE from arabalar   where id = '" + int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()) + "'       ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("kayit silindi! .");
            listele();

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into  arabalar  (plaka, marka, model, uretimYili, km, renk, yakitTuru , KiraUcreti, durum, resim)  values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "',  '" + int.Parse(textBox4.Text) + "',  '" + int.Parse(textBox5.Text) + "', '" + textBox6.Text + "',  '" + textBox7.Text + "',   '" + textBox8.Text + "', '" + comboBox1.Text + "',  '" + pictureBox1.ImageLocation + "'  )       ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("kayit Eklendi. ");
            listele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of1 = new OpenFileDialog();
            of1.Filter = " Resim dosyalari | *jpg ; *.png ; *.tif|Tum dosyalar |*.*";
            of1.ShowDialog();
            pictureBox1.ImageLocation = of1.FileName;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            comboBox1.Text= dataGridView2.CurrentRow.Cells[9].Value.ToString();
            pictureBox1.ImageLocation = dataGridView2.CurrentRow.Cells[10].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from arabalar WHERE marka like  '" +textBox9.Text+"%' ", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
        }
    }
}
