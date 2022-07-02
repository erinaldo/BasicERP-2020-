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
    public partial class userss : Form
    {
        public userss()
        {
            InitializeComponent();
        }
        mobilyaciEntities1 ent = new mobilyaciEntities1();
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        programLog prlg;
        public void doldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from tbl_user where delete_status = '0'", con);
            try
            {
                adtr.Fill(ds, "tbl_user");
                dataGridView1.DataSource = ds.Tables["tbl_user"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
            }
            con.Close();
        }

        private void userss_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            dataGridView1.RowTemplate.Height = 30;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("Kullanıcı Adına Göre");
            comboBox1.Items.Add("Kullanıcı Adı-Soyadına Göre");
            comboBox1.Items.Add("Kullanıcı Durumuna Göre");
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from tbl_user where delete_status = '0'", con);
            try
            {
                adtr.Fill(ds, "tbl_user");
                dataGridView1.DataSource = ds.Tables["tbl_user"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();

                this.dataGridView1.Columns["user_id"].Visible = false;
                this.dataGridView1.Columns["user_imgFileName"].Visible = false;
                this.dataGridView1.Columns["user_permission"].Visible = false;
                this.dataGridView1.Columns["user_add_date"].Visible = false;
                this.dataGridView1.Columns["user_image"].Visible = false;
                this.dataGridView1.Columns["user_password"].Visible = false;
                this.dataGridView1.Columns["delete_status"].Visible = false;
                this.dataGridView1.Columns["u_id"].Visible = false;
                this.dataGridView1.Columns["edit_date"].Visible = false;
                this.dataGridView1.Columns["user_email"].Visible = false;

                dataGridView1.Columns[1].HeaderText = "Kullanıcı Adı";
                dataGridView1.Columns[3].HeaderText = "Adı - Soyadı";
                dataGridView1.Columns[7].HeaderText = "Durum";

                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                for (int i = 0; i < 8; i++)
                {
                    DataGridViewColumn column = dataGridView1.Columns[i];
                    column.Width = 468;
                    if (i == 1 || i == 7)
                    {
                        column.Width = 150;
                    }
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
            }
            con.Close();
        }


        public static string userid,username, userpassword, usernickname, usermail, userpermission, userstatus;

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                doldur();
            }
            else
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                string sorgu = "select * from tbl_user where " + colname + " like '%" + textBox1.Text + "%'";
                con.Open();
                SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                DataSet goster = new DataSet();
                try
                {
                    getir.Fill(goster, "tbl_user");
                    dataGridView1.DataSource = goster.Tables["tbl_user"];
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Kullanıcı Adına Göre")
            {
                colname = "user_name";
            }
            else if (comboBox1.Text == "Kullanıcı Adı-Soyadına Göre")
            {
                colname = "user_nickname";
            }
            else if (comboBox1.Text == "Kullanıcı Durumuna Göre")
            {
                colname = "user_status";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    doldur();
                }
                else
                {
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    string sorgu = "select * from tbl_user where " + colname + " like '%" + textBox1.Text + "%'";
                    con.Open();
                    SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                    DataSet goster = new DataSet();
                    try
                    {
                        getir.Fill(goster, "tbl_user");
                        dataGridView1.DataSource = goster.Tables["tbl_user"];
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

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Ara")
            {
                textBox1.Text = "";
            }
        }

        private void userss_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ara";
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ara";
            }
        }

        public static string colname;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

            if (dataGridView1.Columns[columnIndex].Name == "user_name")
            {
                comboBox1.Text = "Kullanıcı Adına Göre";
                colname = "user_name";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "user_nickname")
            {
                comboBox1.Text = "Kullanıcı Adı-Soyadına Göre";
                colname = "user_nickname";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "user_status")
            {
                comboBox1.Text = "Kullanıcı Durumuna Göre";
                colname = "user_status";
            }
            else
            {

            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ara";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            useradd us = new useradd(this);
            us.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            userid = dataGridView1.CurrentRow.Cells["user_id"].Value.ToString();
            username = dataGridView1.CurrentRow.Cells["user_name"].Value.ToString();
            userpassword = dataGridView1.CurrentRow.Cells["user_password"].Value.ToString();
            usernickname = dataGridView1.CurrentRow.Cells["user_nickname"].Value.ToString();
            usermail = dataGridView1.CurrentRow.Cells["user_email"].Value.ToString();
            userpermission = dataGridView1.CurrentRow.Cells["user_permission"].Value.ToString();
            userstatus = dataGridView1.CurrentRow.Cells["user_status"].Value.ToString();
            users us = new users(this);
            us.Show();

        }
    }
}
