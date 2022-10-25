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
using StockTracking.BLL;
using StockTracking.DAL.DTO;
using System.Net;

namespace StockTracking
{
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public UserDTO dto = new UserDTO();
        public UserDetailDTO detail = new UserDetailDTO();
        public bool isUpdate = false;
        private void FormUser_Load(object sender, EventArgs e)
        {
            cmbRol.DataSource = dto.Roles;
            cmbRol.DisplayMember = "RolName";
            cmbRol.ValueMember = "ID";
            cmbRol.SelectedIndex = -1;
            if (isUpdate)
            {
                txtUserName.Text = detail.UserName;
                txtPassword.Text = detail.Password;
                cmbRol.SelectedValue = detail.Rol_id;
            }
        }

        UserBLL bll = new UserBLL();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
                MessageBox.Show("User Name is Empty");
            else if (cmbRol.SelectedIndex == -1)
                MessageBox.Show("Please select a rol");
            else if (txtPassword.Text.Trim() == "")
                MessageBox.Show("Password is empty");
            else
            {
                if (!isUpdate)
                {
                    UserDetailDTO user = new UserDetailDTO();
                    user.UserName = txtUserName.Text;
                    user.Rol_id = Convert.ToInt32(cmbRol.SelectedValue);
                    user.Password = txtPassword.Text;
                    if (bll.Insert(user))
                    {
                        MessageBox.Show("User was added");
                        txtUserName.Clear();
                        txtPassword.Clear();
                        cmbRol.SelectedIndex = -1;
                    }
                }
                else
                {
                        detail.UserName = txtUserName.Text;
                        detail.Password = txtPassword.Text;
                        detail.Rol_id = Convert.ToInt32(cmbRol.SelectedValue); 
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("User was Updated");
                            this.Close();
                        }
                }
            }
        }
    }
}
