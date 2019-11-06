using ISS.Model;
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
    public partial class LogInYetkili : Form
    {
        public LogInYetkili()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = null;
            cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=iss_controller;Integrated Security=true");

            cn.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * from saglayicilar", cn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    if(txtYetkili.Text.ToLower() == dr[2].ToString().ToLower() && txtSifre.Text.ToLower() == dr[3].ToString().ToLower())
                    {
                       
                        Yonetici ynt = new Yonetici();
                        ynt.saglayici_sirket = dr[1].ToString();
                        ynt.saglayici_mail = dr[2].ToString().ToLower();
                        ynt.saglayici_sifre = dr[3].ToString().ToLower();
                        Form1 frm1 = new Form1(ynt);
                        frm1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Yetkili Bilgisi Bulunamadı");
                    }
                }
            }

            cn.Close();
        }
    }
}
