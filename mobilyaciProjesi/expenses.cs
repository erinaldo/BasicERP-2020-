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
    public partial class expenses : Form
    {
        public expenses()
        {
            InitializeComponent();
        }
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void expenses_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 30;
            doldurexpenses();
        }

        programLog prlg;
        public void doldurexpenses()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from expenses where not delete_status = '1'", con);
            try
            {
                adtr.Fill(ds, "expenses");
                dataGridView1.DataSource = ds.Tables["expenses"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();

                this.dataGridView1.Columns["exp_id"].Visible = false;
                this.dataGridView1.Columns["user_id"].Visible = false;
                this.dataGridView1.Columns["edit_date"].Visible = false;
                this.dataGridView1.Columns["insert_date"].Visible = false;
                this.dataGridView1.Columns["delete_status"].Visible = false;

                dataGridView1.Columns[1].HeaderText = "Gider No";
                dataGridView1.Columns[2].HeaderText = "Gider Adı";
                dataGridView1.Columns[3].HeaderText = "Gider Türü";
                dataGridView1.Columns[4].HeaderText = "Gider Durumu";
                dataGridView1.Columns[5].HeaderText = "Eklenme Tarihi";
                dataGridView1.Columns[6].HeaderText = "Gider Birimi";

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
                    column.Width = 250;
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

        private void button2_Click(object sender, EventArgs e)
        {
            expensesadd expekle = new expensesadd(this);
            expekle.Show();
        }
        public static string expno, expname, exptype, expstatus, expadddate, denid;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            expno = dataGridView1.CurrentRow.Cells["exp_no"].Value.ToString();
            expname = dataGridView1.CurrentRow.Cells["exp_name"].Value.ToString();
            exptype = dataGridView1.CurrentRow.Cells["exp_type"].Value.ToString();
            expstatus = dataGridView1.CurrentRow.Cells["exp_status"].Value.ToString();
            expadddate = dataGridView1.CurrentRow.Cells["exp_add_date"].Value.ToString();
            denid = dataGridView1.CurrentRow.Cells["den_id"].Value.ToString();
            expenseses exp = new expenseses(this);
            exp.Show();
        }
    }
}
