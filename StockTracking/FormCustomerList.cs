﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.BLL;
using StockTracking.DAL.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
            dto = bll.Select();
            dataGridView1.DataSource = dto.Customers;
        }

        CustomerBLL bll = new CustomerBLL();
        CustomerDTO dto = new CustomerDTO();
        private void FormCustomerList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Customers;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Customer Name";
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            List<CustomerDetailDTO> list = dto.Customers;
            list = list.Where(x => x.CustomerName.Contains(txtCustomerName.Text)).ToList();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail = new CustomerDetailDTO();
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.CustomerName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        CustomerDetailDTO detail = new CustomerDetailDTO();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Please select a customer from table");
            else
            {
                FormCustomer frm = new FormCustomer();
                frm.detail = detail;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new CustomerBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Customers;
            }
        }
    }
}
