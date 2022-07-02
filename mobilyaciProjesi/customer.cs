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
    public partial class customer : Form
    {
        //public string connectionstring = @"Data Source = DESKTOP-H56L443\SQLEXPRESS ; Initial Catalog = mobilyaci ; User ID = sa ; Password = 12345";

        public customer()
        {
            InitializeComponent();
        }
        programLog prlg;
        public void doldurcustomer()
        {
            string adapterstring;
            if (home.carikartturu == 1)
            {
                adapterstring = "Select* from tbl_customer where not delete_status = '1' and type = '1'";
            }
            else
            {
                adapterstring = "Select* from tbl_customer where not delete_status = '1' and type = '0'";
            }
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adtr = new SqlDataAdapter(adapterstring, con);
            try
            {
                adtr.Fill(ds, "tbl_customer");
                dataGridView1.DataSource = ds.Tables["tbl_customer"];
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                adtr.Dispose();
                this.dataGridView1.Columns["customer_id"].Visible = false;
                this.dataGridView1.Columns["customer_add_date"].Visible = false;
                this.dataGridView1.Columns["type"].Visible = false;
                this.dataGridView1.Columns["delete_status"].Visible = false;
                this.dataGridView1.Columns["user_id"].Visible = false;
                this.dataGridView1.Columns["edit_date"].Visible = false;

                dataGridView1.Columns[1].HeaderText = "Cari Kart No";
                dataGridView1.Columns[2].HeaderText = "Cari Kart Adı";
                dataGridView1.Columns[3].HeaderText = "Cari Kart GSM";
                dataGridView1.Columns[4].HeaderText = "Cari Kart GSM2";
                dataGridView1.Columns[5].HeaderText = "Cari Kart E-mail";
                dataGridView1.Columns[6].HeaderText = "Cari Kart Adres";
                dataGridView1.Columns[7].HeaderText = "Cari Kart Sektör";
                dataGridView1.Columns[8].HeaderText = "Cari Kart IBAN";
                dataGridView1.Columns[9].HeaderText = "Cari Kart Temsilci Adı";
                dataGridView1.Columns[11].HeaderText = "Cari Kart Durumu";

                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                for (int i = 0; i < 12; i++)
                {
                    DataGridViewColumn column = dataGridView1.Columns[i];
                    column.Width = 125;
                    if (i == 8)
                    {
                        column.Width = 200;
                    }
                }
            }
            catch (SqlException ex)
            {
                prlg = new programLog(ex.Message, this.Text, "PRLG1");//PROGRAMLOG
                prlg.databaseinsert();
                MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG1", "Sistem Mesajı");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customer_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            dataGridView1.RowTemplate.Height = 30;


            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("Cari Kart Numarasına Göre");
            comboBox1.Items.Add("Cari Kart Adına Göre");
            comboBox1.Items.Add("GSM Numarasına Göre");
            comboBox1.Items.Add("GSM2 Numarasına Göre");
            comboBox1.Items.Add("Mail Adresine Göre");
            comboBox1.Items.Add("Cari Kart Adresine Göre");
            comboBox1.Items.Add("Cari Kart Sektörüne Göre");
            comboBox1.Items.Add("IBAN Numarasına Göre");
            comboBox1.Items.Add("Cari Kart Temsilcisi Adına Göre");
            comboBox1.Items.Add("Cari Kart Eklenme Tarihine Göre");
            comboBox1.Items.Add("Cari Kart Durumuna Göre");
            doldurcustomer();
        }


        public static string customerno, customername, customergsm, customergsm2, customeremail, customersector, customeriban, customeragent, customeraddress, customerstatus;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Cari Kart Numarasına Göre")
            {
                colname3 = "customer_no";
            }
            else if (comboBox1.Text == "Cari Kart Adına Göre")
            {
                colname3 = "customer_name";
            }
            else if (comboBox1.Text == "GSM Numarasına Göre")
            {
                colname3 = "customer_gsm";
            }
            else if (comboBox1.Text == "GSM2 Numarasına Göre")
            {
                colname3 = "customer_gsm2";
            }
            else if (comboBox1.Text == "Mail Adresine Göre")
            {
                colname3 = "customer_email";
            }
            else if (comboBox1.Text == "Cari Kart Adresine Göre")
            {
                colname3 = "customer_address";
            }
            else if (comboBox1.Text == "Cari Kart Sektörüne Göre")
            {
                colname3 = "customer_sector";
            }
            else if (comboBox1.Text == "IBAN Numarasına Göre")
            {
                colname3 = "customer_iban";
            }
            else if (comboBox1.Text == "Cari Kart Temsilcisi Adına Göre")
            {
                colname3 = "customer_agent";
            }
            else if (comboBox1.Text == "Cari Kart Eklenme Tarihine Göre")
            {
                colname3 = "customer_add_date";
            }
            else if (comboBox1.Text == "Cari Kart Durumuna Göre")
            {
                colname3 = "customer_status";
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "Ara")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    doldurcustomer();
                }
                else
                {
                    SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                    string sorgu = "select * from tbl_customer where " + colname3 + " like '%" + textBox1.Text + "%'";
                    con.Open();
                    SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                    DataSet goster = new DataSet();
                    try
                    {
                        getir.Fill(goster, "tbl_customer");
                        dataGridView1.DataSource = goster.Tables["tbl_customer"];
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        getir.Dispose();
                    }
                    catch (SqlException ex)
                    {
                        prlg = new programLog(ex.Message, this.Text, "PRLG2");//PROGRAMLOG
                        prlg.databaseinsert();
                        MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG2", "Sistem Mesajı");
                    }
                    con.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                doldurcustomer();
            }
            else
            {
                SqlConnection con = new SqlConnection(BaglanClass.connectionstring);
                string sorgu = "select * from tbl_customer where " + colname3 + " like '%" + textBox1.Text + "%'";
                con.Open();
                SqlDataAdapter getir = new SqlDataAdapter(sorgu, con);
                DataSet goster = new DataSet();
                try
                {
                    getir.Fill(goster, "tbl_customer");
                    dataGridView1.DataSource = goster.Tables["tbl_customer"];
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    getir.Dispose();
                }
                catch (SqlException ex)
                {
                    prlg = new programLog(ex.Message, this.Text, "PRLG3");//PROGRAMLOG
                    prlg.databaseinsert();
                    MessageBox.Show("Veritabanı hatası meydana geldi. Lütfen bu mesajın ekran görüntüsünü alıp sağlayıcınıza iletiniz. Kod:PRLG3", "Sistem Mesajı");
                }
                con.Close();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ara";
            }
        }

        private void customer_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ara";
            }
        }

        public static string colname3;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;

            if (dataGridView1.Columns[columnIndex].Name == "customer_no")
            {
                comboBox1.Text = "Cari Kart Numarasına Göre";
                colname3 = "customer_no";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_name")
            {
                comboBox1.Text = "Cari Kart Adına Göre";
                colname3 = "customer_name";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_gsm")
            {
                comboBox1.Text = "GSM Numarasına Göre";
                colname3 = "customer_gsm";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_gsm2")
            {
                comboBox1.Text = "GSM2 Numarasına Göre";
                colname3 = "customer_gsm2";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_email")
            {
                comboBox1.Text = "Mail Adresine Göre";
                colname3 = "customer_email";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_address")
            {
                comboBox1.Text = "Cari Kart Adresine Göre";
                colname3 = "customer_address";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_sector")
            {
                comboBox1.Text = "Cari Kart Sektörüne Göre";
                colname3 = "customer_sector";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_iban")
            {
                comboBox1.Text = "IBAN Numarasına Göre";
                colname3 = "customer_iban";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_agent")
            {
                comboBox1.Text = "Cari Kart Temsilcisi Adına Göre";
                colname3 = "customer_agent";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_add_date")
            {
                comboBox1.Text = "Cari Kart Eklenme Tarihine Göre";
                colname3 = "customer_add_date";
            }
            else if (dataGridView1.Columns[columnIndex].Name == "customer_status")
            {
                comboBox1.Text = "Cari Kart Durumuna Göre";
                colname3 = "customer_status";
            }
            else
            {

            }
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ara";
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            customerno = dataGridView1.CurrentRow.Cells["customer_no"].Value.ToString();
            customername = dataGridView1.CurrentRow.Cells["customer_name"].Value.ToString();
            customergsm = dataGridView1.CurrentRow.Cells["customer_gsm"].Value.ToString();
            customergsm2 = dataGridView1.CurrentRow.Cells["customer_gsm2"].Value.ToString();
            customeremail = dataGridView1.CurrentRow.Cells["customer_email"].Value.ToString();
            customersector = dataGridView1.CurrentRow.Cells["customer_sector"].Value.ToString();
            customeriban = dataGridView1.CurrentRow.Cells["customer_iban"].Value.ToString();
            customeragent = dataGridView1.CurrentRow.Cells["customer_agent"].Value.ToString();
            customeraddress = dataGridView1.CurrentRow.Cells["customer_address"].Value.ToString();
            customerstatus = dataGridView1.CurrentRow.Cells["customer_status"].Value.ToString();
            customers cs = new customers(this);
            cs.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customeradd cs = new customeradd(this);
            cs.Show();
        }
    }
}
