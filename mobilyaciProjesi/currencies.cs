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
    public partial class currencies : Form
    {
        currency csrid;
        public currencies(currency cs)
        {
            InitializeComponent();
            this.csrid = cs;
        }
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void currencies_Load(object sender, EventArgs e)
        {
            textBox1.Text = currency.curno;
            textBox2.Text = currency.curname;
            if (currency.curstatus == "1")
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            checkBox1.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled == false)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                checkBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                checkBox1.Enabled = false;
            }
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
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox1.Text == "Döviz No" || textBox2.Text == "Döviz Adı")
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
                            prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
                        }

                        SqlCommand command = new SqlCommand("update currency set cur_no=@curno,cur_name=@curname,cur_status=@curstatus, user_id=@userid, edit_date=@editdate where cur_no = '" + currency.curno + "'", con);
                        command.Parameters.AddWithValue("@curno", textBox1.Text);
                        command.Parameters.AddWithValue("@curname", textBox2.Text);

                        if (checkBox1.Checked == true)
                        {
                            command.Parameters.AddWithValue("@curstatus", "0");
                        }
                        else if (checkBox1.Checked == false)
                        {
                            command.Parameters.AddWithValue("@curstatus", "1");
                        }
                        command.Parameters.AddWithValue("@userid", login.userid);
                        command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Kayıt Güncellendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
                        }

                        con.Close();
                        csrid.doldurcurrency();
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
                    prlg = new programLog(ex.Message, this.Text, "PRLG4");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı");
                }

                komut.Connection = con;
                komut.CommandText = "update currency set delete_status=@deletestatus, user_id=@userid, edit_date=@editdate where cur_no= '" + currency.curno + "'";
                komut.Parameters.AddWithValue("@deletestatus", "1");
                komut.Parameters.AddWithValue("@userid", login.userid);
                komut.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                try
                {
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
                }
                con.Close();
                MessageBox.Show("Kayıt silindi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                csrid.doldurcurrency();
                this.Close();
            }
        }
    }
}
