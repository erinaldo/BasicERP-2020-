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
    public partial class reportparameters : Form
    {
        raporlama rprid;
        public reportparameters(raporlama rp)
        {
            InitializeComponent();
            this.rprid = rp;
        }

        private void reportparameters_Load(object sender, EventArgs e)
        {
            metroComboBox1.Text = "Tahsilat Raporu";
            metroComboBox2.Text = "Belirli Tarihe Göre";
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            label1.Text = metroComboBox2.Text;
            if (metroComboBox2.Text == "Belirli Tarihe Göre")
            {
                dateTimePicker3.Visible = true;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                metroLabel3.Visible = false;
            }
            else if (metroComboBox2.Text == "Belirtilen İki Tarih Aralığına Göre")
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                metroLabel3.Visible = false;
            }
            else if (metroComboBox2.Text == "Son X Günlük")
            {
                textBox1.Visible = true;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;
                textBox2.Visible = false;
                metroLabel3.Text = "Gün Sayısı: ";
                metroLabel3.Visible = true;
            }
            else
            {
                textBox2.Visible = true;
                textBox1.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;
                metroLabel3.Text = "İsim: ";
                metroLabel3.Visible = true;
            }
        }
        programLog prlg;
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DateTime dt = DateTime.Now;

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
                prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
            }

            SqlCommand command = new SqlCommand("Insert Into report_list(rep_no, rep_name, param1, param2, param3, param4, insert_date, user_id, edit_date) " +
                "Values (@repno, @repname, @param1 ,@param2,@param3,@param4,@insertdate,@userid,@editdate)", con);
            command.Parameters.AddWithValue("@repno", metroTextBox1.Text);
            command.Parameters.AddWithValue("@repname", metroTextBox2.Text);
            command.Parameters.AddWithValue("@param1", metroComboBox1.Text);
            command.Parameters.AddWithValue("@param2", metroComboBox2.Text);
            if (metroComboBox2.Text == "Belirli Tarihe Göre")
            {
                command.Parameters.AddWithValue("@param3", dateTimePicker3.Value.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@param4", "");
            }
            else if (metroComboBox2.Text == "Belirtilen İki Tarih Aralığına Göre")
            {
                command.Parameters.AddWithValue("@param3", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@param4", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            }
            else if (metroComboBox2.Text == "Son X Günlük")
            {
                command.Parameters.AddWithValue("@param3", textBox1.Text);
                command.Parameters.AddWithValue("@param4", "");
            }
            else
            {
                command.Parameters.AddWithValue("@param3", textBox2.Text);
                command.Parameters.AddWithValue("@param4", "");
            }
            command.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
            rprid.doldurreport();
            this.Close();

        }
    }
}
