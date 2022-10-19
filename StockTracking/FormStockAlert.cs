using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockTracking
{
    public partial class FormStockAlert : Form
    {
        public FormStockAlert()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FormMain frm = new FormMain();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
