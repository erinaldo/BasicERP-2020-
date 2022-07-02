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
    public partial class sale : Form
    {
        public sale()
        {
            InitializeComponent();
        }
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";
        void customerdoldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from tbl_customer where delete_status = '0' and type = '1'", con);
            try
            {
                adtr.Fill(ds, "tbl_customer");
                dataGridView1.DataSource = ds.Tables["tbl_customer"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                dataGridView1.Columns[1].HeaderText = "Müşteri No";
                dataGridView1.Columns[2].HeaderText = "Müşteri Adı";
                dataGridView1.Columns[3].HeaderText = "Müşteri GSM";
                dataGridView1.Columns[4].HeaderText = "Müşteri GSM 2";
                dataGridView1.Columns[5].HeaderText = "Müşteri E-mail";
                dataGridView1.Columns[6].HeaderText = "Müşteri Adres";
                dataGridView1.Columns[7].HeaderText = "Müşteri Sektör";
                dataGridView1.Columns[8].HeaderText = "Müşteri IBAN";
                dataGridView1.Columns[9].HeaderText = "Müşteri Temsilci";
                dataGridView1.Columns[10].HeaderText = "Müşteri Kayıt Tarihi";
                dataGridView1.Columns[11].HeaderText = "Müşteri Durumu";
                this.dataGridView1.Columns["customer_add_date"].Visible = false;
                this.dataGridView1.Columns["customer_id"].Visible = false;
                this.dataGridView1.Columns["customer_status"].Visible = false;
                this.dataGridView1.Columns["type"].Visible = false;
                this.dataGridView1.Columns["delete_status"].Visible = false;
                this.dataGridView1.Columns["user_id"].Visible = false;
                this.dataGridView1.Columns["edit_date"].Visible = false;
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
                    column.Width = 90;

                }
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[2].Width = 120;
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
            }
            con.Close();
        }
        void stockdoldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from tbl_stock where stock_status = '1' and delete_status = '0'", con);
            try
            {
                adtr.Fill(ds, "tbl_stock");
                dataGridView2.DataSource = ds.Tables["tbl_stock"];
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                con.Close();
                dataGridView2.Columns[1].HeaderText = "Stok No";
                dataGridView2.Columns[2].HeaderText = "Stok Adı";
                dataGridView2.Columns[3].HeaderText = "Stok Barkodu";
                dataGridView2.Columns[4].HeaderText = "Stok Miktarı";
                dataGridView2.Columns[5].HeaderText = "Stok Birimi";
                dataGridView2.Columns[6].HeaderText = "Ürün Açıklaması";
                dataGridView2.Columns[8].HeaderText = "Stok Durumu";
                this.dataGridView2.Columns["stock_id"].Visible = false;
                this.dataGridView2.Columns["stock_add_date"].Visible = false;
                this.dataGridView2.Columns["stock_material"].Visible = false;
                this.dataGridView2.Columns["stock_price"].Visible = false;
                this.dataGridView2.Columns["stock_price_dollar"].Visible = false;
                this.dataGridView2.Columns["img"].Visible = false;
                this.dataGridView2.Columns["user_id"].Visible = false;
                this.dataGridView2.Columns["edit_date"].Visible = false;
                this.dataGridView2.Columns["delete_status"].Visible = false;
                this.dataGridView2.Columns["stock_status"].Visible = false;
                dataGridView2.BorderStyle = BorderStyle.None;
                dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView2.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                dataGridView2.EnableHeadersVisualStyles = false;
                dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {
                    DataGridViewColumn column = dataGridView2.Columns[i];
                    column.Width = 90;
                }
                dataGridView2.Columns[1].Width = 50;
                dataGridView2.Columns[2].Width = 120;
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
            }
        }
        void combo2doldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string query = "select cur_name from currency where cur_status = '1' and delete_status = '0'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "cur_name");
                comboBox2.DisplayMember = "cur_name";
                comboBox2.ValueMember = "cur_name";
                comboBox2.DataSource = ds.Tables["cur_name"];
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
            }
        }
        void combo4doldur()
        {
            comboBox4.Items.Clear();
            comboBox4.Items.Add("Müşteri Numarasına Göre");
            comboBox4.Items.Add("Müşteri Adına Göre");
            comboBox4.Items.Add("GSM Numarasına Göre");
            comboBox4.Items.Add("GSM2 Numarasına Göre");
            comboBox4.Items.Add("Mail Adresine Göre");
            comboBox4.Items.Add("Müşteri Adresine Göre");
            comboBox4.Items.Add("Müşteri Sektörüne Göre");
            comboBox4.Items.Add("IBAN Numarasına Göre");
            comboBox4.Items.Add("Müşteri Temsilcisi Adına Göre");
            comboBox4.Items.Add("Müşteri Durumuna Göre");

            comboBox4.Text = "Müşteri Numarasına Göre";
        }
        void combo5doldur()
        {
            comboBox5.Items.Clear();
            comboBox5.Items.Add("Stok Numarasına Göre");
            comboBox5.Items.Add("Stok Adına Göre");
            comboBox5.Items.Add("Barkod Numarasına Göre");
            comboBox5.Items.Add("Kalan Miktara Göre");
            comboBox5.Items.Add("Birime Göre");
            comboBox5.Items.Add("Ürün Açıklamasına Göre");
            comboBox5.Items.Add("Stok Durumuna Göre");

            comboBox5.Text = "Stok Numarasına Göre";
        }

        private void sale_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            WindowState = FormWindowState.Maximized;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            this.flowLayoutPanel1.AutoScroll = true;
            metroLabel1.BackColor = System.Drawing.Color.Transparent;


            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker2.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "dd.MM.yyyy - HH:mm";
            //dateTimePicker2.CustomFormat = "dd.MM.yyyy - HH:mm";

            comboBox1.Text = "Nakit";
            comboBox3.Text = "18";

            customerdoldur();

            stockdoldur();

            combo2doldur();

            combo4doldur();

            combo5doldur();
            timer1.Start();

            panel6.Size = new Size(213, 145);




            string sqlquery4 = "SELECT TOP 1 slip_no FROM tbl_sale ORDER BY slip_id DESC";
            SqlCommand command4 = new SqlCommand(sqlquery4, con);
            con.Open();
            try
            {
                object nullableValue5 = command4.ExecuteScalar();
                con.Close();
                if (nullableValue5 == null || nullableValue5 == DBNull.Value)
                {
                    textBox1.Text = "1";
                }
                else
                {
                    textBox1.Text = (Convert.ToInt64(nullableValue5) + 1).ToString();
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG4");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı");
            }
        }




        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//SLİP NO SORGULAYICI
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
                if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
                {
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adtr = new SqlDataAdapter("Select slip_no from tbl_sale where slip_no like '%" + textBox1.Text + "%'", con);
                    try
                    {
                        adtr.Fill(ds, "tbl_sale");
                        dataGridView3.DataSource = ds.Tables["tbl_sale"];
                        dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        adtr.Dispose();
                        dataGridView3.Columns[0].HeaderText = "Fiş Numarası";
                        dataGridView3.Visible = true;
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG5");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı");
                    }
                    con.Close();
                }
                else
                {
                    dataGridView3.Visible = false;
                }
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
                {
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adtr = new SqlDataAdapter("Select slip_no from tbl_sale where slip_no like '%" + textBox1.Text + "%'", con);
                    try
                    {
                        adtr.Fill(ds, "tbl_sale");
                        dataGridView3.DataSource = ds.Tables["tbl_sale"];
                        dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        adtr.Dispose();
                        dataGridView3.Columns[0].HeaderText = "Fiş Numarası";
                        dataGridView3.Visible = true;
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG6");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı");
                    }
                    con.Close();
                }
                else
                {
                    dataGridView3.Visible = false;
                }
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)//MÜŞTERİ NO SORGULAYICI
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
                if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
                {
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adtr = new SqlDataAdapter("Select customer_no, customer_name from tbl_customer where customer_no like '%" + textBox2.Text + "%'", con);
                    try
                    {
                        adtr.Fill(ds, "tbl_customer");
                        dataGridView4.DataSource = ds.Tables["tbl_customer"];
                        dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        adtr.Dispose();
                        dataGridView4.Columns[0].HeaderText = "Müşteri No";
                        dataGridView4.Visible = true;

                        this.dataGridView4.Columns["customer_name"].Visible = false;
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG7");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG7", "Sistem Mesajı");
                    }
                    con.Close();
                }
                else
                {
                    dataGridView4.Visible = false;
                }
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
                {
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    DataSet ds = new DataSet();
                    con.Open();
                    SqlDataAdapter adtr = new SqlDataAdapter("Select customer_no, customer_name from tbl_customer where customer_no like '%" + textBox2.Text + "%'", con);
                    try
                    {
                        adtr.Fill(ds, "tbl_customer");
                        dataGridView4.DataSource = ds.Tables["tbl_customer"];
                        dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        adtr.Dispose();

                        dataGridView4.Columns[0].HeaderText = "Müşteri No";
                        dataGridView4.Visible = true;

                        this.dataGridView4.Columns["customer_name"].Visible = false;
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG8");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG8", "Sistem Mesajı");
                    }
                    con.Close();
                }
                else
                {
                    dataGridView4.Visible = false;
                }
            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)//STOK NO SORGULAYICI
        {
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select stock_no from tbl_stock where stock_no like '%" + textBox2.Text + "%'", con);
                try
                {
                    adtr.Fill(ds, "tbl_stock");
                    dataGridView4.DataSource = ds.Tables["tbl_stock"];
                    dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    adtr.Dispose();
                    dataGridView4.Columns[0].HeaderText = "Stok No";
                    dataGridView4.Visible = true;
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG9");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG9", "Sistem Mesajı");
                }
                con.Close();

            }
            else
            {
                dataGridView4.Visible = false;
            }
        }





        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Fiş No")
            {
                textBox1.Text = "";
            }
        }
        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Müşteri No")
            {
                textBox2.Text = "";
            }
        }
        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Stok No")
            {
                textBox3.Text = "";
            }
        }
        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "Miktar")
            {
                textBox4.Text = "";
            }
        }
        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox8.Text == "Peşinat")
            {
                textBox8.Text = "";
            }
        }



        private void sale_MouseClick(object sender, MouseEventArgs e)
        {
            button1.Focus();
            if (textBox1.Text == "")
            {
                textBox1.Text = "Fiş No";
            }

            if (textBox2.Text == "")
            {
                textBox2.Text = "Müşteri No";
            }

            if (textBox3.Text == "")
            {
                textBox3.Text = "Stok No";
            }

            if (textBox4.Text == "")
            {
                textBox4.Text = "Miktar";
            }
            if (textBox5.Text == "")
            {
                textBox5.Text = "KDV (%)";
            }
            if (textBox8.Text == "")
            {
                textBox8.Text = "Peşinat";
            }
        }

        public static bool createcontrol = false;
        public static int icontrol = 6;

        private void button4_Click(object sender, EventArgs e)
        {
            if (sayac != 0)
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                stockno = dataGridView2.CurrentRow.Cells["stock_no"].Value.ToString();
                stockname = dataGridView2.CurrentRow.Cells["stock_name"].Value.ToString();
                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select stock_id from tbl_stock where stock_no = '" + dataGridView2.CurrentRow.Cells["stock_no"].Value.ToString() + "'", con);
                try
                {
                    adtr.Fill(ds, "tbl_stock");
                    dataGridView6.DataSource = ds.Tables["tbl_stock"];
                    dataGridView6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    adtr.Dispose();
                    con.Close();
                    stockid = dataGridView6.CurrentRow.Cells["stock_id"].Value.ToString();

                    if (flowLayoutPanel1.Controls.Count > 6)
                    {
                        createcontrol = true;
                    }
                    else
                    {
                        createcontrol = false;
                    }

                    ListItem3 listItems = new ListItem3();
                    if (flowLayoutPanel1.Controls.Count > -1)
                    {
                        flowLayoutPanel1.Controls.Add(listItems);
                    }
                    int listitemsayisi1 = flowLayoutPanel1.Controls.Count;
                    listitemsayisi2 = listitemsayisi1;
                    ListItem3[] listItems5 = new ListItem3[listitemsayisi1];

                    stringdizi2 = new string[listItems5.Length - 6];

                    for (int i = 6; i < listItems5.Length; i++)
                    {
                        listItems5[i] = (ListItem3)flowLayoutPanel1.Controls[i];
                        stringdizi2[i - 6] = listItems5[i].StokNo.ToString();
                    }
                    dist2 = stringdizi2.Distinct().ToArray();
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG10");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG10", "Sistem Mesajı");
                }
            }
            else
            {
                MessageBox.Show("Lütfen ürün seçiniz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "KDV (%)")
            {
                textBox5.Text = "";
            }
        }


        public static string customerno = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label15.Text = "";
            textBox2.Text = dataGridView1.CurrentRow.Cells["customer_no"].Value.ToString();
            label5.Text = dataGridView1.CurrentRow.Cells["customer_name"].Value.ToString();

            /////////////////////////

            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT top 5 stock_name FROM tbl_stock INNER JOIN sale_details ON tbl_stock.stock_id = sale_details.stock_id where customer_id = '" + dataGridView1.CurrentRow.Cells["customer_id"].Value.ToString() + "' GROUP BY stock_name ORDER BY count(*) desc;", con);
            try
            {
                adtr.Fill(ds, "tbl_stock");
                dataGridView7.DataSource = ds.Tables["tbl_stock"];
                dataGridView7.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                con.Close();

                for (int i = 0; i < dataGridView7.Rows.Count - 1; i++)
                {
                    label15.Text = dataGridView7.Rows[i].Cells[0].Value.ToString() + System.Environment.NewLine + label15.Text;
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG11");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG11", "Sistem Mesajı");
            }



            /////////////////////////

            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

            if (dataGridView1.Columns[columnIndex].Name == "customer_no")
            {
                comboBox4.Text = "Müşteri Numarasına Göre";
                colname1 = "customer_no";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_name")
            {
                comboBox4.Text = "Müşteri Adına Göre";
                colname1 = "customer_name";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_gsm")
            {
                comboBox4.Text = "GSM Numarasına Göre";
                colname1 = "customer_gsm";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_gsm2")
            {
                comboBox4.Text = "GSM2 Numarasına Göre";
                colname1 = "customer_gsm2";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_email")
            {
                comboBox4.Text = "Mail Adresine Göre";
                colname1 = "customer_email";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_address")
            {
                comboBox4.Text = "Müşteri Adresine Göre";
                colname1 = "customer_address";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_sector")
            {
                comboBox4.Text = "Müşteri Sektörüne Göre";
                colname1 = "customer_sector";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_iban")
            {
                comboBox4.Text = "IBAN Numarasına Göre";
                colname1 = "customer_iban";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_agent")
            {
                comboBox4.Text = "Müşteri Temsilcisi Adına Göre";
                colname1 = "customer_agent";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_status")
            {
                comboBox4.Text = "Müşteri Durumuna Göre";
                colname1 = "customer_status";
            }
            else
            {

            }
            if (textBox6.Text == "")
            {
                textBox6.Text = "Ara";
            }
        }

        public static string stockno, stockname, stockid = "";

        public static string stockaydi = "";

        public int sayac = 0;

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sayac++;
            int columnIndex = dataGridView2.CurrentCell.ColumnIndex;


            if (dataGridView2.Columns[columnIndex].Name == "stock_no")
            {
                comboBox5.Text = "Stok Numarasına Göre";
                colname2 = "stock_no";
            }
            else if (dataGridView2.Columns[columnIndex].Name == "stock_name")
            {
                comboBox5.Text = "Stok Adına Göre";
                colname2 = "stock_name";
            }
            else if (dataGridView2.Columns[columnIndex].Name == "stock_barkod")
            {
                comboBox5.Text = "Barkod Numarasına Göre";
                colname2 = "stock_barkod";
            }
            else if (dataGridView2.Columns[columnIndex].Name == "stock_amount")
            {
                comboBox5.Text = "Kalan Miktara Göre";
                colname2 = "stock_amount";
            }
            else if (dataGridView2.Columns[columnIndex].Name == "stock_price")
            {
                comboBox5.Text = "Fiyata Göre";
                colname2 = "stock_price";
            }
            else if (dataGridView2.Columns[columnIndex].Name == "stock_denomination")
            {
                comboBox5.Text = "Birime Göre";
                colname2 = "stock_denomination";
            }
            else if (dataGridView2.Columns[columnIndex].Name == "stock_description")
            {
                comboBox5.Text = "Ürün Açıklamasına Göre";
                colname2 = "stock_description";
            }
            else if (dataGridView2.Columns[columnIndex].Name == "stock_status")
            {
                comboBox5.Text = "Stok Durumuna Göre";
                colname2 = "stock_status";
            }
            else
            {

            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ara";
            }
        }

        public static string kdv = "";
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            kdv = comboBox3.Text;
        }


        public static double yenideger = 0;
        public static double yenideger2 = 0;
        //public static long newstockamount1 = 0;
        public static bool containsNegative = true;

        public static int listitemsayisi2 = 1;
        //public static ListItem3[] listItems3 = new ListItem3[0];
        public static string[] stringdizi2 = new string[6 - 6];
        public static string[] dist2 = stringdizi2.Distinct().ToArray();

        programLog prlg;
        public static int fisturu = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DateTime dt = DateTime.Now;
            int islemdurdurucu = 0;
            int musterinoileislemdurdurucu = 0;
            int programlogislemdurdurucu = 0;
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || textBox1.Text == "Fiş No" || textBox2.Text == "Müşteri No" || comboBox3.Text == "KDV (%)")
            {
                MessageBox.Show("Lütfen ekrandaki parametreleri doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                string sqlquery8 = "SELECT slip_no FROM tbl_sale where slip_no = '" + textBox1.Text + "'";
                SqlCommand command8 = new SqlCommand(sqlquery8, con);
                con.Open();
                SqlCommand command6 = new SqlCommand("Insert Into tbl_userlog(user_id,form_name,islem,log_date) Values (@userid,@formname,@islem, @logdate)", con);
                command6.Parameters.AddWithValue("@userid", login.userid);
                command6.Parameters.AddWithValue("@formname", this.Text);
                command6.Parameters.AddWithValue("@islem", button2.Text);
                command6.Parameters.AddWithValue("@logdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                try
                {
                    command6.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG30");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG30", "Sistem Mesajı");
                }
                object nullableValue8 = null;
                string kontrol;
                try
                {
                    nullableValue8 = command8.ExecuteScalar();
                    if (nullableValue8 == null || nullableValue8 == DBNull.Value)
                    {
                        kontrol = "";
                    }
                    else
                    {
                        kontrol = "iptal";
                    }
                }
                catch (SqlException ex)
                {
                    kontrol = "iptal";
                    prlg = new programLog(ex.Message, this.Text, "PRLG12");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG12", "Sistem Mesajı");
                }

                if (kontrol == "")
                {
                    if ((comboBox1.Text != "Nakit" && comboBox1.Text != "Havale") && textBox8.Text == "Peşinat" || textBox8.Text == "")
                    {
                        textBox8.Text = "0";
                    }
                    //else
                    //{


                    string sqlquery4 = "SELECT customer_id FROM tbl_customer where customer_no = '" + textBox2.Text + "'";
                    SqlCommand command4 = new SqlCommand(sqlquery4, con);
                    try
                    {
                        object nullableValue5 = command4.ExecuteScalar();
                        if (nullableValue5 == null || nullableValue5 == DBNull.Value)
                        {
                            islemdurdurucu++;
                            musterinoileislemdurdurucu++;
                        }
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG13");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG13", "Sistem Mesajı");
                    }


                    double totalprice = 0, totalkdv = 0;

                    int listitemsayisi1 = flowLayoutPanel1.Controls.Count;
                    listitemsayisi2 = listitemsayisi1;
                    ListItem3[] listItems1 = new ListItem3[listitemsayisi1];
                    double[] intdizi = new double[listItems1.Length - 6];

                    int fakingcount = 0;
                    for (int i = 6; i < listItems1.Length; i++)//KDV-TOTALKDV-DİNAMİK ARRAY DÖNGÜSÜ
                    {

                        double kdvpercentagetomiktar = 0;
                        listItems1[i] = (ListItem3)flowLayoutPanel1.Controls[i];

                        if (listItems1[i].Miktar == "Miktar" || listItems1[i].Miktar == "" || listItems1[i].Kdv == "" || listItems1[i].Kdv == "KDV (%)" || listItems1[i].Fiyat == "Fiyat" || listItems1[i].Fiyat == "")
                        {
                            //MessageBox.Show("Miktar Giriniz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            islemdurdurucu++;
                        }
                        else
                        {
                            totalprice += Convert.ToDouble(listItems1[i].Fiyat) * Convert.ToDouble(listItems1[i].Miktar);
                            kdvpercentagetomiktar = ((Convert.ToDouble(listItems1[i].Fiyat) * Convert.ToDouble(listItems1[i].Miktar) * Convert.ToDouble(listItems1[i].Kdv)) / 100);
                            totalkdv += kdvpercentagetomiktar;
                            listItems1[i] = (ListItem3)flowLayoutPanel1.Controls[i];

                            string sqlquery = "SELECT stock_amount FROM tbl_stock where stock_id = '" + listItems1[i].StokId.ToString() + "'";
                            SqlCommand command2 = new SqlCommand(sqlquery, con);
                            string stockamount = "";
                            try
                            { stockamount = command2.ExecuteScalar().ToString(); }
                            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG14"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG14", "Sistem Mesajı"); }
                            //PROGRAMLOG

                            string newstockamount = (Convert.ToDouble(stockamount) - Convert.ToDouble(listItems1[i].Miktar)).ToString();

                            yenideger = Convert.ToDouble(newstockamount);
                            intdizi[i - 6] = yenideger;
                            if (yenideger < 0)
                            {
                                fakingcount++;
                            }
                            //islemdurdurucu = 0;
                        }
                    }
                    string[] stringdizi = new string[fakingcount];


                    ListItem3[] listItems4 = new ListItem3[listitemsayisi1];
                    int k = 0;
                    for (int i = 6; i < listItems4.Length; i++) // LİSTİTEMLERİNİ ARRAYA ATAN DÖNGÜ
                    {
                        listItems4[i] = (ListItem3)flowLayoutPanel1.Controls[i];

                        if (listItems4[i].Miktar == "Miktar" || listItems4[i].Miktar == "" || listItems4[i].Kdv == "" || listItems4[i].Kdv == "KDV (%)")
                        {
                            //MessageBox.Show("Miktar Giriniz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            islemdurdurucu++;
                        }
                        else
                        {
                            string sqlquery = "SELECT stock_amount FROM tbl_stock where stock_id = '" + listItems4[i].StokId.ToString() + "'";
                            SqlCommand command2 = new SqlCommand(sqlquery, con);
                            string stockamount = "";
                            try { stockamount = command2.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG15"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG15", "Sistem Mesajı"); }
                            //PROGRAMLOG


                            string newstockamount = (Convert.ToDouble(stockamount) - Convert.ToDouble(listItems4[i].Miktar)).ToString();

                            yenideger = Convert.ToDouble(newstockamount);
                            //newstockamount1 = Convert.ToInt64(newstockamount);

                            if (yenideger < 0)
                            {
                                stringdizi[k] = listItems4[i].StokAdi.ToString();
                                k++;
                            }
                            //islemdurdurucu = 0;
                        }
                    }
                    string[] dist = stringdizi.Distinct().ToArray();

                    containsNegative = intdizi.Min() < 0;
                    if (containsNegative == true)
                    {
                        string toDisplay = string.Join(Environment.NewLine, dist);
                        DialogResult res = new DialogResult();
                        res = MessageBox.Show("Yetersiz Sayıdaki Ürünlerin Listesi \n\n" + toDisplay, "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (islemdurdurucu == 0)
                        {
                            //MessageBox.Show("POZİTİF", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SqlCommand command = new SqlCommand("Insert Into tbl_sale(slip_no,customer_id,allcost,price,currency, total_kdv, total_price, charged_money, slip_type, sold_date, payment_date, status, insert_date, over_status,user_id,edit_date, boss_date) " +
                            "Values (" + "@slipno, @customerid, @allcost,@price,@currency,@totalkdv,@totalprice, @chargedmoney, @sliptype, @solddate, @paymentdate, @status, @insertdate, @overstatus, @userid, @editdate,@bossdate)", con);
                            command.Parameters.AddWithValue("@slipno", textBox1.Text);
                            command.Parameters.AddWithValue("@customerid", dataGridView1.CurrentRow.Cells["customer_id"].Value.ToString());
                            command.Parameters.AddWithValue("@allcost", Convert.ToDouble(totalprice + totalkdv));
                            command.Parameters.AddWithValue("@price", Convert.ToDouble(totalprice));
                            command.Parameters.AddWithValue("@currency", currencyid.ToString());
                            command.Parameters.AddWithValue("@totalkdv", Convert.ToDouble(totalkdv));
                            command.Parameters.AddWithValue("@totalprice", Convert.ToDouble(totalprice + totalkdv));
                            if (comboBox1.Text == "Nakit" || comboBox1.Text == "Havale")
                            {
                                command.Parameters.AddWithValue("@chargedmoney", Convert.ToDouble(totalprice + totalkdv));
                            }
                            else
                            {

                                if (textBox8.Text == "" || textBox8.Text == "Peşinat")
                                {
                                    command.Parameters.AddWithValue("@chargedmoney", Convert.ToDouble(0));
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@chargedmoney", Convert.ToDouble(textBox8.Text));
                                }
                            }
                            command.Parameters.AddWithValue("@sliptype", (comboBox1.SelectedIndex + 1).ToString());
                            command.Parameters.AddWithValue("@solddate", dateTimePicker1.Value);
                            if ((comboBox1.SelectedIndex + 1) > 2)
                            {
                                command.Parameters.AddWithValue("@paymentdate", dateTimePicker2.Value);

                            }
                            else
                            {
                                command.Parameters.AddWithValue("@paymentdate", dateTimePicker1.Value);
                            }


                            //string sqlquery10 = "SELECT admin_status FROM permission where user_id = '" + login.userid + "'";
                            //SqlCommand command10 = new SqlCommand(sqlquery10, con);
                            //string ad_status;
                            //con.Open();
                            //try
                            //{
                            //    ad_status = command10.ExecuteScalar().ToString();
                            //    if (ad_status == "1")
                            //    {
                            //        command.Parameters.AddWithValue("@status", "1");
                            //    }
                            //    else
                            //    {
                            //        command.Parameters.AddWithValue("@status", "0");
                            //    }
                            //}
                            //catch (SqlException ex)
                            //{
                            //    prlg = new programLog(ex.Message, this.Text, "PRLG31");//PROGRAMLOG
                            //    prlg.databaseinsert();
                            //    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG31", "Sistem Mesajı");
                            //}


                            string sqlquerys = "SELECT admin_status FROM permission where user_id = '" + login.userid + "'";
                            SqlCommand command2s = new SqlCommand(sqlquerys, con);
                            string admin_status = "";
                            try
                            {
                                admin_status = command2s.ExecuteScalar().ToString();
                                if (admin_status == "1")
                                {
                                    command.Parameters.AddWithValue("@status", "0");
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@status", "1");
                                }
                            }
                            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG31"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG31", "Sistem Mesajı"); }
                            //PROGRAMLOG

                            command.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            if ((comboBox1.SelectedIndex + 1) > 2)
                            {
                                command.Parameters.AddWithValue("@overstatus", "0");
                                //if (admin_status == "1")
                                //{
                                //    command.Parameters.AddWithValue("@overstatus", "0");
                                //}
                                //else
                                //{
                                //    command.Parameters.AddWithValue("@overstatus", "1");
                                //}
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@overstatus", "1");
                            }
                            string tarih = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            command.Parameters.AddWithValue("@userid", login.userid);
                            command.Parameters.AddWithValue("@editdate", tarih);
                            if (admin_status == "1")
                            {
                                command.Parameters.AddWithValue("@bossdate", dateTimePicker1.Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@bossdate", "");
                            }
                            int listitemsayisi2 = flowLayoutPanel1.Controls.Count;
                            ListItem3[] listItems2 = new ListItem3[listitemsayisi1];

                            int wrongidcheck = 0;

                            for (int i = 6; i < listItems1.Length; i++)
                            {

                                listItems2[i] = (ListItem3)flowLayoutPanel1.Controls[i];
                                string sqlquery = "SELECT stock_amount FROM tbl_stock where stock_no = '" + listItems2[i].StokNo.ToString() + "'";
                                SqlCommand command2 = new SqlCommand(sqlquery, con);

                                try
                                {
                                    object nullableValue = command2.ExecuteScalar();
                                    if (nullableValue == null || nullableValue == DBNull.Value)
                                    {
                                        wrongidcheck = 1;
                                    }
                                }
                                catch (SqlException ex)
                                {
                                    prlg = new programLog(ex.Message, this.Text, "PRLG16");//PROGRAMLOG
                                    prlg.databaseinsert();
                                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG16", "Sistem Mesajı");
                                }



                                string sqlquery1 = "SELECT stock_amount FROM tbl_stock where stock_name = '" + listItems2[i].StokAdi.ToString() + "'";
                                SqlCommand command3 = new SqlCommand(sqlquery1, con);
                                try
                                {
                                    object nullableValue1 = command3.ExecuteScalar();
                                    if (nullableValue1 == null || nullableValue1 == DBNull.Value)
                                    {
                                        wrongidcheck = 1;
                                    }
                                }
                                catch (SqlException ex)
                                {
                                    prlg = new programLog(ex.Message, this.Text, "PRLG17");//PROGRAMLOG
                                    prlg.databaseinsert();
                                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG17", "Sistem Mesajı");
                                }

                            }

                            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            ///
                            if (wrongidcheck == 0)
                            {
                                try
                                {
                                    command.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    prlg = new programLog(ex.Message, this.Text, "PRLG21");//PROGRAMLOG
                                    prlg.databaseinsert();
                                    programlogislemdurdurucu++;
                                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG21", "Sistem Mesajı");
                                }

                                for (int i = 6; i < listItems1.Length; i++)
                                {

                                    listItems2[i] = (ListItem3)flowLayoutPanel1.Controls[i];
                                    string sqlquery = "SELECT stock_amount FROM tbl_stock where stock_no = '" + listItems2[i].StokNo.ToString() + "'";
                                    SqlCommand command2 = new SqlCommand(sqlquery, con);
                                    string stockamount = "";
                                    try { stockamount = command2.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG18"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG18", "Sistem Mesajı"); }
                                    //PROGRAMLOG

                                    string newstockamount = (Convert.ToDouble(stockamount) - Convert.ToDouble(listItems2[i].Miktar)).ToString();
                                    SqlCommand command1 = new SqlCommand("Insert Into sale_details(slip_id,customer_id, stock_id, quantity, unit_price, total_price, currency, kdv_percentage, total_kdv, insert_date,user_id,edit_date) " +
                                            "Values (" + "@slipid, @customerid,@stockid,@quantity, @unitprice, @totalprice, @currency, @kdvpercentage, @totalkdv, @insertdate, @userid, @editdate)", con);

                                    string sqlquery5 = "SELECT slip_id FROM tbl_sale where slip_no = '" + textBox1.Text + "'";
                                    SqlCommand command5 = new SqlCommand(sqlquery5, con);
                                    string slipid;
                                    try
                                    {
                                        slipid = command5.ExecuteScalar().ToString();
                                        command1.Parameters.AddWithValue("@slipid", slipid);
                                        command1.Parameters.AddWithValue("@customerid", dataGridView1.CurrentRow.Cells["customer_id"].Value.ToString());
                                        command1.Parameters.AddWithValue("@stockid", listItems2[i].StokId.ToString());
                                        command1.Parameters.AddWithValue("@quantity", listItems2[i].Miktar.ToString());
                                        command1.Parameters.AddWithValue("@unitprice", Convert.ToDouble(listItems2[i].Fiyat));
                                        command1.Parameters.AddWithValue("@totalprice", Convert.ToDouble(Convert.ToDouble(listItems2[i].Fiyat) * Convert.ToDouble(listItems2[i].Miktar)));
                                        command1.Parameters.AddWithValue("@currency", currencyid);
                                        command1.Parameters.AddWithValue("@kdvpercentage", Convert.ToDouble(listItems2[i].Kdv));
                                        command1.Parameters.AddWithValue("@totalkdv", Convert.ToDouble((Convert.ToDouble(listItems2[i].Fiyat) * Convert.ToDouble(listItems2[i].Miktar)) * (Convert.ToDouble(listItems2[i].Kdv)) / 100));
                                        command1.Parameters.AddWithValue("@insertdate", tarih);
                                        command1.Parameters.AddWithValue("@userid", login.userid);
                                        command1.Parameters.AddWithValue("@editdate", tarih);
                                    }
                                    catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG32"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG32", "Sistem Mesajı"); }
                                    //command1.Parameters.AddWithValue("@slipid", slipid);

                                    SqlCommand command3 = new SqlCommand("update tbl_stock set stock_amount=@stockamount where stock_no = '" + listItems2[i].StokNo.ToString() + "'", con);
                                    command3.Parameters.AddWithValue("@stockamount", Convert.ToDouble(newstockamount));

                                    try
                                    {
                                        command1.ExecuteNonQuery();

                                    }
                                    catch (SqlException ex)
                                    {
                                        prlg = new programLog(ex.Message, this.Text, "PRLG19");//PROGRAMLOG
                                        prlg.databaseinsert();
                                        programlogislemdurdurucu++;
                                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG19", "Sistem Mesajı");
                                    }
                                    try
                                    {
                                        command3.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        prlg = new programLog(ex.Message, this.Text, "PRLG20");//PROGRAMLOG
                                        prlg.databaseinsert();
                                        programlogislemdurdurucu++;
                                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG20", "Sistem Mesajı");
                                    }

                                }



                                if ((comboBox1.SelectedIndex + 1) > 2)
                                {
                                    string sqlquery = "SELECT slip_id FROM tbl_sale where slip_no = '" + textBox1.Text + "'";
                                    SqlCommand command2 = new SqlCommand(sqlquery, con);
                                    string slipid = "";
                                    try { slipid = command2.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG22"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG22", "Sistem Mesajı"); }
                                    //PROGRAMLOG


                                    string sqlquery1 = "SELECT customer_id FROM tbl_customer where customer_no = '" + textBox2.Text + "'";
                                    SqlCommand command3 = new SqlCommand(sqlquery1, con);
                                    string customerid = "";
                                    try { customerid = command3.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG23"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG23", "Sistem Mesajı"); }
                                    //PROGRAMLOG


                                    string sqlquery2 = "SELECT cur_id FROM currency where cur_name = '" + comboBox2.Text + "'";
                                    SqlCommand command5 = new SqlCommand(sqlquery2, con);
                                    string curid = "";
                                    try { curid = command5.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG24"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG24", "Sistem Mesajı"); }
                                    //PROGRAMLOG

                                    if (textBox8.Text != "0")
                                    {
                                        SqlCommand command1 = new SqlCommand("Insert Into sale_opencheck(slip_id,customer_id, charged_money, cur_id, type, payment_date, insert_date, user_id, edit_date) " +
                                    "Values (" + "@slipid, @customerid, @chargedmoney, @curid, @type, @paymentdate, @insertdate, @userid, @editdate)", con);
                                        command1.Parameters.AddWithValue("@slipid", slipid.ToString());
                                        command1.Parameters.AddWithValue("@customerid", customerid.ToString());
                                        command1.Parameters.AddWithValue("@chargedmoney", textBox8.Text);
                                        command1.Parameters.AddWithValue("@curid", curid.ToString());
                                        command1.Parameters.AddWithValue("@type", (comboBox1.SelectedIndex + 1).ToString());
                                        command1.Parameters.AddWithValue("@paymentdate", dateTimePicker1.Value);
                                        command1.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        command1.Parameters.AddWithValue("@userid", login.userid);
                                        command1.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        try
                                        {
                                            command1.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            prlg = new programLog(ex.Message, this.Text, "PRLG25");//PROGRAMLOG
                                            prlg.databaseinsert();
                                            programlogislemdurdurucu++;
                                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG25", "Sistem Mesajı");
                                        }
                                    }
                                }
                                if (programlogislemdurdurucu == 0)
                                {
                                    MessageBox.Show("Kayıt Tamamlandı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    stockdoldur();
                                }
                                else
                                {
                                    programlogislemdurdurucu = 0;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Hatalı stok bilgisi girildi. Lütfen girilen bilgileri kontrol ediniz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (musterinoileislemdurdurucu != 0)
                            {
                                MessageBox.Show("Hatalı müşteri numarası girildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                musterinoileislemdurdurucu = 0;
                            }
                            else
                            {
                                MessageBox.Show("Hatalı veri mevcut. Lütfen 'Satılacak Ürünler Penceresi' panelini inceledikten sonra doğru veri girişi yapınız", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                islemdurdurucu = 0;
                            }
                        }
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Geçersiz fiş numarası girildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Close();
        }

        //MÜŞTERİ ARAMA
        public static string colname1 = "";
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox6.Text == "")
                {
                    customerdoldur();
                }
                else
                {
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    string sorgu = "select * from tbl_customer where " + colname1 + " like '" + textBox6.Text + "%'";
                    con.Open();
                    SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                    DataSet goster = new DataSet();
                    try
                    {
                        getir.Fill(goster, "tbl_customer");
                        dataGridView1.DataSource = goster.Tables["tbl_customer"];
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        getir.Dispose();
                        this.dataGridView1.Columns["customer_id"].Visible = false;
                        this.dataGridView1.Columns["customer_add_date"].Visible = false;
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG26");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG26", "Sistem Mesajı");
                    }
                    con.Close();
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Müşteri Numarasına Göre")
            {
                colname1 = "customer_no";
            }
            else if (comboBox4.Text == "Müşteri Adına Göre")
            {
                colname1 = "customer_name";
            }
            else if (comboBox4.Text == "GSM Numarasına Göre")
            {
                colname1 = "customer_gsm";
            }
            else if (comboBox4.Text == "GSM2 Numarasına Göre")
            {
                colname1 = "customer_gsm2";
            }
            else if (comboBox4.Text == "Mail Adresine Göre")
            {
                colname1 = "customer_email";
            }
            else if (comboBox4.Text == "Müşteri Adresine Göre")
            {
                colname1 = "customer_address";
            }
            else if (comboBox4.Text == "Müşteri Sektörüne Göre")
            {
                colname1 = "customer_sector";
            }
            else if (comboBox4.Text == "IBAN Numarasına Göre")
            {
                colname1 = "customer_iban";
            }
            else if (comboBox4.Text == "Müşteri Temsilcisi Adına Göre")
            {
                colname1 = "customer_agent";
            }
            else if (comboBox4.Text == "Müşteri Durumuna Göre")
            {
                colname1 = "customer_status";
            }
        }

        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

        //STOK ARAMA
        public static string colname2 = "";
        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox7.Text == "")
                {
                    stockdoldur();
                }
                else
                {
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    string sorgu = "select * from tbl_stock where " + colname2 + " like '" + textBox7.Text + "%'";
                    con.Open();
                    SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                    DataSet goster = new DataSet();
                    try
                    {
                        getir.Fill(goster, "tbl_stock");
                        dataGridView2.DataSource = goster.Tables["tbl_stock"];
                        dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        getir.Dispose();
                        this.dataGridView2.Columns["stock_id"].Visible = false;
                        this.dataGridView2.Columns["stock_add_date"].Visible = false;
                        this.dataGridView2.Columns["stock_material"].Visible = false;
                        this.dataGridView2.Columns["stock_price"].Visible = false;
                        this.dataGridView2.Columns["stock_price_dollar"].Visible = false;
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG27");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG27", "Sistem Mesajı");
                    }
                    con.Close();
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Text == "Stok Numarasına Göre")
            {
                colname2 = "stock_no";
            }
            else if (comboBox5.Text == "Stok Adına Göre")
            {
                colname2 = "stock_name";
            }
            else if (comboBox5.Text == "Barkod Numarasına Göre")
            {
                colname2 = "stock_barkod";
            }
            else if (comboBox5.Text == "Kalan Miktara Göre")
            {
                colname2 = "stock_amount";
            }
            else if (comboBox5.Text == "Fiyata Göre")
            {
                colname2 = "stock_price";
            }
            else if (comboBox5.Text == "Birime Göre")
            {
                colname2 = "stock_denomination";
            }
            else if (comboBox5.Text == "Ürün Açıklamasına Göre")
            {
                colname2 = "stock_description";
            }
            else if (comboBox5.Text == "Stok Durumuna Göre")
            {
                colname2 = "stock_status";
            }
        }

        //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^



        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox6.Text == "Ara")
            {
                textBox6.Text = "";
            }
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox7.Text == "Ara")
            {
                textBox7.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "dd.MM.yyyy - HH:mm";
            //dateTimePicker1.Value = DateTime.Now("dd.MM.yyyy - HH:mm:ss");
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
            {
                //dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.Value = DateTime.Now;
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView3.CurrentRow.Cells["slip_no"].Value.ToString();
            dataGridView3.Visible = false;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView4.CurrentRow.Cells["customer_no"].Value.ToString();
            label5.Text = dataGridView4.CurrentRow.Cells["customer_name"].Value.ToString();
            dataGridView4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tcmerkezbankasi dv = new tcmerkezbankasi();
            dv.Show();
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fisturu = comboBox1.SelectedIndex + 1;
            if (comboBox1.Text == "Nakit" || comboBox1.Text == "Havale")
            {
                panel4.Visible = false;
            }
            else
            {
                panel4.Visible = true;
                if (comboBox1.Text == "Çek")
                {
                    label13.Text = "Çek Bilgileri";
                    MessageBox.Show("Çek ile ödeme paneli aktifleştirildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (comboBox1.Text == "Açık Hesap")
                {
                    label13.Text = "Açık Hesap Bilgileri";
                    MessageBox.Show("Açık Hesap ile ödeme paneli aktifleştirildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    label13.Text = "Senet Bilgileri";
                    MessageBox.Show("Senet ile ödeme paneli aktifleştirildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //dateTimePicker2.Format = DateTimePickerFormat.Custom;
            //dateTimePicker2.CustomFormat = "dd.MM.yyyy - HH:mm";
        }

        private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
            {
                dateTimePicker2.Value = DateTime.Now;
            }
        }

        public static string currency, currencyid = "";


        private home HandleToForm1;

        public sale(home frm1Handle)
        {
            InitializeComponent();

            HandleToForm1 = frm1Handle;
        }
        private void sale_FormClosing(object sender, FormClosingEventArgs e)
        {
            HandleToForm1.WriteToTextbox("1");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(connectionstring);
        //    SqlCommand command1 = new SqlCommand("Insert Into deneme(deneme) " +
        //                            "Values (" + "@deneme)", con);
        //    //dateTimePicker1.Format = DateTimePickerFormat.Custom;
        //    //dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
        //    command1.Parameters.AddWithValue("@deneme", dateTimePicker1.Value);
        //    con.Open();
        //    command1.ExecuteNonQuery();
        //    con.Close();
        //}

        //public int sayac1 = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //sayac1++;
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                dolaylama();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            con.Open();
            string sqlquery = "SELECT cur_id from currency where cur_name = '" + comboBox2.Text + "'";
            SqlCommand command = new SqlCommand(sqlquery, con);
            try { currencyid = command.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG28"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG28", "Sistem Mesajı"); }
            //PROGRAMLOG

            con.Close();

            currency = comboBox2.Text;

            int listitemsayisi1 = flowLayoutPanel1.Controls.Count;
            ListItem3[] listItems2 = new ListItem3[listitemsayisi1];

            for (int i = 6; i < listItems2.Length; i++)
            {

                listItems2[i] = (ListItem3)flowLayoutPanel1.Controls[i];
                string sqlquery2 = "SELECT price FROM stock_currency where stock_id = '" + listItems2[i].StokId.ToString() + "' and cur_id = '" + currencyid + "'";
                SqlCommand command2 = new SqlCommand(sqlquery2, con);
                con.Open();
                try
                {
                    object nullableValue = command2.ExecuteScalar();
                    con.Close();
                    if (nullableValue == null || nullableValue == DBNull.Value)
                    {
                        listItems2[i].Fiyat = "";
                    }
                    else
                    {
                        listItems2[i].Fiyat = nullableValue.ToString();
                    }
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG29");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG29", "Sistem Mesajı");
                }

            }
        }

        void dolaylama()
        {
            //SqlConnection con = new SqlConnection(connectionstring);
            double totalprice = 0;
            double totalkdv = 0;
            int listitemsayisi1 = flowLayoutPanel1.Controls.Count;
            //listitemsayisi2 = listitemsayisi1;
            ListItem3[] listItems1 = new ListItem3[listitemsayisi1];
            for (int i = 6; i < listItems1.Length; i++)//KDV-TOTALKDV-DİNAMİK ARRAY DÖNGÜSÜ
            {

                double kdvpercentagetomiktar = 0;
                listItems1[i] = (ListItem3)flowLayoutPanel1.Controls[i];

                if (listItems1[i].Miktar == "Miktar" || listItems1[i].Miktar == "" || listItems1[i].Kdv == "" || listItems1[i].Kdv == "KDV (%)" || listItems1[i].Fiyat == "Fiyat" || listItems1[i].Fiyat == "")
                {

                }
                else
                {
                    totalprice += Convert.ToDouble(listItems1[i].Fiyat) * Convert.ToDouble(listItems1[i].Miktar);
                    kdvpercentagetomiktar = ((Convert.ToDouble(listItems1[i].Fiyat) * Convert.ToDouble(listItems1[i].Miktar) * Convert.ToDouble(listItems1[i].Kdv)) / 100);
                    totalkdv += kdvpercentagetomiktar;
                }
            }
            metroLabel5.Text = "Ürünlerin Fiyatı:      " + totalprice.ToString() + "      " + comboBox2.Text;
            metroLabel6.Text = "KDV:      " + totalkdv.ToString() + "      " + comboBox2.Text;
            metroLabel7.Text = "Toplam Fiyat:      " + (totalprice + totalkdv).ToString() + "      " + comboBox2.Text;
        }
    }
}
