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
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string tcno;

        cqlbaglantisi bgl = new cqlbaglantisi();

        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTC.Text = tcno;

            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar where HastaTC = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                mskTelefon.Text = dr[4].ToString();
                txtSifre.Text = dr[5].ToString();
                cmbCinsiyet.Text = dr[6].ToString();
                rtxtSikayet.Text = dr[7].ToString();

            }
            bgl.baglanti().Close();


        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Hastalar set HastaAd = @p1, HastaSoyad = @p2 , HastaTC = @p3, HastaTelefon = @p4,HastaSifre = @p5, HastaCinsiyet = @p6, HastaSikayet = @p7 where HastaTC = @p3 ", bgl.baglanti());

            komut2.Parameters.AddWithValue("@p1", txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", MskTC.Text);
            komut2.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut2.Parameters.AddWithValue("@p5", txtSifre.Text);
            komut2.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p7", rtxtSikayet.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi..", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
