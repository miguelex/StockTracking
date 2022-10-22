using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.DAL.DTO;
using StockTracking.BLL;

namespace StockTracking
{
    public partial class FormSales : Form
    {
        public FormSales()
        {
            InitializeComponent();
        }

        private void txtProductSalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public SalesDTO dto = new SalesDTO();
        public SalesDetailDTO detail = new SalesDetailDTO();
        private void FormSales_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            gridProducts.DataSource = dto.Products;
            gridProducts.Columns[0].HeaderText = "Product Name";
            gridProducts.Columns[1].HeaderText = "Category Name";
            gridProducts.Columns[2].HeaderText = "Stock Amount";
            gridProducts.Columns[3].HeaderText = "Price";
            gridProducts.Columns[4].Visible = false;
            gridProducts.Columns[5].Visible = false;
            gridProducts.Columns[6].Visible = false;
            gridCustomers.DataSource = dto.Customers;
            gridCustomers.Columns[0].Visible = false;
            gridCustomers.Columns[1].HeaderText = "Customer Name";
            if (dto.Categories.Count > 0)
                combofull = true;
        }

        bool combofull = false;
        SalesBLL bll = new SalesBLL();
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                List<ProductDetailDTO> list = dto.Products;
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
                gridProducts.DataSource = list;
                if (list.Count == 0)
                {
                    txtPrice.Clear();
                    txtProductName.Clear();
                    txtStock.Clear();
                }

            }
        }

        private void txtCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            List<CustomerDetailDTO> list = dto.Customers;
            list = list.Where(x => x.CustomerName.Contains(txtCustomerSearch.Text)).ToList();
            gridCustomers.DataSource = list;
            if (list.Count == 0)
                txtCustomerName.Clear();
        }

        private void gridProducts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = gridProducts.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.Price = Convert.ToInt32(gridProducts.Rows[e.RowIndex].Cells[3].Value);
            detail.StockAmount = Convert.ToInt32(gridProducts.Rows[e.RowIndex].Cells[2].Value);
            detail.ProductID = Convert.ToInt32(gridProducts.Rows[e.RowIndex].Cells[4].Value);
            detail.CategoryID = Convert.ToInt32(gridProducts.Rows[e.RowIndex].Cells[5].Value);
            txtProductName.Text = detail.ProductName;
            txtPrice.Text = detail.Price.ToString();
            txtStock.Text = detail.StockAmount.ToString();
        }

        private void gridCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.CustomerName = gridCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.CustomerID = Convert.ToInt32(gridCustomers.Rows[e.RowIndex].Cells[0].Value);
            txtCustomerName.Text = detail.CustomerName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
                MessageBox.Show("Please select a product from product table");
            else if (detail.CustomerID == 0)
                MessageBox.Show("Please select a customer from customer table");
            else if (detail.StockAmount < Convert.ToInt32(txtProductSalesAmount.Text))
                MessageBox.Show("You have bot enough product for sale");
            else
            {
                detail.SalesAmount = Convert.ToInt32(txtProductSalesAmount.Text);
                detail.SalesDate = DateTime.Today;
                if (bll.Insert(detail))
                {
                    MessageBox.Show("Sales was added");
                    bll = new SalesBLL();
                    dto = bll.Select();
                    gridProducts.DataSource = dto.Products;
                    dto.Customers = dto.Customers;
                    combofull = false;
                    cmbCategory.DataSource = dto.Categories;
                    if (dto.Products.Count > 0)
                        combofull = true;
                    txtProductSalesAmount.Clear();

                }
            }
        }
    }
}
