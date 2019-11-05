using ISS.DAL;
using ISS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS.BLL
{
    public class OgrenciBLL
    {
        public bool  Musteri_Ekle(Musteri mstr)
        {
            Helper hlp = new Helper();


            SqlParameter[] p = { new SqlParameter("@Ad", mstr.Ad), new SqlParameter("@Adres", mstr.Adres), new SqlParameter("@Numara", mstr.Num), new SqlParameter("@Paket", mstr.Paket), new SqlParameter("@Taahut", mstr.Taahut) };


            return hlp.ExecuteNonQuery("INSERT into ttnetTablo values (@Ad,@Adres,@Paket,@Taahut,@Numara)",p) > 0 ;
        }
    }
}
