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
using StockTracking.DAL;
using StockTracking.DAL.DTO;

namespace StockTracking
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        UserDetailDTO user = new UserDetailDTO();
        UserBLL bll = new UserBLL();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                MessageBox.Show("Please fill the userno and password");
            else
            {
                user.UserName = txtUserName.Text;
                user.Password = txtPassword.Text;
                user = bll.Select(user);
                if (user == null)
                {
                    MessageBox.Show("Username or password is incorrect");
                    user = new UserDetailDTO();
                }
                else
                {
                    UserStatic.RolID = user.Rol_id;
                    if (UserStatic.RolID == 2)
                    { 
                        FormStockAlert frm = new FormStockAlert();
                        this.Hide();
                        frm.ShowDialog();
                    }
                    else
                    {
                        FormMain frm = new FormMain();
                        this.Hide();
                        frm.ShowDialog();
                    }

                }
            }
        }
    }
}
