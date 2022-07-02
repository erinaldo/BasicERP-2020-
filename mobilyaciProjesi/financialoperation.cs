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
    public partial class financialoperation : Form
    {
        public financialoperation()
        {
            InitializeComponent();
        }
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        private void financialoperation_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            dataGridView1.RowTemplate.Height = 30;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            doldurstokfinansal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        programLog prlg;
        public void doldurstokfinansal()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT tbl_stock.stock_no, tbl_stock.stock_name,  stock_currency.price,stock_currency.cur_id ,stock_currency.sc_status FROM tbl_stock INNER JOIN stock_currency ON tbl_stock.stock_id = stock_currency.stock_id where not tbl_stock.stock_status = '0'  and tbl_stock.delete_status = '0'", con);
            try
            {
                adtr.Fill(ds, "stock_currency");
                dataGridView1.DataSource = ds.Tables["stock_currency"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();

                dataGridView1.Columns[0].HeaderText = "Stok No";
                dataGridView1.Columns[1].HeaderText = "Stok Adı";
                dataGridView1.Columns[2].HeaderText = "Para Miktarı";
                dataGridView1.Columns[3].HeaderText = "Para Birimi";
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
                    column.Width = 265;
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

        public void doldurmateryalfinansal()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT tbl_material.material_no, tbl_material.material_name, material_currency.price, material_currency.cur_id , material_currency.mc_status  FROM tbl_material INNER JOIN material_currency ON tbl_material.material_id = material_currency.material_id where not tbl_material.material_status = '0'", con);
            try
            {
                adtr.Fill(ds, "material_currency");
                dataGridView1.DataSource = ds.Tables["material_currency"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();

                dataGridView1.Columns[0].HeaderText = "Materyal No";
                dataGridView1.Columns[1].HeaderText = "Materyal Adı";
                dataGridView1.Columns[2].HeaderText = "Para Miktarı";
                dataGridView1.Columns[3].HeaderText = "Para Birimi";
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
                    column.Width = 265;
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
            }
            con.Close();
        }

        void parabirimigetir()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds1 = new DataSet();
            con.Open();
            SqlDataAdapter adtr1 = new SqlDataAdapter("select cur_name from currency where cur_id = '" + dataGridView1.CurrentRow.Cells["cur_id"].Value.ToString() + "'", con);
            try
            {
                adtr1.Fill(ds1, "currency");
                dataGridView2.DataSource = ds1.Tables["currency"];
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr1.Dispose();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
            }
            con.Close();
        }

        public static string labelname = "Stok Mali İşlemleri";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Stok Ürünleri")
            {
                doldurstokfinansal();
                label1.Text = "Stok Mali İşlemleri";
                labelname = "Stok Mali İşlemleri";
            }
            else
            {
                doldurmateryalfinansal();
                label1.Text = "Materyal Mali İşlemleri";
                labelname = "Materyal Mali İşlemleri";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            financialadd fadd = new financialadd(this);
            fadd.Show();
        }

        public static string stockno, stockname, scstatus, paramiktari, parabirimi;

        private void button3_Click(object sender, EventArgs e)
        {
            currency cr = new currency();
            cr.Show();
            //this.Hide();
        }

        public static string materialno, materialname, mcstatus;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            parabirimigetir();
            if (labelname == "Stok Mali İşlemleri")
            {
                stockno = dataGridView1.CurrentRow.Cells["stock_no"].Value.ToString();
                stockname = dataGridView1.CurrentRow.Cells["stock_name"].Value.ToString();
                scstatus = dataGridView1.CurrentRow.Cells["sc_status"].Value.ToString();
            }
            else
            {
                materialno = dataGridView1.CurrentRow.Cells["material_no"].Value.ToString();
                materialname = dataGridView1.CurrentRow.Cells["material_name"].Value.ToString();
                mcstatus = dataGridView1.CurrentRow.Cells["mc_status"].Value.ToString();
            }
            paramiktari = dataGridView1.CurrentRow.Cells["price"].Value.ToString();
            parabirimi = dataGridView2.CurrentRow.Cells["cur_name"].Value.ToString();
            financials fs = new financials(this);
            fs.Show();
        }
    }
}
