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
    public partial class personels : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        personel prrid;
        public personels(personel pr)
        {
            InitializeComponent();
            this.prrid = pr;
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
            string query = "select cur_name from currency";
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

        void personelbilgisigetir()
        {
            textBox1.Text = personel.tcno;
            textBox2.Text = personel.adi;
            textBox3.Text = personel.soyadi;
            textBox4.Text = personel.sicilno;
            dateTimePicker1.Text = personel.dogumtarihi;
            textBox5.Text = personel.kangrubu;
            textBox6.Text = personel.cinsiyet;
            textBox7.Text = personel.yetki;
            textBox8.Text = personel.medenihali;
            textBox9.Text = personel.gsm;
            textBox10.Text = personel.evadresi;
            textBox11.Text = personel.mail;
            textBox12.Text = personel.iban;
            textBox13.Text = personel.parmakizino;
            textBox14.Text = personel.sskno;
            textBox15.Text = personel.vergino;
            textBox16.Text = personel.maas;
            metroComboBox1.Text = personel.depadi;
            metroComboBox2.Text = personel.curadi;

            if (personel.perstatus == "0")
            {
                metroCheckBox2.Checked = true;
            }
            else
            {
                metroCheckBox2.Checked = false;
            }
            if (personel.nullimage == false)
            {
                pictureBox1.Image = personel.img;
            }
            else
            {
                pictureBox1.Image = mobilyaciProjesi.Properties.Resources.sil;
            }
        }

        void inaktif()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox13.Enabled = false;
            textBox14.Enabled = false;
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            label2.Enabled = false;
            dateTimePicker1.Enabled = false;
            metroCheckBox2.Enabled = false;
            metroComboBox1.Enabled = false;
            metroComboBox2.Enabled = false;
            button3.Enabled = false;
        }

        void aktif()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            textBox13.Enabled = true;
            textBox14.Enabled = true;
            textBox15.Enabled = true;
            textBox16.Enabled = true;
            label2.Enabled = true;
            dateTimePicker1.Enabled = true;
            metroCheckBox2.Enabled = true;
            metroComboBox1.Enabled = true;
            metroComboBox2.Enabled = true;
            button3.Enabled = true;
        }

        private void personels_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            combodoldur();
            combo2doldur();
            personelbilgisigetir();
            inaktif();
            startingpath = personel.picurl;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled == false)
            {
                aktif();
            }
            else
            {
                inaktif();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
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
                    pictureBox1.Image = resizeImage(pictureBox1.Image, new Size(200, 200));
                    ImageConverter imgc = new ImageConverter();
                    byte[] img = (byte[])imgc.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));

                    DateTime dt = DateTime.Now;
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);


                    string depid = "";
                    con.Open();
                    SqlCommand command6 = new SqlCommand("Insert Into tbl_userlog(user_id,form_name,islem,log_date) Values (@userid,@formname,@islem, @logdate)", con);
                    command6.Parameters.AddWithValue("@userid", login.userid);
                    command6.Parameters.AddWithValue("@formname", this.Text);
                    command6.Parameters.AddWithValue("@islem", button1.Text);
                    command6.Parameters.AddWithValue("@logdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    try
                    {
                        command6.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG7");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG7", "Sistem Mesajı");
                    }
                    string sqlquery4 = "SELECT dep_id FROM tbl_department where dep_name = '" + metroComboBox1.Text + "'";
                    SqlCommand command4 = new SqlCommand(sqlquery4, con);
                    try
                    {
                        object nullableValue5 = command4.ExecuteScalar();
                        if (nullableValue5 == null || nullableValue5 == DBNull.Value)
                        {
                            //MessageBox.Show("Eksik departman verisi mevcut. Lütfen departman düzenleme paneline geçiş yaparak eksik veriyi doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //islemdurdurucu++;
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
                            //MessageBox.Show("Eksik döviz verisi mevcut. Lütfen döviz düzenleme paneline geçiş yaparak eksik veriyi doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //islemdurdurucu++;
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


                    SqlCommand command = new SqlCommand("update tbl_personnel set per_tc_no=@tcno,per_name=@pername,per_surname=@persurname,per_bday=@perbday," +
                        "blood_type=@bloodtype ,gender=@gender ,per_type=@pertype  ,marital_status=@maritalstatus ,per_gsm=@pergsm ,per_address=@peraddress ," +
                        "per_mail=@permail ,per_iban=@periban ,per_f_no=@perfno ,per_ssk_no=@persskno ,per_tax_id=@pertaxid ,per_charge=@percharge ," +
                        "dep_id=@depid ,per_status=@perstatus ,cur_id=@curid,img=@img,user_id=@userid,edit_date=@editdate where per_id = '" + personel.perid + "'", con);
                    command.Parameters.AddWithValue("@tcno", textBox1.Text);
                    command.Parameters.AddWithValue("@pername", textBox2.Text);
                    command.Parameters.AddWithValue("@persurname", textBox3.Text);
                    command.Parameters.AddWithValue("@perbday", dateTimePicker1.Text);
                    command.Parameters.AddWithValue("@bloodtype", textBox5.Text);
                    command.Parameters.AddWithValue("@gender", textBox6.Text);
                    command.Parameters.AddWithValue("@pertype", textBox7.Text);
                    command.Parameters.AddWithValue("@maritalstatus", textBox8.Text);
                    command.Parameters.AddWithValue("@pergsm", textBox9.Text);
                    command.Parameters.AddWithValue("@peraddress", textBox10.Text);
                    command.Parameters.AddWithValue("@permail", textBox11.Text);
                    command.Parameters.AddWithValue("@periban", textBox12.Text);
                    command.Parameters.AddWithValue("@perfno", textBox13.Text);
                    command.Parameters.AddWithValue("@persskno", textBox14.Text);
                    command.Parameters.AddWithValue("@pertaxid", textBox15.Text);
                    command.Parameters.AddWithValue("@percharge", textBox16.Text);
                    command.Parameters.AddWithValue("@depid", depid);
                    if (metroCheckBox2.Checked == true)
                    {
                        command.Parameters.AddWithValue("@perstatus", "0");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@perstatus", "1");
                    }
                    command.Parameters.AddWithValue("@curid", curid);
                    command.Parameters.AddWithValue("@img", img);
                    command.Parameters.AddWithValue("@userid", login.userid);
                    command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Kayıt Güncellendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    con.Close();

                }
            }
            else
            {
                MessageBox.Show("Değişiklik yapmak için kalem butonuna tıklayınız.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                SqlCommand command = new SqlCommand("update tbl_personnel set delete_status=@deletestatus, user_id = @userid, edit_date = @editdate where per_tc_no = '" + personel.tcno + "'", con);
                command.Parameters.AddWithValue("@deletestatus", "1");
                command.Parameters.AddWithValue("@userid", login.userid);
                command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
                    prlg = new programLog(ex.Message, this.Text, "PRLG8");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG8", "Sistem Mesajı");
                }
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Kayıt silindi.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG6");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı");
                }

                con.Close();
                this.Controls.Clear();
                this.InitializeComponent();
                prrid.doldurpersonel();
                this.Close();

            }
        }


        public string startingpath = "";
        public static string imgurl = "";
        public static bool bosimage = false;
        private void button3_Click(object sender, EventArgs e)
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
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {


            //if (startingpath == personel.picurl)
            //{
            //    MessageBox.Show("SORUİŞARETİ");
            //}
            //else
            //{
            //    //File.Move(personel.picurl, "C:/Users/Muhammed/source/repos/mobilyaciImages/deleted" + personel.perid + ".jpg");
            //    //string subPath = @"C:/Users/Muhammed/source/repos/mobilyaciImages/" + personel.perid + ".jpg";
            //    //File.Delete(subPath);
            //}
        }
    }
}
