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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        void listele()
        {
            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0; Data Source=bilgisyrbirimsatis.accdb");
            connect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter("select * from urunler", connect);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dataGridView1.DataSource = table;
            connect.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
                OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0; Data Source=bilgisyrbirimsatis.accdb");
                connect.Open();
                OleDbCommand cmmnd = new OleDbCommand("select * from urunler where urun_id=@no", connect);
                cmmnd.Parameters.AddWithValue("@no", textBox1.Text);
                OleDbDataReader okuyucu = cmmnd.ExecuteReader();
                if (okuyucu.Read())
                {
                    textBox2.Text = okuyucu["urunadi"].ToString();
                    textBox3.Text = okuyucu["markasi"].ToString();
                    textBox4.Text = okuyucu["fiyat"].ToString();
                    textBox5.Text = okuyucu["stok_adet"].ToString();


                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;



                }
                else
                {
                    MessageBox.Show("Kayıtınız Bulunamadı .");
                }
                connect.Close();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            listele();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            
                OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0; Data Source=bilgisyrbirimsatis.accdb");
                connect.Open();
                OleDbCommand cmmnd = new OleDbCommand("update urunler set urunadi=@urunad,markasi=@marka,fiyat=@fiyat,stok_adet=@stok where urun_id='" + textBox1.Text + "'", connect);
                cmmnd.Parameters.AddWithValue("@urunad", textBox2.Text);
                cmmnd.Parameters.AddWithValue("@marka", textBox3.Text);
                cmmnd.Parameters.AddWithValue("@fiyat", textBox4.Text);
                cmmnd.Parameters.AddWithValue("@stok", textBox5.Text);
                cmmnd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Girdiğiniz Kayıt Başarıyla Güncellendi.");
                listele();
            }


        }
      
    }

   

