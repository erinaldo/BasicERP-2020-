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
    public partial class stockadd : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";
        //public static string connectionstringpub = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        stock strid;
        public stockadd(stock st)
        {
            InitializeComponent();
            this.strid = st;
        }

        string alan = "";

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "" + alan + " No")
            {
                textBox1.Text = "";
                textBox1.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "" + alan + " Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Barkod";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "" + alan + " Miktarı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Fiyat";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Ürün Açıklaması";
            }
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox2.Text == "" + alan + " Adı")
            {
                textBox2.Text = "";
                textBox2.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "" + alan + " No";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Barkod";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "" + alan + " Miktarı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Fiyat";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Ürün Açıklaması";
            }
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox3.Text == "Barkod")
            {
                textBox3.Text = "";
                textBox3.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "" + alan + " Adı";
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "" + alan + " No";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "" + alan + " Miktarı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Fiyat";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Ürün Açıklaması";
            }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox4.Text == "" + alan + " Miktarı")
            {
                textBox4.Text = "";
                textBox4.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "" + alan + " Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Barkod";
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "" + alan + " No";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Fiyat";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Ürün Açıklaması";
            }
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox5.Text == "Fiyat")
            {
                textBox5.Text = "";
                textBox5.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "" + alan + " Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Barkod";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "" + alan + " Miktarı";
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "" + alan + " No";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Ürün Açıklaması";
            }
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox6.Text == "Ürün Açıklaması")
            {
                textBox6.Text = "";
                textBox6.ForeColor = System.Drawing.Color.Black;
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "" + alan + " Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Barkod";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "" + alan + " Miktarı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Fiyat";
            }

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "" + alan + " No";
            }
        }

        private void stockadd_MouseClick(object sender, MouseEventArgs e)
        {
            button1.Focus();

            if (textBox1.Text == "")
            {
                textBox1.ForeColor = System.Drawing.Color.DimGray;
                textBox1.Text = "" + alan + " No";
            }

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = System.Drawing.Color.DimGray;
                textBox2.Text = "" + alan + " Adı";
            }

            if (textBox3.Text == "")
            {
                textBox3.ForeColor = System.Drawing.Color.DimGray;
                textBox3.Text = "Barkod";
            }

            if (textBox4.Text == "")
            {
                textBox4.ForeColor = System.Drawing.Color.DimGray;
                textBox4.Text = "" + alan + " Miktarı";
            }

            if (textBox5.Text == "")
            {
                textBox5.ForeColor = System.Drawing.Color.DimGray;
                textBox5.Text = "Fiyat";
            }

            if (textBox6.Text == "")
            {
                textBox6.ForeColor = System.Drawing.Color.DimGray;
                textBox6.Text = "Ürün Açıklaması";
            }
        }




        public static SqlConnection conpub = new SqlConnection(BaglanClass.connectionstring);
        public SqlCommand commandpub1 = new SqlCommand("Insert Into tbl_material(material_no,material_name,material_barkod,material_amount,material_price, material_den_id, material_description, material_add_date, material_status, material_sellable, delete_status, img, user_id, edit_date) " +
                        "Values (" + "@materialno, @materialname, @materialbarkod,@materialamount,@materialprice,@materialdenid,@materialdescription, @materialadddate, @materialstatus, @materialsellable,@deletestatus, @img, @userid, @editdate)", conpub);




        public static SqlConnection conpub2 = new SqlConnection(BaglanClass.connectionstring);
        public SqlCommand commandpub2 = new SqlCommand("Insert Into tbl_stock(stock_no,stock_name,stock_barkod,stock_amount,stock_price, stock_den_id, stock_description, stock_add_date, stock_status, stock_material, delete_status, img, user_id, edit_date) " +
                            "Values (" + "@stockno, @stockname, @stockbarkod,@stockamount,@stockprice,@stockdenid,@stockdescription, @stockadddate, @stockstatus, @stockmaterial,@deletestatus, @img, @userid, @editdate)", conpub2);

        public static SqlConnection conpub3 = new SqlConnection(BaglanClass.connectionstring);
        //public static 



        public static SqlConnection conpub4 = new SqlConnection(BaglanClass.connectionstring);
        //public static 

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        programLog prlg;
        private void button2_Click(object sender, EventArgs e)
        {
            //doldurid();
            pictureBox1.Image = resizeImage(pictureBox1.Image, new Size(200, 200));
            ImageConverter imgc = new ImageConverter();
            byte[] img = (byte[])imgc.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            //DateTime dt = DateTime.Now;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox1.Text == "Stok No" || textBox2.Text == "Stok Adı")
            {
                MessageBox.Show("Lütfen ekrandaki parametreleri doldurunuz.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                int denetle = 0;
                int checkboxisareti = 0;
                if (comboBox2.Text == "STOK ÜRÜNÜ")
                {
                    if (flowLayoutPanel1.Controls.Count <= 0)
                    {
                        denetle = 1;
                        MessageBox.Show("Lütfen maliyet kaydı yapınız.", "Sistem Mesajı");
                    }
                    else
                    {
                        denetle = 0;
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
                            prlg = new programLog(ex.Message, this.Text, "PRLG28");//PROGRAMLOG
                            prlg.databaseinsert();
                            MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG28", "Sistem Mesajı");
                        }


                        SqlCommand command = new SqlCommand("Insert Into tbl_stock(stock_no,stock_name,stock_barkod,stock_amount, stock_den_id, stock_description, stock_add_date, stock_status, stock_material, delete_status, img, user_id, edit_date) " +
                            "Values (" + "@stockno, @stockname, @stockbarkod,@stockamount,@stockdenid,@stockdescription, @stockadddate, @stockstatus, @stockmaterial,@deletestatus, @img, @userid, @editdate)", con);
                        command.Parameters.AddWithValue("@stockno", textBox1.Text);
                        command.Parameters.AddWithValue("@stockname", textBox2.Text);
                        if (textBox3.Text == "" || textBox3.Text == "Barkod")
                        {
                            command.Parameters.AddWithValue("@stockbarkod", "");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@stockbarkod", textBox3.Text);
                        }
                        command.Parameters.AddWithValue("@stockamount", "0");
                        //command.Parameters.AddWithValue("@stockprice", textBox5.Text);


                        string denid = "";
                        string sqlquery = "SELECT den_id from tbl_denomination where den_name = '" + comboBox1.Text + "'";
                        SqlCommand command2 = new SqlCommand(sqlquery, con);
                        try { denid = command2.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG1"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı"); }
                        //PROGRAMLOG



                        command.Parameters.AddWithValue("@stockdenid", denid.ToString());

                        if (textBox6.Text == "" || textBox6.Text == "Ürün Açıklaması")
                        {
                            command.Parameters.AddWithValue("@stockdescription", "");
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@stockdescription", textBox6.Text);
                        }
                        
                        command.Parameters.AddWithValue("@stockadddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@stockstatus", "1");
                        command.Parameters.AddWithValue("@stockmaterial", "0");
                        command.Parameters.AddWithValue("@deletestatus", "0");
                        command.Parameters.AddWithValue("@img", img);
                        command.Parameters.AddWithValue("@userid", login.userid);
                        command.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                            prlg.databaseinsert();
                            if (ex.Number == 2627)
                            {
                                denetle = 1;
                                MessageBox.Show("Bu stok numarası zaten kullanılıyor.", "Sistem Mesajı");
                            }
                            else
                            {
                                denetle = 1;
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
                            }
                        }

                        con.Close();

                        //doldurid();

                        int listitemsayisi = flowLayoutPanel1.Controls.Count;

                        ListItem2[] listItems = new ListItem2[listitemsayisi];
                        con.Open();
                        for (int i = 4; i < listItems.Length; i++)//HAMMADDE VERİLERİNİ GİREN KOD
                        {
                            listItems[i] = (ListItem2)flowLayoutPanel1.Controls[i];

                            SqlCommand command1 = new SqlCommand("Insert Into tbl_manufacture(stock_id,material_id, material_amount, den_id) " +
                                    "Values (" + "@stockid, @materialid,@materialamountt,@denid)", con);

                            string stockid = "";
                            string sqlquery1 = "SELECT stock_id from tbl_stock where stock_no = '" + textBox1.Text + "'";
                            SqlCommand command3 = new SqlCommand(sqlquery1, con);
                            try { stockid = command3.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG3"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı"); }
                            //PROGRAMLOG
                            command1.Parameters.AddWithValue("@stockid", stockid.ToString());
                            string materialid = "";
                            string sqlquery2 = "SELECT material_id from tbl_material where material_name = '" + listItems[i].Isim.ToString() + "'";
                            SqlCommand command4 = new SqlCommand(sqlquery2, con);
                            try { materialid = command4.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG4"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı"); }
                            //PROGRAMLOG
                            command1.Parameters.AddWithValue("@materialid", materialid);
                            command1.Parameters.AddWithValue("@materialamountt", listItems[i].Miktar.ToString());
                            string denid1 = "";
                            string sqlquery3 = "SELECT den_id from tbl_denomination where den_name = '" + listItems[i].Birim.ToString() + "'";
                            SqlCommand command5 = new SqlCommand(sqlquery3, con);
                            try { denid1 = command5.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG5"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı"); }
                            //PROGRAMLOG
                            command1.Parameters.AddWithValue("@denid", denid1);
                            try
                            {
                                command1.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {

                                prlg = new programLog(ex.Message, this.Text, "PRLG6");//PROGRAMLOG
                                prlg.databaseinsert();
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı");
                            }
                        }

                        if (flowLayoutPanel2.Controls.Count > 0)//FATURA GİDERLERİNİ GİREN KOD
                        {
                            int listitemsayisi1 = flowLayoutPanel2.Controls.Count;

                            ListItem2_2[] listItems2 = new ListItem2_2[listitemsayisi1];
                            //con.Open();
                            for (int i = 4; i < listItems2.Length; i++)
                            {
                                listItems2[i] = (ListItem2_2)flowLayoutPanel2.Controls[i];

                                SqlCommand command1 = new SqlCommand("Insert Into other_expenses(stock_id,exp_id,exp_amount,den_id,oth_add_date,insert_date) Values (@stockid, @expid, @expamount,@denid,@othadddate,@insertdate)", con);


                                string stockid = "";
                                string sqlquery1 = "SELECT stock_id from tbl_stock where stock_no = '" + textBox1.Text + "'";
                                SqlCommand command3 = new SqlCommand(sqlquery1, con);
                                try { stockid = command3.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG7"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG7", "Sistem Mesajı"); }
                                //PROGRAMLOG
                                command1.Parameters.AddWithValue("@stockid", stockid.ToString());
                                string expid = "";
                                string sqlquery2 = "SELECT exp_id from expenses where exp_name = '" + listItems2[i].Isim.ToString() + "'";
                                SqlCommand command4 = new SqlCommand(sqlquery2, con);
                                try { expid = command4.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG8"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG8", "Sistem Mesajı"); }
                                //PROGRAMLOG
                                command1.Parameters.AddWithValue("@expid", expid.ToString());
                                //string expamount = "";
                                //string sqlquery3 = "SELECT exp_id from expenses where exp_name = '" + listItems2[i].Miktar.ToString() + "'";
                                //SqlCommand command5 = new SqlCommand(sqlquery3, con);
                                //expamount = command5.ExecuteScalar().ToString();
                                command1.Parameters.AddWithValue("@expamount", listItems2[i].Miktar.ToString());

                                string denid1 = "";
                                string sqlquery3 = "SELECT den_id from tbl_denomination where den_name = '" + listItems2[i].Birim.ToString() + "'";
                                SqlCommand command5 = new SqlCommand(sqlquery3, con);
                                try { denid1 = command5.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG9"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG9", "Sistem Mesajı"); }
                                //PROGRAMLOG

                                command1.Parameters.AddWithValue("@denid", denid1.ToString());

                                command1.Parameters.AddWithValue("@othadddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                command1.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                try
                                {
                                    command1.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    prlg = new programLog(ex.Message, this.Text, "PRLG10");//PROGRAMLOG
                                    prlg.databaseinsert();
                                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG10", "Sistem Mesajı");
                                }
                            }
                        }
                        con.Close();
                        this.Controls.Clear();
                        this.InitializeComponent();
                        strid.doldurstock();
                    }
                }
                else
                {
                    bool listitemdoldurucu = false;
                    bool nodenetleyicii = false;
                    bool nodenetleyicii2 = false;
                    denetle = 0;
                    //conpub.Open();
                    con.Open();////////////////////////////////////
                    SqlCommand command10 = new SqlCommand("Insert Into tbl_userlog(user_id,form_name,islem,log_date) Values (@userid,@formname,@islem, @logdate)", con);
                    command10.Parameters.AddWithValue("@userid", login.userid);
                    command10.Parameters.AddWithValue("@formname", this.Text);
                    command10.Parameters.AddWithValue("@islem", button2.Text);
                    command10.Parameters.AddWithValue("@logdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    try
                    {
                        command10.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG28");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG28", "Sistem Mesajı");
                    }

                    commandpub1.Parameters.AddWithValue("@materialno", textBox1.Text);
                    commandpub1.Parameters.AddWithValue("@materialname", textBox2.Text);
                    commandpub1.Parameters.AddWithValue("@materialbarkod", textBox3.Text);
                    commandpub1.Parameters.AddWithValue("@materialamount", "0");
                    commandpub1.Parameters.AddWithValue("@materialprice", textBox5.Text);


                    string denid1 = "";
                    string sqlquery3 = "SELECT den_id from tbl_denomination where den_name = '" + comboBox1.Text + "'";
                    SqlCommand command5 = new SqlCommand(sqlquery3, con);
                    try { denid1 = command5.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG11"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG11", "Sistem Mesajı"); }
                    //PROGRAMLOG



                    commandpub1.Parameters.AddWithValue("@materialdenid", denid1);
                    commandpub1.Parameters.AddWithValue("@materialdescription", textBox6.Text);
                    commandpub1.Parameters.AddWithValue("@materialadddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    commandpub1.Parameters.AddWithValue("@materialstatus", "1");
                    commandpub1.Parameters.AddWithValue("@deletestatus", "0");
                    commandpub1.Parameters.AddWithValue("@img", img);
                    commandpub1.Parameters.AddWithValue("@userid", login.userid);
                    commandpub1.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (checkBox1.Checked == false)
                    {
                        commandpub1.Parameters.AddWithValue("@materialsellable", "0");
                    }
                    int listitemsayisi = flowLayoutPanel1.Controls.Count;
                    if (checkBox1.Checked == true)
                    {
                        checkboxisareti = 1;
                        if (flowLayoutPanel1.Controls.Count > 0)
                        {
                            commandpub1.Parameters.AddWithValue("@materialsellable", "1");

                            commandpub2.Parameters.AddWithValue("@stockno", textBox1.Text);
                            commandpub2.Parameters.AddWithValue("@stockname", textBox2.Text);
                            commandpub2.Parameters.AddWithValue("@stockbarkod", textBox3.Text);
                            commandpub2.Parameters.AddWithValue("@stockamount", "0");
                            commandpub2.Parameters.AddWithValue("@stockprice", textBox5.Text);

                            string denid2 = "";
                            string sqlquery4 = "SELECT den_id from tbl_denomination where den_name = '" + comboBox1.Text + "'";
                            SqlCommand command6 = new SqlCommand(sqlquery4, con);
                            try { denid2 = command6.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG12"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG12", "Sistem Mesajı"); }
                            //PROGRAMLOG

                            commandpub2.Parameters.AddWithValue("@stockdenid", denid2);
                            commandpub2.Parameters.AddWithValue("@stockdescription", textBox6.Text);
                            commandpub2.Parameters.AddWithValue("@stockadddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            commandpub2.Parameters.AddWithValue("@stockstatus", "1");
                            commandpub2.Parameters.AddWithValue("@stockmaterial", "1");
                            commandpub2.Parameters.AddWithValue("@deletestatus", "0");
                            commandpub2.Parameters.AddWithValue("@img", img);
                            commandpub2.Parameters.AddWithValue("@userid", login.userid);
                            commandpub2.Parameters.AddWithValue("@editdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                            string sqlquery6 = "SELECT stock_no FROM tbl_stock where stock_no = '" + textBox1.Text + "'";
                            SqlCommand command8 = new SqlCommand(sqlquery6, con);
                            try
                            {
                                object nullableValue1 = command8.ExecuteScalar();
                                if (nullableValue1 == null || nullableValue1 == DBNull.Value)
                                {
                                    nodenetleyicii = true;
                                }
                                else
                                {
                                    nodenetleyicii = false;
                                }
                            }
                            catch (SqlException ex)
                            {
                                prlg = new programLog(ex.Message, this.Text, "PRLG13");//PROGRAMLOG
                                prlg.databaseinsert();
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG13", "Sistem Mesajı");
                            }


                            string sqlquery7 = "SELECT material_no FROM tbl_material where material_no = '" + textBox1.Text + "'";
                            SqlCommand command7 = new SqlCommand(sqlquery7, con);
                            try
                            {
                                object nullableValue2 = command7.ExecuteScalar();
                                if (nullableValue2 == null || nullableValue2 == DBNull.Value)
                                {
                                    nodenetleyicii2 = true;
                                }
                                else
                                {
                                    nodenetleyicii2 = false;
                                }
                            }
                            catch (SqlException ex)
                            {
                                prlg = new programLog(ex.Message, this.Text, "PRLG14");//PROGRAMLOG
                                prlg.databaseinsert();
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG14", "Sistem Mesajı");
                            }

                            if (nodenetleyicii == true && nodenetleyicii2 == true)
                            {
                                try
                                {
                                    conpub.Open();
                                    commandpub1.ExecuteNonQuery();
                                    conpub.Close();
                                }
                                catch (SqlException ex)
                                {
                                    conpub.Close();
                                    prlg = new programLog(ex.Message, this.Text, "PRLG15");//PROGRAMLOG
                                    prlg.databaseinsert();
                                    if (ex.Number == 2627)
                                    {
                                        MessageBox.Show("Materyal numarası üst üste biniyor. Lütfen kontrolleri sağlayınız.", "Sistem Mesajı");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG15", "Sistem Mesajı");
                                    }
                                }
                                try
                                {
                                    conpub2.Open();
                                    commandpub2.ExecuteNonQuery();
                                    conpub2.Close();
                                }
                                catch (SqlException ex)
                                {
                                    conpub2.Close();
                                    prlg = new programLog(ex.Message, this.Text, "PRLG16");//PROGRAMLOG
                                    prlg.databaseinsert();
                                    if (ex.Number == 2627)
                                    {
                                        MessageBox.Show("Stok numarası üst üste biniyor. Lütfen kontrolleri sağlayınız.", "Sistem Mesajı");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG16", "Sistem Mesajı");
                                    }
                                }

                                listitemdoldurucu = true;
                            }
                            if (listitemdoldurucu == true)
                            {
                                //con.Open();
                                ListItem2[] listItems = new ListItem2[listitemsayisi];
                                for (int i = 4; i < listItems.Length; i++)
                                {
                                    listItems[i] = (ListItem2)flowLayoutPanel1.Controls[i];

                                    string stockid = "";
                                    string sqlquery1 = "SELECT stock_id from tbl_stock where stock_no = '" + textBox1.Text + "'";
                                    SqlCommand command3 = new SqlCommand(sqlquery1, con);
                                    try { stockid = command3.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG17"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG17", "Sistem Mesajı"); }
                                    //PROGRAMLOG
                                    

                                    SqlCommand commandpub3 = new SqlCommand("Insert Into tbl_manufacture(stock_id,material_id, material_amount, den_id) " +
                                        "Values (@stockid, @materialid,@materialamountt,@denid)", con);

                                    commandpub3.Parameters.AddWithValue("@stockid", stockid.ToString());
                                    //"@stockid1, @materialid1,@materialamountt1,@denid1"
                                    string materialid = "";
                                    string sqlquery2 = "SELECT material_id from tbl_material where material_name = '" + listItems[i].Isim.ToString() + "'";
                                    SqlCommand command4 = new SqlCommand(sqlquery2, con);
                                    try { materialid = command4.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG18"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG18", "Sistem Mesajı"); }
                                    //PROGRAMLOG
                                    

                                    commandpub3.Parameters.AddWithValue("@materialid", materialid);
                                    commandpub3.Parameters.AddWithValue("@materialamountt", listItems[i].Miktar.ToString());

                                    string denid3 = "";
                                    string sqlquery5 = "SELECT den_id from tbl_denomination where den_name = '" + listItems[i].Birim.ToString() + "'";
                                    SqlCommand command9 = new SqlCommand(sqlquery5, con);
                                    try { denid3 = command9.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG19"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG19", "Sistem Mesajı"); }
                                    //PROGRAMLOG
                                    commandpub3.Parameters.AddWithValue("@denid", denid3);

                                    try
                                    {
                                        commandpub3.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        prlg = new programLog(ex.Message, this.Text, "PRLG20");//PROGRAMLOG
                                        prlg.databaseinsert();
                                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG20", "Sistem Mesajı");
                                    }

                                }
                                //con.Close();
                            }


                        }
                        if (listitemdoldurucu == true)
                        {
                            if (flowLayoutPanel2.Controls.Count > 0)//FATURA GİDERLERİNİ GİREN KOD
                            {
                                //conpub4.Open();
                                int listitemsayisi1 = flowLayoutPanel2.Controls.Count;

                                ListItem2_2[] listItems2 = new ListItem2_2[listitemsayisi1];
                                //con.Open();
                                for (int i = 4; i < listItems2.Length; i++)
                                {
                                    listItems2[i] = (ListItem2_2)flowLayoutPanel2.Controls[i];

                                    string stockid = "";
                                    string sqlquery1 = "SELECT stock_id from tbl_stock where stock_no = '" + textBox1.Text + "'";
                                    SqlCommand command3 = new SqlCommand(sqlquery1, con);
                                    try { stockid = command3.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG21"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG21", "Sistem Mesajı"); }
                                    //PROGRAMLOG
                                    
                                    SqlCommand commandpub4 = new SqlCommand("Insert Into other_expenses(stock_id,exp_id,exp_amount,den_id,oth_add_date, insert_date) " +
                                    "Values (@stockid, @expid, @expamount,@denid, @othadddate, @insertdate)", con);
                                    commandpub4.Parameters.AddWithValue("@stockid", stockid.ToString());

                                    string expid = "";
                                    string sqlquery2 = "SELECT exp_id from expenses where exp_name = '" + listItems2[i].Isim.ToString() + "'";
                                    SqlCommand command4 = new SqlCommand(sqlquery2, con);
                                    try { expid = command4.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG22"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG22", "Sistem Mesajı"); }
                                    //PROGRAMLOG
                                    
                                    commandpub4.Parameters.AddWithValue("@expid", expid.ToString());

                                    //string expamount = "";
                                    //string sqlquery3 = "SELECT exp_id from expenses where exp_name = '" + listItems2[i].Miktar.ToString() + "'";
                                    //SqlCommand command5 = new SqlCommand(sqlquery3, con);
                                    //expamount = command5.ExecuteScalar().ToString();
                                    commandpub4.Parameters.AddWithValue("@expamount", listItems2[i].Miktar.ToString());

                                    string denid2 = "";
                                    string sqlquery4 = "SELECT den_id from tbl_denomination where den_name = '" + listItems2[i].Birim.ToString() + "'";
                                    SqlCommand command6 = new SqlCommand(sqlquery4, con);
                                    try { denid2 = command6.ExecuteScalar().ToString(); } catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG23"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG23", "Sistem Mesajı"); }
                                    //PROGRAMLOG
                                    
                                    commandpub4.Parameters.AddWithValue("@denid", denid2.ToString());

                                    commandpub4.Parameters.AddWithValue("@othadddate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    commandpub4.Parameters.AddWithValue("@insertdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                    try
                                    {
                                        commandpub4.ExecuteNonQuery();
                                    }
                                    catch (SqlException ex)
                                    {
                                        prlg = new programLog(ex.Message, this.Text, "PRLG24");//PROGRAMLOG
                                        prlg.databaseinsert();
                                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG24", "Sistem Mesajı");
                                    }
                                }
                            }
                        }
                    }

                    if (checkboxisareti != 1)
                    {
                        try
                        {
                            conpub.Open();
                            commandpub1.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            prlg = new programLog(ex.Message, this.Text, button2.Text);
                            prlg.databaseinsert();
                            if (ex.Number == 2627)
                            {
                                MessageBox.Show("Materyal numarası üst üste biniyor. Lütfen kontrolleri sağlayınız.", "Sistem Mesajı");
                                denetle = 1;
                            }
                            else
                            {
                                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG25", "Sistem Mesajı");
                                denetle = 1;
                            }
                        }
                        conpub.Close();
                    }
                    else
                    {
                        if (nodenetleyicii == true && nodenetleyicii2 == true)
                        {
                            denetle = 0;
                        }
                        else
                        {
                            denetle = 1;
                            MessageBox.Show("Seçtiğiniz numara, eşsiz bir materyal ve stok numarası olmalı.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                    con.Close();
                    strid.doldurmateryal();
                }

                if (denetle == 0)
                {
                    MessageBox.Show("Kayıt Tamamlandı", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    denetle = 0;
                    this.Close();
                }
            }
        }


        private void stockadd_Load(object sender, EventArgs e)
        {
            metroTabControl1.SelectedTab = metroTabPage1;
            if (stock.labelname == "Stok Listesi")
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
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
                    prlg = new programLog(ex.Message, this.Text, "PRLG26");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG26", "Sistem Mesajı");
                }
                con.Close();
                comboBox2.Text = "STOK ÜRÜNÜ";
                button2.Text = "Stok Ekle";
                label1.Text = "Stok Ekleme Paneli";
                panel1.Enabled = true;
                panel3.Enabled = true;
            }
            else if (stock.labelname == "Materyaller Listesi")
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
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
                    prlg = new programLog(ex.Message, this.Text, "PRLG27");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG27", "Sistem Mesajı");
                }
                
                con.Close();
                comboBox2.Text = "İMALAT ÜRÜNÜ";
                button2.Text = "Materyal Ekle";
                label1.Text = "Materyal Ekleme Paneli";
                panel1.Enabled = false;
                panel3.Enabled = false;

            }

            this.flowLayoutPanel1.AutoScroll = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "STOK ÜRÜNÜ")
            {
                label1.Text = "Stok Ekleme Paneli";
                button2.Text = "Stok Ekle";
                alan = "Stok";
                textBox1.Text = "" + alan + " No";
                textBox2.Text = "" + alan + " Adı";
                textBox4.Text = "" + alan + " Miktarı";
                strid.doldurstock();
                checkBox1.Visible = false;
                panel1.Enabled = true;
                panel3.Enabled = true;
            }
            else if (comboBox2.Text == "İMALAT ÜRÜNÜ")
            {
                label1.Text = "Materyal Ekleme Paneli";
                button2.Text = "Materyal Ekle";
                alan = "Materyal";
                textBox1.Text = "" + alan + " No";
                textBox2.Text = "" + alan + " Adı";
                textBox4.Text = "" + alan + " Miktarı";
                strid.doldurmateryal();
                checkBox1.Visible = true;
                panel1.Enabled = false;
                panel3.Enabled = false;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ListItem2 listItems = new ListItem2();

            if (flowLayoutPanel1.Controls.Count > -1)
            {
                flowLayoutPanel1.Controls.Add(listItems);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel1.Enabled = true;
                panel3.Enabled = true;
            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();
                panel1.Enabled = false;
                panel3.Enabled = false;
            }
        }

        void doldurid()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT tbl_stock.stock_id, tbl_material.material_id,tbl_manufacture.material_amount ,tbl_manufacture.den_id " +
                "FROM tbl_stock " +
                "INNER JOIN tbl_manufacture ON tbl_stock.stock_id = tbl_manufacture.stock_id " +
                "INNER JOIN tbl_material ON tbl_material.material_id = tbl_manufacture.material_id " +
                "where tbl_stock.stock_id = '" + stock.stockid + "'", con);

            adtr.Fill(ds, "tbl_stock");
            dataGridView1.DataSource = ds.Tables["tbl_stock"];
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            adtr.Dispose();
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListItem2_2 listItems = new ListItem2_2();

            if (flowLayoutPanel2.Controls.Count > -1)
            {
                flowLayoutPanel2.Controls.Add(listItems);
            }
        }

        private void button6_Click(object sender, EventArgs e)
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
    }
}
