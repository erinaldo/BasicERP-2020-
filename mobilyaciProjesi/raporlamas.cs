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
    public partial class raporlamas : Form
    {
        raporlama rprid;
        public raporlamas(raporlama rp)
        {
            InitializeComponent();
            this.rprid = rp;
        }

        private void raporlamas_Load(object sender, EventArgs e)
        {
            metroComboBox1.Text = raporlama.param1;
            metroComboBox2.Text = raporlama.param2;
            metroTextBox1.Text = raporlama.repno;
            metroTextBox2.Text = raporlama.repname;
            if (raporlama.param2 == "Belirli Tarihe Göre")
            {
                dateTimePicker3.Value = Convert.ToDateTime(raporlama.param3);
                dateTimePicker3.Visible = true;
                panel1.Visible = true;
            }
            else if (raporlama.param2 == "Belirtilen İki Tarih Aralığına Göre")
            {
                dateTimePicker1.Value = Convert.ToDateTime(raporlama.param3);
                dateTimePicker1.Visible = true;
                dateTimePicker2.Value = Convert.ToDateTime(raporlama.param4);
                dateTimePicker2.Visible = true;
                panel1.Visible = true;
            }
            else if (raporlama.param2 == "Son X Günlük")
            {
                textBox1.Text = raporlama.param3;
            }
            else
            {
                textBox2.Text = raporlama.param3;
            }
        }
        programLog prlg;
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult c;
            c = MessageBox.Show("Güncellemek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
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

                SqlCommand command = new SqlCommand("update report_list set rep_no=@repno,rep_name=@repname,param1=@param1,param2=@param2,param3=@param3,param4=@param4, user_id=@userid, edit_date=@editdate where rep_id = '" + raporlama.repid + "'", con);
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

                command.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@userid", login.userid);
                command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd"));

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

                con.Close();
                rprid.doldurreport();
                this.Close();
            }
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //panel1.Visible = true;
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
    }
}
