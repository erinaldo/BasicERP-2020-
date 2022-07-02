using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobilyaciProjesi
{
    public partial class personel : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";
        public personel()
        {
            InitializeComponent();
        }

        programLog prlg;
        public void doldurpersonel()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from tbl_personnel where delete_status = '0'", con);
            try
            {
                adtr.Fill(ds, "tbl_personnel");
                dataGridView1.DataSource = ds.Tables["tbl_personnel"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                con.Close();
                this.dataGridView1.Columns["per_id"].Visible = false;
                this.dataGridView1.Columns["img"].Visible = false;
                this.dataGridView1.Columns["cur_id"].Visible = false;
                this.dataGridView1.Columns["delete_status"].Visible = false;
                this.dataGridView1.Columns["user_id"].Visible = false;
                this.dataGridView1.Columns["edit_date"].Visible = false;

                dataGridView1.Columns[1].HeaderText = "Personel Sicil No";
                dataGridView1.Columns[2].HeaderText = "Personel TC Kimlik No";
                dataGridView1.Columns[3].HeaderText = "Personel Adı";
                dataGridView1.Columns[4].HeaderText = "Personel Soyadı";
                dataGridView1.Columns[5].HeaderText = "Doğum Tarihi";
                dataGridView1.Columns[6].HeaderText = "Kan Grubu";
                dataGridView1.Columns[7].HeaderText = "Cinsiyeti";
                dataGridView1.Columns[8].HeaderText = "Yetkisi";
                dataGridView1.Columns[9].HeaderText = "Medeni Hali";
                dataGridView1.Columns[10].HeaderText = "Telefon Numarası";
                dataGridView1.Columns[11].HeaderText = "Ev Adresi";
                dataGridView1.Columns[12].HeaderText = "Mail Adresi";
                dataGridView1.Columns[13].HeaderText = "IBAN Numarası";
                dataGridView1.Columns[14].HeaderText = "İşe Girdiği Tarih";
                dataGridView1.Columns[15].HeaderText = "Parmak İzi No";
                dataGridView1.Columns[16].HeaderText = "SSK Numarası";
                dataGridView1.Columns[17].HeaderText = "Vergi Numarası";
                dataGridView1.Columns[18].HeaderText = "Maaşı";
                dataGridView1.Columns[19].HeaderText = "Departman";
                dataGridView1.Columns[20].HeaderText = "Personel Aktiflik Durumu";

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
                    column.Width = 126;
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
            }
        }

        private void personel_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            dataGridView1.RowTemplate.Height = 30;
            doldurpersonel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            personeladd padd = new personeladd(this);
            padd.Show();
        }


        public static string tcno, adi, soyadi, dogumtarihi, kangrubu, cinsiyet, yetki, medenihali, gsm, evadresi, mail, iban, parmakizino, sskno, vergino, maas, depadi, perstatus, curadi, sicilno, perid, picurl;

        public static bool nullimage = false;

        public static Image img;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string depname = "";
            con.Open();
            string sqlquery4 = "SELECT dep_name FROM tbl_department where dep_id = '" + dataGridView1.CurrentRow.Cells["dep_id"].Value.ToString() + "'";
            SqlCommand command4 = new SqlCommand(sqlquery4, con);

            try
            {
                object nullableValue5 = command4.ExecuteScalar();
                if (nullableValue5 == null || nullableValue5 == DBNull.Value)
                {
                }
                else
                {
                    depname = nullableValue5.ToString();
                }
                string curname = "";
                string sqlquery5 = "SELECT cur_name FROM currency where cur_id = '" + dataGridView1.CurrentRow.Cells["cur_id"].Value.ToString() + "'";
                SqlCommand command5 = new SqlCommand(sqlquery5, con);
                try
                {
                    object nullableValue6 = command5.ExecuteScalar();
                    if (nullableValue6 == null || nullableValue6 == DBNull.Value)
                    {
                    }
                    else
                    {
                        curname = nullableValue6.ToString();
                    }
                    perid = dataGridView1.CurrentRow.Cells["per_id"].Value.ToString();
                    tcno = dataGridView1.CurrentRow.Cells["per_tc_no"].Value.ToString();
                    adi = dataGridView1.CurrentRow.Cells["per_name"].Value.ToString();
                    soyadi = dataGridView1.CurrentRow.Cells["per_surname"].Value.ToString();
                    dogumtarihi = dataGridView1.CurrentRow.Cells["per_bday"].Value.ToString();
                    kangrubu = dataGridView1.CurrentRow.Cells["blood_type"].Value.ToString();
                    cinsiyet = dataGridView1.CurrentRow.Cells["gender"].Value.ToString();
                    yetki = dataGridView1.CurrentRow.Cells["per_type"].Value.ToString();
                    medenihali = dataGridView1.CurrentRow.Cells["marital_status"].Value.ToString();
                    gsm = dataGridView1.CurrentRow.Cells["per_gsm"].Value.ToString();
                    evadresi = dataGridView1.CurrentRow.Cells["per_address"].Value.ToString();
                    mail = dataGridView1.CurrentRow.Cells["per_mail"].Value.ToString();
                    iban = dataGridView1.CurrentRow.Cells["per_iban"].Value.ToString();
                    parmakizino = dataGridView1.CurrentRow.Cells["per_f_no"].Value.ToString();
                    sskno = dataGridView1.CurrentRow.Cells["per_ssk_no"].Value.ToString();
                    vergino = dataGridView1.CurrentRow.Cells["per_tax_id"].Value.ToString();
                    maas = dataGridView1.CurrentRow.Cells["per_charge"].Value.ToString();
                    depadi = depname;
                    perstatus = dataGridView1.CurrentRow.Cells["per_status"].Value.ToString();
                    curadi = curname;
                    sicilno = dataGridView1.CurrentRow.Cells["sicil_no"].Value.ToString();

                    if (dataGridView1.CurrentRow.Cells["img"].Value != DBNull.Value)
                    {
                        var data = (Byte[])(dataGridView1.CurrentRow.Cells["img"].Value);
                        var stream = new MemoryStream(data);
                        pictureBox1.Image = Image.FromStream(stream);
                        img = pictureBox1.Image;
                        nullimage = false;
                    }
                    else
                    {
                        nullimage = true;
                    }

                    personels prs = new personels(this);
                    prs.Show();
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
                }
                
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
            }
            
        }
    }
}
