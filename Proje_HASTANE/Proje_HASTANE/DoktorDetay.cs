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
    public partial class DoktorDetay : Form
    {
        public DoktorDetay()
        {
            InitializeComponent();
        }
        cqlbaglantisi bgl = new cqlbaglantisi();
        public string tca;
        private void DoktorDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = tca;

            // Doktor Ad Soyad
            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad From  Tbl_Doktorlar where DoktorTC=@p1",bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lblAdSoyad.Text = dr[0] + "" + dr[1];
            }
            bgl.baglanti().Close();

            //Randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuDoktor = '" + lblAdSoyad.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle fr = new FrmDoktorBilgiDuzenle();
            fr.tcno = lblTC.Text;
            fr.Show();

        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            RchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
