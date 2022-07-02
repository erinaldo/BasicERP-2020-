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
    public partial class currency : Form
    {
        public currency()
        {
            InitializeComponent();
        }
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        private void button1_Click(object sender, EventArgs e)
        {
            financialoperation fc = new financialoperation();
            fc.Show();
            this.Close();
        }
        programLog prlg;
        public void doldurcurrency()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from currency where not delete_status = '1'", con);
            try
            {
                adtr.Fill(ds, "currency");
                dataGridView1.DataSource = ds.Tables["currency"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                this.dataGridView1.Columns["cur_id"].Visible = false;
                this.dataGridView1.Columns["user_id"].Visible = false;
                this.dataGridView1.Columns["edit_date"].Visible = false;
                this.dataGridView1.Columns["delete_status"].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Döviz No";
                dataGridView1.Columns[2].HeaderText = "Döviz Adı";
                dataGridView1.Columns[3].HeaderText = "Eklenme Tarihi";
                dataGridView1.Columns[4].HeaderText = "Durumu";
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
                    column.Width = 300;
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

        private void currency_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 30;
            doldurcurrency();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currencyadd cr = new currencyadd(this);
            cr.Show();
        }
        public static string curno, curname, curstatus;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            curno = dataGridView1.CurrentRow.Cells["cur_no"].Value.ToString();
            curname = dataGridView1.CurrentRow.Cells["cur_name"].Value.ToString();
            curstatus = dataGridView1.CurrentRow.Cells["cur_status"].Value.ToString();
            currencies cr = new currencies(this);
            cr.Show();
        }
    }
}
