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
    public partial class expenseses : Form
    {
        expenses exrid;
        public expenseses(expenses ex)
        {
            InitializeComponent();
            this.exrid = ex;
        }
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        void combodoldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string query = "select den_name from tbl_denomination";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds, "den_name");
                metroComboBox1.DisplayMember = "den_name";
                metroComboBox1.ValueMember = "den_name";
                metroComboBox1.DataSource = ds.Tables["den_name"];
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
            }
            con.Close();
        }

        private void expenseses_Load(object sender, EventArgs e)
        {
            combodoldur();
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);

            textBox1.Text = expenses.expno;
            textBox2.Text = expenses.expname;
            if (expenses.exptype == "1")
            {
                metroCheckBox1.Checked = true;
            }
            else
            {
                metroCheckBox1.Checked = false;
            }
            maskedTextBox1.Text = expenses.expadddate;

            con.Open();
            string sqlquery1 = "SELECT den_name FROM tbl_denomination where den_id = '" + expenses.denid + "'";
            SqlCommand command3 = new SqlCommand(sqlquery1, con);
            string denname = "";

            try { denname = command3.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG2"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı"); }
            //PROGRAMLOG

            con.Close();

            metroComboBox1.Text = denname;

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            metroCheckBox1.Enabled = false;
            metroCheckBox2.Enabled = false;
            metroComboBox1.Enabled = false;
            maskedTextBox1.Enabled = false;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled == false)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                metroCheckBox1.Enabled = true;
                metroCheckBox2.Enabled = true;
                metroComboBox1.Enabled = true;
                maskedTextBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                metroCheckBox1.Enabled = false;
                metroCheckBox2.Enabled = false;
                metroComboBox1.Enabled = false;
                maskedTextBox1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        programLog prlg;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled == true)
            {
                DialogResult c;
                c = MessageBox.Show("Güncellemek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    DateTime dt = DateTime.Now;
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox1.Text == "Gider No" || textBox2.Text == "Gider Adı")
                    {
                        MessageBox.Show("Lütfen ekrandaki parametreleri doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        con.Open();
                        SqlCommand command5 = new SqlCommand("Insert Into tbl_userlog(user_id,form_name,islem,log_date) Values (@userid,@formname,@islem, @logdate)", con);
                        command5.Parameters.AddWithValue("@userid", login.userid);
                        command5.Parameters.AddWithValue("@formname", this.Text);
                        command5.Parameters.AddWithValue("@islem", button1.Text);
                        command5.Parameters.AddWithValue("@logdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        try
                        {
                            command5.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG6");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı");
                        }

                        SqlCommand command = new SqlCommand("update expenses set exp_no=@expno,exp_name=@expname,exp_type=@exptype,exp_status=@expstatus," +
                            "exp_add_date=@expadddate,den_id=@denid,user_id=@userid,edit_date=@editdate where exp_no = '" + expenses.expno + "'", con);
                        command.Parameters.AddWithValue("@expno", textBox1.Text);
                        command.Parameters.AddWithValue("@expname", textBox2.Text);

                        if (metroCheckBox1.Checked == true) { command.Parameters.AddWithValue("@exptype", "1"); }
                        else if (metroCheckBox1.Checked == false) { command.Parameters.AddWithValue("@exptype", "0"); }

                        if (metroCheckBox2.Checked == true) { command.Parameters.AddWithValue("@expstatus", "0"); }
                        else if (metroCheckBox2.Checked == false) { command.Parameters.AddWithValue("@expstatus", "1"); }

                        command.Parameters.AddWithValue("@expadddate", maskedTextBox1.Text);


                        string sqlquery1 = "SELECT den_id FROM tbl_denomination where den_name = '" + metroComboBox1.Text + "'";
                        SqlCommand command3 = new SqlCommand(sqlquery1, con);
                        string denid = "";

                        try { denid = command3.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG3"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı"); }
                        //PROGRAMLOG

                        command.Parameters.AddWithValue("@denid", denid);
                        command.Parameters.AddWithValue("@userid", login.userid);
                        command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Kayıt Güncellendi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG4");//PROGRAMLOG
                            prlg.databaseinsert();

                            if (ex.Number == 2627)
                            {
                                MessageBox.Show("Bu gider numarası zaten kullanılıyor.", "Sistem Mesajı");
                            }
                            else
                            {
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı");
                            }
                        }
                        con.Close();
                        exrid.doldurexpenses();
                        this.Close();
                    }

                }
            }
            else
            {
                MessageBox.Show("Değişiklik yapmak için kalem butonuna tıklayınız.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                con.Open();
                SqlCommand command5 = new SqlCommand("Insert Into tbl_userlog(user_id,form_name,islem,log_date) Values (@userid,@formname,@islem, @logdate)", con);
                command5.Parameters.AddWithValue("@userid", login.userid);
                command5.Parameters.AddWithValue("@formname", this.Text);
                command5.Parameters.AddWithValue("@islem", button4.Text);
                command5.Parameters.AddWithValue("@logdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                try
                {
                    command5.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG7");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG7", "Sistem Mesajı");
                }
                komut.Connection = con;
                komut.CommandText = "update expenses set delete_status = '1', user_id = '" + login.userid + "', edit_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where exp_no= '" + expenses.expno + "'";

                try
                {
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    MessageBox.Show("Kayıt silindi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG5");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı");
                }

                con.Close();
                exrid.doldurexpenses();
                this.Close();
            }
        }
    }
}
