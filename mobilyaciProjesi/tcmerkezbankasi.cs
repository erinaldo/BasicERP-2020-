using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mobilyaciProjesi
{
    public partial class tcmerkezbankasi : Form
    {
        public tcmerkezbankasi()
        {
            InitializeComponent();
        }
        public int sayac = 0;
        private void tcmerkezbankasi_Load(object sender, EventArgs e)
        {
            webBrowser1.Visible = false;
            timer1.Interval = 1000;
            //WindowState = FormWindowState.Maximized;
            webBrowser1.Navigate("https://www.denizbank.com/oran-ve-fiyatlar/denizbank-kur-bilgileri.aspx");
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.Window.ScrollTo(285, 1122);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sayac == 10)
            {
                webBrowser1.Document.Body.Style = "zoom:75%;";
                //webBrowser1.Document.Window.ScrollTo(293, 460);
                webBrowser1.Visible = true;
                sayac = 0;
                timer1.Stop();
            }
            else
            {
                sayac++;
            }
        }
    }
}
