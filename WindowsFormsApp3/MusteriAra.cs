using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class MusteriAra : Form
    {
        public Form1 form1;

        public MusteriAra()
        {
            InitializeComponent();
        }

        public MusteriAra(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Bul(int.Parse(textBox1.Text));
       
        }
        void Bul(int numara)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-B5C74FA\SQLEXPRESS;Initial Catalog=ntpdatabase;Integrated Security=true");
            SqlCommand cmd = new SqlCommand($"SELECT * FROM ttnetTablo WHERE musteriId=@mID", cn);
            cmd.Parameters.AddWithValue("@mID", numara);
            Baglan(cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               
                form1.textBox1.Text = dr[1].ToString();
                form1.textBox2.Text = dr[2].ToString();
                form1.maskedTextBox1.Text = dr[5].ToString();
      
                // MessageBox.Show(dr[1].ToString() + dr[2].ToString() + dr[3].ToString() + dr[4].ToString() + dr[5].ToString());
            }
            else
            {
                MessageBox.Show("Öğrenci Yok!");
            }
            dr.Close();

        }
        void Baglan(SqlConnection con)
        {
            try
            {
                if (con != null && con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                else if (con != null && con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bağlantı Hatası");
            }
        }
    }
}
