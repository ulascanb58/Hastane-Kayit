using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_HASTANE
{
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        cqlbaglantisi bgl = new cqlbaglantisi();
        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {

        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC =@p1 and DoktorSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                DoktorDetay frm = new DoktorDetay();
                frm.tca = MskTC.Text;
                frm.Show();

            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı adı veya Parola..");

            }
            bgl.baglanti().Close();
        }

    }
    }

