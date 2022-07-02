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
    public partial class stokekle : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";
        public stokekle()
        {
            InitializeComponent();
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
            if (textBox3.Text == "Eklenecek Miktar")
            {
                textBox3.Text = "";
            }
        }

        private void stokekle_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Stok No";
            }
            if (textBox4.Text == "")
            {
                textBox4.Text = "Materyal No";
            }

            if (textBox2.Text == "")
            {
                textBox2.Text = "Stok Adı";
            }

            if (textBox5.Text == "")
            {
                textBox5.Text = "Materyal Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.Text = "Eklenecek Miktar";
            }

            if (textBox6.Text == "")
            {
                textBox6.Text = "Eklenecek Miktar";
            }

            if (textBox7.Text == "")
            {
                textBox7.Text = "Tedarik Edilen Fiyat (₺)";
            }

            if (textBox8.Text == "")
            {
                textBox8.Text = "Peşinat";
            }

            if (textBox9.Text == "")
            {
                textBox9.Text = "Fiş No";
            }

            if (textBox10.Text == "")
            {
                textBox10.Text = "Firma Adı";
            }

            button3.Focus();
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

        void data1doldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select stock_no, stock_name, stock_id, stock_material from tbl_stock where stock_no like '%" + textBox1.Text + "%' and not stock_status = '0' and delete_status = '0'", con);
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

        void data2doldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select stock_name, stock_no, stock_id, stock_material from tbl_stock where stock_name like '%" + textBox2.Text + "%' and not stock_status = '0' and delete_status = '0'", con);
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
                prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
            }
            con.Close();
        }

        void data3doldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select material_no, material_name, material_id from tbl_material where material_no like '%" + textBox4.Text + "%' and not material_status = '0' and not material_sellable = '1' and delete_status = '0'", con);
            try
            {
                adtr.Fill(ds, "tbl_material");
                dataGridView4.DataSource = ds.Tables["tbl_material"];
                dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                this.dataGridView4.Columns["material_name"].Visible = false;
                this.dataGridView4.Columns["material_id"].Visible = false;
                dataGridView4.Columns[0].HeaderText = "Material No";
                dataGridView4.Visible = true;
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
            }
            con.Close();
        }


        void data4doldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select material_name, material_no, material_id from tbl_material where material_name like '%" + textBox5.Text + "%' and not material_status = '0' and not material_sellable = '1' and delete_status = '0'", con);
            try
            {
                adtr.Fill(ds, "tbl_material");
                dataGridView5.DataSource = ds.Tables["tbl_material"];
                dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                this.dataGridView5.Columns["material_no"].Visible = false;
                this.dataGridView5.Columns["material_id"].Visible = false;
                dataGridView5.Columns[0].HeaderText = "Materyal Adı";
                dataGridView5.Visible = true;
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG4");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı");
            }
            con.Close();
        }

        void data6doldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select customer_name, customer_no, customer_id from tbl_customer where customer_name like '%" + textBox10.Text + "%' and not customer_status = '0' and delete_status = '0' and type = '0'", con);
            try
            {
                adtr.Fill(ds, "tbl_customer");
                dataGridView6.DataSource = ds.Tables["tbl_customer"];
                dataGridView6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                this.dataGridView6.Columns["customer_no"].Visible = false;
                this.dataGridView6.Columns["customer_id"].Visible = false;
                dataGridView6.Columns[0].HeaderText = "Müşteri Adı";
                dataGridView6.Visible = true;
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG5");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı");
            }
            con.Close();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["stock_no"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["stock_name"].Value.ToString();
            dataGridView1.Visible = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.CurrentRow.Cells["stock_no"].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells["stock_name"].Value.ToString();
            dataGridView2.Visible = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
        public static bool containsNegative = false;
        public static bool islemdurdurucu = false;
        public static bool formclose = true;

        programLog prlg;
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            //int yenideger = 0;
            con.Open();
            SqlCommand command7 = new SqlCommand("Insert Into tbl_userlog(user_id,form_name,islem,log_date) Values (@userid,@formname,@islem, @logdate)", con);
            command7.Parameters.AddWithValue("@userid", login.userid);
            command7.Parameters.AddWithValue("@formname", label1.Text);
            command7.Parameters.AddWithValue("@islem", button2.Text);
            command7.Parameters.AddWithValue("@logdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            try
            {
                command7.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG14");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG14", "Sistem Mesajı");
            }
            if (home.labeladi == "Üretilen Stok Paneli")
            {
                fisturu = 6;
                string sqlquery2 = "SELECT stock_id FROM tbl_stock where stock_no = '" + textBox1.Text + "'";
                SqlCommand command3 = new SqlCommand(sqlquery2, con);
                try
                {
                    object nullableValue3 = command3.ExecuteScalar();
                    if (nullableValue3 == null || nullableValue3 == DBNull.Value)
                    {
                        MessageBox.Show("Yanlış stok numarası girildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string sqlquery = "SELECT stock_amount FROM tbl_stock where stock_no = '" + textBox1.Text + "'";
                        SqlCommand command2 = new SqlCommand(sqlquery, con);
                        try
                        {
                            object nullableValue = command2.ExecuteScalar();
                            if (nullableValue == null || nullableValue == DBNull.Value)
                            {
                                MessageBox.Show("Yanlış stok numarası girildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                int fakingcount = 0;
                                string sorgu = "SELECT tbl_manufacture.material_id, tbl_manufacture.material_amount, tbl_material.material_name FROM tbl_manufacture INNER JOIN tbl_material ON tbl_material.material_id = tbl_manufacture.material_id where stock_id = '" + nullableValue3.ToString() + "'";
                                SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                                DataSet goster = new DataSet();
                                try
                                {
                                    getir.Fill(goster, "tbl_manufacture");
                                    dataGridView3.DataSource = goster.Tables["tbl_manufacture"];
                                    dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                    getir.Dispose();
                                }
                                catch (SqlException ex)
                                {
                                    prlg = new programLog(ex.Message, this.Text, "PRLG17");//PROGRAMLOG
                                    prlg.databaseinsert();
                                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG17", "Sistem Mesajı");
                                }


                                double[] intdizi = new double[dataGridView3.Rows.Count];


                                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                                {
                                    string sqlquery4 = "SELECT material_amount FROM tbl_material where material_id = '" + dataGridView3.Rows[i].Cells[0].Value.ToString() + "'";
                                    SqlCommand command4 = new SqlCommand(sqlquery4, con);
                                    try
                                    {
                                        string materialamount = command4.ExecuteScalar().ToString();
                                        string deger = (Convert.ToDouble(materialamount) - (Convert.ToDouble(textBox3.Text) * Convert.ToDouble(dataGridView3.Rows[i].Cells[1].Value))).ToString();

                                        intdizi[i] = Convert.ToDouble(deger);

                                        if (Convert.ToDouble(deger) < 0)
                                        {
                                            fakingcount++;
                                        }
                                    }
                                    catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG18"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG18", "Sistem Mesajı"); }
                                    //PROGRAMLOG
                                }

                                string[] stringdizi = new string[fakingcount];
                                int k = 0;

                                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                                {
                                    string sqlquery4 = "SELECT material_amount FROM tbl_material where material_id = '" + dataGridView3.Rows[i].Cells[0].Value.ToString() + "'";
                                    SqlCommand command4 = new SqlCommand(sqlquery4, con);
                                    try
                                    {
                                        string materialamount = command4.ExecuteScalar().ToString();

                                        string deger = (Convert.ToDouble(materialamount) - (Convert.ToDouble(textBox3.Text) * Convert.ToDouble(dataGridView3.Rows[i].Cells[1].Value))).ToString();

                                        intdizi[i] = Convert.ToDouble(deger);

                                        if (Convert.ToDouble(deger) < 0)
                                        {
                                            stringdizi[k] = dataGridView3.Rows[i].Cells[2].Value.ToString();
                                            k++;
                                        }
                                    }
                                    catch (SqlException ex)
                                    {
                                        prlg = new programLog(ex.Message, this.Text, "PRLG19");//PROGRAMLOG
                                        prlg.databaseinsert();
                                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG19", "Sistem Mesajı");
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

                                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                                    {
                                        string sqlquery9 = "SELECT material_sellable FROM tbl_material where material_id = '" + dataGridView3.Rows[i].Cells[0].Value.ToString() + "'";
                                        SqlCommand command9 = new SqlCommand(sqlquery9, con);
                                        string materialsellable = "";
                                        try { materialsellable = command9.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG26"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG26", "Sistem Mesajı"); }
                                        //PROGRAMLOG


                                        string sqlquery4 = "SELECT material_amount FROM tbl_material where material_id = '" + dataGridView3.Rows[i].Cells[0].Value.ToString() + "'";
                                        SqlCommand command4 = new SqlCommand(sqlquery4, con);
                                        try
                                        {
                                            string materialamount = command4.ExecuteScalar().ToString();
                                            string deger = (Convert.ToDouble(materialamount) - (Convert.ToDouble(textBox3.Text) * Convert.ToDouble(dataGridView3.Rows[i].Cells[1].Value))).ToString();
                                            SqlCommand command1 = new SqlCommand("update tbl_material set material_amount=@newamount,user_id=@userid,edit_date=@editdate where material_id = '" + dataGridView3.Rows[i].Cells[0].Value.ToString() + "'", con);
                                            command1.Parameters.AddWithValue("@newamount", Convert.ToDouble(deger));
                                            command1.Parameters.AddWithValue("@userid", login.userid);
                                            command1.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            try
                                            {
                                                command1.ExecuteNonQuery();
                                            }
                                            catch (SqlException ex)
                                            {
                                                prlg = new programLog(ex.Message, this.Text, "PRLG21");//PROGRAMLOG
                                                prlg.databaseinsert();
                                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG21", "Sistem Mesajı");
                                            }
                                            if (materialsellable == "1")
                                            {
                                                string sqlquery10 = "SELECT stock_id FROM tbl_stock inner join tbl_material on tbl_stock.stock_no = tbl_material.material_no where material_id = '" + dataGridView3.Rows[i].Cells[0].Value.ToString() + "'";
                                                SqlCommand command10 = new SqlCommand(sqlquery10, con);
                                                string stock_id = "";
                                                try { stock_id = command10.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG26"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG26", "Sistem Mesajı"); }
                                                //PROGRAMLOG

                                                SqlCommand command8 = new SqlCommand("update tbl_stock set stock_amount=@newamount,user_id=@userid,edit_date=@editdate where stock_id = '" + stock_id + "'", con);
                                                command8.Parameters.AddWithValue("@newamount", Convert.ToDouble(deger));
                                                command8.Parameters.AddWithValue("@userid", login.userid);
                                                command8.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                                try
                                                {
                                                    command8.ExecuteNonQuery();
                                                }
                                                catch (SqlException ex)
                                                {
                                                    prlg = new programLog(ex.Message, this.Text, "PRLG27");//PROGRAMLOG
                                                    prlg.databaseinsert();
                                                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG27", "Sistem Mesajı");
                                                }
                                            }
                                        }
                                        catch (SqlException ex)
                                        {
                                            prlg = new programLog(ex.Message, this.Text, "PRLG20");//PROGRAMLOG
                                            prlg.databaseinsert();
                                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG20", "Sistem Mesajı");
                                        }


                                    }
                                }
                                if (containsNegative == false)
                                {
                                    SqlCommand command5 = new SqlCommand("update tbl_stock set stock_amount=@newamount,user_id=@userid,edit_date=@editdate where stock_id = '" + nullableValue3 + "'", con);

                                    command5.Parameters.AddWithValue("@newamount", Convert.ToDouble(nullableValue) + (Convert.ToDouble(textBox3.Text)));
                                    command5.Parameters.AddWithValue("@userid", login.userid);
                                    command5.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    try
                                    {
                                        command5.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        prlg = new programLog(ex.Message, this.Text, "PRLG23");//PROGRAMLOG
                                        prlg.databaseinsert();
                                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG23", "Sistem Mesajı");
                                    }

                                    string sqlquery9 = "SELECT stock_material FROM tbl_stock where stock_id = '" + nullableValue3 + "'";
                                    SqlCommand command9 = new SqlCommand(sqlquery9, con);
                                    string stockmaterial = "";
                                    try { stockmaterial = command9.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG25"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG25", "Sistem Mesajı"); }
                                    //PROGRAMLOG
                                    if (stockmaterial == "1")
                                    {
                                        SqlCommand command8 = new SqlCommand("update tbl_material set material_amount=@newamount,user_id=@userid,edit_date=@editdate where material_no = '" + textBox1.Text + "'", con);
                                        command8.Parameters.AddWithValue("@newamount", Convert.ToDouble(nullableValue) + (Convert.ToDouble(textBox3.Text)));
                                        command8.Parameters.AddWithValue("@userid", login.userid);
                                        command8.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        try
                                        {
                                            command8.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            prlg = new programLog(ex.Message, this.Text, "PRLG24");//PROGRAMLOG
                                            prlg.databaseinsert();
                                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG24", "Sistem Mesajı");
                                        }
                                    }
                                    SqlCommand command6 = new SqlCommand("Insert Into stock_details(stock_id,quantity,insert_date,user_id,edit_date) " +
                                                    "Values (@stockid,@quantity, @insertdate,@userid,@editdate)", con);
                                    command6.Parameters.AddWithValue("@stockid", nullableValue3);
                                    command6.Parameters.AddWithValue("@quantity", textBox3.Text);
                                    command6.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    command6.Parameters.AddWithValue("@userid", login.userid);
                                    command6.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    try
                                    {
                                        command6.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        prlg = new programLog(ex.Message, this.Text, "PRLG22");//PROGRAMLOG
                                        prlg.databaseinsert();
                                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG22", "Sistem Mesajı");
                                    }
                                    MessageBox.Show("Kayıt Tamamlandı.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);//28.03.2021 20.30
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG16");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG16", "Sistem Mesajı");
                        }

                    }
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG15");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG15", "Sistem Mesajı");
                }

            }
            else
            {
                if (textBox4.Text == "" || textBox4.Text == "Materyal No" || textBox5.Text == "" || textBox5.Text == "Materyal Adı" || textBox6.Text == ""
                    || textBox6.Text == "Eklenecek Miktar" || textBox7.Text == "" || textBox7.Text == "Tedarik Edilen Fiyat (₺)" || textBox9.Text == ""
                    || textBox9.Text == "Fiş No" || textBox10.Text == "" || textBox10.Text == "Firma Adı")
                {
                    MessageBox.Show("Ekrandaki parametreleri doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formclose = false;
                }
                else
                {
                    string sqlquery2 = "SELECT material_id FROM tbl_material where material_no = '" + textBox4.Text + "' and not material_sellable = '1'";
                    SqlCommand command3 = new SqlCommand(sqlquery2, con);
                    try
                    {
                        object nullableValue3 = command3.ExecuteScalar();
                        if (nullableValue3 == null || nullableValue3 == DBNull.Value)
                        {
                            MessageBox.Show("Yanlış materyal girildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string sqlquery = "SELECT material_amount FROM tbl_material where material_no = '" + textBox4.Text + "'";
                            SqlCommand command2 = new SqlCommand(sqlquery, con);
                            try
                            {
                                object nullableValue = command2.ExecuteScalar();
                                if (nullableValue == null || nullableValue == DBNull.Value)
                                {
                                    MessageBox.Show("Yanlış materyal girildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    string deger = (Convert.ToDouble(nullableValue) + Convert.ToDouble(textBox6.Text)).ToString();

                                    SqlCommand command1 = new SqlCommand("update tbl_material set material_amount=@newamount,user_id=@userid,edit_date=@editdate where material_id = '" + nullableValue3 + "'", con);
                                    command1.Parameters.AddWithValue("@newamount", deger);
                                    command1.Parameters.AddWithValue("@userid", login.userid);
                                    command1.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    //MessageBox.Show(deger, "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);




                                    SqlCommand command5 = new SqlCommand("Insert Into material_details(slip_id,customer_id,material_id, quantity, price, insert_date, user_id, edit_date) " +
                                        "Values (" + "@slipid,@customerid,@materialid, @quantity, @price, @insertdate, @userid, @editdate)", con);


                                    ///////////////////////
                                    SqlCommand command6 = new SqlCommand("Insert Into acq(slip_no, customer_id, allcost, price, cur_id, total_price, paid_money, slip_type, acquisition_date, payment_date, status, insert_date, over_status, user_id, edit_date) " +
                                        "Values (" + "@slip_no, @customer_id, @allcost, @price, @curid, @total_price, @paid_money, @slip_type, @acquisition_date, @payment_date, @status, @insert_date, @over_status, @userid,@editdate)", con);
                                    command6.Parameters.AddWithValue("@slip_no", textBox9.Text);
                                    command6.Parameters.AddWithValue("@customer_id", dataGridView6.CurrentRow.Cells[2].Value);
                                    command6.Parameters.AddWithValue("@allcost", Convert.ToDouble(textBox7.Text));
                                    command6.Parameters.AddWithValue("@price", 0);
                                    command6.Parameters.AddWithValue("@curid", "1");
                                    command6.Parameters.AddWithValue("@total_price", Convert.ToDouble(textBox7.Text));

                                    if ((metroComboBox1.SelectedIndex + 1) > 2)
                                    {
                                        if (textBox8.Text == "Peşinat" || textBox8.Text == "")
                                        {
                                            command6.Parameters.AddWithValue("@paid_money", Convert.ToDouble(0));
                                            textBox8.Text = "0";
                                        }
                                        else
                                        {
                                            command6.Parameters.AddWithValue("@paid_money", Convert.ToDouble(textBox8.Text));
                                        }
                                    }
                                    else
                                    {
                                        command6.Parameters.AddWithValue("@paid_money", Convert.ToDouble(textBox7.Text));
                                    }
                                    command6.Parameters.AddWithValue("@slip_type", (metroComboBox1.SelectedIndex + 1).ToString());
                                    command6.Parameters.AddWithValue("@acquisition_date", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));

                                    if ((metroComboBox1.SelectedIndex + 1) > 2)
                                    {
                                        command6.Parameters.AddWithValue("@payment_date", dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                    else
                                    {
                                        command6.Parameters.AddWithValue("@payment_date", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                    command6.Parameters.AddWithValue("@status", "1");
                                    command6.Parameters.AddWithValue("@insert_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                                    if ((metroComboBox1.SelectedIndex + 1) > 2)
                                    {
                                        command6.Parameters.AddWithValue("@over_status", "0");
                                    }
                                    else
                                    {
                                        command6.Parameters.AddWithValue("@over_status", "1");
                                    }
                                    command6.Parameters.AddWithValue("@userid", login.userid);
                                    command6.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    try
                                    {
                                        command6.ExecuteNonQuery();

                                        string sqlquery11 = "SELECT slip_id FROM acq where slip_no = '" + textBox9.Text + "'";
                                        SqlCommand command11 = new SqlCommand(sqlquery11, con);
                                        string slipid1;
                                        try
                                        {
                                            slipid1 = command11.ExecuteScalar().ToString();
                                            command5.Parameters.AddWithValue("@slipid", slipid1);
                                            command5.Parameters.AddWithValue("@customerid", dataGridView6.CurrentRow.Cells["customer_id"].Value.ToString());
                                            command5.Parameters.AddWithValue("@materialid", nullableValue3);
                                            command5.Parameters.AddWithValue("@quantity", textBox6.Text);
                                            command5.Parameters.AddWithValue("@price", textBox7.Text);
                                            command5.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            command5.Parameters.AddWithValue("@userid", login.userid);
                                            command5.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                        }
                                        catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG32"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG32", "Sistem Mesajı"); }
                                        //command1.Parameters.AddWithValue("@slipid", slipid);
                                        formclose = true;
                                    }
                                    catch (SqlException ex)
                                    {
                                        prlg = new programLog(ex.Message, this.Text, button2.Text);//PROGRAMLOG
                                        prlg.databaseinsert();

                                        if (ex.Number == 2627)
                                        {
                                            islemdurdurucu = true;
                                            formclose = false;
                                            MessageBox.Show("Geçersiz fiş numarası girildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı");
                                        }
                                    }

                                    if (islemdurdurucu != true)
                                    {
                                        if ((metroComboBox1.SelectedIndex + 1) > 2)
                                        {
                                            string sqlquery9 = "SELECT slip_id FROM acq where slip_no = '" + textBox9.Text + "'";
                                            SqlCommand command9 = new SqlCommand(sqlquery9, con);
                                            string slipid = "";
                                            try { slipid = command9.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG7"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG7", "Sistem Mesajı"); }
                                            //PROGRAMLOG


                                            SqlCommand command8 = new SqlCommand("Insert Into acq_opencheck(slip_id, customer_id, paid_money, cur_id, type, payment_date, insert_date, user_id, edit_date) " +
                                            "Values (" + "@slipid, @customerid, @paidmoney, @curid, @type, @paymentdate, @insertdate, @userid, @editdate)", con);
                                            command8.Parameters.AddWithValue("@slipid", slipid);
                                            command8.Parameters.AddWithValue("@customerid", dataGridView6.CurrentRow.Cells[2].Value);
                                            command8.Parameters.AddWithValue("@paidmoney", Convert.ToDouble(textBox8.Text));
                                            command8.Parameters.AddWithValue("@curid", "1");
                                            command8.Parameters.AddWithValue("@type", (metroComboBox1.SelectedIndex + 1).ToString());
                                            command8.Parameters.AddWithValue("@paymentdate", dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                                            command8.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                            command8.Parameters.AddWithValue("@userid", login.userid);
                                            command8.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                            try
                                            {
                                                command8.ExecuteNonQuery();
                                            }
                                            catch (SqlException ex)
                                            {
                                                prlg = new programLog(ex.Message, this.Text, "PRLG8");
                                                prlg.databaseinsert();
                                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG8", "Sistem Mesajı");
                                            }
                                        }

                                        try
                                        {
                                            command1.ExecuteNonQuery();
                                            try
                                            {
                                                command5.ExecuteNonQuery();
                                            }
                                            catch (SqlException ex)
                                            {
                                                prlg = new programLog(ex.Message, this.Text, "PRLG9");//PROGRAMLOG
                                                prlg.databaseinsert();
                                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG9", "Sistem Mesajı");
                                            }

                                            MessageBox.Show("Kayıt Tamamlandı.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (SqlException ex)
                                        {
                                            prlg = new programLog(ex.Message, this.Text, "PRLG10");//PROGRAMLOG
                                            prlg.databaseinsert();
                                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG10", "Sistem Mesajı");
                                        }
                                    }
                                }
                            }
                            catch (SqlException ex)
                            {
                                prlg = new programLog(ex.Message, this.Text, "PRLG11");//PROGRAMLOG
                                prlg.databaseinsert();
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG11", "Sistem Mesajı");
                            }

                        }
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG12");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG12", "Sistem Mesajı");
                    }

                }

            }
            con.Close();
            if (formclose != false)
            {
                this.Close();
            }
            formclose = true;
        }

        private void stokekle_Load(object sender, EventArgs e)
        {
            label1.Text = home.labeladi;

            if (label1.Text == "Üretilen Stok Paneli")
            {
                panel2.Visible = false;
                button2.Location = new Point(12, 235);
                button1.Location = new Point(79, 280);
                this.Size = new Size(321, 365);
            }
            else
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                panel1.Visible = false;
                metroComboBox1.Text = "Nakit";
                string sqlquery4 = "SELECT TOP 1 slip_no FROM acq ORDER BY slip_id DESC";
                SqlCommand command4 = new SqlCommand(sqlquery4, con);
                con.Open();
                try
                {
                    object nullableValue5 = command4.ExecuteScalar();
                    if (nullableValue5 == null || nullableValue5 == DBNull.Value)
                    {
                        textBox9.Text = "1";

                    }
                    else
                    {
                        textBox9.Text = (Convert.ToInt64(nullableValue5) + 1).ToString();
                    }
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG13");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG13", "Sistem Mesajı");
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
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
                textBox3.Text = "Eklenecek Miktar";
            }


            button3.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tcmerkezbankasi tcmer = new tcmerkezbankasi();
            tcmer.Show();
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "Materyal No")
            {
                textBox4.Text = "";
            }
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "Materyal Adı")
            {
                textBox5.Text = "";
            }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox6.Text == "Eklenecek Miktar")
            {
                textBox6.Text = "";
            }
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox7.Text == "Tedarik Edilen Fiyat (₺)")
            {
                textBox7.Text = "";
            }
        }









        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Materyal No";
            }

            if (textBox5.Text == "")
            {
                textBox5.Text = "Materyal Adı";
            }

            if (textBox6.Text == "")
            {
                textBox6.Text = "Eklenecek Miktar";
            }

            if (textBox7.Text == "")
            {
                textBox7.Text = "Tedarik Edilen Fiyat (₺)";
            }

            if (textBox8.Text == "")
            {
                textBox8.Text = "Peşinat";
            }

            if (textBox9.Text == "")
            {
                textBox9.Text = "Fiş No";
            }

            if (textBox10.Text == "")
            {
                textBox10.Text = "Firma Adı";
            }


            button3.Focus();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
            {
                data3doldur();

            }
            else
            {
                dataGridView4.Visible = false;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
            {
                data4doldur();

            }
            else
            {
                dataGridView5.Visible = false;
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView4.CurrentRow.Cells["material_no"].Value.ToString();
            textBox5.Text = dataGridView4.CurrentRow.Cells["material_name"].Value.ToString();
            dataGridView4.Visible = false;
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView5.CurrentRow.Cells["material_no"].Value.ToString();
            textBox5.Text = dataGridView5.CurrentRow.Cells["material_name"].Value.ToString();
            dataGridView5.Visible = false;
        }
        public static int fisturu = 1;
        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fisturu = metroComboBox1.SelectedIndex + 1;
            if (metroComboBox1.Text == "Çek" || metroComboBox1.Text == "Açık Hesap" || metroComboBox1.Text == "Senet")
            {
                panel3.Visible = true;
                if (metroComboBox1.Text == "Çek")
                {
                    label2.Text = "Çek Paneli";
                    MessageBox.Show("Çek ile tedarik paneli aktifleştirildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (metroComboBox1.Text == "Açık Hesap")
                {
                    label2.Text = "Açık Hesap Paneli";
                    MessageBox.Show("Açık Hesap ile tedarik paneli aktifleştirildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    label2.Text = "Senet Paneli";
                    MessageBox.Show("Senet ile tedarik paneli aktifleştirildi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                panel3.Visible = false;
            }
        }

        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox8.Text == "Peşinat")
            {
                textBox8.Text = "";
            }
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

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
            {
                data6doldur();

            }
            else
            {
                dataGridView6.Visible = false;
            }
        }

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox9.Text == "Fiş No")
            {
                textBox9.Text = "";
            }
        }

        private void textBox10_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox10.Text == "Firma Adı")
            {
                textBox10.Text = "";
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox10.Text = dataGridView6.CurrentRow.Cells["customer_name"].Value.ToString();
            dataGridView6.Visible = false;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) != Keys.Control && e.KeyChar == '*' || (Control.ModifierKeys & Keys.Shift) == Keys.Shift && e.KeyChar == ' ')
            {
                //dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.Value = DateTime.Now;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "dd.MM.yyyy - HH:mm:ss";
        }

        private void stokekle_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (home.labeladi != "Üretilen Stok Paneli")
            //{
            HandleToForm1.WriteToTextbox("1");
            //}
            home.labeladi = "";
        }
        private home HandleToForm1;
        public stokekle(home frm1Handle)
        {
            InitializeComponent();
            HandleToForm1 = frm1Handle;
        }
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(pictureBox2, "Buradan Ödeme Tarihini Seçiniz");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(pictureBox1, "Buradan Malzemenin Alındığı Tarihini Seçiniz");
        }
    }
}
