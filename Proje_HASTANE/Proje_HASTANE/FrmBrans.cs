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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        cqlbaglantisi bgl = new cqlbaglantisi();
        private void FrmBrans_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Branslar", bgl.baglanti());
            da.Fill(dt);

            dataGridView1.DataSource = dt;




        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Branslar (BransAd) values (@b1)",bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", txtBransAD.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Eklendi", "Bilgi");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtBransID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBransAD.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbl_branslar where Bransid = @b1", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", txtBransID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş silindi..");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update tbl_branslar set Bransad = @p1 where Bransid=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBransAD.Text);
            komut.Parameters.AddWithValue("@p2", txtBransID.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Güncellendi..");
        }
    }
}
