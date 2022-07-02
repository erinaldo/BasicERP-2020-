using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class raporEkranı : Form
    {
        public raporEkranı()
        {
            InitializeComponent();
        }

        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
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

        programLog prlg;
        void raporgetir()
        {
            SqlConnection con = new SqlConnection(BaglanClass.connectionstring);

            //string adapterstring = raporlama.sorgu;
            DataSet ds = new DataSet();
            con.Open();
            SqlCommand command = new SqlCommand(raporlama.sorgu, con);
            DataTable dt = new DataTable();

            try
            {
                if (raporlama.tablename == "Tahsilat Raporu")
                {
                    dataGridView1.Columns.Add("Fiş Numarası", "");
                    dataGridView1.Columns.Add("Tahsil Edilen Miktar", "");
                    dataGridView1.Columns.Add("Para Birimi", "");
                    dataGridView1.Columns.Add("Tahsilat Tarihi", "");
                    dataGridView1.Columns.Add("Müşteri Adı", "");
                    dataGridView1.Columns.Add("Fiş Türü", "");
                    dt.Load(command.ExecuteReader());
                    SqlCommand command2 = new SqlCommand(raporlama.sorgu2, con);
                    DataTable dt2 = new DataTable();
                    dt2.Load(command2.ExecuteReader());
                    dataGridView2.DataSource = dt2;
                    dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.Rows.AddRange(CloneDataGridViewRows(dataGridView2));
                    dataGridView3.DataSource = dt;
                    dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.Rows.AddRange(CloneDataGridViewRows(dataGridView3));
                    dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Descending);
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                    dataGridView1.Columns[0].HeaderText = "Fiş No";
                    dataGridView1.Columns[1].HeaderText = "Tahsil Edilen Miktar";
                    dataGridView1.Columns[2].HeaderText = "Para Birimi";
                    dataGridView1.Columns[3].HeaderText = "Tahsilat Tarihi";
                    dataGridView1.Columns[4].HeaderText = "Müşteri Adı";
                    dataGridView1.Columns[5].HeaderText = "Fiş Türü";
                }
                else if (raporlama.tablename == "Satış Raporu")
                {
                    dt.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dt;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    if (dataGridView1.Columns.Count > 6)
                    {
                        dataGridView1.Columns[0].HeaderText = "Fiş No";
                        dataGridView1.Columns[1].HeaderText = "Fişten Kalan Borç";
                        dataGridView1.Columns[2].HeaderText = "Ürün Adı";
                        dataGridView1.Columns[3].HeaderText = "Satılan Miktar";
                        dataGridView1.Columns[4].HeaderText = "Satış Tarihi";
                        dataGridView1.Columns[5].HeaderText = "Satılan Müşteri";
                        dataGridView1.Columns[6].HeaderText = "Ürün Fiyatı";
                        dataGridView1.Columns[7].HeaderText = "Ödeme Şekli";
                    }
                    else
                    {
                        dataGridView1.Columns[0].HeaderText = "Ürün Adı";
                        dataGridView1.Columns[1].HeaderText = "Satılan Miktar";
                        dataGridView1.Columns[2].HeaderText = "Satıldığı Tarih";
                        dataGridView1.Columns[3].HeaderText = "Satılan Müşteri";
                        dataGridView1.Columns[4].HeaderText = "Müşterinin Borcu";
                        dataGridView1.Columns[5].HeaderText = "Ödeme Şekli";
                    }
                }
                else if (raporlama.tablename == "Tedarik Raporu")
                {
                    dt.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dt;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    if (dataGridView1.Columns.Count > 6)
                    {
                        dataGridView1.Columns[0].HeaderText = "Fiş No";
                        dataGridView1.Columns[1].HeaderText = "Fişe Ödenecek Borç";
                        dataGridView1.Columns[2].HeaderText = "Materyal Adı";
                        dataGridView1.Columns[3].HeaderText = "Tedarik Edilen Miktar";
                        dataGridView1.Columns[4].HeaderText = "Tedarik Tarihi";
                        dataGridView1.Columns[5].HeaderText = "Tedarikçi";
                        dataGridView1.Columns[6].HeaderText = "Materyalin Fiyatı";
                        dataGridView1.Columns[7].HeaderText = "Ödeme Şekli";
                    }
                    else
                    {
                        dataGridView1.Columns[0].HeaderText = "Materyal Adı";
                        dataGridView1.Columns[1].HeaderText = "Tedarik Edilen Miktar";
                        dataGridView1.Columns[2].HeaderText = "Tedarik Tarih";
                        dataGridView1.Columns[3].HeaderText = "Tedarikçi";
                        dataGridView1.Columns[4].HeaderText = "Kalan Borç";
                        dataGridView1.Columns[5].HeaderText = "Ödeme Şekli";
                    }
                }
                else if (raporlama.tablename == "Üretim Raporu")
                {
                    dt.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dt;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.Columns[0].HeaderText = "Ürün Adı";
                    dataGridView1.Columns[1].HeaderText = "Üretilen Miktar";
                    dataGridView1.Columns[2].HeaderText = "Üretim Tarihi";
                    dataGridView1.Columns[3].HeaderText = "Üretimi Giren Kullanıcı";

                }
                else if (raporlama.tablename == "Materyal Raporu")
                {
                    dt.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dt;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.Columns[0].HeaderText = "Materyal Adı";
                    dataGridView1.Columns[1].HeaderText = "Tedarik Edilen Miktar";
                    dataGridView1.Columns[2].HeaderText = "Tedarik Tarihi";
                    dataGridView1.Columns[3].HeaderText = "Tedarik Eden Kullanıcı";
                }
                else if (raporlama.tablename == "Stok Raporu")
                {
                    dt.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dt;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.Columns[0].HeaderText = "Ürün Adı";
                    dataGridView1.Columns[1].HeaderText = "Stoktaki Miktar";
                    dataGridView1.Columns[2].HeaderText = "Müşteri Talebi";
                    dataGridView1.Columns[3].HeaderText = "Döviz Adı";
                    dataGridView1.Columns[4].HeaderText = "Satılan Miktar";
                }

                dataGridView1.BorderStyle = BorderStyle.None;
                dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
                dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    DataGridViewColumn column = dataGridView1.Columns[i];
                    column.Width = 220;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    row.Height = 30;
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
        private void raporEkranı_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            raporgetir();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                copyAlltoClipboard();
                Microsoft.Office.Interop.Excel.Application xlexcel;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlexcel = new Microsoft.Office.Interop.Excel.Application();
                xlexcel.Visible = true;
                xlWorkBook = xlexcel.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            }
            else
            {
                MessageBox.Show("Tabloda kayıt bulunamadı.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            //MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Bu hatanın resmini alarak sağlayıcınıza iletiniz : " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Tabloda kayıt bulunamadı.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
