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
    public partial class stock : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        public stock()
        {
            InitializeComponent();
        }

        public static string stockid, stockno, stockname, stockbarkod, stockmiktar, stockbirim, stockfiyat, stockdescription, stockstatus, stockmaterial;
        public static string materialno, materialname, materialbarkod, materialmiktar, materialbirim, materialfiyat, materialdescription, materialstatus, materialsellable;

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ara";
            }
        }

        private void stock_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ara";
            }
            button4.Focus();
        }
        public static string ekleload = "false";//Yeni Parti Ürünün Eklenme Değişkeni

        programLog prlg;
        private void button3_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Stok Listesi")
            {
                if (textBox1.Text == "")
                {
                    doldurstock();
                }
                else
                {
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    string sorgu = "select * from tbl_stock where " + colname2 + " like '%" + textBox1.Text + "%'";
                    con.Open();
                    SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                    DataSet goster = new DataSet();
                    try
                    {
                        getir.Fill(goster, "tbl_stock");
                        dataGridView1.DataSource = goster.Tables["tbl_stock"];
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        getir.Dispose();
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
                    }
                    con.Close();
                }
            }

            else
            {
                if (textBox1.Text == "")
                {
                    doldurmateryal();
                }
                else
                {
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    string sorgu = "select * from tbl_material where " + colname2 + " like '%" + textBox1.Text + "%'";
                    con.Open();
                    SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                    DataSet goster = new DataSet();
                    try
                    {
                        getir.Fill(goster, "tbl_material");
                        dataGridView1.DataSource = goster.Tables["tbl_material"];
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        getir.Dispose();
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
                    }
                    con.Close();
                }
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Ara")
            {
                textBox1.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (label1.Text == "Stok Listesi")
            {
                //comboBox1.Items.Clear();
                if (comboBox1.Text == "Stok Numarasına Göre")
                {
                    colname2 = "stock_no";
                }
                else if (comboBox1.Text == "Stok Adına Göre")
                {
                    colname2 = "stock_name";
                }
                else if (comboBox1.Text == "Barkod Numarasına Göre")
                {
                    colname2 = "stock_barkod";
                }
                else if (comboBox1.Text == "Kalan Miktara Göre")
                {
                    colname2 = "stock_amount";
                }
                else if (comboBox1.Text == "Fiyata Göre")
                {
                    colname2 = "stock_price";
                }
                else if (comboBox1.Text == "Birime Göre")
                {
                    colname2 = "stock_denomination";
                }
                else if (comboBox1.Text == "Ürün Açıklamasına Göre")
                {
                    colname2 = "stock_description";
                }
                else if (comboBox1.Text == "Stok Durumuna Göre")
                {
                    colname2 = "stock_status";
                }
                else if (comboBox1.Text == "Stok Kayıt Tarihine Göre")
                {
                    colname2 = "stock_add_date";
                }
            }
            else
            {
                //comboBox1.Items.Clear();
                if (comboBox1.Text == "Materyal Numarasına Göre")
                {
                    colname2 = "material_no";
                }
                else if (comboBox1.Text == "Materyal Adına Göre")
                {
                    colname2 = "material_name";
                }
                else if (comboBox1.Text == "Barkod Numarasına Göre")
                {
                    colname2 = "material_barkod";
                }
                else if (comboBox1.Text == "Kalan Miktara Göre")
                {
                    colname2 = "material_amount";
                }
                else if (comboBox1.Text == "Fiyata Göre")
                {
                    colname2 = "material_price";
                }
                else if (comboBox1.Text == "Birime Göre")
                {
                    colname2 = "material_denomination";
                }
                else if (comboBox1.Text == "Ürün Açıklamasına Göre")
                {
                    colname2 = "material_description";
                }
                else if (comboBox1.Text == "Materyal Durumuna Göre")
                {
                    colname2 = "material_status";
                }
                else if (comboBox1.Text == "Materyal Kayıt Tarihine Göre")
                {
                    colname2 = "material_add_date";
                }
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (label1.Text == "Stok Listesi")
                {
                    if (textBox1.Text == "")
                    {
                        doldurstock();
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                        string sorgu = "select * from tbl_stock where " + colname2 + " like '" + textBox1.Text + "%'";
                        con.Open();
                        SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                        DataSet goster = new DataSet();
                        try
                        {
                            getir.Fill(goster, "tbl_stock");
                            dataGridView1.DataSource = goster.Tables["tbl_stock"];
                            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            getir.Dispose();
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
                        }

                        con.Close();
                    }
                }

                else
                {
                    if (textBox1.Text == "")
                    {
                        doldurmateryal();
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                        string sorgu = "select * from tbl_material where " + colname2 + " like '%" + textBox1.Text + "%'";
                        con.Open();
                        SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                        DataSet goster = new DataSet();
                        try
                        {
                            getir.Fill(goster, "tbl_material");
                            dataGridView1.DataSource = goster.Tables["tbl_material"];
                            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                            getir.Dispose();
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG4");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı");
                        }

                        con.Close();
                    }
                }
            }
        }

        public static string colname2;

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "STOK")
            {
                doldurstock();
            }
            else
            {
                doldurmateryal();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

            if (label1.Text == "Stok Listesi")
            {
                if (dataGridView1.Columns[columnIndex].Name == "stock_no")
                {
                    comboBox1.Text = "Stok Numarasına Göre";
                    colname2 = "stock_no";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "stock_name")
                {
                    comboBox1.Text = "Stok Adına Göre";
                    colname2 = "stock_name";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "stock_barkod")
                {
                    comboBox1.Text = "Barkod Numarasına Göre";
                    colname2 = "stock_barkod";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "stock_amount")
                {
                    comboBox1.Text = "Kalan Miktara Göre";
                    colname2 = "stock_amount";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "stock_price")
                {
                    comboBox1.Text = "Fiyata Göre";
                    colname2 = "stock_price";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "stock_denomination")
                {
                    comboBox1.Text = "Birime Göre";
                    colname2 = "stock_denomination";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "stock_description")
                {
                    comboBox1.Text = "Ürün Açıklamasına Göre";
                    colname2 = "stock_description";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "stock_status")
                {
                    comboBox1.Text = "Stok Durumuna Göre";
                    colname2 = "stock_status";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "stock_add_date")
                {
                    comboBox1.Text = "Stok Kayıt Tarihine Göre";
                    colname2 = "stock_add_date";
                }
                else
                {

                }
                if (textBox1.Text == "")
                {
                    textBox1.Text = "Ara";
                }
            }
            else
            {
                if (dataGridView1.Columns[columnIndex].Name == "material_no")
                {
                    comboBox1.Text = "Materyal Numarasına Göre";
                    colname2 = "material_no";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "material_name")
                {
                    comboBox1.Text = "Materyal Adına Göre";
                    colname2 = "material_name";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "material_barkod")
                {
                    comboBox1.Text = "Barkod Numarasına Göre";
                    colname2 = "material_barkod";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "material_amount")
                {
                    comboBox1.Text = "Kalan Miktara Göre";
                    colname2 = "material_amount";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "material_price")
                {
                    comboBox1.Text = "Fiyata Göre";
                    colname2 = "material_price";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "material_denomination")
                {
                    comboBox1.Text = "Birime Göre";
                    colname2 = "material_denomination";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "material_description")
                {
                    comboBox1.Text = "Ürün Açıklamasına Göre";
                    colname2 = "material_description";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "material_status")
                {
                    comboBox1.Text = "Materyal Durumuna Göre";
                    colname2 = "material_status";
                }
                else if (dataGridView1.Columns[columnIndex].Name == "material_add_date")
                {
                    comboBox1.Text = "Materyal Kayıt Tarihine Göre";
                    colname2 = "material_add_date";
                }
                else
                {

                }
                if (textBox1.Text == "")
                {
                    textBox1.Text = "Ara";
                }
            }
        }

        public static string labelname = "Stok Listesi";

        public static Image img;
        public static bool nullimage = false;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (label1.Text == "Stok Listesi")
            {
                labelname = "Stok Listesi";
                stockid = dataGridView1.CurrentRow.Cells["stock_id"].Value.ToString();
                stockno = dataGridView1.CurrentRow.Cells["stock_no"].Value.ToString();
                stockname = dataGridView1.CurrentRow.Cells["stock_name"].Value.ToString();
                stockbarkod = dataGridView1.CurrentRow.Cells["stock_barkod"].Value.ToString();
                stockmiktar = dataGridView1.CurrentRow.Cells["stock_amount"].Value.ToString();
                stockbirim = dataGridView1.CurrentRow.Cells["stock_den_id"].Value.ToString();
                stockfiyat = dataGridView1.CurrentRow.Cells["stock_price"].Value.ToString();
                stockdescription = dataGridView1.CurrentRow.Cells["stock_description"].Value.ToString();
                stockstatus = dataGridView1.CurrentRow.Cells["stock_status"].Value.ToString();
                stockmaterial = dataGridView1.CurrentRow.Cells["stock_material"].Value.ToString();
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
            }
            else
            {
                labelname = "Materyaller Listesi";
                materialno = dataGridView1.CurrentRow.Cells["material_no"].Value.ToString();
                materialname = dataGridView1.CurrentRow.Cells["material_name"].Value.ToString();
                materialbarkod = dataGridView1.CurrentRow.Cells["material_barkod"].Value.ToString();
                materialmiktar = dataGridView1.CurrentRow.Cells["material_amount"].Value.ToString();
                materialbirim = dataGridView1.CurrentRow.Cells["material_den_id"].Value.ToString();
                materialfiyat = dataGridView1.CurrentRow.Cells["material_price"].Value.ToString();
                materialdescription = dataGridView1.CurrentRow.Cells["material_description"].Value.ToString();
                materialstatus = dataGridView1.CurrentRow.Cells["material_status"].Value.ToString();
                materialsellable = dataGridView1.CurrentRow.Cells["material_sellable"].Value.ToString();
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
            }
            stocks us = new stocks(this);
            us.Show();
        }

        public void doldurstock()
        {
            label1.Text = "Stok Listesi";
            labelname = "Stok Listesi";
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from tbl_stock where not delete_status = '1' and stock_status = '1'", con);
            try
            {
                adtr.Fill(ds, "tbl_stock");
                dataGridView1.DataSource = ds.Tables["tbl_stock"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();

                comboBox1.Items.Clear();
                comboBox1.Items.Add("Stok Numarasına Göre");
                comboBox1.Items.Add("Stok Adına Göre");
                comboBox1.Items.Add("Barkod Numarasına Göre");
                comboBox1.Items.Add("Kalan Miktara Göre");
                comboBox1.Items.Add("Fiyata Göre");
                comboBox1.Items.Add("Birime Göre");
                comboBox1.Items.Add("Ürün Açıklamasına Göre");
                comboBox1.Items.Add("Stok Durumuna Göre");
                comboBox1.Items.Add("Stok Kayıt Tarihine Göre");
                this.dataGridView1.Columns["stock_id"].Visible = false;
                this.dataGridView1.Columns["stock_price"].Visible = false;
                this.dataGridView1.Columns["stock_price_dollar"].Visible = false;
                this.dataGridView1.Columns["stock_material"].Visible = false;
                this.dataGridView1.Columns["img"].Visible = false;
                this.dataGridView1.Columns["delete_status"].Visible = false;
                this.dataGridView1.Columns["user_id"].Visible = false;
                this.dataGridView1.Columns["edit_date"].Visible = false;

                dataGridView1.Columns[1].HeaderText = "Stok No";
                dataGridView1.Columns[2].HeaderText = "Stok Adı";
                dataGridView1.Columns[3].HeaderText = "Stok Barkodu";
                dataGridView1.Columns[4].HeaderText = "Stok Miktarı";
                dataGridView1.Columns[5].HeaderText = "Stok Birimi";
                dataGridView1.Columns[6].HeaderText = "Ürün Açıklaması";
                dataGridView1.Columns[7].HeaderText = "Stok Eklenme Tarihi";
                dataGridView1.Columns[8].HeaderText = "Stok Durumu";

                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                button1.Text = "Stok Ekle";

                for (int i = 0; i < 8; i++)
                {
                    DataGridViewColumn column = dataGridView1.Columns[i];
                    column.Width = 180;
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG5");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı");
            }
            con.Close();
        }

        public void doldurmateryal()
        {
            label1.Text = "Materyaller Listesi";
            labelname = "Materyaller Listesi";
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from tbl_material where not delete_status = '1' and material_status = 1", con);
            try
            {
                adtr.Fill(ds, "tbl_material");
                dataGridView1.DataSource = ds.Tables["tbl_material"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                con.Close();

                comboBox1.Items.Clear();
                comboBox1.Items.Add("Materyal Numarasına Göre");
                comboBox1.Items.Add("Materyal Adına Göre");
                comboBox1.Items.Add("Barkod Numarasına Göre");
                comboBox1.Items.Add("Kalan Miktara Göre");
                comboBox1.Items.Add("Fiyata Göre");
                comboBox1.Items.Add("Birime Göre");
                comboBox1.Items.Add("Ürün Açıklamasına Göre");
                comboBox1.Items.Add("Materyal Durumuna Göre");
                comboBox1.Items.Add("Materyal Kayıt Tarihine Göre");
                this.dataGridView1.Columns["material_id"].Visible = false;
                this.dataGridView1.Columns["material_price"].Visible = false;
                this.dataGridView1.Columns["img"].Visible = false;
                this.dataGridView1.Columns["delete_status"].Visible = false;
                this.dataGridView1.Columns["user_id"].Visible = false;
                this.dataGridView1.Columns["edit_date"].Visible = false;
                //this.dataGridView1.Columns["material_sellable"].Visible = false;

                dataGridView1.Columns[1].HeaderText = "Materyal No";
                dataGridView1.Columns[2].HeaderText = "Materyal Adı";
                dataGridView1.Columns[3].HeaderText = "Materyal Barkodu";
                dataGridView1.Columns[4].HeaderText = "Materyal Miktarı";
                dataGridView1.Columns[5].HeaderText = "Fiyat";
                dataGridView1.Columns[6].HeaderText = "Materyal Birimi";
                dataGridView1.Columns[7].HeaderText = "Ürün Açıklaması";
                dataGridView1.Columns[8].HeaderText = "Materyal Eklenme Tarihi";
                dataGridView1.Columns[9].HeaderText = "Materyal Durumu";
                dataGridView1.Columns[10].HeaderText = "Satılabilir Materyal";

                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                button1.Text = "Materyal Ekle";

                for (int i = 0; i < 8; i++)
                {
                    DataGridViewColumn column = dataGridView1.Columns[i];
                    column.Width = 170;
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG6");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı");
            }
        }

        private void stock_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            dataGridView1.RowTemplate.Height = 30;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Text = "STOK";
            if (home.stockturu == 1)
            {
                doldurstock();
            }
            else
            {
                doldurmateryal();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stockadd st = new stockadd(this);
            st.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
