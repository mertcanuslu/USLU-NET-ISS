using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS.DAL
{
    public class Helper
    {
        SqlConnection cn = null;
        public int ExecuteNonQuery(string cmdtext,SqlParameter[] p) {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString);
            SqlCommand cmd = new SqlCommand(cmdtext, cn);
            if(p!=null)
                cmd.Parameters.Add(p);
            Baglan(cn);
            return cmd.ExecuteNonQuery();
            Baglan(cn);
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
    }
}
