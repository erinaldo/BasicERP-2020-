using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobilyaciProjesi
{
    public partial class onaysizsatislar : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";
        public onaysizsatislar()
        {
            InitializeComponent();
        }
        programLog prlg;
        void datadoldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT s.customer_name, hp.slip_no as fisNo, hp.slip_type as fisTürü, hp.price as fiyat, hp.total_kdv as kdvTutari, hp.allcost as toplamTutar, hp.charged_money as alinanMiktar, hp.sold_date as satisTarihi, hp.payment_date as odemeTarihi, c.cur_name as paraBirimi, h.user_nickname as satici FROM tbl_customer s INNER JOIN tbl_sale hp on s.customer_id = hp.customer_id INNER JOIN tbl_user h on hp.user_id= h.user_id INNER JOIN currency c on hp.currency= c.cur_id where hp.status = '1'", con);
            try
            {
                adtr.Fill(ds, "tbl_customer");
                dataGridView1.DataSource = ds.Tables["tbl_customer"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                dataGridView1.Columns[0].HeaderText = "Müşteri Adı";
                dataGridView1.Columns[1].HeaderText = "Fiş Numarası";
                dataGridView1.Columns[2].HeaderText = "Fiş Tipi";
                dataGridView1.Columns[3].HeaderText = "Brüt Fiyat";
                dataGridView1.Columns[4].HeaderText = "Kdv Fiyatı";
                dataGridView1.Columns[5].HeaderText = "Toplam Fiyat";
                dataGridView1.Columns[6].HeaderText = "Alınan Miktar";
                dataGridView1.Columns[7].HeaderText = "Satış Tarihi";
                dataGridView1.Columns[8].HeaderText = "Ödeme Tarihi";
                dataGridView1.Columns[9].HeaderText = "Para Birimi";
                dataGridView1.Columns[10].HeaderText = "Satışı Yapan Personel";
                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    DataGridViewColumn column = dataGridView1.Columns[i];
                    column.Width = 100;
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
            }
            con.Close();
        }
        private void onaysizsatislar_Load(object sender, EventArgs e)
        {
            datadoldur();
        }

        public static string slipno = "";
        public static string slipid = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            slipno = dataGridView1.CurrentRow.Cells["fisNo"].Value.ToString();
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT slip_id FROM tbl_sale where slip_no = '" + slipno + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            slipid = "";
            con.Open();
            try
            { slipid = command2.ExecuteScalar().ToString(); }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG15"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG15", "Sistem Mesajı"); }
            //PROGRAMLOG
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (slipno != "")
            {
                DialogResult c;
                c = MessageBox.Show("Bu satışı iptal etmek istiyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    con.Open();
                    //string sqlquery = "SELECT slip_id FROM tbl_sale where slip_no = '" + slipno + "'";
                    //SqlCommand command2 = new SqlCommand(sqlquery, con);
                    //string slipid = "";
                    //try
                    //{ slipid = command2.ExecuteScalar().ToString(); }
                    //catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG14"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG14", "Sistem Mesajı"); }
                    //PROGRAMLOG

                    SqlCommand command1 = new SqlCommand("delete from tbl_sale where slip_no = '" + slipid + "'", con);
                    try { command1.ExecuteNonQuery(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG4"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı"); }
                    //PROGRAMLOG

                    SqlCommand command4 = new SqlCommand("delete from sale_details where slip_id = '" + slipid + "'", con);
                    try { command4.ExecuteNonQuery(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG5"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı"); }
                    //PROGRAMLOG

                    SqlCommand command3 = new SqlCommand("delete from sale_opencheck where slip_id = '" + slipid + "'", con);
                    try { command3.ExecuteNonQuery(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG6"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı"); }
                    //PROGRAMLOG
                    con.Close();
                    MessageBox.Show("Satış iptal edildi.", "Sistem Mesajı");
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (slipno != "")
            {
                DialogResult c;
                c = MessageBox.Show("Bu satışı onaylıyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    SqlCommand command = new SqlCommand("update tbl_sale set status=@status,boss_date=@bossdate where slip_id = '" + slipid + "'", con);
                    command.Parameters.AddWithValue("@status", "0");
                    command.Parameters.AddWithValue("@bossdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    con.Open();
                    if (Convert.ToInt64(dataGridView1.CurrentRow.Cells["fisTürü"].Value) <3)
                    {
                        SqlCommand command1 = new SqlCommand("update tbl_sale set over_status=@overstatus where slip_id = '" + slipid + "'", con);
                        command1.Parameters.AddWithValue("@overstatus", "1");
                        try { command1.ExecuteNonQuery(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG3"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı"); }
                    }
                    try { command.ExecuteNonQuery(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG2"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı"); }
                    //PROGRAMLOG
                    con.Close();
                    MessageBox.Show("Satış onaylandı.", "Sistem Mesajı");
                    this.Close();
                }
            }
        }
    }
}
