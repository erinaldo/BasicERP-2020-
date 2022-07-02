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
    public partial class checkdetay : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        public checkdetay()
        {
            InitializeComponent();
        }

        private void checkdetay_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            label1.Text = ListItem1.slipid;
            label2.Text = ListItem1.customername;

            if (ListItem1.type == "Red")
            {
                string sorgu = "select top 1 acq.allcost as total, acq.paid_money as odenmis , (acq.allcost - acq.paid_money) as odenecek, convert(varchar, acq.payment_date, 101) as son_odeme, slip_no as fişno, acq.customer_id as musteriid, acq.cur_id as curid, acq.slip_type as fisturu from acq_opencheck inner join acq on acq.slip_id = acq_opencheck.slip_id where acq.slip_id = '" + label1.Text + "'";
                con.Open();
                SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                DataSet goster = new DataSet();

                try
                {
                    getir.Fill(goster, "sale_opencheck");
                    dataGridView1.DataSource = goster.Tables["sale_opencheck"];
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    getir.Dispose();

                    label4.Text = "Çek Toplam: " + dataGridView1.Rows[0].Cells[0].Value.ToString() + " " + ListItem1.birim;
                    label5.Text = "Ödenen: " + dataGridView1.Rows[0].Cells[1].Value.ToString() + " " + ListItem1.birim;
                    label6.Text = "Ödenecek: " + dataGridView1.Rows[0].Cells[2].Value.ToString() + " " + ListItem1.birim;
                    label7.Text = "Son Ödeme Tarihi: " + dataGridView1.Rows[0].Cells[3].Value.ToString();
                    label8.Text = "Fiş Numarası: " + dataGridView1.Rows[0].Cells[4].Value.ToString();
                    metroCheckBox1.Text = "Şimdi Ödeme Yap";
                    label3.BackColor = Color.FromArgb(255, 252, 114, 104);
                    textBox1.Text = "Ödenen Miktar";
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1.", "Sistem Mesajı");
                    button2.Enabled = false;
                }
                con.Close();
            }
            else
            {
                string sorgu = "select top 1 tbl_sale.allcost as total, tbl_sale.charged_money as alınmış , (tbl_sale.allcost - tbl_sale.charged_money) as alınacak, convert(varchar, tbl_sale.payment_date, 101) as son_odeme, slip_no as fişno, tbl_sale.customer_id as musteriid, tbl_sale.currency as curid, tbl_sale.slip_type as fisturu from tbl_sale where tbl_sale.slip_id = '" + label1.Text + "'";
                con.Open();
                SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                DataSet goster = new DataSet();

                try
                {
                    getir.Fill(goster, "tbl_sale");
                    dataGridView1.DataSource = goster.Tables["tbl_sale"];
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    getir.Dispose();
                    con.Close();

                    label4.Text = "Çek Toplam: " + dataGridView1.Rows[0].Cells[0].Value.ToString() + " " + ListItem1.birim;
                    label5.Text = "Tahsil Edilen: " + dataGridView1.Rows[0].Cells[1].Value.ToString() + " " + ListItem1.birim;
                    label6.Text = "Tahsil Edilecek: " + dataGridView1.Rows[0].Cells[2].Value.ToString() + " " + ListItem1.birim;
                    label7.Text = "Son Ödeme Tarihi: " + dataGridView1.Rows[0].Cells[3].Value.ToString();
                    label8.Text = "Fiş Numarası: " + dataGridView1.Rows[0].Cells[4].Value.ToString();
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2.", "Sistem Mesajı");
                    button2.Enabled = false;
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == false)
            {
                Size = new Size(305, 317);
                textBox1.Visible = false;
                button2.Visible = false;
            }
            else
            {
                Size = new Size(305, 464);
                textBox1.Visible = true;
                button2.Visible = true;
            }

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Alınan Miktar")
            {
                textBox1.Text = "";
            }
            else if (textBox1.Text == "Ödenen Miktar")
            {
                textBox1.Text = "";
            }
        }

        private void checkdetay_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Alınan Miktar";
            }
            button1.Focus();
        }

        home hm;
        programLog prlg;
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Çek işlemi yapılıyor, onaylıyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
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
                if (ListItem1.type == "Red")
                {
                    SqlCommand command4 = new SqlCommand("Insert Into acq_opencheck(slip_id,customer_id, paid_money, cur_id, type, payment_date, insert_date, user_id,edit_date) " +
                                    "Values (" + "@slipid, @customerid, @paidmoney, @curid, @type, @paymentdate, @insertdate, @userid, @editdate)", con);
                    command4.Parameters.AddWithValue("@slipid", label1.Text);
                    command4.Parameters.AddWithValue("@customerid", dataGridView1.Rows[0].Cells[5].Value.ToString());
                    command4.Parameters.AddWithValue("@paidmoney", Convert.ToDouble(textBox1.Text));
                    command4.Parameters.AddWithValue("@curid", dataGridView1.Rows[0].Cells[6].Value.ToString());
                    command4.Parameters.AddWithValue("@type", dataGridView1.Rows[0].Cells[7].Value.ToString());
                    command4.Parameters.AddWithValue("@paymentdate", dateTimePicker1.Value);
                    command4.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command4.Parameters.AddWithValue("@userid", login.userid);
                    command4.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    double miktar = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString());
                    if (miktar > Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Çek miktarı aşıldı. Lütfen doğru veri girişi yapınız.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SqlCommand command1 = new SqlCommand("update acq set paid_money=@paidmoney, user_id=@userid, edit_date=@editdate where slip_id = '" + Convert.ToInt64(label1.Text) + "'", con);
                        command1.Parameters.AddWithValue("@paidmoney", miktar);
                        command1.Parameters.AddWithValue("@userid", login.userid);
                        command1.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        try { command1.ExecuteNonQuery(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG3"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı"); }
                        //PROGRAMLOG

                        string sqlquery = "SELECT allcost FROM acq where slip_id = '" + Convert.ToInt64(label1.Text) + "'";
                        SqlCommand command2 = new SqlCommand(sqlquery, con);
                        string allcost = "";

                        try { allcost = command2.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG4"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı"); }
                        //PROGRAMLOG


                        if (Convert.ToDouble(allcost) == miktar)
                        {
                            SqlCommand command3 = new SqlCommand("update acq set over_status=@overstatus where slip_id = '" + Convert.ToInt64(label1.Text) + "'", con);
                            command3.Parameters.AddWithValue("@overstatus", "1");

                            try { command3.ExecuteNonQuery(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG5"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı"); }
                            //PROGRAMLOG
                        }

                        try
                        {
                            command4.ExecuteNonQuery();
                            MessageBox.Show("Ödeme yapıldı.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG6");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı");
                        }
                    }
                    
                }
                else
                {
                    SqlCommand command4 = new SqlCommand("Insert Into sale_opencheck(slip_id,customer_id, charged_money, cur_id, type, payment_date, insert_date, user_id, edit_date) " +
                                    "Values (" + "@slipid, @customerid, @chargedmoney, @curid, @type, @paymentdate, @insertdate, @userid, @editdate)", con);
                    command4.Parameters.AddWithValue("@slipid", label1.Text);
                    command4.Parameters.AddWithValue("@customerid", dataGridView1.Rows[0].Cells[5].Value.ToString());
                    command4.Parameters.AddWithValue("@chargedmoney", Convert.ToDouble(textBox1.Text));
                    command4.Parameters.AddWithValue("@curid", dataGridView1.Rows[0].Cells[6].Value.ToString());
                    command4.Parameters.AddWithValue("@type", dataGridView1.Rows[0].Cells[7].Value.ToString());
                    command4.Parameters.AddWithValue("@paymentdate", dateTimePicker1.Value);
                    command4.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command4.Parameters.AddWithValue("@userid", login.userid);
                    command4.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                    double miktar = Convert.ToDouble(textBox1.Text) + Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString());

                    if (miktar > Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Çek miktarı aşıldı. Lütfen doğru veri girişi yapınız.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SqlCommand command1 = new SqlCommand("update tbl_sale set charged_money=@chargedmoney, user_id=@userid, edit_date=@editdate where slip_id = '" + Convert.ToInt64(label1.Text) + "'", con);
                        command1.Parameters.AddWithValue("@chargedmoney", miktar);
                        command1.Parameters.AddWithValue("@userid", login.userid);
                        command1.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        try { command1.ExecuteNonQuery(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG7"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG7", "Sistem Mesajı"); }
                        //PROGRAMLOG

                        string sqlquery = "SELECT allcost FROM tbl_sale where slip_id = '" + Convert.ToInt64(label1.Text) + "'";
                        SqlCommand command2 = new SqlCommand(sqlquery, con);
                        string allcost = "";


                        try { allcost = command2.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG8"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG8", "Sistem Mesajı"); }
                        //PROGRAMLOG

                        if (Convert.ToDouble(allcost) == miktar)
                        {
                            SqlCommand command3 = new SqlCommand("update tbl_sale set over_status=@overstatus where slip_id = '" + Convert.ToInt64(label1.Text) + "'", con);
                            command3.Parameters.AddWithValue("@overstatus", "1");

                            try { command3.ExecuteNonQuery(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG9"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG9", "Sistem Mesajı"); }
                            //PROGRAMLOG
                        }
                        try
                        {
                            command4.ExecuteNonQuery();
                            MessageBox.Show("Tahsilat yapıldı.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG10");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG10", "Sistem Mesajı");
                        }
                    }


                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Bu işlem için yetkiniz yoktur.", "Yetkisiz Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Close();

        }

        private void checkdetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            hm = new home();
            hm.tedarikhavale();
        }
    }
}
