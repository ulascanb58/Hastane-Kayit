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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();

        }
        cqlbaglantisi bgl = new cqlbaglantisi();

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void FrmHastaKayit_Load(object sender, EventArgs e)
        {
            txtAd.Focus();
        }

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet,HastaSikayet) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7) ",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTC.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtSifre.Text);
            komut.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
            komut.Parameters.AddWithValue("@p7", rtxtSikayet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Kaydınız Gerçekleşmiştir Şifreniz : " + txtSifre.Text,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information); 

         }
    }
}
