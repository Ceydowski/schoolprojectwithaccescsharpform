using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace bilgisayarbirimsatis
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        void list() {

            OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0; Data Source=bilgisyrbirimsatis.accdb");
            connect.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter("select * from urunler", connect);
            DataTable table = new DataTable();
            adapt.Fill(table);
            dataGridView1.DataSource = table;
            connect.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            list();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            list();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
                OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0; Data Source=bilgisyrbirimsatis.accdb");
                connect.Open();
                OleDbCommand cmmnd = new OleDbCommand("insert into urunler (urun_id,urunadi,markasi,fiyat,stok_adet) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", connect);
                cmmnd.Parameters.AddWithValue("@urun_id", textBox1.Text);
                cmmnd.Parameters.AddWithValue("@urunadi", textBox2.Text);
                cmmnd.Parameters.AddWithValue("@markasi", textBox3.Text);
                cmmnd.Parameters.AddWithValue("@fiyat", textBox4.Text);
                cmmnd.Parameters.AddWithValue("@stok_adet", textBox5.Text);
                cmmnd.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                textBox1.Focus();
                list();
                connect.Close();
            }




           
        }

        
    }

