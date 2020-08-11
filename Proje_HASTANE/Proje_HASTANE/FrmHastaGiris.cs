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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        cqlbaglantisi bgl = new cqlbaglantisi();
        private void LnkKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FrmHastaKayit fr = new FrmHastaKayit();
            fr.Show();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC= @p1 and HastaSifre = @p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                
                FrmHastaDetay fr = new FrmHastaDetay();
                fr.tc = MskTC.Text;
               
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre girdiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }
    }
}
