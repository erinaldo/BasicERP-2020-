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
    public partial class financialadd : Form
    {
        financialoperation fsrid;
        public financialadd(financialoperation fs)
        {
            InitializeComponent();
            this.fsrid = fs;
        }
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";


        void data1doldur()
        {
            if (financialoperation.labelname == "Stok Mali İşlemleri")
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select stock_no, stock_name, stock_id from tbl_stock where stock_no like '%" + textBox1.Text + "%' and not stock_status = '0' and delete_status = '0'", con);
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
                    prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
                }
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select material_no, material_name, material_id from tbl_material where material_no like '%" + textBox1.Text + "%' and not material_status = '0' and delete_status = '0'", con);
                try
                {
                    adtr.Fill(ds, "tbl_material");
                    dataGridView1.DataSource = ds.Tables["tbl_material"];
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    adtr.Dispose();
                    this.dataGridView1.Columns["material_name"].Visible = false;
                    this.dataGridView1.Columns["material_id"].Visible = false;
                    dataGridView1.Columns[0].HeaderText = "Materyal No";
                    dataGridView1.Visible = true;
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

        void data2doldur()
        {
            if (financialoperation.labelname == "Stok Mali İşlemleri")
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select stock_name, stock_no, stock_id from tbl_stock where stock_name like '%" + textBox2.Text + "%' and not stock_status = '0' and delete_status = '0'", con);

                try
                {
                    adtr.Fill(ds, "tbl_stock");
                    dataGridView2.DataSource = ds.Tables["tbl_stock"];
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    adtr.Dispose();
                    this.dataGridView2.Columns["stock_no"].Visible = false;
                    this.dataGridView2.Columns["stock_id"].Visible = false;
                    dataGridView2.Columns[0].HeaderText = "Stok Adı";
                    dataGridView2.Visible = true;
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
                }
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                DataSet ds = new DataSet();
                con.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("Select material_name, material_no, material_id from tbl_material where material_name like '%" + textBox2.Text + "%' and not material_status = '0' and delete_status = '0'", con);

                try
                {
                    adtr.Fill(ds, "tbl_material");
                    dataGridView2.DataSource = ds.Tables["tbl_material"];
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    adtr.Dispose();
                    this.dataGridView2.Columns["material_no"].Visible = false;
                    this.dataGridView2.Columns["material_id"].Visible = false;
                    dataGridView2.Columns[0].HeaderText = "Materyal Adı";
                    dataGridView2.Visible = true;
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG4");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı");
                }


            }
        }

        void data3doldur()
        {

            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT stock_id, stock_material from tbl_stock where stock_no = '" + textBox1.Text + "' and delete_status = '0'", con);
            try
            {
                adtr.Fill(ds, "tbl_stock");
                dataGridView3.DataSource = ds.Tables["tbl_stock"];
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG5");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı");
            }
            con.Close();

            DataSet ds1 = new DataSet();
            con.Open();
            SqlDataAdapter adtr1 = new SqlDataAdapter("Select material_id, material_sellable from tbl_material where material_no = '" + textBox1.Text + "' and delete_status = '0'", con);
            try
            {
                adtr1.Fill(ds1, "tbl_material");
                dataGridView5.DataSource = ds1.Tables["tbl_material"];
                dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr1.Dispose();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG6");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı");
            }
            con.Close();
        }

        void combodoldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            SqlCommand sqlCmd = new SqlCommand("select cur_name from currency where not delete_status = '1'", con);
            con.Open();

            try
            {
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                while (sqlReader.Read())
                {
                    metroComboBox1.Items.Add(sqlReader["cur_name"].ToString());
                }
                sqlReader.Close();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG7");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG7", "Sistem Mesajı");
            }

            con.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
            {
                data1doldur();

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
                data2doldur();
            }
            else
            {
                dataGridView2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Stok No" || textBox1.Text == "Materyal No")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Stok Adı" || textBox2.Text == "Materyal Adı")
            {
                textBox2.Text = "";
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Para Miktarı")
            {
                textBox3.Text = "";
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "Para Birimi")
            {
                textBox4.Text = "";
            }
        }

        private void financialadd_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                if (financialoperation.labelname == "Stok Mali İşlemleri")
                {
                    textBox1.Text = "Stok No";
                }
                else
                {
                    textBox1.Text = "Materyal No";
                }
            }

            if (textBox2.Text == "")
            {
                if (financialoperation.labelname == "Stok Mali İşlemleri")
                {
                    textBox2.Text = "Stok Adı";
                }
                else
                {
                    textBox2.Text = "Materyal Adı";
                }
            }

            if (textBox3.Text == "")
            {
                textBox3.Text = "Para Miktarı";
            }

            if (textBox4.Text == "")
            {
                textBox4.Text = "Para Birimi";
            }
            button1.Focus();
        }

        private void financialadd_Load(object sender, EventArgs e)
        {
            combodoldur();
            if (financialoperation.labelname == "Materyal Mali İşlemleri")
            {
                textBox1.Text = "Materyal No";
                textBox2.Text = "Materyal Adı";
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (financialoperation.labelname == "Stok Mali İşlemleri")
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["stock_no"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["stock_name"].Value.ToString();

            }
            else
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells["material_no"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["material_name"].Value.ToString();

            }
            dataGridView1.Visible = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (financialoperation.labelname == "Stok Mali İşlemleri")
            {
                textBox1.Text = dataGridView2.CurrentRow.Cells["stock_no"].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells["stock_name"].Value.ToString();

            }
            else
            {
                textBox1.Text = dataGridView2.CurrentRow.Cells["material_no"].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells["material_name"].Value.ToString();

            }
            dataGridView2.Visible = false;
        }

        programLog prlg;
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DateTime.Now.ToString("ddMMyyyyHHmmss");
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || metroComboBox1.Text == "" || textBox1.Text == "Stok No" || textBox2.Text == "Stok Adı" || textBox3.Text == "Para Miktarı" || textBox1.Text == "Materyal No" || textBox2.Text == "Materyal Adı")
            {
                MessageBox.Show("Lütfen ekrandaki parametreleri doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                data3doldur();
                if (financialoperation.labelname == "Stok Mali İşlemleri")
                {
                    con.Open();
                    SqlCommand command5 = new SqlCommand("Insert Into tbl_userlog(user_id,form_name,islem,log_date) Values (@userid,@formname,@islem, @logdate)", con);
                    command5.Parameters.AddWithValue("@userid", login.userid);
                    command5.Parameters.AddWithValue("@formname", this.Text);
                    command5.Parameters.AddWithValue("@islem", button2.Text);
                    command5.Parameters.AddWithValue("@logdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    try
                    {
                        command5.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG15");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG15", "Sistem Mesajı");
                    }

                    SqlCommand command = new SqlCommand("Insert Into stock_currency(stock_id,price,cur_id,insert_date, sc_status, user_id, edit_date) Values (" +
                        "@stockid, @price, @curid,@insertdate, @scstatus, @userid, @editdate)", con);
                    command.Parameters.AddWithValue("@stockid", dataGridView3.CurrentRow.Cells["stock_id"].Value.ToString());
                    command.Parameters.AddWithValue("@price", textBox3.Text);
                    command.Parameters.AddWithValue("@curid", dataGridView4.CurrentRow.Cells["cur_id"].Value.ToString());
                    command.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@scstatus", "1");
                    command.Parameters.AddWithValue("@userid", login.userid);
                    command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    try
                    {
                        command.ExecuteNonQuery();
                        if (dataGridView3.CurrentRow.Cells["stock_material"].Value.ToString() == "1")
                        {
                            SqlCommand command1 = new SqlCommand("Insert Into material_currency(material_id,price,cur_id,insert_date, mc_status, user_id, edit_date) Values (" +
                                "@materialid, @price, @cur_id,@insertdate,@mtstatus, @userid, @editdate)", con);
                            command1.Parameters.AddWithValue("@materialid", dataGridView5.CurrentRow.Cells["material_id"].Value.ToString());
                            command1.Parameters.AddWithValue("@price", textBox3.Text);
                            command1.Parameters.AddWithValue("@cur_id", dataGridView4.CurrentRow.Cells["cur_id"].Value.ToString());
                            command1.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            command1.Parameters.AddWithValue("@mtstatus", "1");
                            command1.Parameters.AddWithValue("@userid", login.userid);
                            command1.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                            try
                            {
                                command1.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                prlg = new programLog(ex.Message, this.Text, "PRLG8");//PROGRAMLOG
                                prlg.databaseinsert();
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG8", "Sistem Mesajı");
                            }
                        }
                        MessageBox.Show("Kayıt Tamamlandı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Controls.Clear();
                        this.InitializeComponent();
                        fsrid.doldurstokfinansal();

                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG9");//PROGRAMLOG
                        prlg.databaseinsert();

                        if (ex.Number == 2627)
                        {
                            MessageBox.Show("Girilen Para Birimi Zaten Mevcut", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG9", "Sistem Mesajı");
                        }
                    }
                    con.Close();
                    this.Close();
                }
                else
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("Insert Into material_currency(material_id,price,cur_id,insert_date, mc_status) Values (" +
                        "@materialid, @price, @cur_id,@insertdate,@mtstatus)", con);
                    command.Parameters.AddWithValue("@materialid", dataGridView5.CurrentRow.Cells["material_id"].Value.ToString());
                    command.Parameters.AddWithValue("@price", textBox3.Text);
                    command.Parameters.AddWithValue("@cur_id", dataGridView4.CurrentRow.Cells["cur_id"].Value.ToString());
                    command.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@mtstatus", "1");
                    try
                    {
                        command.ExecuteNonQuery();
                        if (dataGridView5.CurrentRow.Cells["material_sellable"].Value.ToString() == "1")
                        {
                            con.Open();
                            SqlCommand command1 = new SqlCommand("Insert Into stock_currency(stock_id,price,cur_id,insert_date, sc_status) Values (" +
                                "@stockid, @price, @curid,@insertdate, @scstatus)", con);
                            command1.Parameters.AddWithValue("@stockid", dataGridView3.CurrentRow.Cells["stock_id"].Value.ToString());
                            command1.Parameters.AddWithValue("@price", textBox3.Text);
                            command1.Parameters.AddWithValue("@curid", dataGridView4.CurrentRow.Cells["cur_id"].Value.ToString());
                            command1.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            command1.Parameters.AddWithValue("@scstatus", "1");
                            try
                            {
                                command1.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                prlg = new programLog(ex.Message, this.Text, "PRLG10");//PROGRAMLOG
                                prlg.databaseinsert();

                                if (ex.Number == 2627)
                                {
                                    MessageBox.Show("Girilen Para Birimi Zaten Mevcut.", "Sistem Mesajı");
                                }
                                else
                                {
                                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG10", "Sistem Mesajı");
                                }
                            }
                            con.Close();
                        }

                        MessageBox.Show("Kayıt Tamamlandı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Controls.Clear();
                        this.InitializeComponent();
                        fsrid.doldurmateryalfinansal();
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG11");//PROGRAMLOG
                        prlg.databaseinsert();

                        if (ex.Number == 2627)
                        {
                            MessageBox.Show("Girilen Para Birimi Zaten Mevcut.", "Sistem Mesajı");
                        }
                        else
                        {
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG11", "Sistem Mesajı");
                        }
                    }
                    con.Close();
                    this.Close();
                }

            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds1 = new DataSet();
            con.Open();
            SqlDataAdapter adtr1 = new SqlDataAdapter("select cur_id from currency where cur_name = '" + metroComboBox1.Text + "'", con);

            try
            {
                adtr1.Fill(ds1, "currency");
                dataGridView4.DataSource = ds1.Tables["currency"];
                dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr1.Dispose();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG12");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG12", "Sistem Mesajı");
            }

            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery2 = "SELECT stock_id FROM tbl_stock where stock_no like '%" + textBox1.Text + "%'";
            SqlCommand command3 = new SqlCommand(sqlquery2, con);
            try
            {
                con.Open();
                object nullableValue3 = command3.ExecuteScalar();
                if (nullableValue3 == null || nullableValue3 == DBNull.Value)
                {
                    metroComboBox1.Items.Clear();
                    combodoldur();
                }
                else
                {
                    metroComboBox1.Items.Clear();
                    combodoldur();
                    DataSet ds1 = new DataSet();
                    SqlDataAdapter adtr = new SqlDataAdapter("select cur_name from currency inner join stock_currency on stock_currency.cur_id = currency.cur_id where stock_id = '" + nullableValue3 + "'", con);
                    try
                    {
                        adtr.Fill(ds1, "currency");
                        dataGridView6.DataSource = ds1.Tables["currency"];
                        dataGridView6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        adtr.Dispose();

                        if (dataGridView6.Rows.Count > 1)
                        {
                            for (int i = 0; i < dataGridView6.Rows.Count - 1; i++)
                            {
                                metroComboBox1.Items.Remove(dataGridView6.Rows[i].Cells[0].Value.ToString());
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG13");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG13", "Sistem Mesajı");
                    }
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG14");
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG14", "Sistem Mesajı");
            }
            //PROGRAMLOG
            con.Close();

        }
    }
}
