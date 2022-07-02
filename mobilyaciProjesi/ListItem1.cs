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
using System.Windows.Forms.DataVisualization.Charting;

namespace mobilyaciProjesi
{
    public partial class ListItem1 : UserControl
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        public ListItem1()
        {
            InitializeComponent();
        }


        //public static string renk = "";


        #region Properties


        private string _tarih;
        private string _adi;
        private string _birimi;
        private double _miktar;
        private string _slipid;
        private string _rengi;
        //private Image _icon;

        [Category("Custom Props")]
        public string Tarih
        {
            get { return _tarih; }
            set { _tarih = value; label1.Text = value + " Gün Sonra"; }
        }

        [Category("Custom Props")]
        public string Adi
        {
            get { return _adi; }
            set { _adi = value; label2.Text = value; }
        }
        [Category("Custom Props")]
        public string Birimi
        {
            get { return _birimi; }
            set { _birimi = value; label5.Text = value; }
        }

        public double Miktar
        {
            get { return _miktar; }
            set { _miktar = value; label4.Text = value.ToString() + "  " + Birimi; }
        }

        public string SlipId
        {
            get { return _slipid; }
            set { _slipid = value; label6.Text = value; }
        }

        public string Rengi
        {
            get { return _rengi; }
            set { _rengi = value; label7.Text = value; }
        }


        #endregion

        public static string slipid = "";
        public static string customername = "";
        public static string birim = "";
        public static string type = "";

        programLog prlg;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT admin_status FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string admin_status = "";
            con.Open();
            try
            {
                admin_status = command2.ExecuteScalar().ToString();
                if (admin_status == "1")
                {
                    slipid = label6.Text;
                    customername = label2.Text;
                    birim = label5.Text;
                    type = label7.Text;
                    checkdetay cd = new checkdetay();
                    cd.Show();
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG1"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı"); }
            //PROGRAMLOG

        }

        private void ListItem1_MouseHover(object sender, EventArgs e)
        {
            over();
        }

        void over()
        {
            pictureBox1.Location = new Point(14, 45);
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            over();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            over();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            over();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            over();
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            over();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(-39, 45);
        }

        private void ListItem1_Load(object sender, EventArgs e)
        {
            if (label7.Text == "Red")
            {
                this.BackColor = Color.FromArgb(255, 252, 114, 104);
            }
            else
            {
                this.BackColor = Color.FromArgb(255, 37, 150, 190);
            }

        }

        
        public void homeguncelleme()
        {
            
        }
    }
}
