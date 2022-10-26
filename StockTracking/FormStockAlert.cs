using System;
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

        ProductBLL bll = new ProductBLL();
        ProductDTO dto = new ProductDTO();
        private void FormStockAlert_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dto.Products = dto.Products.Where(x => x.StockAmount <= 10).ToList();
            dataGridView1.DataSource = dto.Products;
            if (dto.Products.Count == 0)
            {
                FormMain frm = new FormMain();
                this.Hide();
                frm.ShowDialog();
            }
            else
            {
                dataGridView1.Columns[0].HeaderText = "Product Name";
                dataGridView1.Columns[1].HeaderText = "Category Name";
                dataGridView1.Columns[2].HeaderText = "Stock Amount";
                dataGridView1.Columns[3].HeaderText = "Price";
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
            }
        }

        ProductDetailDTO selected = new ProductDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            selected.ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            selected.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            selected.ProductID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
            selected.Price = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            selected.StockAmount = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {           
            FormAddStock frm = new FormAddStock();
            frm.detail = selected;
            frm.isUpdate = true;
            
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            ProductDTO dto = new ProductDTO();
            dto = bll.Select();
            dto.Products = dto.Products.Where(x => x.StockAmount <= 10).ToList();
            dataGridView1.DataSource = dto.Products;
        }
    }
}
