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
    public partial class ListItem2 : UserControl
    {
        public ListItem2()
        {
            InitializeComponent();
        }
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";


        void comboBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }

        programLog prlg;
        //public string materialid = "";
        private void ListItem2_Load(object sender, EventArgs e)
        {
            //comboBox1.Text = "Adet";
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox1.MouseWheel += new MouseEventHandler(comboBox1_MouseWheel);
            //comboBox2.Text = stocks.stockbirim;

            string query = "SELECT den_name FROM tbl_denomination where den_no = '" + comboBox2.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds, "den_name");
                comboBox2.DisplayMember = "den_name";
                comboBox2.ValueMember = "den_name";
                comboBox2.DataSource = ds.Tables["den_name"];
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, "ListItem2", "PRLG1");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
            }
            
            
            degistirr();
            comboBox1.Text = _isim;
            comboBox2.Text = _birim;
            //if (_isim == null)
            //{
            //    
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }



        #region Properties
        private string _isim;
        private string _miktar;
        private string _birim;
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                                                    
        /// <summary>
        ///VERİTABANINDAN KAYIT ÇEKEN KOD vvvvvvvvvvvvvvvvv ///////////////////////
        /// </summary>

        [Category("CustomProps")]
        public string Isim2
        {
            get
            {
                return _isim;
            }
            set
            {
                _isim = value;
                comboBox1.Text = value;
            }
        }
        [Category("CustomProps")]
        public string Miktar2
        {
            get
            {
                return _miktar;
            }
            set
            {
                _miktar = value;
                textBox1.Text = value;
            }
        }
        [Category("CustomProps")]
        public string Birim2
        {
            get
            {
                return _birim;
            }
            set
            {
                _birim = value;
                comboBox2.Text = value;
            }
        }

        /// <summary>
        ///VERİTABANINDAN KAYIT ÇEKEN KOD ^^^^^^^^^^^^^^^^^^ /////////////////////////////////////////
        /// </summary>
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                                                    
        /// <summary>
        ///VERİTABANINA KAYIT EDEN KOD vvvvvvvvvvvvvvvvv ///////////////////////
        /// </summary>
        //[Category("CustomProps")]
        public string Isim
        {

            get { return comboBox1.Text; }
            set { comboBox1.Text = value; }
        }

        //[Category("CustomProps")]
        public string Miktar
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        //[Category("CustomProps")]
        public string Birim
        {
            get { return comboBox2.Text; }
            set { comboBox2.Text = value; }
        }


        /// <summary>
        ///VERİTABANINA KAYIT EDEN KOD ^^^^^^^^^^^^^^^^^^ /////////////////////////////////////////
        /// </summary>
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////   


        #endregion

        void degistirr()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            con.Open();
            string query1 = "select material_name from tbl_material where not material_name = '" + stock.stockname + "' and delete_status = '0' ";
            SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
            DataSet ds1 = new DataSet();

            try
            {
                da1.Fill(ds1, "material_name");
                comboBox1.DisplayMember = "material_name";
                comboBox1.ValueMember = "material_name";
                comboBox1.DataSource = ds1.Tables["material_name"];
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, "ListItem2", "PRLG2");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
            }
            
            con.Close();
        }


        void degistir()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string query = "SELECT tbl_denomination.den_name FROM tbl_denomination INNER JOIN tbl_material ON tbl_denomination.den_id = tbl_material.material_den_id where tbl_material.material_name = '" + comboBox1.Text + "' and tbl_material.delete_status = '0'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "den_name");
                comboBox2.DisplayMember = "den_name";
                comboBox2.ValueMember = "den_name";
                comboBox2.DataSource = ds.Tables["den_name"];
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, "ListItem2", "PRLG3");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
            }
            
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            degistir();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }


    }
}
