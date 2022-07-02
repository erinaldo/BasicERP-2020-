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
    public partial class expensesadd : Form
    {
        expenses exrid;
        public expensesadd(expenses ex)
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

        private void expensesadd_Load(object sender, EventArgs e)
        {
            combodoldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        programLog prlg;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DateTime dt = DateTime.Now;
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
                    prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
                }

                SqlCommand command = new SqlCommand("Insert Into expenses(exp_no, exp_name, exp_type, exp_status, exp_add_date, den_id, insert_date, delete_status, user_id, edit_date) Values " +
                    "(@expno, @expname, @exptype ,@expstatus,@expaddate,@denid,@insertdate,@deletestatus,@userid,@editdate)", con);
                command.Parameters.AddWithValue("@expno", textBox1.Text);
                command.Parameters.AddWithValue("@expname", textBox2.Text);
                if (metroCheckBox1.Checked == true) { command.Parameters.AddWithValue("@exptype", "1"); }
                if (metroCheckBox1.Checked == false) { command.Parameters.AddWithValue("@exptype", "0"); }
                command.Parameters.AddWithValue("@expstatus", "1");
                command.Parameters.AddWithValue("@expaddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                string sqlquery1 = "SELECT den_id FROM tbl_denomination where den_name = '" + metroComboBox1.Text + "'";
                SqlCommand command3 = new SqlCommand(sqlquery1, con);
                string denid = "";
                try { denid = command3.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG1"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı"); }
                //PROGRAMLOG
                

                command.Parameters.AddWithValue("@denid", denid);
                command.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
                    prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                    prlg.databaseinsert();

                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("Bu gider numarası zaten kullanılıyor.", "Sistem Mesajı");
                    }
                    else
                    {
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
                    }
                }
                con.Close();
                this.Controls.Clear();
                this.InitializeComponent();
                exrid.doldurexpenses();
                this.Close();
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Gider No")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Gider Adı")
            {
                textBox2.Text = "";
            }
        }

        private void expensesadd_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Gider No";
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "Gider Adı";
            }
            button3.Focus();
        }
    }
}
