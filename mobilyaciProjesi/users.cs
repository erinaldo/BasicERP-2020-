using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace mobilyaciProjesi
{
    public partial class users : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        userss fgrid;
        public users(userss fg)
        {
            InitializeComponent();
            this.fgrid = fg;
        }

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

        public static string userid;
        private void users_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            comboBox1.Enabled = false;
            checkBox1.Enabled = false;

            if (login.yetkisi != 0)
            {
                comboBox1.Visible = false;
            }

            comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("Operatör");
            comboBox1.Items.Add("Üye");

            textBox1.Text = userss.username;
            textBox2.Text = userss.userpassword;
            textBox3.Text = userss.usernickname;
            textBox4.Text = userss.usermail;
            userid = userss.userid;
            if (userss.userpermission == "0")
            {
                comboBox1.Text = "Admin";
            }
            else if (userss.userpermission == "1")
            {
                comboBox1.Text = "Operatör";
            }
            else
            {
                comboBox1.Text = "Üye";
            }

            if (userss.userstatus == "1")
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
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
                    button4.Enabled = true;
                }
                else
                {
                    button4.Enabled = false;
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG5"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı"); }
            //PROGRAMLOG
            con.Close();
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
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    string sqlquery10 = "SELECT admin_status FROM permission where user_id = '" + login.userid + "'";
                    SqlCommand command10 = new SqlCommand(sqlquery10, con);
                    string ad_status;
                    con.Open();
                    try
                    {
                        ad_status = command10.ExecuteScalar().ToString();
                        if (ad_status == "1")
                        {
                            DateTime dt = DateTime.Now;
                            //SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "" || textBox1.Text == "Kullanıcı Adı" || textBox2.Text == "Şifre" || textBox3.Text == "Adı ve Soyadı" || textBox4.Text == "Mail" || comboBox1.Text == "Yetki Seçiniz")
                            {
                                MessageBox.Show("Lütfen ekrandaki parametreleri doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                //con.Open();
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

                                SqlCommand command = new SqlCommand("update tbl_user set user_name=@username,user_password=@userpassword,user_nickname=@nickname,user_email=@useremail,user_permission=@userpermission, user_status=@userstatus,u_id=@uid,edit_date=@editdate where user_name = '" + userss.username + "'", con);
                                command.Parameters.AddWithValue("@username", textBox1.Text);
                                command.Parameters.AddWithValue("@userpassword", textBox2.Text);
                                command.Parameters.AddWithValue("@nickname", textBox3.Text);
                                command.Parameters.AddWithValue("@useremail", textBox4.Text);
                                if (comboBox1.Text == "Admin")
                                {
                                    command.Parameters.AddWithValue("@userpermission", "0");
                                }
                                else if (comboBox1.Text == "Operatör")
                                {
                                    command.Parameters.AddWithValue("@userpermission", "1");
                                }
                                else if (comboBox1.Text == "Üye")
                                {
                                    command.Parameters.AddWithValue("@userpermission", "2");
                                }


                                if (checkBox1.Checked == true)
                                {
                                    command.Parameters.AddWithValue("@userstatus", "0");
                                }
                                else if (checkBox1.Checked == false)
                                {
                                    command.Parameters.AddWithValue("@userstatus", "1");
                                }
                                command.Parameters.AddWithValue("@uid", login.userid);
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
                                
                                fgrid.doldur();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bu kullanıcı üzerinde değişiklik yapamazsınız.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG31");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG31", "Sistem Mesajı");
                    }
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Değişiklik yapmak için kalem butonuna tıklayınız.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG6"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı"); }
            //PROGRAMLOG
            con.Close();
        }


        private void button2_Click(object sender, EventArgs e)
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
                command5.Parameters.AddWithValue("@islem", button2.Text);
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
                komut.CommandText = "update tbl_user set delete_status = '1', u_id = '" + login.userid + "', edit_date = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where user_name= '" + textBox1.Text + "'";
                try
                {
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    MessageBox.Show("Kayıt Silindi !", "Başarılı");
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
                }
                con.Close();
                fgrid.doldur();
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled == false)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                comboBox1.Enabled = true;
                checkBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                comboBox1.Enabled = false;
                checkBox1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(pictureBox1, "Şifreyi Gör");
        }

        public static string username, nickname;
        private void button4_Click(object sender, EventArgs e)
        {
            username = textBox3.Text;
            nickname = textBox1.Text;
            yetkilendirme yt = new yetkilendirme();
            yt.Show();
        }
    }
}
