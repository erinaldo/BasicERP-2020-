using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobilyaciProjesi
{
    public partial class login : Form
    {
        mobilyaciEntities1 dbo = new mobilyaciEntities1();
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";
        public static int yetkisi;
        public static string userid;
        string imgUrl = null;

        public login()
        {
            InitializeComponent();
        }

        SqlConnection con;

        SqlCommand cmd;

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
            }
            else
            {
                if (textBox2.Text == "")
                {
                    textBox2.ForeColor = System.Drawing.Color.DimGray;
                    textBox2.Text = "Şifre";
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
            }
            else
            {
                if (textBox1.Text == "")
                {
                    textBox1.ForeColor = System.Drawing.Color.DimGray;
                    textBox1.Text = "Kullanıcı Adı";
                }
            }
        }

        programLog prlg;
        private void login_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select * from tbl_user", con);
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

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }

        void userlog()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            SqlCommand command5 = new SqlCommand("Insert Into tbl_userlog(user_id,form_name,islem,log_date) Values (@userid,@formname,@islem, @logdate)", con);
            command5.Parameters.AddWithValue("@userid", login.userid);
            command5.Parameters.AddWithValue("@formname", this.Text);
            command5.Parameters.AddWithValue("@islem", button1.Text);
            command5.Parameters.AddWithValue("@logdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            con.Open();
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
            con.Close();
        }
        void giriskodu()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            con.Open();

            command.CommandText = "select * from tbl_user where user_name = '" + textBox1.Text + "' and user_password = '" + textBox2.Text + "' and user_status = '1'";


            try
            {
                SqlDataReader reader = command.ExecuteReader();
                int sayi = 0;
                while (reader.Read())
                {
                    sayi++;
                }

                if (sayi == 1)
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter adtr = new SqlDataAdapter("Select * from tbl_user", con);

                    int rowindex = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        if (row.Cells["user_name"].Value.ToString() == textBox1.Text)
                        {
                            rowindex = row.Index;
                            break;
                        }
                    }

                    DataGridViewRow selectedRow = new DataGridViewRow();
                    selectedRow = dataGridView1.Rows[rowindex];

                    string kullaniciadi = selectedRow.Cells[3].Value.ToString();
                    AutoClosingMessageBox.Show("Sayın " + kullaniciadi + " hoşgeldiniz. Giriş işlemi yapılıyor..", "Sistem Mesajı", 2000);
                    userid = selectedRow.Cells[0].Value.ToString();
                    userlog();
                    home ho = new home();
                    ho.Show();
                    //if (selectedRow.Cells[4].Value.ToString() == "0")
                    //{
                    //    yetkisi = 0;
                    //    
                    //}
                    //else if (selectedRow.Cells[4].Value.ToString() == "1")
                    //{
                    //    yetkisi = 1;
                    //    userid = selectedRow.Cells[0].Value.ToString();
                    //    userlog();
                    //    home ho = new home();
                    //    ho.Show();
                    //}
                    //else if (selectedRow.Cells[4].Value.ToString() == "2")
                    //{
                    //    yetkisi = 2;
                    //    userid = selectedRow.Cells[0].Value.ToString();
                    //    userlog();
                    //    home ho = new home();
                    //    ho.Show();
                    //}
                    this.Hide();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya parola hatalı", "Notice");
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            giriskodu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "mmt";
            textBox2.Text = "123";
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                giriskodu();
            }
        }

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                giriskodu();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                giriskodu();
            }
        }
    }
}
