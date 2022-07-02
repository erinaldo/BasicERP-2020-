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

namespace mobilyaciProjesi
{
    public partial class personeladd : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";
        personel prrid;
        public personeladd(personel pr)
        {
            InitializeComponent();
            this.prrid = pr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void combodoldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string query = "select dep_name from tbl_department";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "dep_name");
                metroComboBox1.DisplayMember = "dep_name";
                metroComboBox1.ValueMember = "dep_name";
                metroComboBox1.DataSource = ds.Tables["dep_name"];
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
            }
            con.Close();
        }
        void combo2doldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string query = "select cur_name from currency where delete_status = '0'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "cur_name");
                metroComboBox2.DisplayMember = "cur_name";
                metroComboBox2.ValueMember = "cur_name";
                metroComboBox2.DataSource = ds.Tables["cur_name"];
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
            }
            
            con.Close();
        }

        programLog prlg;
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DateTime dt = DateTime.Now;
            string tarih = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int islemdurdurucu = 0;
            pictureBox1.Image = resizeImage(pictureBox1.Image, new Size(200, 200));
            ImageConverter imgc = new ImageConverter();
            byte[] img = (byte[])imgc.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox7.Text == "" || textBox9.Text == "" || textBox10.Text == ""  || textBox12.Text == ""  || textBox14.Text == ""  || textBox16.Text == ""
                || textBox1.Text == "TC Kimlik No" || textBox2.Text == "Adı" || textBox3.Text == "Soyadı" || textBox7.Text == "Yetkisi" || textBox9.Text == "GSM" || textBox10.Text == "Ev Adresi"  || textBox12.Text == "IBAN"  || textBox14.Text == "SSK No" || textBox16.Text == "Maaş")
            {
                MessageBox.Show("Lütfen ekrandaki parametreleri doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                string depid = "";
                con.Open();
                SqlCommand command6 = new SqlCommand("Insert Into tbl_userlog(user_id,form_name,islem,log_date) Values (@userid,@formname,@islem, @logdate)", con);
                command6.Parameters.AddWithValue("@userid", login.userid);
                command6.Parameters.AddWithValue("@formname", this.Text);
                command6.Parameters.AddWithValue("@islem", button2.Text);
                command6.Parameters.AddWithValue("@logdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                try
                {
                    command6.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG6");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı");
                }
                string sqlquery4 = "SELECT dep_id FROM tbl_department where dep_name = '" + metroComboBox1.Text + "'";
                SqlCommand command4 = new SqlCommand(sqlquery4, con);
                try
                {
                    object nullableValue5 = command4.ExecuteScalar();
                    if (nullableValue5 == null || nullableValue5 == DBNull.Value)
                    {
                        MessageBox.Show("Eksik departman verisi mevcut. Lütfen departman düzenleme paneline geçiş yaparak eksik veriyi doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        islemdurdurucu++;
                    }
                    else
                    {
                        depid = nullableValue5.ToString();
                    }
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
                }
                

                string curid = "";
                string sqlquery5 = "SELECT cur_id FROM currency where cur_name = '" + metroComboBox2.Text + "'";
                SqlCommand command5 = new SqlCommand(sqlquery5, con);
                try
                {
                    object nullableValue6 = command5.ExecuteScalar();
                    if (nullableValue6 == null || nullableValue6 == DBNull.Value)
                    {
                        MessageBox.Show("Eksik döviz verisi mevcut. Lütfen döviz düzenleme paneline geçiş yaparak eksik veriyi doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        islemdurdurucu++;
                    }
                    else
                    {
                        curid = nullableValue6.ToString();
                    }
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG4");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı");
                }
                
                if (islemdurdurucu == 0)
                {
                    SqlCommand command = new SqlCommand("Insert Into tbl_personnel(sicil_no,per_tc_no,per_name,per_surname,per_bday,blood_type, gender, per_type, marital_status, per_gsm, per_address,per_mail,per_iban,per_add_date,per_f_no,per_ssk_no,per_tax_id,per_charge,dep_id,per_status,cur_id,delete_status, img, user_id, edit_date) Values (" +
                    "@sicilno,@pertcno, @pername, @persurname,@perbday,@perbloodtype,@pergender,@pertype, @maritalstatus, @pergsm,@peraddress," +
                    "@peremail,@periban,@peradddate,@perfno,@persskno,@pertaxid,@percharge,@depid,@perstatus,@curid, @deletestatus, @img,@userid,@editdate)", con);
                    command.Parameters.AddWithValue("@sicilno", textBox18.Text);
                    command.Parameters.AddWithValue("@pertcno", textBox1.Text);
                    command.Parameters.AddWithValue("@pername", textBox2.Text);
                    command.Parameters.AddWithValue("@persurname", textBox3.Text);
                    command.Parameters.AddWithValue("@perbday", dateTimePicker1.Text);
                    if (textBox5.Text == "" || textBox5.Text == "Kan Grubu")
                    {
                        command.Parameters.AddWithValue("@perbloodtype", "");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@perbloodtype", textBox5.Text);
                    }
                    if (textBox6.Text == "" || textBox6.Text == "Cinsiyet")
                    {
                        command.Parameters.AddWithValue("@pergender", "");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@pergender", textBox6.Text);
                    }
                    
                    command.Parameters.AddWithValue("@pertype", textBox7.Text);
                    if (textBox8.Text == "" || textBox8.Text == "Medeni Hali")
                    {
                        command.Parameters.AddWithValue("@maritalstatus", "");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@maritalstatus", textBox8.Text);
                    }
                    
                    command.Parameters.AddWithValue("@pergsm", textBox9.Text);
                    command.Parameters.AddWithValue("@peraddress", textBox10.Text);

                    if (textBox11.Text == "" || textBox11.Text == "Mail Adresi")
                    {
                        command.Parameters.AddWithValue("@peremail", "");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@peremail", textBox11.Text);
                    }
                    
                    command.Parameters.AddWithValue("@periban", textBox12.Text);
                    command.Parameters.AddWithValue("@peradddate", tarih);
                    if (textBox13.Text == "" || textBox13.Text == "Parmak İzi No")
                    {
                        command.Parameters.AddWithValue("@perfno", "");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@perfno", textBox13.Text);
                    }
                    command.Parameters.AddWithValue("@persskno", textBox14.Text);

                    if (textBox15.Text == "" || textBox15.Text == "")
                    {
                        command.Parameters.AddWithValue("@pertaxid", "");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@pertaxid", textBox15.Text);
                    }
                    
                    command.Parameters.AddWithValue("@percharge", textBox16.Text);
                    command.Parameters.AddWithValue("@depid", depid);
                    command.Parameters.AddWithValue("@perstatus", "1");
                    command.Parameters.AddWithValue("@curid", curid);
                    command.Parameters.AddWithValue("@deletestatus", "0");
                    command.Parameters.AddWithValue("@img", img);
                    command.Parameters.AddWithValue("@userid", login.userid);
                    command.Parameters.AddWithValue("@editdate", tarih);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Tamamlandı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG5");//PROGRAMLOG
                        prlg.databaseinsert();

                        if (ex.Number == 2627)
                        {
                            MessageBox.Show("Girilen TC Kimlik Numarası zaten sistemde kayıtlı.", "Sistem Mesajı");
                        }
                        else
                        {
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı");
                        }
                    }
                    this.Controls.Clear();
                    this.InitializeComponent();
                    prrid.doldurpersonel();
                    this.Close();
                }
                con.Close();
            }
        }

        //public string startingpath = "";
        private void personeladd_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            combodoldur();
            combo2doldur();

            //pictureBox1.ImageLocation = "C:/Users/Muhammed/source/repos/mobilyaciProjesi/mobilyaciProjesi/Resources/sil.png";
            //startingpath = "C:/Users/Muhammed/source/repos/mobilyaciProjesi/mobilyaciProjesi/Resources/sil.png";
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "TC Kimlik No")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Adı")
            {
                textBox2.Text = "";
                textBox2.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Soyadı")
            {
                textBox3.Text = "";
                textBox3.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "Kan Grubu")
            {
                textBox5.Text = "";
                textBox5.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox6.Text == "Cinsiyet")
            {
                textBox6.Text = "";
                textBox6.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox7.Text == "Yetkisi")
            {
                textBox7.Text = "";
                textBox7.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox8.Text == "Medeni Hali")
            {
                textBox8.Text = "";
                textBox8.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox9.Text == "GSM")
            {
                textBox9.Text = "";
                textBox9.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }
            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox10_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox10.Text == "Ev Adresi")
            {
                textBox10.Text = "";
                textBox10.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox11_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox11.Text == "Mail Adresi")
            {
                textBox11.Text = "";
                textBox11.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox12_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox12.Text == "IBAN")
            {
                textBox12.Text = "";
                textBox12.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox13_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox13.Text == "Parmak İzi No")
            {
                textBox13.Text = "";
                textBox13.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox14_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox14.Text == "SSK No")
            {
                textBox14.Text = "";
                textBox14.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox15_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox15.Text == "Vergi No")
            {
                textBox15.Text = "";
                textBox15.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void textBox16_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox16.Text == "Maaş")
            {
                textBox16.Text = "";
                textBox16.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox18.Text == "")
            {
                textBox18.ForeColor = System.Drawing.Color.DimGray;
                textBox18.Text = "Sicil No";
            }
        }

        private void personeladd_MouseClick(object sender, MouseEventArgs e)
        {
            button1.Focus();
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }






            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }
        }

        //DataClasses1DataContext db = new DataClasses1DataContext();
        public static string imgurl = "";

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
                pictureBox1.ImageLocation = file;
                imgurl = file;
            }
        }

        private void textBox18_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox18.Text == "Sicil No")
            {
                textBox18.Text = "";
                textBox18.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "TC Kimlik No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Soyadı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Kan Grubu";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cinsiyet";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Yetkisi";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Medeni Hali";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "GSM";
            }

            if (textBox10.Text == "")
            {
                textBox10.ForeColor = System.Drawing.Color.DimGray;
                textBox10.Text = "Ev Adresi";
            }

            if (textBox11.Text == "")
            {
                textBox11.ForeColor = System.Drawing.Color.DimGray;
                textBox11.Text = "Mail Adresi";
            }

            if (textBox12.Text == "")
            {
                textBox12.ForeColor = System.Drawing.Color.DimGray;
                textBox12.Text = "IBAN";
            }

            if (textBox13.Text == "")
            {
                textBox13.ForeColor = System.Drawing.Color.DimGray;
                textBox13.Text = "Parmak İzi No";
            }

            if (textBox14.Text == "")
            {
                textBox14.ForeColor = System.Drawing.Color.DimGray;
                textBox14.Text = "SSK No";
            }

            if (textBox15.Text == "")
            {
                textBox15.ForeColor = System.Drawing.Color.DimGray;
                textBox15.Text = "Vergi No";
            }

            if (textBox16.Text == "")
            {
                textBox16.ForeColor = System.Drawing.Color.DimGray;
                textBox16.Text = "Maaş";
            }
        }
    }
}
