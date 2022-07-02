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
    public partial class yetkilendirme : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";
        public yetkilendirme()
        {
            InitializeComponent();
        }
        programLog prlg;
        void datadoldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from permission where user_id = '" + users.userid + "'", con);
            try
            {
                adtr.Fill(ds, "permission");
                dataGridView1.DataSource = ds.Tables["permission"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                this.dataGridView1.Columns["perm_id"].Visible = false;
                this.dataGridView1.Columns["user_id"].Visible = false;
                this.dataGridView1.Columns["admin_status"].Visible = false;

            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
            }
            con.Close();
        }
        private void yetkilendirme_Load(object sender, EventArgs e)
        {
            datadoldur();
            label1.Text = users.nickname + " / " + users.username;
            if (dataGridView1.Rows[0].Cells[2].Value.ToString() == "1")
            {
                checkBox1.Checked = true;
            }
            if (dataGridView1.Rows[0].Cells[3].Value.ToString() == "1")
            {
                checkBox2.Checked = true;
            }
            if (dataGridView1.Rows[0].Cells[4].Value.ToString() == "1")
            {
                checkBox3.Checked = true;
            }
            if (dataGridView1.Rows[0].Cells[5].Value.ToString() == "1")
            {
                checkBox4.Checked = true;
            }
            if (dataGridView1.Rows[0].Cells[6].Value.ToString() == "1")
            {
                checkBox5.Checked = true;
            }
            if (dataGridView1.Rows[0].Cells[7].Value.ToString() == "1")
            {
                checkBox6.Checked = true;
            }
            if (dataGridView1.Rows[0].Cells[8].Value.ToString() == "1")
            {
                checkBox7.Checked = true;
            }
            if (dataGridView1.Rows[0].Cells[9].Value.ToString() == "1")
            {
                checkBox8.Checked = true;
            }
            if (dataGridView1.Rows[0].Cells[10].Value.ToString() == "1")
            {
                checkBox9.Checked = true;
            }
            if (dataGridView1.Rows[0].Cells[11].Value.ToString() == "1")
            {
                checkBox10.Checked = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
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
            SqlCommand command = new SqlCommand("update permission set personels=@personels,users=@users,customers=@customers,expenses=@expenses," +
                "financials=@financials, currencies=@currencies,production=@production,acquisition=@acquisition,stock=@stock,sale=@sale, u_id=@uid," +
                "edit_date=@editdate where user_id = '" + users.userid + "'", con);

            if (checkBox1.Checked == true)
            {
                command.Parameters.AddWithValue("@personels", "1");
            }
            else
            {
                command.Parameters.AddWithValue("@personels", "0");
            }
            if (checkBox2.Checked == true)
            {
                command.Parameters.AddWithValue("@users", "1");
            }
            else
            {
                command.Parameters.AddWithValue("@users", "0");
            }
            if (checkBox3.Checked == true)
            {
                command.Parameters.AddWithValue("@customers", "1");
            }
            else
            {
                command.Parameters.AddWithValue("@customers", "0");
            }
            if (checkBox4.Checked == true)
            {
                command.Parameters.AddWithValue("@expenses", "1");
            }
            else
            {
                command.Parameters.AddWithValue("@expenses", "0");
            }
            if (checkBox5.Checked == true)
            {
                command.Parameters.AddWithValue("@financials", "1");
            }
            else
            {
                command.Parameters.AddWithValue("@financials", "0");
            }
            if (checkBox6.Checked == true)
            {
                command.Parameters.AddWithValue("@currencies", "1");
            }
            else
            {
                command.Parameters.AddWithValue("@currencies", "0");
            }
            if (checkBox7.Checked == true)
            {
                command.Parameters.AddWithValue("@production", "1");
            }
            else
            {
                command.Parameters.AddWithValue("@production", "0");
            }
            if (checkBox8.Checked == true)
            {
                command.Parameters.AddWithValue("@acquisition", "1");
            }
            else
            {
                command.Parameters.AddWithValue("@acquisition", "0");
            }
            if (checkBox9.Checked == true)
            {
                command.Parameters.AddWithValue("@stock", "1");
            }
            else
            {
                command.Parameters.AddWithValue("@stock", "0");
            }
            if (checkBox10.Checked == true)
            {
                command.Parameters.AddWithValue("@sale", "1");
            }
            else
            {
                command.Parameters.AddWithValue("@sale", "0");
            }
            command.Parameters.AddWithValue("@uid", login.userid);
            command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Yetkilendirme işlemi tamamlandı.", "Sistem Mesajı");
                this.Close();
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
