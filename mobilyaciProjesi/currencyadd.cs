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
    public partial class currencyadd : Form
    {
        currency csrid;
        public currencyadd(currency cs)
        {
            InitializeComponent();
            this.csrid = cs;
        }
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        programLog prlg;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DateTime dt = DateTime.Now;
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
                    prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
                }

                SqlCommand command = new SqlCommand("Insert Into currency(cur_no, cur_name, insert_date, cur_status, delete_status, user_id, edit_date) Values (@curno, @curname, @insertdate ,@curstatus,@deletestatus,@userid,@editdate)", con);
                command.Parameters.AddWithValue("@curno", textBox1.Text);
                command.Parameters.AddWithValue("@curname", textBox2.Text);
                command.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@curstatus", "1");
                command.Parameters.AddWithValue("@deletestatus", "0");
                command.Parameters.AddWithValue("@userid", login.userid);
                command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Tamamlandı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                    prlg.databaseinsert();

                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Bu döviz numarası zaten kullanılıyor.", "Sistem Mesajı");
                    }
                    else
                    {
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
                    }
                }
                con.Close();
                this.Controls.Clear();
                this.InitializeComponent();
                csrid.doldurcurrency();
                this.Close();
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Döviz No")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Döviz Adı")
            {
                textBox2.Text = "";
            }
        }

        private void currencyadd_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Döviz No";
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "Döviz Adı";
            }
            button2.Focus();
        }
    }
}
