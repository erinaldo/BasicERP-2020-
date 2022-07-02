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
    public partial class customeradd : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        customer csrid;
        public customeradd(customer cs)
        {
            InitializeComponent();
            this.csrid = cs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Cari Kart No")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Cari Kart Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Cari Kart GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Cari Kart GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Cari Kart E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cari Kart Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Cari Kart IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Cari Kart Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Cari Kart Adres";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "Cari Kart Adı")
            {
                textBox2.Text = "";
                textBox2.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Cari Kart No";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Cari Kart GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Cari Kart GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Cari Kart E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cari Kart Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Cari Kart IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Cari Kart Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Cari Kart Adres";
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Cari Kart GSM")
            {
                textBox3.Text = "";
                textBox3.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Cari Kart No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Cari Kart Adı";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Cari Kart GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Cari Kart E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cari Kart Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Cari Kart IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Cari Kart Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Cari Kart Adres";
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "Cari Kart GSM2")
            {
                textBox4.Text = "";
                textBox4.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Cari Kart No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Cari Kart Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Cari Kart GSM";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Cari Kart E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cari Kart Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Cari Kart IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Cari Kart Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Cari Kart Adres";
            }
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "Cari Kart E-mail")
            {
                textBox5.Text = "";
                textBox5.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Cari Kart No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Cari Kart Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Cari Kart GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Cari Kart GSM2";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cari Kart Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Cari Kart IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Cari Kart Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Cari Kart Adres";
            }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox6.Text == "Cari Kart Sektör")
            {
                textBox6.Text = "";
                textBox6.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Cari Kart No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Cari Kart Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Cari Kart GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Cari Kart GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Cari Kart E-mail";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Cari Kart IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Cari Kart Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Cari Kart Adres";
            }
        }

        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox7.Text == "Cari Kart IBAN")
            {
                textBox7.Text = "";
                textBox7.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Cari Kart No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Cari Kart Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Cari Kart GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Cari Kart GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Cari Kart E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cari Kart Sektör";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Cari Kart Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Cari Kart Adres";
            }
        }

        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox8.Text == "Cari Kart Temsilci Adı")
            {
                textBox8.Text = "";
                textBox8.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Cari Kart No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Cari Kart Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Cari Kart GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Cari Kart GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Cari Kart E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cari Kart Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Cari Kart IBAN";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Cari Kart Adres";
            }
        }

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox9.Text == "Cari Kart Adres")
            {
                textBox9.Text = "";
                textBox9.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Cari Kart No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Cari Kart Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Cari Kart GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Cari Kart GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Cari Kart E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cari Kart Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Cari Kart IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Cari Kart Temsilci Adı";
            }
        }

        private void customeradd_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "Cari Kart No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "Cari Kart Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Cari Kart GSM";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "Cari Kart GSM2";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Cari Kart E-mail";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Cari Kart Sektör";
            }

            if (textBox7.Text == "")
            {
                textBox7.ForeColor = System.Drawing.Color.DimGray;
                textBox7.Text = "Cari Kart IBAN";
            }

            if (textBox8.Text == "")
            {
                textBox8.ForeColor = System.Drawing.Color.DimGray;
                textBox8.Text = "Cari Kart Temsilci Adı";
            }

            if (textBox9.Text == "")
            {
                textBox9.ForeColor = System.Drawing.Color.DimGray;
                textBox9.Text = "Cari Kart Adres";
            }
        }

        programLog prlg;
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            //DateTime dt = DateTime.Now;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox1.Text == "Müşteri No" || textBox2.Text == "Müşteri Adı" || textBox3.Text == "Müşteri GSM" || textBox5.Text == "Müşteri E-mail" || textBox7.Text == "Müşteri IBAN" || textBox8.Text == "Müşteri Temsilci Adı" || textBox9.Text == "Müşteri Adres")
            {
                MessageBox.Show("Lütfen ekrandaki parametreleri doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                con.Open();
                SqlCommand command5 = new SqlCommand("Insert Into tbl_userlog(user_id, form_name,islem,log_date) Values (@userid,@formname,@islem, @logdate)", con);
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
                    prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
                }

                SqlCommand command = new SqlCommand("Insert Into tbl_customer(customer_no,customer_name,customer_gsm,customer_gsm2,customer_email, customer_address, customer_sector, customer_iban, customer_agent, customer_add_date,customer_status, type, delete_status, user_id, edit_date) Values (" +
                    "@customerno, @customername, @customergsm,@customergsm2,@customeremail,@customeraddress,@customersector, @customeriban, @customeragent,@customeradddate,@customerstatus, @type, @deletestatus, @userid, @editdate)", con);
                command.Parameters.AddWithValue("@customerno", textBox1.Text);
                command.Parameters.AddWithValue("@customername", textBox2.Text);
                command.Parameters.AddWithValue("@customergsm", textBox3.Text);
                command.Parameters.AddWithValue("@customergsm2", textBox4.Text);
                command.Parameters.AddWithValue("@customeremail", textBox5.Text);
                command.Parameters.AddWithValue("@customeraddress", textBox9.Text);
                command.Parameters.AddWithValue("@customersector", textBox6.Text);
                command.Parameters.AddWithValue("@customeriban", textBox7.Text);
                command.Parameters.AddWithValue("@customeragent", textBox8.Text);
                command.Parameters.AddWithValue("@customeradddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@customerstatus", "1");
                if (home.carikartturu == 0)
                {
                    command.Parameters.AddWithValue("@type", "0");
                }
                else
                {
                    command.Parameters.AddWithValue("@type", "1");
                }
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
                        MessageBox.Show("Bu cari kart numarası zaten kullanılıyor.", "Sistem Mesajı");
                    }
                    else
                    {
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
                    }
                }
                con.Close();
                this.Controls.Clear();
                this.InitializeComponent();
                csrid.doldurcustomer();
                this.Close();
            }
        }

        private void customeradd_Load(object sender, EventArgs e)
        {
            metroComboBox1.Text = "Müşteri";
        }
    }
}
