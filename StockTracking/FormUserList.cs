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
            if (dto.Roles.Count > 0)
                combofull = true;
        }

        bool combofull = false;
        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                List<UserDetailDTO> list = dto.Users.Where(x => x.Rol_id == Convert.ToInt32(cmbRol.SelectedValue)).ToList();
                dataGridView1.DataSource = list;
            }
        }

        UserDetailDTO detail = new UserDetailDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detail.UserName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.Password = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Rol_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Please select a user from table");
            else
            {
                FormUser frm = new FormUser();
                frm.detail = detail;
                frm.dto = dto;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new UserBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Users;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Please select a customer from table");
            else
            {
                DialogResult result = MessageBox.Show("Are you sure", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {

                        MessageBox.Show("User was Deleted");
                        bll = new UserBLL();
                        dto = bll.Select();
                        dataGridView1.DataSource = dto.Users;
                    }
                }
            }
        }
    }
}
