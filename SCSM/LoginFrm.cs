using BLL;
using Entity;
using System;
using System.Windows.Forms;

namespace SCSM
{
    public partial class LoginFrm : Form
    {
        private MainFrm mf;
        public LoginFrm(MainFrm mf)
        {
            InitializeComponent();
            this.mf = mf;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            this.login();
        }


        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login() {
            if (this.UserName.Text.Trim() == "")
            {
                MessageBox.Show("用户名不能为空！");
                this.UserName.Focus();
                return;
            }

            if (this.Password.Text.Trim() == "")
            {
                MessageBox.Show("密码不能为空！");
                this.Password.Focus();
                return;
            }

            User user = null;
            UserBLL userBLL = new UserBLL();

            user = userBLL.GetUserByNameAndPassword(this.UserName.Text.Trim(), this.Password.Text.Trim());

            if (user != null)
            {
                mf.User = user;

                mf.InitMainFrm();

                this.Close();
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                login();
            }
        }
    }
}
