using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace bilgisayarbirimsatis
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        void listele()
        {
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0; Data Source=bilgisyrbirimsatis.accdb");
            connect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter("select * from uyeler", connect);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dataGridView1.DataSource = table;
            connect.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Değer girdiğinizden emin olun.");
            }
            else
            {
                OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0; Data Source=bilgisyrbirimsatis.accdb");
                connect.Open();
                OleDbCommand cmmnd = new OleDbCommand("insert into uyeler (ad,soyad,dtarihi,tckimlikno,telefonno,adres,eposta,sifre,cinsiyet) values (@ad,@soyad,@dtarihi,@tckimlikno,@telefonno,@adres,@eposta,@sifre,@cinsiyet)", connect);
                cmmnd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmmnd.Parameters.AddWithValue("@soyad", textBox2.Text);
                cmmnd.Parameters.AddWithValue("@dtarihi", maskedTextBox1.Text);
                cmmnd.Parameters.AddWithValue("@tckimlikno", maskedTextBox2.Text);
                cmmnd.Parameters.AddWithValue("@telefonno", maskedTextBox3.Text);
                cmmnd.Parameters.AddWithValue("@adres", textBox3.Text);
                cmmnd.Parameters.AddWithValue("@eposta", textBox4.Text);
                cmmnd.Parameters.AddWithValue("@sifre", textBox5.Text);
                

                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Değer Seçmediniz");
                }
                else
                {
                    cmmnd.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);

                }
                cmmnd.ExecuteNonQuery();
                comboBox1.Items.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                maskedTextBox3.Clear();
               
                textBox1.Focus();
                connect.Close();
            }



        }

        private void Form2_Load(object sender, EventArgs e)
        {
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0; Data Source=bilgisyrbirimsatis.accdb");
            connect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter("select * from uyeler", connect);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dataGridView1.DataSource = table;
            connect.Close();
            



        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
