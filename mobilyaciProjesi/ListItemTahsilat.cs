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
    public partial class ListItemTahsilat : UserControl
    {
        public ListItemTahsilat()
        {
            InitializeComponent();
        }

        #region Properties
        private string _tarih;
        private string _adi;
        private string _birimi;
        private double _miktar;
        private string _fisturu;

        [Category("Custom Props")]
        public string Tarih
        {
            get { return _tarih; }
            set { _tarih = value; label1.Text = value ; }
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
        public string FisTuru
        {
            get { return _fisturu; }
            set { _fisturu = value; label6.Text = value; }
        }
        #endregion
    }
}
