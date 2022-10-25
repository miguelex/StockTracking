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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            FormSalesList frm = new FormSalesList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            FormProductList frm = new FormProductList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FormCustomerList frm = new FormCustomerList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnDeleted_Click(object sender, EventArgs e)
        {
            FormDeleted frm = new FormDeleted();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddStock frm = new FormAddStock();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            FormCategoryList frm = new FormCategoryList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FormLogin frmMain = new FormLogin();
            this.Hide();
            frmMain.ShowDialog();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            FormUserList frm = new FormUserList();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            switch (UserStatic.RolID)
            {
                case 1:
                    btnCustomer.Visible = false;
                    btnProduct.Visible = false;
                    btnAdd.Visible = false;
                    btnCategory.Visible = false;
                    btnDeleted.Visible = false;
                    btnUser.Visible = false;
                    btnSales.Location = new Point(23, 12);
                    btnExit.Location = new Point(159, 12);
                    break;
                case 2:
                    btnCustomer.Visible = false;
                    btnDeleted.Visible = false;
                    btnSales.Visible = false;
                    btnUser.Visible = false;
                    btnProduct.Location = new Point(23, 12);
                    btnCategory.Location = new Point(159, 12);
                    btnAdd.Location = new Point(296, 12);
                    btnExit.Location = new Point(159, 140);
                    break;
                case 3:
                    btnSales.Visible = false;
                    btnAdd.Visible = false;
                    btnCategory.Visible = false;
                    btnDeleted.Visible = false;
                    btnUser.Visible = false;
                    btnExit.Location = new Point(296, 12);
                    break;
                case 4:
                    btnCustomer.Visible = false;
                    btnProduct.Visible = false;
                    btnSales.Visible = false;
                    btnAdd.Visible = false;
                    btnCategory.Visible = false;
                    btnDeleted.Visible = false;
                    btnUser.Location = new Point(23, 12);
                    btnExit.Location = new Point(159, 12);
                    break;
                default:
                    break;
            }
        }
    }
}
