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
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }

        private void Musteriler_Load(object sender, EventArgs e)
        {
            SqlConnection cn = null;
            cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ntpdatabase;Integrated Security=true");

            cn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * from ttnetTablo", cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                        listBox1.Items.Add(dr[1].ToString());
                        listBox2.Items.Add(dr[2].ToString());
                        listBox3.Items.Add(dr[3].ToString());
                        listBox4.Items.Add(dr[4].ToString());
                        listBox5.Items.Add(dr[5].ToString());
                     }
                    }
                }

            cn.Close();
            

        }
    }
}
