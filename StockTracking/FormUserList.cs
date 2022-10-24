using StockTracking.BLL;
using StockTracking.DAL.DTO;
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
    public partial class FormUserList : Form
    {
        public FormUserList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormUser frm = new FormUser();
            frm.dto = dto;
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Users;

        }

        UserBLL bll = new UserBLL();
        UserDTO dto = new UserDTO();
        private void FormUserList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbRol.DataSource = dto.Roles;
            cmbRol.DisplayMember = "RolName";
            cmbRol.ValueMember = "ID";
            cmbRol.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Users;
            dataGridView1.Columns[1].HeaderText = "User Name";
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }
    }
}
