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
    public partial class ListItem3 : UserControl
    {
        public ListItem3()
        {
            InitializeComponent();
        }

        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        public static string stockid = sale.stockid;
        public static string stockno = sale.stockno;

        public static bool create = true;


        //public static string[] stringdizi2 = new string[1];
        private void ListItem3_Load(object sender, EventArgs e)
        {
            stockid = sale.stockid;
            string stringToCheck = sale.stockno;

            if (sale.createcontrol == true)
            {
                foreach (string x in sale.dist2)
                {
                    if (stringToCheck.Contains(x))
                    {
                        sale.dist2 = sale.dist2.Where(o => o != textBox1.Text).ToArray();
                        this.Parent.Controls.Remove(this);
                    }
                    else
                    {
                        kdvatama();
                        stocknogetir();
                        stocknamegetir();
                        stockfiyatgetir();
                        stockidgetir();
                        label1.Text = id;
                    }
                }
            }
            else
            {
                kdvatama();
                stocknogetir();
                stocknamegetir();
                stockfiyatgetir();
                stockidgetir();
                label1.Text = id;
            }

        }


        private void ListItem3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Stok No";
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "Stok Adı";
            }
            if (textBox3.Text == "")
            {
                textBox3.Text = "Miktar";
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "Fiyat";
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = "KDV (%)";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sale.dist2 = sale.dist2.Where(o => o != textBox1.Text).ToArray();

            this.Parent.Controls.Remove(this);
        }




        programLog prlg;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select stock_no, stock_name, stock_id from tbl_stock where stock_no like '%" + textBox1.Text + "%'", con);

                try
                {
                    adtr.Fill(ds, "tbl_stock");
                    dataGridView1.DataSource = ds.Tables["tbl_stock"];
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    adtr.Dispose();

                    this.dataGridView1.Columns["stock_name"].Visible = false;
                    this.dataGridView1.Columns["stock_id"].Visible = false;

                    dataGridView1.Columns[0].HeaderText = "Stok No";
                    dataGridView1.Visible = true;
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, "ListItem3", "PRLG1");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
                }
                con.Close();
            }
            else
            {
                dataGridView1.Visible = false;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select stock_name, stock_no, stock_id from tbl_stock where stock_name like '%" + textBox2.Text + "%'", con);
                try
                {
                    adtr.Fill(ds, "tbl_stock");
                    dataGridView2.DataSource = ds.Tables["tbl_stock"];
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    adtr.Dispose();
                    dataGridView2.Columns[0].HeaderText = "Stok Adı";
                    dataGridView2.Visible = true;
                    this.dataGridView2.Columns["stock_no"].Visible = false;
                    this.dataGridView2.Columns["stock_id"].Visible = false;
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, "ListItem3", "PRLG2");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
                }
                con.Close();
            }
            else
            {
                dataGridView2.Visible = false;
            }
        }





        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Stok No")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Stok Adı")
            {
                textBox2.Text = "";
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Miktar")
            {
                textBox3.Text = "";
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "Fiyat")
            {
                textBox4.Text = "";
            }
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "KDV (%)")
            {
                textBox5.Text = "";
            }
        }



        #region Properties
        private string _stokno;
        private string _stokadi;
        private string _miktar;
        private string _fiyat;
        private string _kdv;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                                                    
        /// <summary>
        ///VERİTABANINDAN KAYIT ÇEKEN KOD vvvvvvvvvvvvvvvvv ///////////////////////
        /// </summary>

        [Category("CustomProps")]
        public string StokNo1
        {
            get
            {
                return _stokno;
            }
            set
            {
                _stokno = value;
                textBox1.Text = value;
            }
        }

        [Category("CustomProps")]
        public string StokAdi1
        {
            get
            {
                return _stokadi;
            }
            set
            {
                _stokadi = value;
                textBox2.Text = value;
            }
        }

        [Category("CustomProps")]
        public string Miktar1
        {
            get
            {
                return _miktar;
            }
            set
            {
                _miktar = value;
                textBox3.Text = value;
            }
        }

        [Category("CustomProps")]
        public string Fiyat1
        {
            get
            {
                return _fiyat;
            }
            set
            {
                _fiyat = value;
                textBox4.Text = value;
            }
        }

        [Category("CustomProps")]
        public string Kdv1
        {
            get
            {
                return _kdv;
            }
            set
            {
                _kdv = value;
                textBox5.Text = value;
            }
        }

        /// <summary>
        ///VERİTABANINDAN KAYIT ÇEKEN KOD ^^^^^^^^^^^^^^^^^^ /////////////////////////////////////////
        /// </summary>
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                                                    
        /// <summary>
        ///VERİTABANINA KAYIT EDEN KOD vvvvvvvvvvvvvvvvv ///////////////////////
        /// </summary>


        public string StokNo
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public string StokAdi
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }

        public string Miktar
        {
            get { return textBox3.Text; }
            set { textBox3.Text = value; }
        }

        public string Fiyat
        {
            get { return textBox4.Text; }
            set { textBox4.Text = value; }
        }

        public string Kdv
        {
            get { return textBox5.Text; }
            set { textBox5.Text = value; }
        }

        public string StokId
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }



        /// <summary>
        ///VERİTABANINA KAYIT EDEN KOD ^^^^^^^^^^^^^^^^^^ /////////////////////////////////////////
        /// </summary>
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    


        #endregion


        void kdvatama()
        {
            if (sale.kdv != "KDV (%)")
            {
                textBox5.Text = sale.kdv;
            }
        }

        void stocknamegetir()
        {
            if (sale.stockname != "")
            {
                textBox2.Text = sale.stockname;
            }
        }

        void stocknogetir()
        {
            if (sale.stockno != "")
            {
                textBox1.Text = sale.stockno;
            }
        }

        void stockfiyatgetir()
        {
            if (sale.currencyid == "" && sale.stockid == "")
            {

            }
            else
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);

                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("SELECT stock_currency.price FROM stock_currency INNER JOIN currency ON stock_currency.cur_id = currency.cur_id where stock_currency.stock_id = '" + sale.stockid + "' and stock_currency.cur_id = '" + sale.currencyid + "'", con);
                try
                {
                    adtr.Fill(ds, "stock_currency");
                    dataGridView3.DataSource = ds.Tables["stock_currency"];
                    dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    adtr.Dispose();

                    foreach (DataGridViewRow rw in this.dataGridView3.Rows)
                    {
                        for (int i = 0; i < rw.Cells.Count; i++)
                        {
                            if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                            {
                                // here is your message box...
                            }
                            else
                            {
                                textBox4.Text = dataGridView3.CurrentRow.Cells["price"].Value.ToString();
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, "ListItem3", "PRLG3");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
                }
                con.Close();
            }
        }



        public static string id = "";
        void stockidgetir()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT stock_id FROM tbl_stock where stock_no = '" + textBox1.Text + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string stokid = "";
            con.Open();
            try { stokid = command2.ExecuteScalar().ToString(); id = stokid; } catch (SqlException ex) { prlg = new programLog(ex.Message, "ListItem3", "PRLG4"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı"); }
            //PROGRAMLOG
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["stock_no"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["stock_name"].Value.ToString();
            label1.Text = dataGridView1.CurrentRow.Cells["stock_id"].Value.ToString();
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            con.Open();
            string sqlquery = "SELECT price FROM stock_currency where stock_id = '" + Convert.ToInt64(label1.Text) + "' and cur_id = '" + sale.currencyid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string price = "";
            try { price = command2.ExecuteScalar().ToString(); textBox4.Text = price.ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, "ListItem3", "PRLG5"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı"); }
            //PROGRAMLOG
            con.Close();
            textBox5.Text = sale.kdv;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.CurrentRow.Cells["stock_no"].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells["stock_name"].Value.ToString();
            label1.Text = dataGridView2.CurrentRow.Cells["stock_id"].Value.ToString();

            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            con.Open();
            string sqlquery = "SELECT price FROM stock_currency where stock_id = '" + Convert.ToInt64(label1.Text) + "' and cur_id = '" + sale.currencyid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string price = "";
            try { price = command2.ExecuteScalar().ToString(); textBox4.Text = price.ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, "ListItem3", "PRLG6"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı"); }
            //PROGRAMLOG
            con.Close();
            textBox5.Text = sale.kdv;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dataGridView1.Visible = false;
            }
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dataGridView2.Visible = false;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
