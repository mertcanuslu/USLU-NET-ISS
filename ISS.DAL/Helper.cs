using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS.DAL
{
    public class Helper:IDisposable
    {
        SqlConnection cn = null;
        public int ExecuteNonQuery(string cmdtext,SqlParameter[] p) {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, cn);
            if (p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            Baglan(cn);
            return cmd.ExecuteNonQuery();
        }
        public void TalepList()
        {
             
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ntpdatabase;Integrated Security=true");

            cn.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * from paketler", cn))
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
        public void Baglan(SqlConnection con)
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
                throw;
            }
        }

        public void Dispose()
        {
            cn.Dispose();
        }
    }
}
