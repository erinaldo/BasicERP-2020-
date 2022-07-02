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
    public partial class useradd : Form
    {
        userss fgrid;
        public useradd(userss fg)
        {
            InitializeComponent();
            this.fgrid = fg;
        }

        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox1.Text == "Yetki Seçiniz")
            {
                comboBox1.ForeColor = System.Drawing.Color.Black;
                comboBox1.Text = "";

                if (textBox1.Text == "")
                {
                    textBox1.ForeColor = System.Drawing.Color.DimGray;
                    textBox1.Text = "Kullanıcı Adı";
                }
                if (textBox2.Text == "")
                {
                    textBox2.ForeColor = System.Drawing.Color.DimGray;
                    textBox2.Text = "Şifre";
                }
                if (textBox3.Text == "")
                {
                    textBox3.ForeColor = System.Drawing.Color.DimGray;
                    textBox3.Text = "Adı ve Soyadı";
                }
                if (textBox4.Text == "")
                {
                    textBox4.ForeColor = System.Drawing.Color.DimGray;
                    textBox4.Text = "Mail";
                }
            }
            else
            {
                if (textBox1.Text == "")
                {
                    textBox1.ForeColor = System.Drawing.Color.DimGray;
                    textBox1.Text = "Kullanıcı Adı";
                }
                if (textBox2.Text == "")
                {
                    textBox2.ForeColor = System.Drawing.Color.DimGray;
                    textBox2.Text = "Şifre";
                }
                if (textBox3.Text == "")
                {
                    textBox3.ForeColor = System.Drawing.Color.DimGray;
                    textBox3.Text = "Adı ve Soyadı";
                }
                if (textBox4.Text == "")
                {
                    textBox4.ForeColor = System.Drawing.Color.DimGray;
                    textBox4.Text = "Mail";
                }
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "Mail")
            {
                textBox4.ForeColor = System.Drawing.Color.Black;
                textBox4.Text = "";

                if (textBox1.Text == "")
                {
                    textBox1.ForeColor = System.Drawing.Color.DimGray;
                    textBox1.Text = "Kullanıcı Adı";
                }
                if (textBox2.Text == "")
                {
                    textBox2.ForeColor = System.Drawing.Color.DimGray;
                    textBox2.Text = "Şifre";
                }
                if (textBox3.Text == "")
                {
                    textBox3.ForeColor = System.Drawing.Color.DimGray;
                    textBox3.Text = "Adı ve Soyadı";
                }
                if (comboBox1.Text == "")
                {
                    comboBox1.ForeColor = System.Drawing.Color.DimGray;
                    comboBox1.Text = "Yetki Seçiniz";
                }
            }
            else
            {
                if (textBox1.Text == "")
                {
                    textBox1.ForeColor = System.Drawing.Color.DimGray;
                    textBox1.Text = "Kullanıcı Adı";
                }
                if (textBox2.Text == "")
                {
                    textBox2.ForeColor = System.Drawing.Color.DimGray;
                    textBox2.Text = "Şifre";
                }
                if (textBox3.Text == "")
                {
                    textBox3.ForeColor = System.Drawing.Color.DimGray;
                    textBox3.Text = "Adı ve Soyadı";
                }
                if (comboBox1.Text == "")
                {
                    comboBox1.ForeColor = System.Drawing.Color.DimGray;
                    comboBox1.Text = "Yetki Seçiniz";
                }
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {

            if (textBox3.Text == "Adı ve Soyadı")
            {
                textBox3.ForeColor = System.Drawing.Color.Black;
                textBox3.Text = "";

                if (textBox1.Text == "")
                {
                    textBox1.ForeColor = System.Drawing.Color.DimGray;
                    textBox1.Text = "Kullanıcı Adı";
                }
                if (textBox2.Text == "")
                {
                    textBox2.ForeColor = System.Drawing.Color.DimGray;
                    textBox2.Text = "Şifre";
                }
                if (textBox4.Text == "")
                {
                    textBox4.ForeColor = System.Drawing.Color.DimGray;
                    textBox4.Text = "Mail";
                }
                if (comboBox1.Text == "")
                {
                    comboBox1.ForeColor = System.Drawing.Color.DimGray;
                    comboBox1.Text = "Yetki Seçiniz";
                }
            }
            else
            {
                if (textBox1.Text == "")
                {
                    textBox1.ForeColor = System.Drawing.Color.DimGray;
                    textBox1.Text = "Kullanıcı Adı";
                }
                if (textBox2.Text == "")
                {
                    textBox2.ForeColor = System.Drawing.Color.DimGray;
                    textBox2.Text = "Şifre";
                }
                if (textBox4.Text == "")
                {
                    textBox4.ForeColor = System.Drawing.Color.DimGray;
                    textBox4.Text = "Mail";
                }
                if (comboBox1.Text == "")
                {
                    comboBox1.ForeColor = System.Drawing.Color.DimGray;
                    comboBox1.Text = "Yetki Seçiniz";
                }
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Şifre")
            {
                textBox2.ForeColor = System.Drawing.Color.Black;
                textBox2.Text = "";

                if (textBox1.Text == "")
                {
                    textBox1.ForeColor = System.Drawing.Color.DimGray;
                    textBox1.Text = "Kullanıcı Adı";
                }
                if (textBox3.Text == "")
                {
                    textBox3.ForeColor = System.Drawing.Color.DimGray;
                    textBox3.Text = "Adı ve Soyadı";
                }
                if (textBox4.Text == "")
                {
                    textBox4.ForeColor = System.Drawing.Color.DimGray;
                    textBox4.Text = "Mail";
                }
                if (comboBox1.Text == "")
                {
                    comboBox1.ForeColor = System.Drawing.Color.DimGray;
                    comboBox1.Text = "Yetki Seçiniz";
                }
            }
            else
            {
                if (textBox1.Text == "")
                {
                    textBox1.ForeColor = System.Drawing.Color.DimGray;
                    textBox1.Text = "Kullanıcı Adı";
                }
                if (textBox3.Text == "")
                {
                    textBox3.ForeColor = System.Drawing.Color.DimGray;
                    textBox3.Text = "Adı ve Soyadı";
                }
                if (textBox4.Text == "")
                {
                    textBox4.ForeColor = System.Drawing.Color.DimGray;
                    textBox4.Text = "Mail";
                }
                if (comboBox1.Text == "")
                {
                    comboBox1.ForeColor = System.Drawing.Color.DimGray;
                    comboBox1.Text = "Yetki Seçiniz";
                }
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Kullanıcı Adı")
            {
                textBox1.ForeColor = System.Drawing.Color.Black;
                textBox1.Text = "";


                if (textBox2.Text == "")
                {
                    textBox2.ForeColor = System.Drawing.Color.DimGray;
                    textBox2.Text = "Şifre";
                }
                if (textBox3.Text == "")
                {
                    textBox3.ForeColor = System.Drawing.Color.DimGray;
                    textBox3.Text = "Adı ve Soyadı";
                }
                if (textBox4.Text == "")
                {
                    textBox4.ForeColor = System.Drawing.Color.DimGray;
                    textBox4.Text = "Mail";
                }
                if (comboBox1.Text == "")
                {
                    comboBox1.ForeColor = System.Drawing.Color.DimGray;
                    comboBox1.Text = "Yetki Seçiniz";
                }
            }
            else
            {
                if (textBox2.Text == "")
                {
                    textBox2.ForeColor = System.Drawing.Color.DimGray;
                    textBox2.Text = "Şifre";
                }
                if (textBox3.Text == "")
                {
                    textBox3.ForeColor = System.Drawing.Color.DimGray;
                    textBox3.Text = "Adı ve Soyadı";
                }
                if (textBox4.Text == "")
                {
                    textBox4.ForeColor = System.Drawing.Color.DimGray;
                    textBox4.Text = "Mail";
                }
                if (comboBox1.Text == "")
                {
                    comboBox1.ForeColor = System.Drawing.Color.DimGray;
                    comboBox1.Text = "Yetki Seçiniz";
                }
            }
        }

        private void useradd_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            if (login.yetkisi == 0)
            {
                comboBox1.Items.Add("Admin");
                comboBox1.Items.Add("Operatör");
                comboBox1.Items.Add("Üye");
            }
            else if (login.yetkisi == 1)
            {
                comboBox1.Items.Add("Operatör");
                comboBox1.Items.Add("Üye");
            }
            else
            {
                comboBox1.Items.Add("Üye");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        programLog prlg;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            //DateTime dt = DateTime.Now;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox1.Text == "Kullanıcı Adı" || textBox2.Text == "Şifre" || textBox3.Text == "Adı ve Soyadı" || textBox4.Text == "Mail")
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

                SqlCommand command = new SqlCommand("Insert Into tbl_user(user_name,user_password,user_nickname,user_email,user_permission, user_add_date, user_status, u_id, edit_date, delete_status) Values (@username, @userpassword, @nickname,@useremail,@userpermission,@useradddate,@userstatus,@uid,@editdate,@deletestatus)", con);
                command.Parameters.AddWithValue("@username", textBox1.Text);
                command.Parameters.AddWithValue("@userpassword", textBox2.Text);
                command.Parameters.AddWithValue("@nickname", textBox3.Text);
                command.Parameters.AddWithValue("@useremail", textBox4.Text);
                command.Parameters.AddWithValue("@userpermission", "");
                //if (comboBox1.Text == "Admin")
                //{
                //    
                //}
                //else if (comboBox1.Text == "Operatör")
                //{
                //    command.Parameters.AddWithValue("@userpermission", "1");
                //}
                //else if (comboBox1.Text == "Üye")
                //{
                //    command.Parameters.AddWithValue("@userpermission", "2");
                //}
                command.Parameters.AddWithValue("@useradddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@userstatus", "1");
                command.Parameters.AddWithValue("@uid", login.userid);
                command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@deletestatus", "0");

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Tamamlandı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SqlCommand command1 = new SqlCommand("Insert Into permission(user_id,personels, users, customers, expenses, financials, currencies, production, acquisition, stock, sale, u_id, edit_date, admin_status) " +
                        "Values (@userid, @personels, @users,@customers,@expenses,@financials,@currencies, @production, @acquisition, @stock, @sale,@uid,@editdate,@adminstatus)", con);

                    string sqlquery = "SELECT user_id FROM tbl_user where user_name = '" + textBox1.Text + "'";
                    SqlCommand command2 = new SqlCommand(sqlquery, con);
                    string useraydi = "";
                    try
                    { useraydi = command2.ExecuteScalar().ToString(); }
                    catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG14"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG14", "Sistem Mesajı"); }
                    //PROGRAMLOG
                    command1.Parameters.AddWithValue("@userid", useraydi);
                    command1.Parameters.AddWithValue("@personels", "0");
                    command1.Parameters.AddWithValue("@users", "0");
                    command1.Parameters.AddWithValue("@customers", "0");
                    command1.Parameters.AddWithValue("@expenses", "0");
                    command1.Parameters.AddWithValue("@financials", "0");
                    command1.Parameters.AddWithValue("@currencies", "0");
                    command1.Parameters.AddWithValue("@production", "0");
                    command1.Parameters.AddWithValue("@acquisition", "0");
                    command1.Parameters.AddWithValue("@stock", "0");
                    command1.Parameters.AddWithValue("@sale", "0");
                    command1.Parameters.AddWithValue("@uid", login.userid);
                    command1.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command1.Parameters.AddWithValue("@adminstatus", "0");

                    try
                    {
                        command1.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
                    }
                    
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
                }
                con.Close();


                this.Controls.Clear();
                this.InitializeComponent();
                fgrid.doldur();
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT admin_status FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string adminstatus = "";
            con.Open();
            try
            {
                adminstatus = command2.ExecuteScalar().ToString();
                if (adminstatus == "1")
                {
                    if (textBox2.PasswordChar == '*')
                    {
                        textBox2.PasswordChar = '\0';
                    }
                    else
                    {
                        textBox2.PasswordChar = '*';
                    }
                }
                else
                {
                    MessageBox.Show("Bu detayı göremezsiniz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG4"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı"); }
            //PROGRAMLOG
            con.Close();
            //if (login.yetkisi == 0)
            //{
            //    if (textBox2.PasswordChar == '*')
            //    {
            //        textBox2.PasswordChar = '\0';
            //    }
            //    else
            //    {
            //        textBox2.PasswordChar = '*';
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Bu detayı göremezsiniz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
    }
}
