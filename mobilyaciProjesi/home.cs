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
    public partial class home : Form
    {

        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        public home()
        {
            InitializeComponent();
        }

        void panelaligner()
        {
            //panelpersonel.Location = new Point(221, 26);
            //panelkullanicilar.Location = new Point(221, 26);
            //panelmusteri.Location = new Point(221, 26);
            //panelurunfiyatlandirma.Location = new Point(221, 26);
            //panelstok.Location = new Point(221, 26);
            //paneldoviz.Location = new Point(221, 26);
            //panelgider.Location = new Point(221, 26);
            //panelRaporlama.Location = new Point(221, 26);
            //
            //
            //
            //panelpersonel.Size = new Size(793, 629);
            //panelkullanicilar.Size = new Size(793, 629);
            //panelmusteri.Size = new Size(793, 629);
            //panelurunfiyatlandirma.Size = new Size(793, 629);
            //panelstok.Size = new Size(793, 629);
            //paneldoviz.Size = new Size(793, 629);
            //panelgider.Size = new Size(793, 629);
            //panelRaporlama.Size = new Size(793, 629);

            panelpersonel.Dock = DockStyle.Fill;
            panelkullanicilar.Dock = DockStyle.Fill;
            panelmusteri.Dock = DockStyle.Fill;
            panelurunfiyatlandirma.Dock = DockStyle.Fill;
            panelstok.Dock = DockStyle.Fill;
            paneldoviz.Dock = DockStyle.Fill;
            panelgider.Dock = DockStyle.Fill;
            panelRaporlama.Dock = DockStyle.Fill;
            panel4.Dock = DockStyle.Fill;

        }//panel hizalayıcı-boyutlandırıcı

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //login lg = new login();
            //lg.Show();
            //this.Close();
            Application.Exit();
        }//çıkış
        public static string un = "Kullanıcı Adı";
        private void button1_Click(object sender, EventArgs e)//users
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT users FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string users = "";
            con.Open();
            try
            {
                users = command2.ExecuteScalar().ToString();
                if (users == "1")
                {
                    if (panelkullanicilar.Visible == true)
                    {
                        panelkullanicilar.Visible = false;
                        panel4.Visible = true;
                    }
                    else
                    {
                        panelkullanicilar.Visible = true;
                        panel4.Visible = false;
                        paneldoviz.Visible = false;
                        panelgider.Visible = false;
                        panelmusteri.Visible = false;
                        panelpersonel.Visible = false;
                        panelstok.Visible = false;
                        panelurunfiyatlandirma.Visible = false;
                        panelRaporlama.Visible = false;
                        userss us = new userss() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        us.FormBorderStyle = FormBorderStyle.None;
                        this.panelkullanicilar.Controls.Add(us);
                        us.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG12"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG12", "Sistem Mesajı"); }
            //PROGRAMLOG

        }

        private void button2_Click(object sender, EventArgs e)//stoklar-materyaller
        {
            if (panel13.Visible == true)
            {
                panel13.Visible = false;
                button8.Location = new Point(0, 36);
                button10.Location = new Point(0, 72);
            }
            else
            {
                panel13.Visible = true;
                button8.Location = new Point(0, 63);
                button10.Location = new Point(0, 99);
            }
        }

        programLog prlg;
        void firstchart()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            //1.CHART
            SqlCommand cmd;
            SqlDataReader dr;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT stock_id,sum(quantity) AS sayi FROM dbo.sale_details inner join tbl_sale on tbl_sale.slip_id = sale_details.slip_id where tbl_sale.status = '0' GROUP BY stock_id";

            try
            {
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    foreach (var series in chart1.Series)
                    {
                        series.Points.Clear();
                    }
                    con.Close();
                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT TOP 5 stock_name as urunAdi, SUM(quantity) AS satilanMiktar FROM tbl_stock INNER JOIN sale_details ON tbl_stock.stock_id = sale_details.stock_id inner join tbl_sale on tbl_sale.slip_id = sale_details.slip_id where tbl_sale.status = '0' GROUP BY tbl_stock.stock_name ORDER BY sum(quantity) desc; ", con);
                    SqlCommand command2 = new SqlCommand("SELECT tbl_stock.stock_name as urunAdi, SUM(sale_details.quantity) AS satilanMiktar FROM tbl_stock INNER JOIN sale_details ON tbl_stock.stock_id = sale_details.stock_id inner join tbl_sale on tbl_sale.slip_id = sale_details.slip_id where tbl_sale.status = '0'GROUP BY stock_name ORDER BY satilanMiktar desc OFFSET 5 ROWS", con);
                    DataTable tablo = new DataTable();
                    tablo.Columns.Add("Stok", typeof(string));
                    tablo.Columns.Add("Miktar", typeof(Int64));
                    Int64 toplam = 0;
                    try
                    {
                        SqlDataReader o1 = command.ExecuteReader();
                        while (o1.Read())
                        {
                            tablo.Rows.Add(o1.GetString(0), o1.GetInt64(1));
                            dataGridView2.DataSource = tablo;
                        }
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
                    }
                    con.Close();
                    con.Open();
                    try
                    {
                        SqlDataReader o2 = command2.ExecuteReader();
                        while (o2.Read())
                        {
                            toplam = toplam + Convert.ToInt64(o2.GetInt64(1));
                        }
                        tablo.Rows.Add("Diğer", toplam);
                        dataGridView2.DataSource = tablo;

                        //float dilimmiktari = 100 / toplam;
                        for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                        {
                            chart1.Series["Series1"].Points.AddXY(dataGridView2.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView2.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", Convert.ToDouble(dataGridView2.Rows[i].Cells["Miktar"].Value).ToString());
                            //chart1.Series["Series1"].Points.AddXY("", Convert.ToDouble(dataGridView2.Rows[i].Cells["Miktar"].Value).ToString());
                        }
                        chart1color();
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
                    }

                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
            }

            chart1.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(255, 220, 220, 220);
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LawnGreen;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LawnGreen;
            con.Close();
        }

        void secondchart()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            //2.CHART
            SqlCommand cmd1;
            SqlDataReader dr1;
            cmd1 = new SqlCommand();
            con.Open();
            cmd1.Connection = con;
            cmd1.CommandText = "SELECT top 5 stock_name, sum(convert(int, stock_amount)) AS sayi FROM dbo.tbl_stock GROUP BY stock_name";

            try
            {
                dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    foreach (var series in chart2.Series)
                    {
                        series.Points.Clear();
                    }

                    con.Close();
                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT top 5 tbl_stock.stock_name as urunAdi, SUM(CONVERT(int, tbl_stock.stock_amount)) AS KalanMiktar FROM tbl_stock where tbl_stock.delete_status = '0' GROUP BY stock_name, stock_amount ORDER BY sum(CONVERT(int, tbl_stock.stock_amount)) asc; ", con);
                    DataTable tablo = new DataTable();
                    tablo.Columns.Add("Stok", typeof(string));
                    tablo.Columns.Add("Miktar", typeof(int));

                    try
                    {
                        SqlDataReader o1 = command.ExecuteReader();

                        Int64 toplam = 0;

                        while (o1.Read())
                        {
                            tablo.Rows.Add(o1.GetString(0), o1.GetInt32(1));
                            dataGridView3.DataSource = tablo;
                            toplam = toplam + Convert.ToInt64(o1.GetInt32(1));
                        }
                        for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                        {
                            chart2.Series["Series2"].Points.AddXY(dataGridView3.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView3.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", (360 / dataGridView3.RowCount - 1).ToString());
                        }
                        chart2color();
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG4");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG4", "Sistem Mesajı");
                    }
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG5");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG5", "Sistem Mesajı");
            }


            chart2.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(255, 220, 220, 220);
            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LawnGreen;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LawnGreen;
            con.Close();
        }

        void thirdchart()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            //3.CHART
            SqlCommand cmd2;
            SqlDataReader dr2;
            cmd2 = new SqlCommand();
            con.Open();
            cmd2.Connection = con;
            cmd2.CommandText = "SELECT top 5 stock_name, sum(convert(int, stock_amount)) AS sayi FROM dbo.tbl_stock GROUP BY stock_name";

            try
            {
                dr2 = cmd2.ExecuteReader();
                if (dr2.Read())
                {
                    foreach (var series in chart3.Series)
                    {
                        series.Points.Clear();
                    }

                    con.Close();
                    con.Open();
                    SqlCommand command = new SqlCommand("SELECT top 5 tbl_customer.customer_name as musteriAdi, count(*) AS KereSatıldı FROM sale_details INNER JOIN tbl_customer ON sale_details.customer_id = tbl_customer.customer_id inner join tbl_sale on tbl_sale.slip_id = sale_details.slip_id where tbl_sale.status = '0'GROUP BY tbl_customer.customer_name order by count(*) desc;", con);
                    DataTable tablo = new DataTable();
                    tablo.Columns.Add("Stok", typeof(string));
                    tablo.Columns.Add("Miktar", typeof(int));

                    try
                    {
                        SqlDataReader o1 = command.ExecuteReader();
                        Int64 toplam = 0;
                        while (o1.Read())
                        {
                            tablo.Rows.Add(o1.GetString(0), o1.GetInt32(1));
                            dataGridView4.DataSource = tablo;
                            toplam = toplam + Convert.ToInt64(o1.GetInt32(1));
                        }
                        for (int i = 0; i < dataGridView4.RowCount - 1; i++)
                        {
                            //chart3.Series["Series3"].Points.AddXY(dataGridView4.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView4.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", Convert.ToDouble(dataGridView2.Rows[i].Cells["Miktar"].Value).ToString());
                            chart3.Series["Series3"].Points.AddXY(dataGridView4.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView4.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", Convert.ToDouble(dataGridView4.Rows[i].Cells["Miktar"].Value).ToString());
                        }
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG6");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG6", "Sistem Mesajı");
                    }
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG7");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG7", "Sistem Mesajı");
            }

            chart3color();
            chart3.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(255, 220, 220, 220);
            chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LawnGreen;
            chart3.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LawnGreen;
            con.Close();
        }

        void checkdatagrid()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sorgu1 = "select customer_name as adi, DATEDIFF(day, getdate(),convert(varchar, payment_date, 101)) as tarihi, currency as birimi, convert(float(6), (allcost - charged_money)) as kalan, slip_id, 'sale' as tablosu from tbl_sale inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id where tbl_sale.over_status = '0' and tbl_sale.status = '0' and payment_date < getdate() + 1500 and not tbl_sale.over_status ='1' and tbl_sale.slip_type = '3'";
            string sorgu2 = "select customer_name as adi, DATEDIFF(day, getdate(),convert(varchar, payment_date, 101)) as tarihi, cur_id as birimi, convert(float(6), (allcost - paid_money)) as kalan, slip_id, 'acq' as tablosu from acq inner join tbl_customer on tbl_customer.customer_id = acq.customer_id where acq.over_status = '0' and payment_date < getdate() + 1500 and not acq.over_status ='1' and acq.slip_type = '3'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sorgu1, con);
            SqlCommand cmd2 = new SqlCommand(sorgu2, con);
            DataTable dt = new DataTable();
            try
            {
                dt.Load(cmd.ExecuteReader());
                dt.Load(cmd2.ExecuteReader());
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG8");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG8", "Sistem Mesajı");
            }
            dataGridView5.DataSource = dt;
            dataGridView5.Sort(dataGridView5.Columns[1], ListSortDirection.Ascending);
            con.Close();
        }

        void opencheckdatagrid()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sorgu1 = "select customer_name as adi, DATEDIFF(day, getdate(),convert(varchar, payment_date, 101)) as tarihi, currency as birimi, convert(float(6), (allcost - charged_money)) as kalan, slip_id, 'sale' as tablosu from tbl_sale inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id where tbl_sale.over_status = '0' and tbl_sale.status = '0' and payment_date < getdate() + 1500 and not tbl_sale.over_status ='1' and tbl_sale.slip_type = '4'";
            string sorgu2 = "select customer_name as adi, DATEDIFF(day, getdate(),convert(varchar, payment_date, 101)) as tarihi, cur_id as birimi, convert(float(6), (allcost - paid_money)) as kalan, slip_id, 'acq' as tablosu from acq inner join tbl_customer on tbl_customer.customer_id = acq.customer_id where acq.over_status = '0' and payment_date < getdate() + 1500 and not acq.over_status ='1' and acq.slip_type = '4'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sorgu1, con);
            SqlCommand cmd2 = new SqlCommand(sorgu2, con);
            DataTable dt = new DataTable();
            try
            {
                dt.Load(cmd.ExecuteReader());
                dt.Load(cmd2.ExecuteReader());
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG24");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG24", "Sistem Mesajı");
            }
            dataGridView6.DataSource = dt;
            dataGridView6.Sort(dataGridView6.Columns[1], ListSortDirection.Ascending);
            con.Close();
        }

        void senetdatagrid()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sorgu1 = "select customer_name as adi, DATEDIFF(day, getdate(),convert(varchar, payment_date, 101)) as tarihi, currency as birimi, convert(float(6), (allcost - charged_money)) as kalan, slip_id, 'sale' as tablosu from tbl_sale inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id where tbl_sale.over_status = '0' and tbl_sale.status = '0' and payment_date < getdate() + 1500 and not tbl_sale.over_status ='1' and tbl_sale.slip_type = '5'";
            string sorgu2 = "select customer_name as adi, DATEDIFF(day, getdate(),convert(varchar, payment_date, 101)) as tarihi, cur_id as birimi, convert(float(6), (allcost - paid_money)) as kalan, slip_id, 'acq' as tablosu from acq inner join tbl_customer on tbl_customer.customer_id = acq.customer_id where acq.over_status = '0' and payment_date < getdate() + 1500 and not acq.over_status ='1' and acq.slip_type = '5'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sorgu1, con);
            SqlCommand cmd2 = new SqlCommand(sorgu2, con);
            DataTable dt = new DataTable();
            try
            {
                dt.Load(cmd.ExecuteReader());
                dt.Load(cmd2.ExecuteReader());
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG23");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG23", "Sistem Mesajı");
            }
            dataGridView7.DataSource = dt;
            dataGridView7.Sort(dataGridView7.Columns[1], ListSortDirection.Ascending);
            con.Close();
        }


        private DataGridViewRow[] CloneDataGridViewRows(DataGridView dgv)
        {
            var rowArray = new DataGridViewRow[dgv.Rows.Count];
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                DataGridViewRow clonedRow = (DataGridViewRow)dgv.Rows[i].Clone();
                for (int c = 0; c < clonedRow.Cells.Count; c++)
                {
                    clonedRow.Cells[c].Value = dgv.Rows[i].Cells[c].Value;
                }
                rowArray[i] = clonedRow;
            }
            return rowArray;
        }

        void tahsilatdatagrid()
        {
            dataGridView8.Columns.Clear();
            dataGridView8.Refresh();
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sorgu1 = "SELECT tbl_sale.slip_no as fisNo, tbl_sale.charged_money as tahsilEdilenMiktar, cur_name, CONVERT(varchar, tbl_sale.payment_date, 120) as tahsilatTarihi,customer_name, case when tbl_sale.slip_type = '1' then 'Nakit' when tbl_sale.slip_type = '2' then 'Havale'  end as fisturu FROM tbl_sale inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id inner join currency on currency.cur_id = tbl_sale.currency where tbl_sale.status = '0' and tbl_sale.sold_date >= DATEADD(DAY, -7, GETDATE()) and (tbl_sale.slip_type = '1' or tbl_sale.slip_type = '2') GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, customer_name, tbl_sale.charged_money, tbl_sale.slip_type, tbl_sale.payment_date, cur_name ORDER BY sold_date desc;";
            string sorgu2 = "SELECT tbl_sale.slip_no as fisNo, sale_opencheck.charged_money as tahsilEdilenMiktar, cur_name, CONVERT(varchar, sale_opencheck.payment_date, 120) as tahsilatTarihi, customer_name, case when tbl_sale.slip_type = '3' then 'Çek' when tbl_sale.slip_type = '4' then 'Açık Hesap' when tbl_sale.slip_type = '5' then 'Senet' end as fisturu FROM tbl_sale inner join sale_opencheck on sale_opencheck.slip_id = tbl_sale.slip_id inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id inner join currency on currency.cur_id = tbl_sale.currency where tbl_sale.status = '0' and sale_opencheck.payment_date >= DATEADD(DAY, -7, GETDATE()) and (tbl_sale.slip_type = '3' or tbl_sale.slip_type = '4' or tbl_sale.slip_type = '5') GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, customer_name, sale_opencheck.charged_money, tbl_sale.slip_type, sale_opencheck.payment_date, cur_name ORDER BY sold_date desc;";
            con.Open();
            SqlCommand command = new SqlCommand(sorgu1, con);
            DataTable dt = new DataTable();
            dataGridView8.Columns.Add("Fiş Numarası", "");
            dataGridView8.Columns.Add("Tahsil Edilen Miktar", "");
            dataGridView8.Columns.Add("Para Birimi", "");
            dataGridView8.Columns.Add("Tahsilat Tarihi", "");
            dataGridView8.Columns.Add("Müşteri Adı", "");
            dataGridView8.Columns.Add("Fiş Türü", "");
            dt.Load(command.ExecuteReader());
            SqlCommand command2 = new SqlCommand(sorgu2, con);
            DataTable dt2 = new DataTable();
            dt2.Load(command2.ExecuteReader());
            tahsilatview1.DataSource = dt2;
            tahsilatview1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView8.Rows.AddRange(CloneDataGridViewRows(tahsilatview1));
            tahsilatview2.DataSource = dt;
            tahsilatview2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView8.Rows.AddRange(CloneDataGridViewRows(tahsilatview2));

            //dataGridView8.Rows.RemoveAt(dataGridView8.Rows.Count - 1);
            //dataGridView8.Rows.RemoveAt(dataGridView8.Rows.Count - 1);
            dataGridView8.Columns[0].HeaderText = "Fiş No";
            dataGridView8.Columns[1].HeaderText = "Tahsil Edilen Miktar";
            dataGridView8.Columns[2].HeaderText = "Para Birimi";
            dataGridView8.Columns[3].HeaderText = "Tahsilat Tarihi";
            dataGridView8.Columns[4].HeaderText = "Müşteri Adı";
            dataGridView8.Columns[5].HeaderText = "Fiş Türü";

            //SqlCommand cmd = new SqlCommand(sorgu1, con);
            //SqlCommand cmd2 = new SqlCommand(sorgu2, con);

            //try
            //{
            //    dt.Load(cmd.ExecuteReader());
            //    dt.Load(cmd2.ExecuteReader());
            //}
            //catch (SqlException ex)
            //{
            //    prlg = new programLog(ex.Message, this.Text, "PRLG25");//PROGRAMLOG
            //    prlg.databaseinsert();
            //    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG25", "Sistem Mesajı");
            //}
            //dataGridView8.DataSource = dt;
            //dataGridView8.Sort(dataGridView8.Columns[3], ListSortDirection.Ascending);
            con.Close();
            dataGridView8.Sort(dataGridView8.Columns[3], ListSortDirection.Descending);
        }

        void onaysizsatiskontrol()
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
                    string sqlquery6 = "select count(*) from tbl_sale where status = '1'";
                    SqlCommand command8 = new SqlCommand(sqlquery6, con);
                    try
                    {
                        string onaysizsatis = command8.ExecuteScalar().ToString();
                        if (onaysizsatis == "0")
                        {
                            pictureBox2.Visible = false;
                            label12.Visible = false;
                        }
                        else
                        {
                            pictureBox2.Visible = true;
                            label12.Text = onaysizsatis;
                            label12.Visible = true;
                        }
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG21");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG21", "Sistem Mesajı");
                    }
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG22"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG22", "Sistem Mesajı"); }
            //PROGRAMLOG


            con.Close();
        }

        private void home_Load(object sender, EventArgs e)
        {
            label12.Visible = false;
            timer1.Start();
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sorgu = "select * from tbl_personnel where delete_status = '0'";
            con.Open();
            SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
            DataSet goster = new DataSet();

            try
            {
                getir.Fill(goster, "tbl_personnel");
                dataGridView1.DataSource = goster.Tables["tbl_personnel"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                getir.Dispose();
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG9");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG9", "Sistem Mesajı");
            }



            con.Close();

            onaysizsatiskontrol();

            checkdatagrid();
            opencheckdatagrid();
            senetdatagrid();
            tahsilatdatagrid();

            firstchart();

            secondchart();

            thirdchart();

            WindowState = FormWindowState.Maximized;

            populateItems();
            populatechecks();
            populateopenchecks();
            populatesenets();
            populatetahsilats();

            panelaligner();

            panelkullanicilar.Visible = false;
            panelpersonel.Visible = false;
            panelmusteri.Visible = false;
            panelurunfiyatlandirma.Visible = false;
            panelstok.Visible = false;
            paneldoviz.Visible = false;
            panelgider.Visible = false;
            panelRaporlama.Visible = false;

            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel2.AutoScroll = true;


        }

        private void populateItems()
        {
            int listitemsayisi = Convert.ToInt32(dataGridView1.Rows.Count.ToString()) - 1;

            ListItem[] listItems = new ListItem[listitemsayisi];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem();
                listItems[i].Title = dataGridView1.Rows[i].Cells[3].Value.ToString() + " " + dataGridView1.Rows[i].Cells[4].Value.ToString();

                if (flowLayoutPanel1.Controls.Count > 0)
                {
                    flowLayoutPanel1.Controls.Add(listItems[i]);
                }
                else
                {
                    flowLayoutPanel1.Controls.Clear();
                }
            }
        }

        private void populatechecks()
        {
            checkdatagrid();
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            int listitemsayisi = Convert.ToInt32(dataGridView5.Rows.Count.ToString()) - 1;
            ListItem1[] listItems = new ListItem1[listitemsayisi];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem1();
                listItems[i].Adi = dataGridView5.Rows[i].Cells[0].Value.ToString();
                listItems[i].Tarih = dataGridView5.Rows[i].Cells[1].Value.ToString();

                string sqlquery4 = "SELECT cur_name FROM currency where cur_id = '" + dataGridView5.Rows[i].Cells[2].Value.ToString() + "'";
                SqlCommand command4 = new SqlCommand(sqlquery4, con);
                con.Open();
                try
                {
                    object nullableValue5 = command4.ExecuteScalar();
                    listItems[i].Birimi = nullableValue5.ToString();
                    listItems[i].Miktar = Convert.ToDouble(dataGridView5.Rows[i].Cells[3].Value.ToString());
                    listItems[i].SlipId = dataGridView5.Rows[i].Cells[4].Value.ToString();
                    if (dataGridView5.Rows[i].Cells[5].Value.ToString() == "sale")
                    {
                        listItems[i].Rengi = "Teal";
                    }
                    else if (dataGridView5.Rows[i].Cells[5].Value.ToString() == "acq")
                    {
                        listItems[i].Rengi = "Red";
                    }

                    if (flowLayoutPanel2.Controls.Count > 0)
                    {
                        flowLayoutPanel2.Controls.Add(listItems[i]);
                    }
                    else
                    {
                        flowLayoutPanel2.Controls.Clear();
                    }
                }
                catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG10"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı"); }
                //PROGRAMLOG
                con.Close();
            }
        }

        private void populateopenchecks()
        {
            opencheckdatagrid();
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            int listitemsayisi = Convert.ToInt32(dataGridView6.Rows.Count.ToString()) - 1;
            ListItem1[] listItems = new ListItem1[listitemsayisi];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem1();
                listItems[i].Adi = dataGridView6.Rows[i].Cells[0].Value.ToString();
                listItems[i].Tarih = dataGridView6.Rows[i].Cells[1].Value.ToString();

                string sqlquery4 = "SELECT cur_name FROM currency where cur_id = '" + dataGridView6.Rows[i].Cells[2].Value.ToString() + "'";
                SqlCommand command4 = new SqlCommand(sqlquery4, con);
                con.Open();
                try
                {
                    object nullableValue5 = command4.ExecuteScalar();
                    listItems[i].Birimi = nullableValue5.ToString();
                    listItems[i].Miktar = Convert.ToDouble(dataGridView6.Rows[i].Cells[3].Value.ToString());
                    listItems[i].SlipId = dataGridView6.Rows[i].Cells[4].Value.ToString();
                    if (dataGridView6.Rows[i].Cells[5].Value.ToString() == "sale")
                    {
                        listItems[i].Rengi = "Teal";
                    }
                    else if (dataGridView6.Rows[i].Cells[5].Value.ToString() == "acq")
                    {
                        listItems[i].Rengi = "Red";
                    }

                    if (flowLayoutPanel3.Controls.Count > 0)
                    {
                        flowLayoutPanel3.Controls.Add(listItems[i]);
                    }
                    else
                    {
                        flowLayoutPanel3.Controls.Clear();
                    }
                }
                catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG10"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı"); }
                //PROGRAMLOG
                con.Close();
            }
        }

        private void populatesenets()
        {
            senetdatagrid();
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            int listitemsayisi = Convert.ToInt32(dataGridView7.Rows.Count.ToString()) - 1;
            ListItem1[] listItems = new ListItem1[listitemsayisi];

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem1();
                listItems[i].Adi = dataGridView7.Rows[i].Cells[0].Value.ToString();
                listItems[i].Tarih = dataGridView7.Rows[i].Cells[1].Value.ToString();

                string sqlquery4 = "SELECT cur_name FROM currency where cur_id = '" + dataGridView7.Rows[i].Cells[2].Value.ToString() + "'";
                SqlCommand command4 = new SqlCommand(sqlquery4, con);
                con.Open();
                try
                {
                    object nullableValue5 = command4.ExecuteScalar();
                    listItems[i].Birimi = nullableValue5.ToString();
                    listItems[i].Miktar = Convert.ToDouble(dataGridView7.Rows[i].Cells[3].Value.ToString());
                    listItems[i].SlipId = dataGridView7.Rows[i].Cells[4].Value.ToString();
                    if (dataGridView7.Rows[i].Cells[5].Value.ToString() == "sale")
                    {
                        listItems[i].Rengi = "Teal";
                    }
                    else if (dataGridView7.Rows[i].Cells[5].Value.ToString() == "acq")
                    {
                        listItems[i].Rengi = "Red";
                    }

                    if (flowLayoutPanel5.Controls.Count > 0)
                    {
                        flowLayoutPanel5.Controls.Add(listItems[i]);
                    }
                    else
                    {
                        flowLayoutPanel5.Controls.Clear();
                    }
                }
                catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG10"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı"); }
                //PROGRAMLOG
                con.Close();
            }
        }

        private void populatetahsilats()
        {
            //dataGridView8.Rows.Clear();
            //dataGridView8.Refresh();
            tahsilatdatagrid();
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            int listitemsayisi = Convert.ToInt32(dataGridView8.Rows.Count.ToString()) - 1;
            ListItemTahsilat[] listItems = new ListItemTahsilat[listitemsayisi];

            for (int i = 0; i < listItems.Length; i++)
            {
                if (dataGridView8.Rows[i].Cells[0].Value != null)
                {
                    listItems[i] = new ListItemTahsilat();
                    listItems[i].Adi = dataGridView8.Rows[i].Cells[4].Value.ToString();
                    listItems[i].Tarih = dataGridView8.Rows[i].Cells[3].Value.ToString();

                    listItems[i].Birimi = dataGridView8.Rows[i].Cells[2].Value.ToString();
                    listItems[i].Miktar = Convert.ToDouble(dataGridView8.Rows[i].Cells[1].Value.ToString());

                    listItems[i].FisTuru = dataGridView8.Rows[i].Cells[5].Value.ToString();

                    if (flowLayoutPanel4.Controls.Count > 0)
                    {
                        flowLayoutPanel4.Controls.Add(listItems[i]);
                    }
                    else
                    {
                        flowLayoutPanel4.Controls.Clear();
                    }
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)//carikartlar
        {
            if (panel11.Visible == false)
            {
                panel11.Visible = true;
                button4.Location = new Point(0, 70);
                button3.Location = new Point(0, 106);
                button13.Location = new Point(0, 142);
            }
            else
            {
                panel11.Visible = false;
                button4.Location = new Point(0, 36);
                button3.Location = new Point(0, 72);
                button13.Location = new Point(0, 108);
            }
        }

        private void button3_Click(object sender, EventArgs e)//ürün fiyatlandırma
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT financials FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string financials = "";
            con.Open();
            try
            {
                financials = command2.ExecuteScalar().ToString();
                if (financials == "1")
                {
                    if (panelurunfiyatlandirma.Visible == true)
                    {
                        panel4.Visible = true;
                        panelurunfiyatlandirma.Visible = false;
                    }
                    else
                    {
                        panelurunfiyatlandirma.Visible = true;
                        panel4.Visible = false;
                        paneldoviz.Visible = false;
                        panelgider.Visible = false;
                        panelstok.Visible = false;
                        panelpersonel.Visible = false;
                        panelkullanicilar.Visible = false;
                        panelmusteri.Visible = false;
                        panelRaporlama.Visible = false;
                        financialoperation fc = new financialoperation() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        fc.FormBorderStyle = FormBorderStyle.None;
                        this.panelurunfiyatlandirma.Controls.Add(fc);
                        fc.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG15"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG15", "Sistem Mesajı"); }
            //PROGRAMLOG


        }

        private void button7_Click(object sender, EventArgs e)//satış
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT sale FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string sale = "";
            con.Open();
            try
            {
                sale = command2.ExecuteScalar().ToString();
                if (sale == "1")
                {
                    sale sl = new sale(this);
                    sl.Show();
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG20"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG20", "Sistem Mesajı"); }
            //PROGRAMLOG
        }

        private void button4_Click(object sender, EventArgs e)//giderler
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT expenses FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string expenses = "";
            con.Open();
            try
            {
                expenses = command2.ExecuteScalar().ToString();
                if (expenses == "1")
                {
                    if (panelgider.Visible == true)
                    {
                        panel4.Visible = true;
                        panelgider.Visible = false;
                    }
                    else
                    {
                        panelgider.Visible = true;
                        panel4.Visible = false;
                        paneldoviz.Visible = false;
                        panelurunfiyatlandirma.Visible = false;
                        panelstok.Visible = false;
                        panelpersonel.Visible = false;
                        panelkullanicilar.Visible = false;
                        panelmusteri.Visible = false;
                        panelRaporlama.Visible = false;
                        expenses exp = new expenses() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        exp.FormBorderStyle = FormBorderStyle.None;
                        this.panelgider.Controls.Add(exp);
                        exp.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG14"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG14", "Sistem Mesajı"); }
            //PROGRAMLOG
        }

        private void button6_Click(object sender, EventArgs e)//çalışanlar
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT personels FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string personels = "";
            con.Open();
            try
            {
                personels = command2.ExecuteScalar().ToString();
                if (personels == "1")
                {
                    if (panelpersonel.Visible == true)
                    {
                        panel4.Visible = true;
                        panelpersonel.Visible = false;
                    }
                    else
                    {
                        panelpersonel.Visible = true;
                        panel4.Visible = false;
                        paneldoviz.Visible = false;
                        panelurunfiyatlandirma.Visible = false;
                        panelstok.Visible = false;
                        panelgider.Visible = false;
                        panelkullanicilar.Visible = false;
                        panelmusteri.Visible = false;
                        panelRaporlama.Visible = false;
                        personel pr = new personel() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        pr.FormBorderStyle = FormBorderStyle.None;
                        this.panelpersonel.Controls.Add(pr);
                        pr.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG11"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG11", "Sistem Mesajı"); }
            //PROGRAMLOG
        }

        public static string labeladi = "";
        private void button8_Click(object sender, EventArgs e)//Üretim
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT production FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string production = "";
            con.Open();
            try
            {
                production = command2.ExecuteScalar().ToString();
                if (production == "1")
                {
                    if (labeladi == "" || labeladi == "Materyal Ekleme Paneli")
                    {
                        labeladi = "Üretilen Stok Paneli";
                        stokekle st = new stokekle(this);
                        st.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG17"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG17", "Sistem Mesajı"); }
            //PROGRAMLOG

        }

        private void button10_Click(object sender, EventArgs e)//Tedarik
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT acquisition FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string acquisition = "";
            con.Open();
            try
            {
                acquisition = command2.ExecuteScalar().ToString();
                if (acquisition == "1")
                {
                    if (labeladi == "" || labeladi == "Üretilen Stok Paneli")
                    {
                        labeladi = "Materyal Ekleme Paneli";
                        stokekle st = new stokekle(this);
                        st.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG18"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG18", "Sistem Mesajı"); }
            //PROGRAMLOG

        }


        void chart1color()
        {
            if (chart1.Series[0].Points.Count > 0)
            {
                chart1.Series["Series1"].Points[0].Color = Color.FromArgb(255, 227, 239, 243);
                if (chart1.Series[0].Points.Count > 1)
                {
                    chart1.Series["Series1"].Points[1].Color = Color.FromArgb(255, 167, 193, 216);
                    if (chart1.Series[0].Points.Count > 2)
                    {
                        chart1.Series["Series1"].Points[2].Color = Color.FromArgb(255, 74, 117, 129);
                        if (chart1.Series[0].Points.Count > 3)
                        {
                            chart1.Series["Series1"].Points[3].Color = Color.FromArgb(255, 53, 83, 99);
                            if (chart1.Series[0].Points.Count > 4)
                            {
                                chart1.Series["Series1"].Points[4].Color = Color.FromArgb(255, 189, 118, 117);
                                if (chart1.Series[0].Points.Count > 5)
                                {
                                    chart1.Series["Series1"].Points[5].Color = Color.FromArgb(255, 222, 201, 224);
                                }
                            }
                        }
                    }
                }
                chart1.Series[0]["PieLabelStyle"] = "Outside";
                chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
                chart1.ChartAreas[0].Area3DStyle.Inclination = 20;
            }
        }

        void chart2color()
        {
            if (chart2.Series[0].Points.Count > 0)
            {
                chart2.Series[0].Points[0].Color = Color.FromArgb(255, 227, 239, 243);
                if (chart2.Series[0].Points.Count > 1)
                {
                    chart2.Series[0].Points[1].Color = Color.FromArgb(255, 167, 193, 216);
                    if (chart2.Series[0].Points.Count > 2)
                    {
                        chart2.Series[0].Points[2].Color = Color.FromArgb(255, 74, 117, 129);
                        if (chart2.Series[0].Points.Count > 3)
                        {
                            chart2.Series[0].Points[3].Color = Color.FromArgb(255, 53, 83, 99);
                            if (chart2.Series[0].Points.Count > 4)
                            {
                                chart2.Series[0].Points[4].Color = Color.FromArgb(255, 189, 118, 117);
                                if (chart2.Series[0].Points.Count > 5)
                                {
                                    chart2.Series[0].Points[5].Color = Color.FromArgb(255, 222, 201, 224);
                                }
                            }
                        }
                    }
                }

                chart2.Series[0]["PieLabelStyle"] = "Outside";
                chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
                chart2.ChartAreas[0].Area3DStyle.Inclination = 20;
            }
        }

        void chart3color()
        {
            if (chart3.Series[0].Points.Count > 0)
            {
                chart3.Series[0].Points[0].Color = Color.FromArgb(255, 227, 239, 243);
                if (chart3.Series[0].Points.Count > 1)
                {
                    chart3.Series[0].Points[1].Color = Color.FromArgb(255, 167, 193, 216);
                    if (chart3.Series[0].Points.Count > 2)
                    {
                        chart3.Series[0].Points[2].Color = Color.FromArgb(255, 74, 117, 129);
                        if (chart3.Series[0].Points.Count > 3)
                        {
                            chart3.Series[0].Points[3].Color = Color.FromArgb(255, 53, 83, 99);
                            if (chart3.Series[0].Points.Count > 4)
                            {
                                chart3.Series[0].Points[4].Color = Color.FromArgb(255, 189, 118, 117);
                                if (chart3.Series[0].Points.Count > 5)
                                {
                                    chart3.Series[0].Points[5].Color = Color.FromArgb(255, 222, 201, 224);
                                }
                            }
                        }
                    }
                }

                chart3.Series[0]["PieLabelStyle"] = "Outside";
                chart3.ChartAreas[0].Area3DStyle.Enable3D = true;
                chart3.ChartAreas[0].Area3DStyle.Inclination = 20;
            }
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            //HitTestResult hit = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            //
            //if (hit.PointIndex >= 0 && hit.Series != null)
            //{
            //    DataPoint dp = chart1.Series["Series1"].Points[hit.PointIndex];
            //    label6.Text = hit.PointIndex.ToString();
            //}
            //else label6.Text = "";
            //
            //if (label6.Text != "")
            //{
            //    foreach (var series in chart1.Series)
            //    {
            //        series.Points.Clear();
            //    }
            //    for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            //    {
            //        if (i == Convert.ToInt32(label6.Text))
            //        {
            //            chart1.Series["Series1"].Points.AddXY(dataGridView2.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView2.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", Convert.ToDouble(dataGridView2.Rows[i].Cells["Miktar"].Value).ToString());
            //        }
            //        else
            //        {
            //            chart1.Series["Series1"].Points.AddXY("", Convert.ToDouble(dataGridView2.Rows[i].Cells["Miktar"].Value).ToString());
            //        }
            //    }
            //    chart1.Series["Series1"].Points[0].Color = Color.FromArgb(255, 227, 239, 243);
            //    chart1.Series["Series1"].Points[1].Color = Color.FromArgb(255, 167, 193, 216);
            //    chart1.Series["Series1"].Points[2].Color = Color.FromArgb(255, 74, 117, 129);
            //    chart1.Series["Series1"].Points[3].Color = Color.FromArgb(255, 53, 83, 99);
            //    chart1.Series["Series1"].Points[4].Color = Color.FromArgb(255, 189, 118, 117);
            //}
            //else
            //{
            //    foreach (var series in chart1.Series)
            //    {
            //        series.Points.Clear();
            //    }
            //    for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            //    {
            //        chart1.Series["Series1"].Points.AddXY("", Convert.ToDouble(dataGridView2.Rows[i].Cells["Miktar"].Value).ToString());
            //    }
            //}
        }//İÇİ BOŞ
        private void chart2_MouseClick(object sender, MouseEventArgs e)
        {
            //HitTestResult hit = chart2.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            //
            //if (hit.PointIndex >= 0 && hit.Series != null)
            //{
            //    DataPoint dp = chart2.Series["Series2"].Points[hit.PointIndex];
            //    label7.Text = hit.PointIndex.ToString();
            //}
            //else label7.Text = "";
            //
            //if (label7.Text != "")
            //{
            //    foreach (var series in chart2.Series)
            //    {
            //        series.Points.Clear();
            //    }
            //    for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            //    {
            //        if (i == Convert.ToInt32(label7.Text))
            //        {
            //            chart2.Series["Series2"].Points.AddXY(dataGridView3.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView3.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", (360 / dataGridView3.RowCount - 1).ToString());
            //        }
            //        else
            //        {
            //            chart2.Series["Series2"].Points.AddXY("", (360 / dataGridView3.RowCount - 1).ToString());
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (var series in chart2.Series)
            //    {
            //        series.Points.Clear();
            //    }
            //    for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            //    {
            //        chart2.Series["Series2"].Points.AddXY("", (360 / dataGridView3.RowCount - 1).ToString());
            //    }
            //}
        }//İÇİ BOŞ
        private void chart3_MouseClick(object sender, MouseEventArgs e)
        {
            //HitTestResult hit = chart3.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            //
            //if (hit.PointIndex >= 0 && hit.Series != null)
            //{
            //    DataPoint dp = chart3.Series["Series3"].Points[hit.PointIndex];
            //    label8.Text = hit.PointIndex.ToString();
            //}
            //else label8.Text = "";
            //
            //if (label8.Text != "")
            //{
            //    foreach (var series in chart3.Series)
            //    {
            //        series.Points.Clear();
            //    }
            //    for (int i = 0; i < dataGridView4.RowCount - 1; i++)
            //    {
            //        if (i == Convert.ToInt32(label8.Text))
            //        {
            //            chart3.Series["Series3"].Points.AddXY(dataGridView4.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView4.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", Convert.ToDouble(dataGridView4.Rows[i].Cells["Miktar"].Value).ToString());
            //        }
            //        else
            //        {
            //            chart3.Series["Series3"].Points.AddXY("", (Convert.ToDouble(dataGridView4.Rows[i].Cells["Miktar"].Value)).ToString());
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (var series in chart3.Series)
            //    {
            //        series.Points.Clear();
            //    }
            //    for (int i = 0; i < dataGridView4.RowCount - 1; i++)
            //    {
            //        chart3.Series["Series3"].Points.AddXY("", (Convert.ToDouble(dataGridView4.Rows[i].Cells["Miktar"].Value)).ToString());
            //    }
            //}
        }//İÇİ BOŞ




        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult hit = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            var dp = hit.Object as DataPoint;
            Cursor = (dp is null) ? Cursors.Default : Cursors.Hand;

            chart1color();

            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                DataPoint dp1 = chart1.Series["Series1"].Points[hit.PointIndex];
                label9.Text = hit.PointIndex.ToString();
            }
            else label9.Text = "";

            if (label9.Text != "")
            {
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                {
                    if (i == Convert.ToInt32(label9.Text))
                    {
                        chart1.Series["Series1"].Points.AddXY(dataGridView2.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView2.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", Convert.ToDouble(dataGridView2.Rows[i].Cells["Miktar"].Value).ToString());
                    }
                    else
                    {
                        chart1.Series["Series1"].Points.AddXY("", Convert.ToDouble(dataGridView2.Rows[i].Cells["Miktar"].Value).ToString());
                    }
                }
                chart1color();
                chart1.Series["Series1"].Points[Convert.ToInt32(label9.Text)].Color = Color.FromArgb(255, 193, 235, 161);
                //chart1.Series["Series1"].Points[Convert.ToInt32(label9.Text)].Color = Color.Orange;
            }
            else
            {
                chart1color();
            }
        }
        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult hit = chart2.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            var dp = hit.Object as DataPoint;
            Cursor = (dp is null) ? Cursors.Default : Cursors.Hand;

            chart2color();

            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                DataPoint dp1 = chart2.Series["Series2"].Points[hit.PointIndex];
                label10.Text = hit.PointIndex.ToString();
            }
            else label10.Text = "";

            if (label10.Text != "")
            {
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                {
                    if (i == Convert.ToInt32(label10.Text))
                    {
                        chart2.Series["Series2"].Points.AddXY(dataGridView3.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView3.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", (360 / dataGridView3.RowCount - 1).ToString());
                    }
                    else
                    {
                        chart2.Series["Series2"].Points.AddXY("", (360 / dataGridView3.RowCount - 1).ToString());
                    }
                }
                chart2color();
                chart2.Series["Series2"].Points[Convert.ToInt32(label10.Text)].Color = Color.FromArgb(255, 193, 235, 161);
            }
            else
            {
                foreach (var series in chart2.Series)
                {
                    series.Points.Clear();
                }
                for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                {
                    //chart2.Series["Series2"].Points.AddXY("", (360 / dataGridView3.RowCount - 1).ToString());
                    chart2.Series["Series2"].Points.AddXY(dataGridView3.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView3.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", (360 / dataGridView3.RowCount - 1).ToString());
                }
                chart2color();
            }
        }
        private void chart3_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult hit = chart3.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            var dp = hit.Object as DataPoint;
            Cursor = (dp is null) ? Cursors.Default : Cursors.Hand;

            chart3color();
            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                DataPoint dp1 = chart3.Series["Series3"].Points[hit.PointIndex];
                label11.Text = hit.PointIndex.ToString();
            }
            else label11.Text = "";

            if (label11.Text != "")
            {
                foreach (var series in chart3.Series)
                {
                    series.Points.Clear();
                }
                for (int i = 0; i < dataGridView4.RowCount - 1; i++)
                {
                    if (i == Convert.ToInt32(label11.Text))
                    {
                        chart3.Series["Series3"].Points.AddXY(dataGridView4.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView4.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", Convert.ToDouble(dataGridView4.Rows[i].Cells["Miktar"].Value).ToString());
                    }
                    else
                    {
                        chart3.Series["Series3"].Points.AddXY("", Convert.ToDouble(dataGridView4.Rows[i].Cells["Miktar"].Value).ToString());
                    }
                }
                chart3color();
                chart3.Series["Series3"].Points[Convert.ToInt32(label11.Text)].Color = Color.FromArgb(255, 193, 235, 161);
            }
            else
            {
                foreach (var series in chart3.Series)
                {
                    series.Points.Clear();
                }
                for (int i = 0; i < dataGridView4.RowCount - 1; i++)
                {
                    //chart3.Series["Series3"].Points.AddXY(dataGridView4.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView4.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", Convert.ToDouble(dataGridView2.Rows[i].Cells["Miktar"].Value).ToString());
                    chart3.Series["Series3"].Points.AddXY(dataGridView4.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView4.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", Convert.ToDouble(dataGridView4.Rows[i].Cells["Miktar"].Value).ToString());
                }
                chart3color();
            }
        }




        private void button11_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == false)
            {
                if (panel6.Visible == true)
                {
                    panel6.Visible = false;
                    panel8.Location = new Point(1, 164);
                }
                panel5.Visible = true;
            }
            else
            {
                panel5.Visible = false;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (panel6.Visible == false)
            {
                panel5.Visible = false;
                panel6.Visible = true;
                panel8.Location = new Point(1, 355);
            }
            else
            {
                panel6.Visible = false;
                panel8.Location = new Point(1, 164);
            }
        }

        private void label9_TextChanged(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {
                chart1.Series["Series1"].Points.AddXY(dataGridView2.Rows[i].Cells["Stok"].Value.ToString() + " ( " + dataGridView2.Rows[i].Cells["Miktar"].Value.ToString() + " ) ", Convert.ToDouble(dataGridView2.Rows[i].Cells["Miktar"].Value).ToString());
            }
        }

        private void button13_Click(object sender, EventArgs e)//paneldöviz
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT currencies FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string currencies = "";
            con.Open();
            try
            {
                currencies = command2.ExecuteScalar().ToString();
                if (currencies == "1")
                {
                    if (paneldoviz.Visible == true)
                    {
                        panel4.Visible = true;
                        paneldoviz.Visible = false;
                    }
                    else
                    {
                        paneldoviz.Visible = true;
                        panel4.Visible = false;
                        panelpersonel.Visible = false;
                        panelurunfiyatlandirma.Visible = false;
                        panelstok.Visible = false;
                        panelgider.Visible = false;
                        panelkullanicilar.Visible = false;
                        panelmusteri.Visible = false;
                        panelRaporlama.Visible = false;
                        currency cr = new currency() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        cr.FormBorderStyle = FormBorderStyle.None;
                        this.paneldoviz.Controls.Add(cr);
                        cr.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG16"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG16", "Sistem Mesajı"); }
            //PROGRAMLOG

        }


        private void button14_Click(object sender, EventArgs e)
        {
            //while (flowLayoutPanel4.Controls.Count > 1) flowLayoutPanel4.Controls.RemoveAt(0);
            //populatetahsilats();
            //if (flowLayoutPanel4.Controls.Count > 0)
            //{
            //    flowLayoutPanel4.Controls.RemoveAt(0);
            //}
        }

        private void button15_Click(object sender, EventArgs e)
        {
            while (flowLayoutPanel1.Controls.Count > 1) flowLayoutPanel1.Controls.RemoveAt(0);
            //while (flowLayoutPanel2.Controls.Count > 1) flowLayoutPanel2.Controls.RemoveAt(0);
            //while (flowLayoutPanel3.Controls.Count > 1) flowLayoutPanel3.Controls.RemoveAt(0);
            //while (flowLayoutPanel5.Controls.Count > 1) flowLayoutPanel5.Controls.RemoveAt(0);
            //while (flowLayoutPanel4.Controls.Count > 1) flowLayoutPanel4.Controls.RemoveAt(0);
            populateItems();
            //populatechecks();
            //populateopenchecks();
            //populatesenets();
            //populatetahsilats();

            if (flowLayoutPanel1.Controls.Count < 2)
            {

            }
            else
            {
                flowLayoutPanel1.Controls.RemoveAt(0);
            }
            //if (flowLayoutPanel2.Controls.Count > 0)
            //{
            //    flowLayoutPanel2.Controls.RemoveAt(0);
            //}
            //if (flowLayoutPanel3.Controls.Count > 0)
            //{
            //    flowLayoutPanel3.Controls.RemoveAt(0);
            //}
            //if (flowLayoutPanel4.Controls.Count > 0)
            //{
            //    flowLayoutPanel4.Controls.RemoveAt(0);
            //}
            //if (flowLayoutPanel5.Controls.Count > 0)
            //{
            //    flowLayoutPanel5.Controls.RemoveAt(0);
            //}
            //onaysizsatiskontrol();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            onaysizsatislar oy = new onaysizsatislar();
            oy.Show();
        }


        public void WriteToTextbox(string inputText)
        {
            if (sale.fisturu == 1)
            {
                satisnakit();
            }
            else if (sale.fisturu == 2)
            {
                satishavale();
            }
            else if (sale.fisturu == 3)
            {
                satiscek();
            }
            else if (sale.fisturu == 4)
            {
                satisopencek();
            }
            else if (sale.fisturu == 5)
            {
                satissenet();
            }
            if (stokekle.fisturu == 6)
            {
                tedariknakit();
            }
            //else if (stokekle.fisturu == 6)
            //{
            //    tedarikhavale();
            //}
            else if (stokekle.fisturu == 3)
            {
                tedarikcek();
            }
            else if (stokekle.fisturu == 4)
            {
                tedarikopencek();
            }
            else if (stokekle.fisturu == 5)
            {
                tedariksenet();
            }
            //this.textBox1.Text = inputText;
        }//BURASI YAPILAN BİR İŞLEM SONUNDA ANASAYFADAKİ CHART-GÜNCELVERİPANELİ ALANLARINI OTOMATİK GÜNCELLİYOR

        private void button16_Click(object sender, EventArgs e)//müşteriler
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT customers FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string customers = "";
            con.Open();
            try
            {
                customers = command2.ExecuteScalar().ToString();
                if (customers == "1")
                {
                    if (panelmusteri.Visible == true)
                    {
                        if (carikartturu == 0)
                        {
                            panelmusteri.Visible = true;
                            panel4.Visible = false;
                            paneldoviz.Visible = false;
                            panelgider.Visible = false;
                            panelstok.Visible = false;
                            panelpersonel.Visible = false;
                            panelkullanicilar.Visible = false;
                            panelurunfiyatlandirma.Visible = false;
                            panelRaporlama.Visible = false;
                            carikartturu = 1;
                            customer cs = new customer() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                            cs.FormBorderStyle = FormBorderStyle.None;
                            this.panelmusteri.Controls.Add(cs);
                            cs.Show();
                        }
                        else
                        {
                            panel4.Visible = true;
                            panelmusteri.Visible = false;
                        }
                    }
                    else
                    {
                        panelmusteri.Visible = true;
                        panel4.Visible = false;
                        paneldoviz.Visible = false;
                        panelgider.Visible = false;
                        panelstok.Visible = false;
                        panelpersonel.Visible = false;
                        panelkullanicilar.Visible = false;
                        panelurunfiyatlandirma.Visible = false;
                        panelRaporlama.Visible = false;
                        carikartturu = 1;
                        customer cs = new customer() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        cs.FormBorderStyle = FormBorderStyle.None;
                        this.panelmusteri.Controls.Add(cs);
                        cs.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG13"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG13", "Sistem Mesajı"); }
            //PROGRAMLOG
        }


        public static int carikartturu = 2;
        private void button17_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT customers FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string customers = "";
            con.Open();
            try
            {
                customers = command2.ExecuteScalar().ToString();
                if (customers == "1")
                {
                    if (panelmusteri.Visible == true)
                    {
                        if (carikartturu == 1)
                        {
                            panelmusteri.Visible = true;
                            panel4.Visible = false;
                            paneldoviz.Visible = false;
                            panelgider.Visible = false;
                            panelstok.Visible = false;
                            panelpersonel.Visible = false;
                            panelkullanicilar.Visible = false;
                            panelurunfiyatlandirma.Visible = false;
                            carikartturu = 0;
                            customer cs = new customer() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                            cs.FormBorderStyle = FormBorderStyle.None;
                            this.panelmusteri.Controls.Add(cs);
                            cs.Show();
                        }
                        else
                        {
                            panel4.Visible = true;
                            panelmusteri.Visible = false;
                        }
                    }
                    else
                    {
                        panelmusteri.Visible = true;
                        panel4.Visible = false;
                        paneldoviz.Visible = false;
                        panelgider.Visible = false;
                        panelstok.Visible = false;
                        panelpersonel.Visible = false;
                        panelkullanicilar.Visible = false;
                        panelurunfiyatlandirma.Visible = false;
                        carikartturu = 0;
                        customer cs = new customer() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        cs.FormBorderStyle = FormBorderStyle.None;
                        this.panelmusteri.Controls.Add(cs);
                        cs.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG14"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG14", "Sistem Mesajı"); }
            //PROGRAMLOG
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT admin_status FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string admin = "";
            con.Open();
            try
            {
                admin = command2.ExecuteScalar().ToString();
                if (admin == "1")
                {
                    if (panelRaporlama.Visible == true)
                    {
                        panel4.Visible = true;
                        panelRaporlama.Visible = false;
                    }
                    else
                    {
                        panelRaporlama.Visible = true;
                        panelmusteri.Visible = false;
                        panel4.Visible = false;
                        paneldoviz.Visible = false;
                        panelgider.Visible = false;
                        panelstok.Visible = false;
                        panelpersonel.Visible = false;
                        panelkullanicilar.Visible = false;
                        panelurunfiyatlandirma.Visible = false;
                        raporlama rp = new raporlama() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        rp.FormBorderStyle = FormBorderStyle.None;
                        this.panelRaporlama.Controls.Add(rp);
                        rp.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG14"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG14", "Sistem Mesajı"); }
            //PROGRAMLOG
            //raporlama rp = new raporlama();
            //rp.Show();
        }

        public static int stockturu = 2;
        private void button19_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT stock FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string stock = "";
            con.Open();
            try
            {
                stock = command2.ExecuteScalar().ToString();
                if (stock == "1")
                {
                    if (panelstok.Visible == true)
                    {
                        if (stockturu == 0)
                        {
                            panelstok.Visible = true;
                            panel4.Visible = false;
                            paneldoviz.Visible = false;
                            panelgider.Visible = false;
                            panelmusteri.Visible = false;
                            panelpersonel.Visible = false;
                            panelkullanicilar.Visible = false;
                            panelurunfiyatlandirma.Visible = false;
                            panelRaporlama.Visible = false;
                            stockturu = 1;
                            stock st = new stock() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                            st.FormBorderStyle = FormBorderStyle.None;
                            this.panelstok.Controls.Add(st);
                            st.Show();
                        }
                        else
                        {
                            panelstok.Visible = false;
                            panel4.Visible = true;
                        }

                    }
                    else
                    {
                        panelstok.Visible = true;
                        panel4.Visible = false;
                        paneldoviz.Visible = false;
                        panelgider.Visible = false;
                        panelmusteri.Visible = false;
                        panelpersonel.Visible = false;
                        panelkullanicilar.Visible = false;
                        panelurunfiyatlandirma.Visible = false;
                        panelRaporlama.Visible = false;
                        stockturu = 1;
                        stock st = new stock() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        st.FormBorderStyle = FormBorderStyle.None;
                        this.panelstok.Controls.Add(st);
                        st.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG19"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG19", "Sistem Mesajı"); }
            //PROGRAMLOG
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            string sqlquery = "SELECT stock FROM permission where user_id = '" + login.userid + "'";
            SqlCommand command2 = new SqlCommand(sqlquery, con);
            string stock = "";
            con.Open();
            try
            {
                stock = command2.ExecuteScalar().ToString();
                if (stock == "1")
                {
                    if (panelstok.Visible == true)
                    {
                        if (stockturu == 1)
                        {
                            panelstok.Visible = true;
                            panel4.Visible = false;
                            paneldoviz.Visible = false;
                            panelgider.Visible = false;
                            panelmusteri.Visible = false;
                            panelpersonel.Visible = false;
                            panelkullanicilar.Visible = false;
                            panelurunfiyatlandirma.Visible = false;
                            panelRaporlama.Visible = false;
                            stockturu = 0;
                            stock st = new stock() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                            st.FormBorderStyle = FormBorderStyle.None;
                            this.panelstok.Controls.Add(st);
                            st.Show();
                        }
                        else
                        {
                            panelstok.Visible = false;
                            panel4.Visible = true;
                        }
                    }
                    else
                    {
                        panelstok.Visible = true;
                        panel4.Visible = false;
                        paneldoviz.Visible = false;
                        panelgider.Visible = false;
                        panelmusteri.Visible = false;
                        panelpersonel.Visible = false;
                        panelkullanicilar.Visible = false;
                        panelurunfiyatlandirma.Visible = false;
                        panelRaporlama.Visible = false;
                        stockturu = 0;
                        stock st = new stock() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                        st.FormBorderStyle = FormBorderStyle.None;
                        this.panelstok.Controls.Add(st);
                        st.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Yetkisiz giriş.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex) { prlg = new programLog(ex.Message, this.Text, "PRLG19"); prlg.databaseinsert(); MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG19", "Sistem Mesajı"); }
            //PROGRAMLOG
        }

        private void button20_Click(object sender, EventArgs e)
        {
            button20.Enabled = false;
            tedarikcek();
            tedarikopencek();
            tedariksenet();
            tahsilat();
            button20.Enabled = true; ;
        }


        ////>>>>TETIKLEYICI ILE DATABASE SORGULARI
        ///
        public void satisnakit()
        {
            firstchart();
            secondchart();
            thirdchart();
            while (flowLayoutPanel4.Controls.Count > 1) flowLayoutPanel4.Controls.RemoveAt(0);
            populatetahsilats();
            if (flowLayoutPanel4.Controls.Count > 0)
            {
                flowLayoutPanel4.Controls.RemoveAt(0);
            }
            onaysizsatiskontrol();
        }
        public void satishavale()
        {
            firstchart();
            secondchart();
            thirdchart();
            while (flowLayoutPanel4.Controls.Count > 1) flowLayoutPanel4.Controls.RemoveAt(0);
            populatetahsilats();
            if (flowLayoutPanel4.Controls.Count > 0)
            {
                flowLayoutPanel4.Controls.RemoveAt(0);
            }
            onaysizsatiskontrol();
        }
        public void satiscek()
        {
            firstchart();
            secondchart();
            thirdchart();
            while (flowLayoutPanel4.Controls.Count > 1) flowLayoutPanel4.Controls.RemoveAt(0);
            while (flowLayoutPanel2.Controls.Count > 1) flowLayoutPanel2.Controls.RemoveAt(0);
            populatetahsilats();
            populatechecks();
            if (flowLayoutPanel4.Controls.Count > 0)
            {
                flowLayoutPanel4.Controls.RemoveAt(0);
            }
            if (flowLayoutPanel2.Controls.Count > 0)
            {
                flowLayoutPanel2.Controls.RemoveAt(0);
            }
            onaysizsatiskontrol();
        }
        public void satisopencek()
        {
            firstchart();
            secondchart();
            thirdchart();
            while (flowLayoutPanel4.Controls.Count > 1) flowLayoutPanel4.Controls.RemoveAt(0);
            while (flowLayoutPanel3.Controls.Count > 1) flowLayoutPanel3.Controls.RemoveAt(0);
            populatetahsilats();
            populateopenchecks();
            if (flowLayoutPanel4.Controls.Count > 0)
            {
                flowLayoutPanel4.Controls.RemoveAt(0);
            }
            if (flowLayoutPanel3.Controls.Count > 0)
            {
                flowLayoutPanel3.Controls.RemoveAt(0);
            }
            onaysizsatiskontrol();
        }
        public void satissenet()
        {
            firstchart();
            secondchart();
            thirdchart();
            while (flowLayoutPanel4.Controls.Count > 1) flowLayoutPanel4.Controls.RemoveAt(0);
            while (flowLayoutPanel5.Controls.Count > 1) flowLayoutPanel5.Controls.RemoveAt(0);
            populatetahsilats();
            populatesenets();
            if (flowLayoutPanel4.Controls.Count > 0)
            {
                flowLayoutPanel4.Controls.RemoveAt(0);
            }
            if (flowLayoutPanel5.Controls.Count > 0)
            {
                flowLayoutPanel5.Controls.RemoveAt(0);
            }
            onaysizsatiskontrol();
        }


        //-----------------------


        public void tedariknakit()//BURASI ÜRETİM VERİSİNİ DİKKATE ALARAK CHART GÜNCELLEMESİ YAPACAK ŞEKİLDE DEĞİŞTİRİLMİŞTİR.
        {
            //while (flowLayoutPanel4.Controls.Count > 1) flowLayoutPanel4.Controls.RemoveAt(0);
            //populatetahsilats();
            //if (flowLayoutPanel4.Controls.Count > 0)
            //{
            //    flowLayoutPanel4.Controls.RemoveAt(0);
            //}
            secondchart();
        }
        public void tedarikhavale()//BURASI TEXTBOX1TEXTCHANGED TETİKLEMESİ YAPACAK ŞEKİLDE DEĞİŞTİRİLMİŞTİR.
        {
            textBox1.Text = "1";
        }
        public void tedarikcek()
        {
            while (flowLayoutPanel2.Controls.Count > 1) flowLayoutPanel2.Controls.RemoveAt(0);
            populatechecks();
            if (flowLayoutPanel2.Controls.Count > 0)
            {
                flowLayoutPanel2.Controls.RemoveAt(0);
            }
        }
        public void tedarikopencek()
        {
            while (flowLayoutPanel3.Controls.Count > 1) flowLayoutPanel3.Controls.RemoveAt(0);
            populateopenchecks();
            if (flowLayoutPanel3.Controls.Count > 0)
            {
                flowLayoutPanel3.Controls.RemoveAt(0);
            }
        }
        public void tedariksenet()
        {
            while (flowLayoutPanel5.Controls.Count > 1) flowLayoutPanel5.Controls.RemoveAt(0);
            populatesenets();
            if (flowLayoutPanel5.Controls.Count > 0)
            {
                flowLayoutPanel5.Controls.RemoveAt(0);
            }
        }
        public void tahsilat()
        {
            while (flowLayoutPanel4.Controls.Count > 1) flowLayoutPanel4.Controls.RemoveAt(0);
            populatetahsilats();
            if (flowLayoutPanel4.Controls.Count > 0)
            {
                flowLayoutPanel4.Controls.RemoveAt(0);
            }
        }
        ////>>>>
        ///

    }
}
