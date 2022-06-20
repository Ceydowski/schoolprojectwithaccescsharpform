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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (textBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Değer girdiğinizden emin olun.");
            }
            else
            {
                OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0; Data Source=bilgisyrbirimsatis.accdb");
                connect.Open();
                OleDbCommand cmmnd = new OleDbCommand("select * from urunler where urun_id=@urun_id or urunadi=@urunad"  , connect);
                cmmnd.Parameters.AddWithValue("@urun_id", textBox1.Text);
                cmmnd.Parameters.AddWithValue("@urunadi", textBox1.Text);
                cmmnd.ExecuteNonQuery();
           
                OleDbDataReader readd = cmmnd.ExecuteReader();
                if (readd.Read())
                {
                    label5.Text = readd["urunadi"].ToString();
                    label6.Text = readd["fiyat"].ToString();
                    label7.Text = readd["stok_adet"].ToString();
                    label8.Text = readd["urun_id"].ToString();

                }
                else
                {
                    MessageBox.Show("Aradığınız kayıt bulunamadı.");
                    label5.Text = "";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";

                    textBox1.Text = "";
                    textBox1.Focus();



                }
            }
           
  


        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label5.Text == "")
            {
                MessageBox.Show("Girdiğiniz Kayıt Aratılamadı Veya Stokta kalmadı.");
            }
            else
            {
                DialogResult snc = new DialogResult();
                snc = MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Stok Silme", MessageBoxButtons.YesNo);
                if (snc == DialogResult.Yes)
                {

                    OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0; Data Source=bilgisyrbirimsatis.accdb");

                    connect.Open();
                    OleDbCommand cmmnd = new OleDbCommand("delete from urunler where urun_id='"+textBox1.Text+"'", connect);
                    cmmnd.ExecuteNonQuery();
                    cmmnd.Parameters.AddWithValue("@numara", label5.Text);

            
                    MessageBox.Show("Silme İşlemi Gerçekleşti.");
                    listele();


                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi.");
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || label8.Text == "")
            {
                MessageBox.Show("Ürün Aratılamadı Veya Adet Değeri Girilmedi.");
            }
            else
            {

                OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0; Data Source=bilgisyrbirimsatis.accdb");
                connect.Open();
                OleDbCommand cmmnd = new OleDbCommand("update urunler set stok_adet=stok_adet-(@stok) where urun_id=@urun_id", connect);
                cmmnd.Parameters.AddWithValue("@stok", textBox2.Text);
                cmmnd.Parameters.AddWithValue("@urun_id", label8.Text);
                cmmnd.ExecuteNonQuery();
                OleDbCommand cmmnd2= new OleDbCommand("insert into satis values (@urunno,@adi,@adet,@fiyat)", connect);
                double tfiyat;
                tfiyat= Convert.ToDouble(textBox2.Text) * Convert.ToDouble(label6.Text);
                cmmnd2.Parameters.AddWithValue("@urunno", label5.Text);
                cmmnd2.Parameters.AddWithValue("@adi", label8.Text);
                cmmnd2.Parameters.AddWithValue("@adet", textBox2.Text);
                cmmnd2.Parameters.AddWithValue("@fiyat", tfiyat);
                cmmnd2.ExecuteNonQuery();
                connect.Close();
                listele();
                MessageBox.Show("Satış İşlemi Tamamlandı :)");


            } 
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
