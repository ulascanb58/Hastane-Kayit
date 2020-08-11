using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Proje_HASTANE
{
    class cqlbaglantisi
    {
        public SqlConnection baglanti()
        {

            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-QE2NQQH\\SQLEXPRESS;Initial Catalog=HastaneProje;Integrated Security=True");
            baglan.Open();
            return baglan;

                }

    }
}
