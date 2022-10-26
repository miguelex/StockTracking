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

namespace StockTracking
{
    public partial class FormAddStock : Form
    {
        public FormAddStock()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        private void FormAddStock_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Products;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Category Name";
            dataGridView1.Columns[2].HeaderText = "Stock Amount";
            dataGridView1.Columns[3].HeaderText = "Price";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            if (dto.Categories.Count > 0)
                combofull = true;
            if (isUpdate)
            {
                txtProductName.Text = detail.ProductName;
                txtPrice.Text = detail.Price.ToString();
            }
        }

        bool combofull = false;
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                List<ProductDetailDTO> list = dto.Products;
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                dataGridView1.DataSource = list;
                if (list.Count == 0)
                {
                    txtPrice.Clear();
                    txtProductName.Clear();
                    txtStock.Clear();
                }

            }
        }

        public ProductDetailDTO detail = new ProductDetailDTO();
        public bool isUpdate = false;
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!isUpdate)
            {
                detail.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtProductName.Text = detail.ProductName;
                detail.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                txtPrice.Text = detail.Price.ToString();
                detail.StockAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                detail.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
                MessageBox.Show("Please select a product from table");
            else if (txtStock.Text.Trim() == "")
                MessageBox.Show("Please give a stock amount");
            else
            {
                int sumstock = detail.StockAmount;
                sumstock += Convert.ToInt32(txtStock.Text);
                detail.StockAmount = sumstock;
                if (bll.Update(detail))
                {
                    MessageBox.Show("Stock was added");
                    bll = new ProductBLL();
                    dto = bll.Select();
                    dataGridView1.DataSource = dto.Products;
                    txtStock.Clear();
                }
            }
        }
    }
}
