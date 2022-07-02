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
    public partial class customers : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        customer csrid;
        public customers(customer cs)
        {
            InitializeComponent();
            this.csrid = cs;
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Müşteri No")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Müşteri Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Müşteri GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Müşteri GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Müşteri E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Müşteri Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Müşteri IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Müşteri Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Müşteri Adres";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Müşteri Adı")
            {
                textBox2.Text = "";
                textBox2.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Müşteri No";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Müşteri GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Müşteri GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Müşteri E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Müşteri Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Müşteri IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Müşteri Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Müşteri Adres";
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Müşteri GSM")
            {
                textBox3.Text = "";
                textBox3.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Müşteri No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Müşteri Adı";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Müşteri GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Müşteri E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Müşteri Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Müşteri IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Müşteri Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Müşteri Adres";
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "Müşteri GSM2")
            {
                textBox4.Text = "";
                textBox4.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Müşteri No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Müşteri Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Müşteri GSM";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Müşteri E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Müşteri Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Müşteri IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Müşteri Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Müşteri Adres";
            }
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "Müşteri E-mail")
            {
                textBox5.Text = "";
                textBox5.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Müşteri No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Müşteri Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Müşteri GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Müşteri GSM2";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Müşteri Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Müşteri IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Müşteri Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Müşteri Adres";
            }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox6.Text == "Müşteri Sektör")
            {
                textBox6.Text = "";
                textBox6.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Müşteri No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Müşteri Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Müşteri GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Müşteri GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Müşteri E-mail";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Müşteri IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Müşteri Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Müşteri Adres";
            }
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox7.Text == "Müşteri IBAN")
            {
                textBox7.Text = "";
                textBox7.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Müşteri No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Müşteri Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Müşteri GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Müşteri GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Müşteri E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Müşteri Sektör";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Müşteri Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Müşteri Adres";
            }
        }

        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox8.Text == "Müşteri Temsilci Adı")
            {
                textBox8.Text = "";
                textBox8.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Müşteri No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Müşteri Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Müşteri GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Müşteri GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Müşteri E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Müşteri Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Müşteri IBAN";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Müşteri Adres";
            }
        }

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox9.Text == "Müşteri Adres")
            {
                textBox9.Text = "";
                textBox9.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Müşteri No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Müşteri Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Müşteri GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Müşteri GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Müşteri E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Müşteri Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Müşteri IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Müşteri Temsilci Adı";
            }
        }

        private void customers_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Müşteri No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Müşteri Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Müşteri GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Müşteri GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Müşteri E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Müşteri Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Müşteri IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Müşteri Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Müşteri Adres";
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
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                checkBox1.Enabled = true;
            }
            else
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
                checkBox1.Enabled = false;
            }
        }

        private void customers_Load(object sender, EventArgs e)
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
            checkBox1.Enabled = false;

            textBox1.Text = customer.customerno;
            textBox2.Text = customer.customername;
            textBox3.Text = customer.customergsm;
            textBox4.Text = customer.customergsm2;
            textBox5.Text = customer.customeremail;
            textBox6.Text = customer.customersector;
            textBox7.Text = customer.customeriban;
            textBox8.Text = customer.customeragent;
            textBox9.Text = customer.customeraddress;
            if (customer.customerstatus == "1")
            {
                checkBox1.Checked = false;
            }
            else
            {
                checkBox1.Checked = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        programLog prlg;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled == true)
            {
                DialogResult c;
                c = MessageBox.Show("Güncellemek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    //DateTime dt = DateTime.Now;
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox1.Text == "Müşteri No" || textBox2.Text == "Müşteri Adı" || textBox3.Text == "Müşteri GSM" || textBox5.Text == "Müşteri E-mail" || textBox7.Text == "Müşteri IBAN" || textBox8.Text == "Müşteri Temsilci Adı" || textBox9.Text == "Müşteri Adres")
                    {
                        MessageBox.Show("Lütfen ekrandaki parametreleri doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
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
                            prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
                        }


                        SqlCommand command = new SqlCommand("update tbl_customer set customer_no=@customerno,customer_name=@customername,customer_gsm=@customergsm,customer_gsm2=@customergsm2," +
                            "customer_email=@customeremail, customer_address=@customeraddress,customer_sector=@customersector,customer_iban=@customeriban," +
                            "customer_agent=@customeragent,customer_status=@customerstatus,user_id=@userid,edit_date=@editdate where customer_no = '" + customer.customerno + "'", con);
                        command.Parameters.AddWithValue("@customerno", textBox1.Text);
                        command.Parameters.AddWithValue("@customername", textBox2.Text);
                        command.Parameters.AddWithValue("@customergsm", textBox3.Text);
                        command.Parameters.AddWithValue("@customergsm2", textBox4.Text);
                        command.Parameters.AddWithValue("@customeremail", textBox5.Text);
                        command.Parameters.AddWithValue("@customeraddress", textBox9.Text);
                        command.Parameters.AddWithValue("@customersector", textBox7.Text);
                        command.Parameters.AddWithValue("@customeriban", textBox8.Text);
                        command.Parameters.AddWithValue("@customeragent", textBox6.Text);


                        if (checkBox1.Checked == true)
                        {
                            command.Parameters.AddWithValue("@customerstatus", "0");
                        }
                        else if (checkBox1.Checked == false)
                        {
                            command.Parameters.AddWithValue("@customerstatus", "1");
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

                            if (ex.Number == 2627)
                            {
                                MessageBox.Show("Bu Müşteri numarası zaten kullanılıyor.", "Sistem Mesajı");
                            }
                            else
                            {
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
                            }
                        }
                        con.Close();
                        csrid.doldurcustomer();
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
                komut.CommandText = "update tbl_customer set delete_status = '1', user_id='" + login.userid + "', edit_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where customer_no= '" + textBox1.Text + "'";

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
                csrid.doldurcustomer();
                this.Close();
            }
        }
    }
}
