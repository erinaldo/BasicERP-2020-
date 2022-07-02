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
    public partial class raporlama : Form
    {
        public raporlama()
        {
            InitializeComponent();
        }
        programLog prlg;
        public void doldurreport()
        {
            string adapterstring = "Select* from report_list";
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter(adapterstring, con);
            try
            {
                adtr.Fill(ds, "report_list");
                dataGridView1.DataSource = ds.Tables["report_list"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                this.dataGridView1.Columns["rep_id"].Visible = false;
                this.dataGridView1.Columns["param3"].Visible = false;
                this.dataGridView1.Columns["param4"].Visible = false;
                this.dataGridView1.Columns["user_id"].Visible = false;
                this.dataGridView1.Columns["edit_date"].Visible = false;
                this.dataGridView1.Columns["insert_date"].Visible = false;

                dataGridView1.Columns[1].HeaderText = "Rapor No";
                dataGridView1.Columns[2].HeaderText = "Rapor Adı";
                dataGridView1.Columns[3].HeaderText = "Rapor Alanı";
                dataGridView1.Columns[4].HeaderText = "Sorgulama Biçimi";

                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                for (int i = 0; i < 6; i++)
                {
                    DataGridViewColumn column = dataGridView1.Columns[i];
                    //DataGridViewRow row = dataGridView1.Rows[i];
                    column.Width = 250;
                    //row.Height = 20;
                }
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    DataGridViewRow row = dataGridView1.Rows[i];
                //    row.Height = 30;
                //}
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
            }
            con.Close();
        }
        private void raporlama_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            doldurreport();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                row.Height = 30;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportparameters rp = new reportparameters(this);
            rp.Show();
        }

        public static string repid, repno, repname, param1, param2, param3, param4;

        private void button2_Click(object sender, EventArgs e)
        {
            raporEkranı rp = new raporEkranı();
            rp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DialogResult c;
            c = MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (c == DialogResult.Yes)
            {
                SqlCommand command1 = new SqlCommand("delete from report_list where rep_id = '" + label1.Text + "'", con);
                con.Open();
                command1.ExecuteNonQuery();
                con.Close();
                doldurreport();
            }
        }

        public static string sorgu;
        public static string sorgu2;
        public static string tablename;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tablename = dataGridView1.CurrentRow.Cells["param1"].Value.ToString();
            label1.Text = dataGridView1.CurrentRow.Cells["rep_id"].Value.ToString();



            if (dataGridView1.CurrentRow.Cells["param1"].Value.ToString() == "Satış Raporu")
            {
                if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Belirli Tarihe Göre")
                {
                    sorgu = "SELECT tbl_sale.slip_no as fisNo,tbl_sale.allcost - tbl_sale.charged_money as fistenTahsilEdilecekPara, stock_name as urunAdi, SUM(quantity) AS satilanMiktar , CONVERT(varchar, sold_date, 120) as satisTarihi, customer_name, sale_details.total_price as urunlerinFiyati, case when tbl_sale.slip_type = '1' then 'Nakit' when tbl_sale.slip_type = '2' then 'Havale' when tbl_sale.slip_type = '3' then 'Çek' when tbl_sale.slip_type = '4' then 'Açık Hesap' when tbl_sale.slip_type = '5' then 'Senet' end as fisturu FROM tbl_sale inner join sale_details ON tbl_sale.slip_id = sale_details.slip_id inner join tbl_stock on tbl_stock.stock_id = sale_details.stock_id inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id where tbl_sale.status = '0'  and cast (datediff (day, 0, tbl_sale.sold_date) as datetime) = '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and tbl_sale.boss_date is not null GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, quantity, stock_name, customer_name,sale_details.total_price,tbl_sale.allcost, tbl_sale.charged_money, tbl_sale.slip_type ORDER BY sold_date desc;";
                }//ENSON BURADAYDIM SALEDETAILS-STATUS DURUMUNU SORGULARA ENTEGRE EDİYORDUM 24.05.2021
                else if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Belirtilen İki Tarih Aralığına Göre")
                {
                    sorgu = "SELECT tbl_sale.slip_no as fisNo,tbl_sale.allcost - tbl_sale.charged_money as fistenTahsilEdilecekPara, stock_name as urunAdi, SUM(quantity) AS satilanMiktar , CONVERT(varchar, sold_date, 120) as satisTarihi, customer_name, sale_details.total_price as urunlerinFiyati, case when tbl_sale.slip_type = '1' then 'Nakit' when tbl_sale.slip_type = '2' then 'Havale' when tbl_sale.slip_type = '3' then 'Çek' when tbl_sale.slip_type = '4' then 'Açık Hesap' when tbl_sale.slip_type = '5' then 'Senet' end as fisturu FROM tbl_sale inner join sale_details ON tbl_sale.slip_id = sale_details.slip_id inner join tbl_stock on tbl_stock.stock_id = sale_details.stock_id inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id where tbl_sale.status = '0'  and tbl_sale.sold_date BETWEEN '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and '" + dataGridView1.CurrentRow.Cells["param4"].Value.ToString() + "' and tbl_sale.boss_date is not null GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, quantity, stock_name, customer_name,sale_details.total_price,tbl_sale.allcost, tbl_sale.charged_money, tbl_sale.slip_type ORDER BY sold_date desc;";
                }
                else if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Son X Günlük")
                {
                    sorgu = "SELECT tbl_sale.slip_no as fisNo,tbl_sale.allcost - tbl_sale.charged_money as fistenTahsilEdilecekPara, stock_name as urunAdi, SUM(quantity) AS satilanMiktar , CONVERT(varchar, sold_date, 120) as satisTarihi, customer_name, sale_details.total_price as urunlerinFiyati, case when tbl_sale.slip_type = '1' then 'Nakit' when tbl_sale.slip_type = '2' then 'Havale' when tbl_sale.slip_type = '3' then 'Çek' when tbl_sale.slip_type = '4' then 'Açık Hesap' when tbl_sale.slip_type = '5' then 'Senet' end as fisturu FROM tbl_sale inner join sale_details ON tbl_sale.slip_id = sale_details.slip_id inner join tbl_stock on tbl_stock.stock_id = sale_details.stock_id inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id where tbl_sale.status = '0'  and tbl_sale.sold_date >= DATEADD(DAY, -" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + ", GETDATE()) and tbl_sale.boss_date is not null GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, quantity, stock_name, customer_name,sale_details.total_price,tbl_sale.allcost, tbl_sale.charged_money, tbl_sale.slip_type ORDER BY sold_date desc;";
                }
                else
                {
                    sorgu = "SELECT stock_name, quantity, CONVERT(varchar, sold_date, 120) as satisTarihi, customer_name, tbl_sale.allcost - tbl_sale.charged_money as tahsilEdilecekMiktar, case when tbl_sale.slip_type = '1' then 'Nakit' when tbl_sale.slip_type = '2' then 'Havale' when tbl_sale.slip_type = '3' then 'Çek' when tbl_sale.slip_type = '4' then 'Açık Hesap' when tbl_sale.slip_type = '5' then 'Senet' end as fisturu FROM tbl_stock inner join sale_details ON tbl_stock.stock_id = sale_details.stock_id inner join tbl_sale on tbl_sale.slip_id = sale_details.slip_id inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id where tbl_sale.status = '0'and tbl_stock.stock_name = '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and tbl_sale.boss_date is not null GROUP BY  tbl_sale.sold_date, quantity, stock_name, customer_name, tbl_sale.charged_money, tbl_sale.allcost, tbl_sale.slip_type ORDER BY sold_date asc;";
                }
            }
            else if (dataGridView1.CurrentRow.Cells["param1"].Value.ToString() == "Tedarik Raporu")
            {
                if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Belirli Tarihe Göre")
                {
                    sorgu = "SELECT acq.slip_no as fisNo,acq.allcost - acq.paid_money as fistenKalanBorc,material_name, quantity as tedarikEdilenMiktar, CONVERT(varchar, acquisition_date, 120) as tedarikTarihi, customer_name as tedarikci, material_details.price as materyalinFiyatı, case when acq.slip_type = '1' then 'Nakit' when acq.slip_type = '2' then 'Havale' when acq.slip_type = '3' then 'Çek' when acq.slip_type = '4' then 'Açık Hesap' when acq.slip_type = '5' then 'Senet' end as fisturu FROM tbl_material inner join material_details ON tbl_material.material_id = material_details.material_id inner join acq on acq.slip_id = material_details.slip_id inner join tbl_customer on tbl_customer.customer_id = acq.customer_id where acq.status = '1' and cast (datediff (day, 0, acq.acquisition_date) as datetime) = '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' GROUP BY  acq.slip_no,acq.acquisition_date, quantity, material_name, customer_name, acq.paid_money, acq.allcost, acq.slip_type, material_details.price ORDER BY acquisition_date asc;";
                }
                else if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Belirtilen İki Tarih Aralığına Göre")
                {
                    sorgu = "SELECT acq.slip_no as fisNo,acq.allcost - acq.paid_money as fistenKalanBorc,material_name, quantity as tedarikEdilenMiktar, CONVERT(varchar, acquisition_date, 120) as tedarikTarihi, customer_name as tedarikci, material_details.price as materyalinFiyatı, case when acq.slip_type = '1' then 'Nakit' when acq.slip_type = '2' then 'Havale' when acq.slip_type = '3' then 'Çek' when acq.slip_type = '4' then 'Açık Hesap' when acq.slip_type = '5' then 'Senet' end as fisturu FROM tbl_material inner join material_details ON tbl_material.material_id = material_details.material_id inner join acq on acq.slip_id = material_details.slip_id inner join tbl_customer on tbl_customer.customer_id = acq.customer_id where acq.status = '1' and  acq.acquisition_date BETWEEN '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and '" + dataGridView1.CurrentRow.Cells["param4"].Value.ToString() + "' GROUP BY  acq.slip_no,acq.acquisition_date, quantity, material_name, customer_name, acq.paid_money, acq.allcost, acq.slip_type, material_details.price ORDER BY acquisition_date asc;";
                }
                else if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Son X Günlük")
                {
                    sorgu = "SELECT acq.slip_no as fisNo,acq.allcost - acq.paid_money as fistenKalanBorc,material_name, quantity as tedarikEdilenMiktar, CONVERT(varchar, acquisition_date, 120) as tedarikTarihi, customer_name as tedarikci, material_details.price as materyalinFiyatı, case when acq.slip_type = '1' then 'Nakit' when acq.slip_type = '2' then 'Havale' when acq.slip_type = '3' then 'Çek' when acq.slip_type = '4' then 'Açık Hesap' when acq.slip_type = '5' then 'Senet' end as fisturu FROM tbl_material inner join material_details ON tbl_material.material_id = material_details.material_id inner join acq on acq.slip_id = material_details.slip_id inner join tbl_customer on tbl_customer.customer_id = acq.customer_id where acq.status = '1' and  acq.acquisition_date >= DATEADD(DAY, -" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + ", GETDATE()) GROUP BY  acq.slip_no,acq.acquisition_date, quantity, material_name, customer_name, acq.paid_money, acq.allcost, acq.slip_type, material_details.price ORDER BY acquisition_date asc;";
                }
                else
                {
                    sorgu = "SELECT material_name, quantity, CONVERT(varchar, acquisition_date, 120) as tedarikTarihi, customer_name as tedarikci, acq.allcost - acq.paid_money as tahsilEdilecekMiktar, case when acq.slip_type = '1' then 'Nakit' when acq.slip_type = '2' then 'Havale' when acq.slip_type = '3' then 'Çek' when acq.slip_type = '4' then 'Açık Hesap' when acq.slip_type = '5' then 'Senet' end as fisturu FROM tbl_material inner join material_details ON tbl_material.material_id = material_details.material_id inner join acq on acq.slip_id = material_details.slip_id inner join tbl_customer on tbl_customer.customer_id = acq.customer_id where acq.status = '1' and tbl_material.material_name = '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' GROUP BY  acq.acquisition_date, quantity, material_name, customer_name, acq.paid_money, acq.allcost, acq.slip_type ORDER BY acquisition_date asc;";
                }
            }
            else if (dataGridView1.CurrentRow.Cells["param1"].Value.ToString() == "Üretim Raporu")
            {
                if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Belirli Tarihe Göre")
                {
                    sorgu = "SELECT stock_name, quantity as uretilenMiktar, CONVERT(varchar, stock_details.insert_date, 120) as uretimTarihi, user_name as uretimiOnaylayanKullanıcı FROM tbl_stock inner join stock_details ON tbl_stock.stock_id = stock_details.stock_id inner join tbl_user on stock_details.user_id = tbl_user.user_id where tbl_stock.stock_status = '1' and cast (datediff (day, 0, stock_details.insert_date) as datetime) = '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' ORDER BY insert_date desc;";
                }
                else if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Belirtilen İki Tarih Aralığına Göre")
                {
                    sorgu = "SELECT stock_name, quantity as uretilenMiktar, CONVERT(varchar, stock_details.insert_date, 120) as uretimTarihi, user_name as uretimiOnaylayanKullanıcı FROM tbl_stock inner join stock_details ON tbl_stock.stock_id = stock_details.stock_id inner join tbl_user on stock_details.user_id = tbl_user.user_id where tbl_stock.stock_status = '1' and stock_details.insert_date BETWEEN '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and '" + dataGridView1.CurrentRow.Cells["param4"].Value.ToString() + "' ORDER BY insert_date desc;";
                }
                else if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Son X Günlük")
                {
                    sorgu = "SELECT stock_name, quantity as uretilenMiktar, CONVERT(varchar, stock_details.insert_date, 120) as uretimTarihi, user_name as uretimiOnaylayanKullanıcı FROM tbl_stock inner join stock_details ON tbl_stock.stock_id = stock_details.stock_id inner join tbl_user on stock_details.user_id = tbl_user.user_id where tbl_stock.stock_status = '1' and stock_details.insert_date >= DATEADD(DAY, -" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + ", GETDATE()) ORDER BY insert_date desc;";
                }
                else
                {
                    sorgu = "SELECT stock_name, quantity as uretilenMiktar, CONVERT(varchar, stock_details.insert_date, 120) as uretimTarihi, user_name as uretimiOnaylayanKullanıcı FROM tbl_stock inner join stock_details ON tbl_stock.stock_id = stock_details.stock_id inner join tbl_user on stock_details.user_id = tbl_user.user_id where tbl_stock.stock_status = '1' and stock_name = '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' ORDER BY insert_date desc;";
                }
            }
            else if (dataGridView1.CurrentRow.Cells["param1"].Value.ToString() == "Materyal Raporu")
            {
                if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Belirli Tarihe Göre")
                {
                    sorgu = "SELECT material_name, quantity as tedarikEdilenMiktar, CONVERT(varchar, acq.acquisition_date, 120) as tedarikTarihi, user_name as tedarikEdenKullanıcı FROM tbl_material inner join material_details ON tbl_material.material_id = material_details.material_id inner join tbl_user on material_details.user_id = tbl_user.user_id inner join acq on acq.slip_id = material_details.slip_id where tbl_material.material_status = '1' and cast (datediff (day, 0, acq.acquisition_date) as datetime) = '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' ORDER BY acq.acquisition_date desc;";
                }
                else if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Belirtilen İki Tarih Aralığına Göre")
                {
                    sorgu = "SELECT material_name, quantity as tedarikEdilenMiktar, CONVERT(varchar, acq.acquisition_date, 120) as tedarikTarihi, user_name as tedarikEdenKullanıcı FROM tbl_material inner join material_details ON tbl_material.material_id = material_details.material_id inner join tbl_user on material_details.user_id = tbl_user.user_id inner join acq on acq.slip_id = material_details.slip_id where tbl_material.material_status = '1' and acq.acquisition_date BETWEEN '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and '" + dataGridView1.CurrentRow.Cells["param4"].Value.ToString() + "' ORDER BY acq.acquisition_date desc;";
                }
                else if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Son X Günlük")
                {
                    sorgu = "SELECT material_name, quantity as tedarikEdilenMiktar, CONVERT(varchar, acq.acquisition_date, 120) as tedarikTarihi, user_name as tedarikEdenKullanıcı FROM tbl_material inner join material_details ON tbl_material.material_id = material_details.material_id inner join tbl_user on material_details.user_id = tbl_user.user_id inner join acq on acq.slip_id = material_details.slip_id where tbl_material.material_status = '1' and acq.acquisition_date >= DATEADD(DAY, -" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + ", GETDATE()) ORDER BY acq.acquisition_date desc;";
                }
                else
                {
                    sorgu = "SELECT material_name, quantity as tedarikEdilenMiktar, CONVERT(varchar, acq.acquisition_date, 120) as tedarikTarihi, user_name as tedarikEdenKullanıcı FROM tbl_material inner join material_details ON tbl_material.material_id = material_details.material_id inner join tbl_user on material_details.user_id = tbl_user.user_id inner join acq on acq.slip_id = material_details.slip_id where tbl_material.material_status = '1' and material_name = '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' ORDER BY acq.acquisition_date desc;";
                }
            }
            else if (dataGridView1.CurrentRow.Cells["param1"].Value.ToString() == "Stok Raporu")
            {
                if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Belirli Tarihe Göre")
                {
                    sorgu = "SELECT stock_name, stock_amount, sum(sale_details.total_price)/sum(sale_details.quantity) as musteriTalebi, cur_name, sum(sale_details.quantity) as satilanAdet FROM tbl_stock inner join sale_details on tbl_stock.stock_id = sale_details.stock_id inner join tbl_sale on tbl_sale.slip_id = sale_details.slip_id inner join currency on currency.cur_id = sale_details.currency where tbl_stock.stock_status = '1' and tbl_sale.status = '0' and cast (datediff (day, 0, tbl_sale.sold_date) as datetime) = '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "'  and tbl_sale.boss_date is not null group by stock_name, stock_amount, cur_name";
                }
                else if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Belirtilen İki Tarih Aralığına Göre")
                {
                    sorgu = "SELECT stock_name, stock_amount, sum(sale_details.total_price)/sum(sale_details.quantity) as musteriTalebi, cur_name, sum(sale_details.quantity) as satilanAdet FROM tbl_stock inner join sale_details on tbl_stock.stock_id = sale_details.stock_id inner join tbl_sale on tbl_sale.slip_id = sale_details.slip_id inner join currency on currency.cur_id = sale_details.currency where tbl_stock.stock_status = '1' and tbl_sale.sold_date BETWEEN '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and '"+ dataGridView1.CurrentRow.Cells["param4"].Value.ToString() + "' and tbl_sale.boss_date is not null group by stock_name, stock_amount, cur_name";
                }
                else if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Son X Günlük")
                {
                    sorgu = "SELECT stock_name, stock_amount, sum(sale_details.total_price)/sum(sale_details.quantity) as musteriTalebi, cur_name, sum(sale_details.quantity) as satilanAdet FROM tbl_stock inner join sale_details on tbl_stock.stock_id = sale_details.stock_id inner join tbl_sale on tbl_sale.slip_id = sale_details.slip_id inner join currency on currency.cur_id = sale_details.currency where tbl_stock.stock_status = '1' and tbl_sale.sold_date >= DATEADD(DAY, -" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + ", GETDATE()) and tbl_sale.boss_date is not null group by stock_name, stock_amount, cur_name";
                }
                else
                {
                    sorgu = "SELECT stock_name, stock_amount, sum(sale_details.total_price)/sum(sale_details.quantity) as musteriTalebi, cur_name, sum(sale_details.quantity) as satilanAdet FROM tbl_stock inner join sale_details on tbl_stock.stock_id = sale_details.stock_id inner join tbl_sale on tbl_sale.slip_id = sale_details.slip_id inner join currency on currency.cur_id = sale_details.currency where tbl_stock.stock_status = '1' and tbl_stock.stock_name = '" + dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and tbl_sale.boss_date is not null group by stock_name, stock_amount, cur_name";
                }
            }
            else if (dataGridView1.CurrentRow.Cells["param1"].Value.ToString() == "Tahsilat Raporu")
            {
                if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Belirli Tarihe Göre")
                {
                    sorgu = "SELECT tbl_sale.slip_no as fisNo, tbl_sale.charged_money as tahsilEdilenMiktar, cur_name, CONVERT(varchar, tbl_sale.payment_date, 120) as tahsilatTarihi,customer_name, case when tbl_sale.slip_type = '1' then 'Nakit' when tbl_sale.slip_type = '2' then 'Havale'  end as fisturu FROM tbl_sale inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id inner join currency on currency.cur_id = tbl_sale.currency where tbl_sale.status = '0' and cast (datediff (day, 0, tbl_sale.sold_date) as datetime) = '"+ dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and (tbl_sale.slip_type = '1' or tbl_sale.slip_type = '2') GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, customer_name, tbl_sale.charged_money, tbl_sale.slip_type, tbl_sale.payment_date, cur_name ORDER BY sold_date desc;";
                    sorgu2 = "SELECT tbl_sale.slip_no as fisNo, sale_opencheck.charged_money as tahsilEdilenMiktar, cur_name, CONVERT(varchar, sale_opencheck.payment_date, 120) as tahsilatTarihi, customer_name, case when tbl_sale.slip_type = '3' then 'Çek' when tbl_sale.slip_type = '4' then 'Açık Hesap' when tbl_sale.slip_type = '5' then 'Senet' end as fisturu FROM tbl_sale inner join sale_opencheck on sale_opencheck.slip_id = tbl_sale.slip_id inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id inner join currency on currency.cur_id = tbl_sale.currency where tbl_sale.status = '0' and cast (datediff (day, 0, sale_opencheck.payment_date) as datetime) = '"+ dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "'  and (tbl_sale.slip_type = '3' or tbl_sale.slip_type = '4' or tbl_sale.slip_type = '5') GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, customer_name, sale_opencheck.charged_money, tbl_sale.slip_type, sale_opencheck.payment_date, cur_name ORDER BY sold_date desc;";
                }
                else if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Belirtilen İki Tarih Aralığına Göre")
                {//şuralara currency olayını ekleyeceğim
                    sorgu = "SELECT tbl_sale.slip_no as fisNo, tbl_sale.charged_money as tahsilEdilenMiktar, cur_name, CONVERT(varchar, tbl_sale.payment_date, 120) as tahsilatTarihi,customer_name, case when tbl_sale.slip_type = '1' then 'Nakit' when tbl_sale.slip_type = '2' then 'Havale'  end as fisturu FROM tbl_sale inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id inner join currency on currency.cur_id = tbl_sale.currency where tbl_sale.status = '0' and tbl_sale.sold_date BETWEEN '"+ dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and '"+ dataGridView1.CurrentRow.Cells["param4"].Value.ToString() + "' and (tbl_sale.slip_type = '1' or tbl_sale.slip_type = '2') GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, customer_name, tbl_sale.charged_money, tbl_sale.slip_type, tbl_sale.payment_date, cur_name ORDER BY sold_date desc;";
                    sorgu2 = "SELECT tbl_sale.slip_no as fisNo, sale_opencheck.charged_money as tahsilEdilenMiktar, cur_name, CONVERT(varchar, sale_opencheck.payment_date, 120) as tahsilatTarihi, customer_name, case when tbl_sale.slip_type = '3' then 'Çek' when tbl_sale.slip_type = '4' then 'Açık Hesap' when tbl_sale.slip_type = '5' then 'Senet' end as fisturu FROM tbl_sale inner join sale_opencheck on sale_opencheck.slip_id = tbl_sale.slip_id inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id inner join currency on currency.cur_id = tbl_sale.currency where tbl_sale.status = '0' and sale_opencheck.payment_date BETWEEN '"+ dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and '"+ dataGridView1.CurrentRow.Cells["param4"].Value.ToString() + "'  and (tbl_sale.slip_type = '3' or tbl_sale.slip_type = '4' or tbl_sale.slip_type = '5') GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, customer_name, sale_opencheck.charged_money, tbl_sale.slip_type, sale_opencheck.payment_date, cur_name ORDER BY sold_date desc;";
                }
                else if (dataGridView1.CurrentRow.Cells["param2"].Value.ToString() == "Son X Günlük")
                {
                    sorgu = "SELECT tbl_sale.slip_no as fisNo, tbl_sale.charged_money as tahsilEdilenMiktar, cur_name, CONVERT(varchar, tbl_sale.payment_date, 120) as tahsilatTarihi,customer_name, case when tbl_sale.slip_type = '1' then 'Nakit' when tbl_sale.slip_type = '2' then 'Havale'  end as fisturu FROM tbl_sale inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id inner join currency on currency.cur_id = tbl_sale.currency where tbl_sale.status = '0' and tbl_sale.sold_date >= DATEADD(DAY, -"+ dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + ", GETDATE()) and (tbl_sale.slip_type = '1' or tbl_sale.slip_type = '2') GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, customer_name, tbl_sale.charged_money, tbl_sale.slip_type, tbl_sale.payment_date, cur_name ORDER BY sold_date desc;";
                    sorgu2 = "SELECT tbl_sale.slip_no as fisNo, sale_opencheck.charged_money as tahsilEdilenMiktar, cur_name, CONVERT(varchar, sale_opencheck.payment_date, 120) as tahsilatTarihi, customer_name, case when tbl_sale.slip_type = '3' then 'Çek' when tbl_sale.slip_type = '4' then 'Açık Hesap' when tbl_sale.slip_type = '5' then 'Senet' end as fisturu FROM tbl_sale inner join sale_opencheck on sale_opencheck.slip_id = tbl_sale.slip_id inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id inner join currency on currency.cur_id = tbl_sale.currency where tbl_sale.status = '0' and sale_opencheck.payment_date >= DATEADD(DAY, -"+ dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + ", GETDATE()) and (tbl_sale.slip_type = '3' or tbl_sale.slip_type = '4' or tbl_sale.slip_type = '5') GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, customer_name, sale_opencheck.charged_money, tbl_sale.slip_type, sale_opencheck.payment_date, cur_name ORDER BY sold_date desc;";
                }
                else
                {
                    sorgu = "SELECT tbl_sale.slip_no as fisNo, tbl_sale.charged_money as tahsilEdilenMiktar, cur_name, CONVERT(varchar, tbl_sale.payment_date, 120) as tahsilatTarihi,customer_name, case when tbl_sale.slip_type = '1' then 'Nakit' when tbl_sale.slip_type = '2' then 'Havale'  end as fisturu FROM tbl_sale inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id inner join currency on currency.cur_id = tbl_sale.currency where tbl_sale.status = '0' and customer_name = '"+ dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and (tbl_sale.slip_type = '1' or tbl_sale.slip_type = '2') GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, customer_name, tbl_sale.charged_money, tbl_sale.slip_type, tbl_sale.payment_date, cur_name ORDER BY sold_date desc;";
                    sorgu2 = "SELECT tbl_sale.slip_no as fisNo, sale_opencheck.charged_money as tahsilEdilenMiktar, cur_name, CONVERT(varchar, sale_opencheck.payment_date, 120) as tahsilatTarihi, customer_name, case when tbl_sale.slip_type = '3' then 'Çek' when tbl_sale.slip_type = '4' then 'Açık Hesap' when tbl_sale.slip_type = '5' then 'Senet' end as fisturu FROM tbl_sale inner join sale_opencheck on sale_opencheck.slip_id = tbl_sale.slip_id inner join tbl_customer on tbl_customer.customer_id = tbl_sale.customer_id inner join currency on currency.cur_id = tbl_sale.currency where tbl_sale.status = '0' and customer_name = '"+ dataGridView1.CurrentRow.Cells["param3"].Value.ToString() + "' and (tbl_sale.slip_type = '3' or tbl_sale.slip_type = '4' or tbl_sale.slip_type = '5') GROUP BY tbl_sale.slip_no, tbl_sale.sold_date, customer_name, sale_opencheck.charged_money, tbl_sale.slip_type, sale_opencheck.payment_date, cur_name ORDER BY sold_date desc;";
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            repid = dataGridView1.CurrentRow.Cells["rep_id"].Value.ToString();
            repno = dataGridView1.CurrentRow.Cells["rep_no"].Value.ToString();
            repname = dataGridView1.CurrentRow.Cells["rep_name"].Value.ToString();
            param1 = dataGridView1.CurrentRow.Cells["param1"].Value.ToString();
            param2 = dataGridView1.CurrentRow.Cells["param2"].Value.ToString();
            param3 = dataGridView1.CurrentRow.Cells["param3"].Value.ToString();
            param4 = dataGridView1.CurrentRow.Cells["param4"].Value.ToString();
            raporlamas rs = new raporlamas(this);
            rs.Show();
        }
    }
}
