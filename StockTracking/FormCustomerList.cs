﻿using System;
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
    public partial class FormCustomerList : Form
    {
        public FormCustomerList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();    
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormCustomer frm = new FormCustomer();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }
    }
}
