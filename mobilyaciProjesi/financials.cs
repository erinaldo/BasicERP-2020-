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
    public partial class financials : Form
    {
        financialoperation fsrid;
        public financials(financialoperation fs)
        {
            InitializeComponent();
            this.fsrid = fs;
        }
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        private void financials_Load(object sender, EventArgs e)
        {
            metrocombodoldur();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            metroComboBox1.Enabled = false;
            checkBox1.Enabled = false;

            if (financialoperation.labelname == "Stok Mali İşlemleri")
            {
                textBox1.Text = financialoperation.stockno;
                textBox2.Text = financialoperation.stockname;

            }
            else
            {
                textBox1.Text = financialoperation.materialno;
                textBox2.Text = financialoperation.materialname;

            }
            textBox3.Text = financialoperation.paramiktari;
            metroComboBox1.Text = financialoperation.parabirimi;

            if (financialoperation.scstatus == "1")
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)//KALEM BUTONU
        {
            if (textBox1.Enabled == false)
            {
                textBox3.Enabled = true;
                metroComboBox1.Enabled = true;
                checkBox1.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
                metroComboBox1.Enabled = false;
                checkBox1.Enabled = false;
            }
        }

        void metrocombodoldur()//METROCOMBOBOX VERİ DOLDUR
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string query = "select cur_name from currency";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "cur_name");
                metroComboBox1.DisplayMember = "cur_name";
                metroComboBox1.ValueMember = "cur_name";
                metroComboBox1.DataSource = ds.Tables["cur_name"];
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
            }

            con.Close();
        }


        void data23doldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT stock_id, stock_material from tbl_stock where stock_no = '" + textBox1.Text + "' and stock_name = '" + textBox2.Text + "'", con);
            try
            {
                adtr.Fill(ds, "tbl_stock");
                dataGridView2.DataSource = ds.Tables["tbl_stock"];
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
            }
            DataSet ds1 = new DataSet();
            SqlDataAdapter adtr1 = new SqlDataAdapter("Select material_id, material_sellable from tbl_material where material_no = '" + textBox1.Text + "' and material_name = '" + textBox2.Text + "'", con);
            try
            {
                adtr1.Fill(ds1, "tbl_material");
                dataGridView3.DataSource = ds1.Tables["tbl_material"];
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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

        programLog prlg;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Enabled == true)
            {
                DialogResult c;
                c = MessageBox.Show("Güncellemek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    data23doldur();
                    DateTime dt = DateTime.Now;
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    {
                        MessageBox.Show("Lütfen ekrandaki parametreleri doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
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
                                prlg = new programLog(ex.Message, this.Text, "PRLG11");//PROGRAMLOG
                                prlg.databaseinsert();
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG11", "Sistem Mesajı");
                            }
                            SqlCommand command = new SqlCommand("update stock_currency set price=@price, cur_id=@curid, sc_status=@scstatus, user_id=@userid, edit_date=@editdate where stock_id = '" + dataGridView2.CurrentRow.Cells["stock_id"].Value.ToString() + "'", con);
                            command.Parameters.AddWithValue("@price", textBox3.Text);
                            command.Parameters.AddWithValue("@curid", dataGridView1.CurrentRow.Cells["cur_id"].Value.ToString());

                            if (checkBox1.Checked == true)
                            {
                                command.Parameters.AddWithValue("@scstatus", "0");
                            }
                            else if (checkBox1.Checked == false)
                            {
                                command.Parameters.AddWithValue("@scstatus", "1");
                            }
                            if (dataGridView2.CurrentRow.Cells["stock_material"].Value.ToString() == "1")
                            {
                                SqlCommand command1 = new SqlCommand("update material_currency set price=@price, cur_id=@curid, mc_status=@mcstatus, user_id=@userid, edit_date=@editdate where material_id = '" + dataGridView3.CurrentRow.Cells["material_id"].Value.ToString() + "'", con);
                                command1.Parameters.AddWithValue("@price", textBox3.Text);
                                command1.Parameters.AddWithValue("@curid", dataGridView1.CurrentRow.Cells["cur_id"].Value.ToString());

                                if (checkBox1.Checked == true)
                                {
                                    command1.Parameters.AddWithValue("@mcstatus", "0");
                                }
                                else if (checkBox1.Checked == false)
                                {
                                    command1.Parameters.AddWithValue("@mcstatus", "1");
                                }
                                command1.Parameters.AddWithValue("@userid", login.userid);
                                command1.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                try
                                {
                                    command1.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    prlg = new programLog(ex.Message, this.Text, "PRLG4");//PROGRAMLOG
                                    prlg.databaseinsert();
                                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı");
                                }
                            }
                            command.Parameters.AddWithValue("@userid", login.userid);
                            command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                prlg = new programLog(ex.Message, this.Text, "PRLG5");//PROGRAMLOG
                                prlg.databaseinsert();
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı");
                            }
                            con.Close();
                            fsrid.doldurstokfinansal();
                        }

                        else
                        {
                            con.Open();
                            SqlCommand command = new SqlCommand("update material_currency set price=@price, cur_id=@curid, mc_status=@mcstatus where material_id = '" + dataGridView3.CurrentRow.Cells["material_id"].Value.ToString() + "'", con);
                            command.Parameters.AddWithValue("@price", textBox3.Text);
                            command.Parameters.AddWithValue("@curid", dataGridView1.CurrentRow.Cells["cur_id"].Value.ToString());

                            if (checkBox1.Checked == true)
                            {
                                command.Parameters.AddWithValue("@mcstatus", "0");
                            }
                            else if (checkBox1.Checked == false)
                            {
                                command.Parameters.AddWithValue("@mcstatus", "1");
                            }

                            if (dataGridView3.CurrentRow.Cells["material_sellable"].Value.ToString() == "1")
                            {
                                //con.Open();
                                SqlCommand command1 = new SqlCommand("update stock_currency set price=@price, cur_id=@curid, sc_status=@scstatus where stock_id = '" + dataGridView2.CurrentRow.Cells["stock_id"].Value.ToString() + "'", con);
                                command1.Parameters.AddWithValue("@price", textBox3.Text);
                                command1.Parameters.AddWithValue("@curid", dataGridView1.CurrentRow.Cells["cur_id"].Value.ToString());

                                if (checkBox1.Checked == true)
                                {
                                    command1.Parameters.AddWithValue("@scstatus", "0");
                                }
                                else if (checkBox1.Checked == false)
                                {
                                    command1.Parameters.AddWithValue("@scstatus", "1");
                                }

                                try
                                {
                                    command1.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    prlg = new programLog(ex.Message, this.Text, "PRLG6");//PROGRAMLOG
                                    prlg.databaseinsert();
                                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı");
                                }

                                //con.Close();
                            }

                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                prlg = new programLog(ex.Message, this.Text, "PRLG7");//PROGRAMLOG
                                prlg.databaseinsert();
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG7", "Sistem Mesajı");
                            }
                            con.Close();
                            fsrid.doldurmateryalfinansal();
                        }

                        MessageBox.Show("Kayıt Güncellendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Değişiklik yapmak için kalem butonuna tıklayınız.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dataGridView1.DataSource = ds1.Tables["currency"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr1.Dispose();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG8");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG8", "Sistem Mesajı");
            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            SqlCommand komut = new SqlCommand();
            SqlDataAdapter adtr = new SqlDataAdapter();
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                data23doldur();
                if (financialoperation.labelname == "Stok Mali İşlemleri")
                {
                    con.Open();
                    komut.Connection = con;
                    komut.CommandText = "delete from stock_currency where stock_id= '" + dataGridView2.CurrentRow.Cells["stock_id"].Value.ToString() + "' and cur_id= '" + dataGridView1.CurrentRow.Cells["cur_id"].Value.ToString() + "'";

                    try
                    {
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        MessageBox.Show("Kayıt Silindi !", "Başarılı");
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG9");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG9", "Sistem Mesajı");
                    }
                    con.Close();
                    fsrid.doldurstokfinansal();
                    this.Close();
                }
                else
                {
                    con.Open();
                    komut.Connection = con;
                    komut.CommandText = "delete from material_currency where material_id= '" + dataGridView3.CurrentRow.Cells["material_id"].Value.ToString() + "' and cur_id= '" + dataGridView1.CurrentRow.Cells["cur_id"].Value.ToString() + "'";
                    try
                    {
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        MessageBox.Show("Kayıt Silindi !", "Başarılı");
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG10");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG10", "Sistem Mesajı");
                    }
                    con.Close();
                    fsrid.doldurmateryalfinansal();
                    this.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
