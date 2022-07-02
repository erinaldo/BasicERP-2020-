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
    public partial class stocks : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        stock strid;
        public stocks(stock st)
        {
            InitializeComponent();
            this.strid = st;
        }

        private void button3_Click(object sender, EventArgs e)//CLOSE BUTONU
        {
            this.Close();
        }
        //public static 
        private void populateItems()//Materyalleri getiren fonksiyon
        {
            int listitemsayisi = Convert.ToInt32(dataGridView1.Rows.Count.ToString()) - 1;

            ListItem2[] listItems = new ListItem2[listitemsayisi];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem2();

                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                con.Open();
                string sqlquery1 = "SELECT tbl_material.material_name FROM tbl_material INNER JOIN tbl_manufacture ON tbl_material.material_id = tbl_manufacture.material_id where tbl_material.material_id = '" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "'";
                SqlCommand command3 = new SqlCommand(sqlquery1, con);
                string materialname = "";
                try { materialname = command3.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG1"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı"); }
                //PROGRAMLOG

                con.Close();

                listItems[i].Isim2 = materialname;
                listItems[i].Miktar2 = dataGridView1.Rows[i].Cells[3].Value.ToString();


                con.Open();
                string sqlquery2 = "SELECT tbl_denomination.den_name  FROM tbl_denomination  INNER JOIN tbl_manufacture ON tbl_denomination.den_id = tbl_manufacture.den_id  where tbl_manufacture.den_id = '" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "'";
                SqlCommand command4 = new SqlCommand(sqlquery2, con);
                string materialden = "";
                try {materialden = command4.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG2"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı"); }
                //PROGRAMLOG

                con.Close();


                listItems[i].Birim2 = materialden;

                if (flowLayoutPanel1.Controls.Count > -1)
                {
                    flowLayoutPanel1.Controls.Add(listItems[i]);
                }
                else
                {
                    flowLayoutPanel1.Controls.Clear();
                }
            }
        }

        private void poopulateItems()//GİDERLERİ getiren fonksiyon
        {
            int listitemsayisi = Convert.ToInt32(dataGridView4.Rows.Count.ToString()) - 1;

            ListItem2_2[] listItems = new ListItem2_2[listitemsayisi];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem2_2();

                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                con.Open();
                string sqlquery1 = "SELECT expenses.exp_name FROM expenses INNER JOIN other_expenses ON expenses.exp_id = other_expenses.exp_id where expenses.exp_id = '" + dataGridView4.Rows[i].Cells[0].Value.ToString() + "'";
                SqlCommand command3 = new SqlCommand(sqlquery1, con);
                string materialname = "";
                try { materialname = command3.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG3"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı"); }
                //PROGRAMLOG
                con.Close();
                listItems[i].Isim2 = materialname;
                listItems[i].Miktar2 = dataGridView4.Rows[i].Cells[2].Value.ToString();


                con.Open();
                string sqlquery2 = "SELECT tbl_denomination.den_name  " +
                                   "FROM tbl_denomination  " +
                                   "INNER JOIN expenses " +
                                   "ON tbl_denomination.den_id = expenses.den_id  " +
                                   "where expenses.den_id = '" + dataGridView4.Rows[i].Cells[1].Value.ToString() + "'";
                SqlCommand command4 = new SqlCommand(sqlquery2, con);
                string materialden = "";
                try { materialden = command4.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG4"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı"); }
                //PROGRAMLOG

                con.Close();


                listItems[i].Birim2 = materialden;

                if (flowLayoutPanel2.Controls.Count > -1)
                {
                    flowLayoutPanel2.Controls.Add(listItems[i]);
                }
                else
                {
                    flowLayoutPanel2.Controls.Clear();
                }
            }
        }

        private void stocks_Load(object sender, EventArgs e)//LOAD
        {
            
            if (stock.labelname == "Stok Listesi")
            {
                checkBox2.Visible = false;
                label1.Text = "Stok İşlem Paneli";
                stokdata();
                manufacturedoldur();
                populateItems();
                giderdoldur();
                poopulateItems();

                stocks.stockno = stock.stockno;
                stocks.stockname = stock.stockname;
                stocks.stockbarkod = stock.stockbarkod;
                stocks.stockbirim = stock.stockbirim;
                stocks.stockdescription = stock.stockdescription;
                stocks.stockstatus = stock.stockstatus;
                stocks.stockmaterial = stock.stockmaterial;
                if (stock.stockmaterial == "1")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
            }
            else
            {
                checkBox2.Visible = true;
                pictureBox3.Visible = false;
                if (stock.materialsellable == "1")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                    metroTabControl1.Enabled = false;
                }
                label1.Text = "Materyal İşlem Paneli";
                materyaldata();

                button2.Text = "Materyal Güncelle";
                metroTabControl1.Visible = false;
                textBox6.Location = new Point(227, 43);
                pictureBox1.Location = new Point(120, 147);
                button7.Location = new Point(120, 310);
                checkBox2.Location = new Point(172, 361);
                checkBox1.Location = new Point(191, 387);
                pictureBox2.Location = new Point(212, 412);

                this.Size = new Size(460, 614);
                button2.Location = new Point(0, 453);
                button3.Location = new Point(135, 535);
                button4.Location = new Point(42, 496);

                button2.Size = new Size(444, 37);
                button3.Size = new Size(172, 33);
                button4.Size = new Size(365, 33);
                stocks.materialno = stock.materialno;
                stocks.materialname = stock.materialname;
                stocks.materialbarkod = stock.materialbarkod;
                stocks.materialbirim = stock.materialbirim;
                stocks.materialdescription = stock.materialdescription;
                stocks.materialstatus = stock.materialstatus;
                stocks.materialsellable = stock.materialsellable;
                //stocks.img1 = stock.img;
            }

            panel1.Enabled = false;
            panel3.Enabled = false;



            

            baslangicinaktif();
            combo1veridoldur();
            veridoldur();


            this.flowLayoutPanel1.AutoScroll = true;

            //if (stock.labelname == "Materyaller Listesi")
            //{
            //    SqlConnection con = new SqlConnection(connectionstring);
            //
            //    string sqlquer1 = "SELECT material_sellable FROM tbl_material where material_no = '" + textBox1.Text + "'";
            //    SqlCommand command2 = new SqlCommand(sqlquer1, con);
            //    string result = "";
            //    con.Open();
            //    result = (command2.ExecuteScalar() ?? "").ToString();
            //    object kontrol = command2.ExecuteScalar();
            //    if (kontrol.ToString() == "1")
            //    {
            //        result = kontrol.ToString();
            //        textBox4.Visible = false;
            //    }
            //    else
            //    {
            //        kontrol = "";
            //    }
            //    con.Close();
            //}

            if (stock.nullimage == false)
            {
                pictureBox1.Image = stock.img;
            }
            else
            {
                pictureBox1.Image = mobilyaciProjesi.Properties.Resources.sil;
            }

            pictureBox4.Image = stock.img;
        }

        void manufacturedoldur()//İmalat malzemelerini getiren fonksiyon
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sorgu = "select * from tbl_manufacture where stock_id = '" + stock.stockid + "'";
            con.Open();
            SqlDataAdapter getir1 = new SqlDataAdapter(sorgu, con);
            DataSet goster1 = new DataSet();
            try
            {
                getir1.Fill(goster1, "tbl_manufacture");
                dataGridView1.DataSource = goster1.Tables["tbl_manufacture"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                getir1.Dispose();
                this.dataGridView1.Columns["man_id"].Visible = false;
                this.dataGridView1.Columns["stock_id"].Visible = false;
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG5");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı");
            }
            con.Close();

        }

        void giderdoldur()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sorgu = "select exp_id, den_id, exp_amount from other_expenses where stock_id = '" + stock.stockid + "'";
            con.Open();
            SqlDataAdapter getir1 = new SqlDataAdapter(sorgu, con);
            DataSet goster1 = new DataSet();
            try
            {
                getir1.Fill(goster1, "other_expenses");
                dataGridView4.DataSource = goster1.Tables["other_expenses"];
                dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                getir1.Dispose();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG6");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı");
            }
            con.Close();
        }

        void combo1veridoldur()//Birimleri Getiren fonksiyon
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            string query = "select den_name from tbl_denomination";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            con.Open();
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds, "den_name");
                comboBox1.DisplayMember = "den_name";
                comboBox1.ValueMember = "den_name";
                comboBox1.DataSource = ds.Tables["den_name"];
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG7");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG7", "Sistem Mesajı");
            }
            con.Close();
        }

        void baslangicinaktif()//Load esnasında tool inaktifleştirme
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            comboBox1.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            //button5.Enabled = false;
            //flowLayoutPanel1.Enabled = false;
            panel1.Enabled = false;
            panel3.Enabled = false;
        }

        void veridoldur()//Textboxlara Veri Doldurma İşlemi
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            if (stock.labelname == "Stok Listesi")
            {
                textBox1.Text = stock.stockno;
                textBox2.Text = stock.stockname;
                textBox3.Text = stock.stockbarkod;
                //textBox4.Text = stock.stockmiktar;

                string sqlquery4 = "SELECT den_name FROM tbl_denomination where den_id = '" + stock.stockbirim + "'";
                SqlCommand command4 = new SqlCommand(sqlquery4, con);
                con.Open();
                try
                {
                    object nullableValue5 = command4.ExecuteScalar();
                    comboBox1.Text = nullableValue5.ToString();
                    textBox5.Text = stock.stockfiyat;
                    textBox6.Text = stock.stockdescription;
                    if (stock.stockstatus == "1")
                    {
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        checkBox1.Checked = true;
                    }
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG8");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG8", "Sistem Mesajı");
                }
                con.Close();
            }
            else
            {
                string sqlquery4 = "SELECT den_name FROM tbl_denomination where den_id = '" + stock.materialbirim + "'";
                SqlCommand command4 = new SqlCommand(sqlquery4, con);
                con.Open();
                try
                {
                    object nullableValue5 = command4.ExecuteScalar();
                    comboBox1.Text = nullableValue5.ToString();
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG43");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG43", "Sistem Mesajı");
                }
                textBox1.Text = stock.materialno;
                textBox2.Text = stock.materialname;
                textBox3.Text = stock.materialbarkod;
                //textBox4.Text = stock.materialmiktar;
                //comboBox1.Text = stock.materialbirim;
                textBox5.Text = stock.materialfiyat;
                textBox6.Text = stock.materialdescription;
                if (stock.materialstatus == "1")
                {
                    checkBox1.Checked = false;
                }
                else
                {
                    checkBox1.Checked = true;
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)//Kalem Butonu
        {
            aktiforinaktiftools();
        }

        void aktiforinaktiftools()//aktifleştirme - inaktifleştirme butonu
        {
            if (textBox1.Enabled == false)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                comboBox1.Enabled = true;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                //button5.Enabled = true;
                //flowLayoutPanel1.Enabled = true;
                //flowLayoutPanel2.Enabled = true;

            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                comboBox1.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                //button5.Enabled = false;
                //flowLayoutPanel1.Enabled = false;
                //flowLayoutPanel2.Enabled = false;

            }
        }


        public static double yenideger = 0;
        public static bool containsNegative = true;
        public static string materialno, materialname, materialbarkod, materialbirim, materialdescription, materialstatus, materialsellable;
        public static string stockno, stockname, stockbarkod, stockbirim, stockdescription, stockstatus, stockmaterial;
        public static Image img1;

        public static bool birinci = false;
        public static bool ikinci = false;

        programLog prlg;
        void stokinsertparameters()
        {
            pictureBox1.Image = resizeImage(pictureBox1.Image, new Size(200, 200));
            ImageConverter imgc = new ImageConverter();
            byte[] img = (byte[])imgc.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            con.Open();
            SqlCommand command3 = new SqlCommand("Insert Into tbl_stock(stock_no,stock_name,stock_barkod,stock_amount, stock_den_id, stock_description, stock_add_date, stock_status, stock_material, delete_status, img, user_id, edit_date) " +
                                        "Values (" + "@stockno, @stockname, @stockbarkod,@stockamount,@stockdenid,@stockdescription, @stockadddate, @stockstatus, @stockmaterial,@deletestatus, @img,@userid,@editdate)", con);
            command3.Parameters.AddWithValue("@stockno", textBox1.Text);
            command3.Parameters.AddWithValue("@stockname", textBox2.Text);
            command3.Parameters.AddWithValue("@stockbarkod", textBox3.Text);
            command3.Parameters.AddWithValue("@stockamount", "0");


            string denid2 = "";
            string sqlquery1 = "SELECT den_id from tbl_denomination where den_name = '" + comboBox1.Text + "'";
            SqlCommand command2 = new SqlCommand(sqlquery1, con);
            try { denid2 = command2.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG9"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG9", "Sistem Mesajı"); }
            //PROGRAMLOG



            command3.Parameters.AddWithValue("@stockdenid", denid2.ToString());
            command3.Parameters.AddWithValue("@stockdescription", textBox6.Text);
            command3.Parameters.AddWithValue("@stockadddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            command3.Parameters.AddWithValue("@stockstatus", "1");
            command3.Parameters.AddWithValue("@stockmaterial", "1");
            command3.Parameters.AddWithValue("@deletestatus", "0");
            command3.Parameters.AddWithValue("@img", img);
            command3.Parameters.AddWithValue("@userid", login.userid);
            command3.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            try
            {
                command3.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG11");//PROGRAMLOG
                prlg.databaseinsert();

                if (ex.Number == 2627)
                {
                    string stokname = "";
                    string sqlquery3 = "SELECT stock_name from tbl_stock where stock_no = '" + textBox1.Text + "'";
                    SqlCommand command4 = new SqlCommand(sqlquery3, con);
                    try { stokname = command4.ExecuteScalar().ToString(); } catch (SqlException ex1) { prlg = new programLog(ex1.Message, this.Text, "PRLG10"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG10", "Sistem Mesajı"); }
                    //PROGRAMLOG


                    SqlCommand komut = new SqlCommand();
                    MessageBox.Show("Girilen numara, stok ürünlerinden  " + stokname + " ile eşleşiyor. Lütfen farklı numara girişi yapınız veya yöneticinizle iletişime geçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    previousmateryal();
                }
                else
                {
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG11", "Sistem Mesajı");
                }
            }
            con.Close();
        }
        void stokparameters()
        {
            string sorgu = "";
            if (stock.labelname == "Materyaller Listesi") { sorgu = stock.materialno; }
            else { sorgu = stock.stockno; }

            pictureBox1.Image = resizeImage(pictureBox1.Image, new Size(200, 200));
            ImageConverter imgc = new ImageConverter();
            byte[] img = (byte[])imgc.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));

            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            con.Open();
            SqlCommand command12 = new SqlCommand("update tbl_stock set stock_no=@stockno,stock_name=@stockname,stock_barkod=@stockbarkod," +
                                            "stock_den_id=@stockdenid, stock_price=@stockprice, stock_description=@stockdescription,stock_status=@stockstatus, " +
                                            "img=@img, user_id=@userid, edit_date=@editdate where stock_no = '" + sorgu + "'", con);
            command12.Parameters.AddWithValue("@stockno", textBox1.Text);
            command12.Parameters.AddWithValue("@stockname", textBox2.Text);
            command12.Parameters.AddWithValue("@stockbarkod", textBox3.Text);
            command12.Parameters.AddWithValue("@stockprice", textBox5.Text);
            command12.Parameters.AddWithValue("@stockdescription", textBox6.Text);

            string sqlquery8 = "SELECT den_id FROM tbl_denomination where den_name = '" + comboBox1.Text + "'";
            SqlCommand command13 = new SqlCommand(sqlquery8, con);
            string denid = "";
            try { denid = command13.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG12"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG12", "Sistem Mesajı"); }
            //PROGRAMLOG

            command12.Parameters.AddWithValue("@stockdenid", denid);

            if (checkBox1.Checked == true) { command12.Parameters.AddWithValue("@stockstatus", "0"); }
            else if (checkBox1.Checked == false) { command12.Parameters.AddWithValue("@stockstatus", "1"); }
            command12.Parameters.AddWithValue("@img", img);
            command12.Parameters.AddWithValue("@userid", login.userid);
            command12.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            try
            {
                command12.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG14");//PROGRAMLOG
                prlg.databaseinsert();

                if (ex.Number == 2627)
                {
                    string stokname = "";
                    string sqlquery3 = "SELECT stock_name from tbl_stock where stock_no = '" + textBox1.Text + "'";
                    SqlCommand command4 = new SqlCommand(sqlquery3, con);
                    try { stokname = command4.ExecuteScalar().ToString(); } catch (SqlException ex1) { prlg = new programLog(ex1.Message, this.Text, "PRLG13"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG13", "Sistem Mesajı"); }
                    //PROGRAMLOG


                    MessageBox.Show("Girilen numara, stok ürünlerinden " + stokname + " ile eşleşiyor. Lütfen farklı numara girişi yapınız veya yöneticinizle iletişime geçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    birinci = true;
                    if (stock.labelname == "Materyaller Listesi")
                    {
                        previousmateryal();//STOCK-MATERYAL GÜNCELLENİRKEN STOCK PRİMARY PATLARSA MATERYALİ ÖNCEKİ KAYDA GERİ ALIYOR. STOCK ZATEN GÜNCELLENMİYOR.
                    }
                }
                else
                {
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG14", "Sistem Mesajı");
                }
            }
            con.Close();
        }
        public static bool durdur;
        void materyalparameters()
        {
            string sorgu = "";
            if (stock.labelname == "Stok Listesi") { sorgu = stock.stockno; }
            else { sorgu = stock.materialno; }

            pictureBox1.Image = resizeImage(pictureBox1.Image, new Size(200, 200));
            ImageConverter imgc = new ImageConverter();
            byte[] img = (byte[])imgc.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            con.Open();
            SqlCommand command = new SqlCommand("update tbl_material set material_no=@materialno,material_name=@materialname,material_barkod=@materialbarkod," +
                                             "material_den_id=@materialdenid, material_price=@materialprice, material_description=@materialdescription,material_status=@materialstatus, material_sellable=@materialsellable, img=@img, user_id=@userid, edit_date=@editdate where material_nO = '" + sorgu + "'", con);
            command.Parameters.AddWithValue("@materialno", textBox1.Text);
            command.Parameters.AddWithValue("@materialname", textBox2.Text);
            command.Parameters.AddWithValue("@materialbarkod", textBox3.Text);
            command.Parameters.AddWithValue("@materialprice", textBox5.Text);
            command.Parameters.AddWithValue("@materialdescription", textBox6.Text);

            string sqlquery = "SELECT den_id FROM tbl_denomination where den_name = '" + comboBox1.Text + "'";
            SqlCommand command1 = new SqlCommand(sqlquery, con);
            string denid = "";
            try { denid = command1.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG15"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG15", "Sistem Mesajı"); }
            //PROGRAMLOG


            command.Parameters.AddWithValue("@materialdenid", denid);
            if (checkBox1.Checked == true) { command.Parameters.AddWithValue("@materialstatus", "0"); }
            else if (checkBox1.Checked == false) { command.Parameters.AddWithValue("@materialstatus", "1"); }

            if (checkBox2.Checked == true) { command.Parameters.AddWithValue("@materialsellable", "1"); }
            else if (checkBox2.Checked == false) { command.Parameters.AddWithValue("@materialsellable", "0"); }
            command.Parameters.AddWithValue("@img", img);
            command.Parameters.AddWithValue("@userid", login.userid);
            command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            try
            {
                command.ExecuteNonQuery();
                durdur = false;

            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG17");//PROGRAMLOG
                prlg.databaseinsert();

                if (ex.Number == 2627)
                {
                    string materialname = "";
                    string sqlquery3 = "SELECT material_name from tbl_material where material_no = '" + textBox1.Text + "'";
                    SqlCommand command4 = new SqlCommand(sqlquery3, con);
                    try { materialname = command4.ExecuteScalar().ToString(); } catch (SqlException ex1) { prlg = new programLog(ex1.Message, this.Text, "PRLG16"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG16", "Sistem Mesajı"); }
                    //PROGRAMLOG


                    MessageBox.Show("Girilen numara, materyallerden " + materialname + " ile eşleşiyor. Lütfen farklı numara girişi yapınız veya yöneticinizle iletişime geçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    ikinci = true;
                    durdur = true;
                    previousstok();
                }
                else
                {
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG17", "Sistem Mesajı");
                }
            }
            con.Close();
        }

        void previousmateryal()//BU 2 BAŞVURUNUN 1.Sİ İNSERT İŞLEMİ İÇİN 2.Sİ UPDATE İŞLEMİ İÇİN
        {
            pictureBox4.Image = resizeImage(pictureBox4.Image, new Size(200, 200));
            ImageConverter imgc = new ImageConverter();
            byte[] img = (byte[])imgc.ConvertTo(pictureBox4.Image, Type.GetType("System.Byte[]"));
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            con.Open();
            SqlCommand command = new SqlCommand("update tbl_material set material_no=@materialno,material_name=@materialname,material_barkod=@materialbarkod," +
                                             "material_den_id=@materialdenid, material_description=@materialdescription,material_status=@materialstatus, material_sellable=@materialsellable, img=@img, user_id=@userid, edit_date=@editdate where material_no = '" + textBox1.Text + "'", con);
            command.Parameters.AddWithValue("@materialno", materialno);
            command.Parameters.AddWithValue("@materialname", materialname);
            command.Parameters.AddWithValue("@materialbarkod", materialbarkod);
            command.Parameters.AddWithValue("@materialdescription", materialdescription);

            //string sqlquery = "SELECT den_id FROM tbl_denomination where den_name = '" + comboBox1.Text + "'";
            //SqlCommand command1 = new SqlCommand(sqlquery, con);
            //string denid = "";
            //denid = command1.ExecuteScalar().ToString();

            command.Parameters.AddWithValue("@materialdenid", materialbirim);
            command.Parameters.AddWithValue("@materialstatus", materialstatus);
            command.Parameters.AddWithValue("@materialsellable", materialsellable);

            command.Parameters.AddWithValue("@img", img);
            command.Parameters.AddWithValue("@userid", login.userid);
            command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG18");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG18", "Sistem Mesajı");
            }
            con.Close();
        }

        void previousstok()
        {
            if (birinci == false && ikinci == false)
            {
                pictureBox4.Image = resizeImage(pictureBox4.Image, new Size(200, 200));
                ImageConverter imgc = new ImageConverter();
                byte[] img = (byte[])imgc.ConvertTo(pictureBox4.Image, Type.GetType("System.Byte[]"));
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                con.Open();
                SqlCommand command12 = new SqlCommand("update tbl_stock set stock_no=@stockno,stock_name=@stockname,stock_barkod=@stockbarkod," +
                                                "stock_den_id=@stockdenid, stock_description=@stockdescription,stock_status=@stockstatus,stock_material=@stockmaterial, img=@img, user_id=@userid, edit_date=@editdate where stock_no = '" + textBox1.Text + "'", con);
                command12.Parameters.AddWithValue("@stockno", stockno);
                command12.Parameters.AddWithValue("@stockname", stockname);
                command12.Parameters.AddWithValue("@stockbarkod", stockbarkod);
                command12.Parameters.AddWithValue("@stockdescription", stockdescription);
                command12.Parameters.AddWithValue("@stockdenid", stockbirim);
                command12.Parameters.AddWithValue("@stockstatus", stockstatus);

                command12.Parameters.AddWithValue("@img", img);
                command12.Parameters.AddWithValue("@userid", login.userid);
                command12.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                try
                {
                    command12.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG19");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG19", "Sistem Mesajı");
                }
                con.Close();
            }
        }

        void materyaleksilt()//Materyal eksilten kod
        {

        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        void checkBox2_CheckedChanged()//stokmateryal checkbox ayarı
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            SqlCommand komut = new SqlCommand();
            con.Open();
            komut.Connection = con;
            komut.CommandText = "update tbl_stock set stock_status = '0' where stock_no= '" + stock.materialno + "'";
            try
            {
                komut.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG20");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG20", "Sistem Mesajı");
            }
            komut.Dispose();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)//Güncelleme Butonu
        {
            if (textBox1.Enabled == true || panel1.Enabled == true)
            {
                DialogResult c;
                c = MessageBox.Show("Güncellemek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (c == DialogResult.Yes)
                {
                    pictureBox1.Image = resizeImage(pictureBox1.Image, new Size(200, 200));
                    ImageConverter imgc = new ImageConverter();
                    byte[] img = (byte[])imgc.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));

                    if (label1.Text == "Stok İşlem Paneli") //STOK GÜNCELLEME İŞLEMİ
                    {
                        SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                        if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "" || comboBox1.Text == "" || textBox1.Text == "Stok No" || textBox2.Text == "Stok Adı" || textBox3.Text == "Barkod" || textBox4.Text == "Stok Miktarı" || textBox6.Text == "Ürün Açıklaması")
                        {
                            MessageBox.Show("Lütfen ekrandaki parametreleri doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            con.Open();
                            SqlCommand command12 = new SqlCommand("Insert Into tbl_userlog(user_id,form_name,islem,log_date) Values (@userid,@formname,@islem, @logdate)", con);
                            command12.Parameters.AddWithValue("@userid", login.userid);
                            command12.Parameters.AddWithValue("@formname", this.Text);
                            command12.Parameters.AddWithValue("@islem", button2.Text);
                            command12.Parameters.AddWithValue("@logdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            try
                            {
                                command12.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                prlg = new programLog(ex.Message, this.Text, "PRLG40");//PROGRAMLOG
                                prlg.databaseinsert();
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG40", "Sistem Mesajı");
                            }
                            string sqlquery1 = "SELECT stock_id FROM tbl_stock where stock_no = '" + stock.stockno + "'";
                            SqlCommand command1 = new SqlCommand(sqlquery1, con);
                            try
                            {
                                string stockid = command1.ExecuteScalar().ToString();
                                SqlCommand command2 = new SqlCommand("delete from tbl_manufacture where stock_id = '" + stockid + "'", con);
                                try { command2.ExecuteNonQuery(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG21"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG21", "Sistem Mesajı"); }
                                //PROGRAMLOG


                                SqlCommand command3 = new SqlCommand("delete from other_expenses where stock_id = '" + stockid + "'", con);
                                try { command3.ExecuteNonQuery(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG22"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG22", "Sistem Mesajı"); }
                                //PROGRAMLOG

                            }

                            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG23"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG23", "Sistem Mesajı"); }
                            //PROGRAMLOG




                            int listitemsayisi = flowLayoutPanel1.Controls.Count;
                            int listitemsayisi2 = flowLayoutPanel2.Controls.Count;

                            if (listitemsayisi >= 0)
                            {
                                ListItem2[] listItems = new ListItem2[listitemsayisi];
                                for (int i = 4; i < listItems.Length; i++)
                                {
                                    listItems[i] = (ListItem2)flowLayoutPanel1.Controls[i];
                                    SqlCommand command4 = new SqlCommand("Insert Into tbl_manufacture(stock_id,material_id, material_amount, den_id) " +
                                    "Values (" + "@stockid, @materialid,@materialamountt,@denid)", con);

                                    string sqlquery2 = "SELECT stock_id FROM tbl_stock where stock_no = '" + stock.stockno + "'";
                                    SqlCommand command5 = new SqlCommand(sqlquery2, con);
                                    string stockid1 = "";
                                    stockid1 = command5.ExecuteScalar().ToString();
                                    command4.Parameters.AddWithValue("@stockid", stockid1);

                                    string sqlquery3 = "SELECT material_id FROM tbl_material where material_name = '" + listItems[i].Isim.ToString() + "'";
                                    SqlCommand command6 = new SqlCommand(sqlquery3, con);
                                    string materialid = "";
                                    materialid = command6.ExecuteScalar().ToString();
                                    command4.Parameters.AddWithValue("@materialid", materialid);
                                    command4.Parameters.AddWithValue("@materialamountt", listItems[i].Miktar.ToString());

                                    string sqlquery4 = "SELECT den_id FROM tbl_denomination where den_name = '" + listItems[i].Birim.ToString() + "'";
                                    SqlCommand command7 = new SqlCommand(sqlquery4, con);
                                    string denid1 = "";
                                    denid1 = command7.ExecuteScalar().ToString();
                                    command4.Parameters.AddWithValue("@denid", denid1);


                                    try
                                    {
                                        command4.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        prlg = new programLog(ex.Message, this.Text, "Butonsuz işlem. HAMMADDE LİSTESİ İŞLEMİ");//PROGRAMLOG
                                        prlg.databaseinsert();

                                        if (ex.Number == 2627)
                                        {
                                            MessageBox.Show("Bilinmeyen bir hata meydana geldi, lütfen yöneticinizle iletişime geçiniz.", "Sistem Mesajı");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Bilinmeyen bir hata meydana geldi, lütfen yöneticinizle iletişime geçiniz.", "Sistem Mesajı");
                                        }
                                    }
                                }
                            }// FİRST PENCERE VERİLERİ

                            if (listitemsayisi2 >= 0)
                            {
                                ListItem2_2[] listItems1 = new ListItem2_2[listitemsayisi2];
                                for (int i = 4; i < listItems1.Length; i++)
                                {
                                    listItems1[i] = (ListItem2_2)flowLayoutPanel2.Controls[i];
                                    SqlCommand command8 = new SqlCommand("Insert Into other_expenses(stock_id,exp_id,exp_amount,den_id,oth_add_date,insert_date) " +
                                        "Values (@stockid, @expid, @expamount,@denid,@othadddate,@insertdate)", con);

                                    string stockid1 = "";
                                    string sqlquery5 = "SELECT stock_id from tbl_stock where stock_no = '" + stock.stockno + "'";
                                    SqlCommand command9 = new SqlCommand(sqlquery5, con);
                                    stockid1 = command9.ExecuteScalar().ToString();
                                    command8.Parameters.AddWithValue("@stockid", stockid1.ToString());


                                    string expid = "";
                                    string sqlquery6 = "SELECT exp_id from expenses where exp_name = '" + listItems1[i].Isim.ToString() + "'";
                                    SqlCommand command10 = new SqlCommand(sqlquery6, con);
                                    expid = command10.ExecuteScalar().ToString();
                                    command8.Parameters.AddWithValue("@expid", expid.ToString());
                                    command8.Parameters.AddWithValue("@expamount", listItems1[i].Miktar.ToString());

                                    string denid1 = "";
                                    string sqlquery7 = "SELECT den_id from tbl_denomination where den_name = '" + listItems1[i].Birim.ToString() + "'";
                                    SqlCommand command11 = new SqlCommand(sqlquery7, con);
                                    denid1 = command11.ExecuteScalar().ToString();
                                    command8.Parameters.AddWithValue("@denid", denid1.ToString());

                                    command8.Parameters.AddWithValue("@othadddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    command8.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                    try
                                    {
                                        command8.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        prlg = new programLog(ex.Message, this.Text, "Butonsuz işlem. GİDER LİSTESİ İŞLEMİ");//PROGRAMLOG
                                        prlg.databaseinsert();

                                        if (ex.Number == 2627)
                                        {
                                            MessageBox.Show("Bilinmeyen bir hata meydana geldi, lütfen yöneticinizle iletişime geçiniz.", "Sistem Mesajı");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Bilinmeyen bir hata meydana geldi, lütfen yöneticinizle iletişime geçiniz.", "Sistem Mesajı");
                                        }
                                    }
                                }
                            }// SECOND PENCERE VERİLERİ

                            stokparameters();//UPDATESTOCK

                            if (stock.stockmaterial == "1")
                            {
                                materyalparameters();
                            }
                            con.Close();
                            strid.doldurstock();
                            this.Close();
                        }
                    }
                    else// MATERYAL GÜNCELLEME İŞLEMİ
                    {
                        SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                        con.Open();
                        SqlCommand command12 = new SqlCommand("Insert Into tbl_userlog(user_id,form_name,islem,log_date) Values (@userid,@formname,@islem, @logdate)", con);
                        command12.Parameters.AddWithValue("@userid", login.userid);
                        command12.Parameters.AddWithValue("@formname", this.Text);
                        command12.Parameters.AddWithValue("@islem", button2.Text);
                        command12.Parameters.AddWithValue("@logdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        try
                        {
                            command12.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG41");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG41", "Sistem Mesajı");
                        }
                        string sqlquery4 = "SELECT stock_material from tbl_stock where stock_no = '" + stock.materialno + "'";
                        SqlCommand command5 = new SqlCommand(sqlquery4, con);
                        try
                        {
                            object kontrol = command5.ExecuteScalar();
                            string stokmateryal;
                            if (kontrol == null || kontrol == DBNull.Value)
                            {
                                stokmateryal = "0";
                            }
                            else
                            {
                                string evet = kontrol.ToString();
                                if (evet == "0")
                                {
                                    stokmateryal = "0";
                                }
                                else
                                {
                                    stokmateryal = "1";
                                }
                            }
                            materyalparameters();//UPDATEMATERYAL
                            if (durdur == false)
                            {
                                if (stokmateryal == "1")
                                {
                                    stokparameters();//UPDATESTOCK
                                    if (checkBox2.Checked == false)
                                    {
                                        checkBox2_CheckedChanged();//eğer güncelleme esnasında stokmateryal tikli değilse stok tablosunda olup olmadığını kontrol edip düzenleme yapıyor
                                    }

                                }//Eğer bu materyal zaten stok ürünüyse sadece güncelleme yapıyor.
                                else
                                {
                                    if (checkBox2.Checked == true)
                                    {
                                        stokinsertparameters();//INSERTINTOSTOCK
                                    }
                                }//Eğer bu materyal stok ürünü değilse bunu gidip stok tablosuna ekliyor.
                            }
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG24");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG24", "Sistem Mesajı");
                        }
                        con.Close();
                        strid.doldurmateryal();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Değişiklik yapmak için iki kalem butonuna da tıklayınız.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)//Silme Butonu
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            SqlCommand komut = new SqlCommand();
            SqlCommand komut1 = new SqlCommand();
            SqlCommand komut2 = new SqlCommand();
            SqlCommand komut3 = new SqlCommand();
            SqlCommand komut4 = new SqlCommand();
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
                    prlg = new programLog(ex.Message, this.Text, "PRLG42");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG42", "Sistem Mesajı");
                }
                string sqlquery1 = "SELECT material_sellable FROM tbl_material where material_no = '" + textBox1.Text + "'";
                SqlCommand command1 = new SqlCommand(sqlquery1, con);
                object materialsellable = "";
                try { materialsellable = command1.ExecuteScalar(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG25"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG25", "Sistem Mesajı"); }
                //PROGRAMLOG


                string sqlquery3 = "SELECT stock_material FROM tbl_stock where stock_no = '" + textBox1.Text + "'";
                SqlCommand command3 = new SqlCommand(sqlquery3, con);
                object stockmaterial = "";
                try { stockmaterial = command3.ExecuteScalar(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG26"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG26", "Sistem Mesajı"); }
                //PROGRAMLOG


                string sqlquery4 = "SELECT material_id FROM tbl_material where material_no = '" + textBox1.Text + "'";
                SqlCommand command4 = new SqlCommand(sqlquery4, con);
                object materialid = "";
                try { materialid = command4.ExecuteScalar(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG27"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG27", "Sistem Mesajı"); }
                //PROGRAMLOG


                string sqlquery2 = "SELECT stock_id FROM tbl_stock where stock_no = '" + textBox1.Text + "'";
                SqlCommand command2 = new SqlCommand(sqlquery2, con);
                object stockid1 = "";
                try { stockid1 = command2.ExecuteScalar(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG28"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG28", "Sistem Mesajı"); }
                //PROGRAMLOG


                if (button2.Text == "Stok Güncelle")
                {
                    bool k1 = false;
                    bool k2 = false;
                    bool k3 = false;
                    bool k4 = false;
                    komut.Connection = con;
                    komut.CommandText = "update tbl_stock set delete_status = '1', user_id='" + login.userid + "', edit_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where stock_id= '" + stockid1 + "'";
                    komut1.Connection = con;
                    komut1.CommandText = "update tbl_stock set stock_no = '" + "deleted" + textBox1.Text + "', user_id='" + login.userid + "', edit_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where stock_id= '" + stockid1 + "'";

                    try
                    {
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        k1 = true;
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG29");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG29", "Sistem Mesajı");
                    }

                    try
                    {
                        komut1.ExecuteNonQuery();
                        komut1.Dispose();
                        k2 = true;
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG30");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG30", "Sistem Mesajı");
                    }

                    if (stockmaterial.ToString() == "1")
                    {
                        komut3.Connection = con;
                        komut3.CommandText = "update tbl_material set material_no = '" + "deleted" + textBox1.Text + "', user_id='" + login.userid + "', edit_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where material_id= '" + materialid + "'";
                        komut4.Connection = con;
                        komut4.CommandText = "update tbl_material set delete_status = '1', user_id='" + login.userid + "', edit_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where material_id= '" + materialid + "'";


                        try
                        {
                            komut3.ExecuteNonQuery();
                            komut3.Dispose();
                            k3 = true;
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG31");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG31", "Sistem Mesajı");
                        }

                        try
                        {
                            komut4.ExecuteNonQuery();
                            komut4.Dispose();
                            k4 = true;
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG32");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG32", "Sistem Mesajı");
                        }
                    }
                    if (stockmaterial.ToString() == "1")
                    {
                        if ((k1 == true && k2 == true && k3 == true && k4 == true))
                        {
                            MessageBox.Show("Kayıt Silindi", "Sistem Mesajı");
                        }
                    }
                    else
                    {
                        if (k1 == true && k2 == true)
                        {
                            MessageBox.Show("Kayıt Silindi", "Sistem Mesajı");
                        }
                    }
                    strid.doldurstock();
                }

                else
                {
                    bool k1 = false;
                    bool k2 = false;
                    bool k3 = false;
                    bool k4 = false;
                    bool k5 = false;
                    komut.Connection = con;
                    komut.CommandText = "update tbl_material set delete_status = '1', user_id='" + login.userid + "', edit_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where material_id= '" + materialid + "'";
                    komut1.Connection = con;
                    komut1.CommandText = "delete from tbl_manufacture where material_id= '" + materialid + "'";
                    komut2.Connection = con;
                    komut2.CommandText = "update tbl_material set material_no = '" + "deleted" + textBox1.Text + "', user_id='" + login.userid + "', edit_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where material_id= '" + materialid + "'";

                    try
                    {
                        komut.ExecuteNonQuery();
                        komut.Dispose();
                        k1 = true;
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG33");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG33", "Sistem Mesajı");
                    }
                    try
                    {
                        komut1.ExecuteNonQuery();
                        komut1.Dispose();
                        k2 = true;
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG34");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG34", "Sistem Mesajı");
                    }
                    try
                    {
                        komut2.ExecuteNonQuery();
                        komut2.Dispose();
                        k3 = true;
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG35");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG35", "Sistem Mesajı");
                    }




                    if (materialsellable.ToString() == "1")
                    {
                        komut3.Connection = con;
                        komut3.CommandText = "update tbl_stock set stock_no = '" + "deleted" + textBox1.Text + "', user_id='" + login.userid + "', edit_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where stock_id= '" + stockid1 + "'";
                        komut4.Connection = con;
                        komut4.CommandText = "update tbl_stock set delete_status = '1', user_id='" + login.userid + "', edit_date='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where stock_id= '" + stockid1 + "'";

                        try
                        {
                            komut3.ExecuteNonQuery();
                            komut3.Dispose();
                            k4 = true;
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG36");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG36", "Sistem Mesajı");
                        }
                        try
                        {
                            komut4.ExecuteNonQuery();
                            komut4.Dispose();
                            k5 = true;
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG37");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG37", "Sistem Mesajı");
                        }
                    }

                    if (materialsellable.ToString() == "1")
                    {
                        if (k1 == true && k2 == true && k3 == true && k4 == true && k5 == true)
                        {
                            MessageBox.Show("Kayıt Silindi", "Sistem Mesajı");
                        }
                    }
                    else
                    {
                        if (k1 == true && k2 == true && k3 == true)
                        {
                            MessageBox.Show("Kayıt Silindi", "Sistem Mesajı");
                        }
                    }
                    strid.doldurmateryal();
                }
                con.Close();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListItem2 listItems = new ListItem2();

            if (flowLayoutPanel1.Controls.Count > -1)
            {
                flowLayoutPanel1.Controls.Add(listItems);
            }
        }//Materyal '+' butonu

        void egersatilabilirmateryaldoluise()
        {
            pictureBox1.Image = resizeImage(pictureBox1.Image, new Size(200, 200));
            ImageConverter imgc = new ImageConverter();
            byte[] img = (byte[])imgc.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));

            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            con.Open();
            SqlCommand command4 = new SqlCommand("Insert Into tbl_stock(stock_no,stock_name,stock_barkod,stock_amount,stock_price, stock_den_id, stock_description, stock_add_date, stock_status, stock_material, delete_status, img) " +
                "Values (" + "@stockno, @stockname, @stockbarkod,@stockamount,@stockprice,@stockdenid,@stockdescription, @stockadddate, @stockstatus, @stockmaterial,@deletestatus,@img)", con);
            command4.Parameters.AddWithValue("@stockno", textBox1.Text);
            command4.Parameters.AddWithValue("@stockname", textBox2.Text);
            command4.Parameters.AddWithValue("@stockbarkod", textBox3.Text);
            command4.Parameters.AddWithValue("@stockamount", "0");
            command4.Parameters.AddWithValue("@stockprice", textBox5.Text);


            string denid2 = "";
            string sqlquery2 = "SELECT den_id from tbl_denomination where den_name = '" + comboBox1.Text + "'";
            SqlCommand command3 = new SqlCommand(sqlquery2, con);
            denid2 = command3.ExecuteScalar().ToString();


            command4.Parameters.AddWithValue("@stockdenid", denid2.ToString());
            command4.Parameters.AddWithValue("@stockdescription", textBox6.Text);
            command4.Parameters.AddWithValue("@stockadddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            command4.Parameters.AddWithValue("@stockstatus", "1");
            command4.Parameters.AddWithValue("@stockmaterial", "1");
            command4.Parameters.AddWithValue("@deletestatus", "0");
            command4.Parameters.AddWithValue("@img", img);

            SqlCommand command5 = new SqlCommand("update tbl_material set material_sellable=@materialsellable where material_no = '" + stock.materialno + "'", con);
            command5.Parameters.AddWithValue("@materialsellable", "1");

            try
            {
                command4.ExecuteNonQuery();
                command5.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    //MessageBox.Show("Bu materyalin numarası, stoktaki bir ürünün numarası ile aynı. Kayıt işlemini yapmak için önce stoktaki veya materyaldeki numarayı değiştiriniz.", "Sistem Mesajı");
                    SqlCommand command6 = new SqlCommand("update tbl_stock set stock_material=@stockmaterial, delete_status=@deletestatus where stock_no = '" + stock.materialno + "'", con);
                    command6.Parameters.AddWithValue("@stockmaterial", "1");
                    command6.Parameters.AddWithValue("@deletestatus", "0");

                    SqlCommand command7 = new SqlCommand("update tbl_material set material_sellable=@materialsellable where material_no = '" + stock.materialno + "'", con);
                    command7.Parameters.AddWithValue("@materialsellable", "1");

                    command6.ExecuteNonQuery();
                    command7.ExecuteNonQuery();
                }
                else throw;
            }
            con.Close();
        }

        void egersatilabilirmateryalbosise()
        {
            //if (checkBox2.Visible == true)
            //{
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            //DialogResult cc;
            //cc = MessageBox.Show("Silmek istediğinizden emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (cc == DialogResult.Yes)
            //{
            con.Open();
            SqlCommand komut = new SqlCommand();
            SqlDataAdapter adtr = new SqlDataAdapter();

            string sqlquer1 = "SELECT stock_id FROM tbl_stock where stock_no = '" + textBox1.Text + "'";
            SqlCommand command2 = new SqlCommand(sqlquer1, con);

            string result = "";
            result = (command2.ExecuteScalar() ?? "").ToString();
            object kontrol = command2.ExecuteScalar();
            if (kontrol != null)
            {
                result = kontrol.ToString();
                komut.Connection = con;
                komut.CommandText = "update tbl_stock set delete_status = '1' where stock_id= '" + kontrol + "'";
                komut.ExecuteNonQuery();
                komut.Dispose();

                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandText = "delete from tbl_manufacture where stock_id = '" + kontrol + "'";
                com.ExecuteNonQuery();
                com.Dispose();

                SqlCommand command5 = new SqlCommand("update tbl_material set material_sellable=@materialsellable where material_no = '" + textBox1.Text + "'", con);
                command5.Parameters.AddWithValue("@materialsellable", "0");
                command5.ExecuteNonQuery();

                SqlCommand command6 = new SqlCommand("update tbl_stock set stock_material=@stock_material, delete_status=@deletestatus where stock_no = '" + textBox1.Text + "'", con);
                command6.Parameters.AddWithValue("@stock_material", "0");
                command6.Parameters.AddWithValue("@deletestatus", "1");
                command6.ExecuteNonQuery();

                con.Close();
            }
            else
            {
                kontrol = "";
                MessageBox.Show("Hatalı numara girişi yapıldı.", "Sistem Mesajı");
            }

            //}
            //else
            //{
            this.Close();
            //}
            //}
        }

        void stokdata()//stok amount
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select stock_amount from tbl_stock where stock_no = '" + stock.stockno + "'", con);
            try
            {
                adtr.Fill(ds, "tbl_stock");
                dataGridView2.DataSource = ds.Tables["tbl_stock"];
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG38");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG38", "Sistem Mesajı");
            }
            con.Close();
        }

        void materyaldata()//materyal amount
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("Select material_amount from tbl_material where material_no = '" + stock.materialno + "'", con);
            try
            {
                adtr.Fill(ds, "tbl_material");
                dataGridView2.DataSource = ds.Tables["tbl_material"];
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG39");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG39", "Sistem Mesajı");
            }
            con.Close();
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)//4. Text kutusunu temizleme fonksiyonu
        {
            textBox4.ForeColor = System.Drawing.Color.Black;
            textBox4.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "Eklenecek Miktar")
            {
                textBox4.Text = "0";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ListItem2_2 listItems = new ListItem2_2();

            if (flowLayoutPanel2.Controls.Count > -1)
            {
                flowLayoutPanel2.Controls.Add(listItems);
            }
        }

        private void button7_Click(object sender, EventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (panel1.Enabled == false)
            {
                panel1.Enabled = true;
                panel3.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
                panel3.Enabled = false;
            }
        }
    }
}
