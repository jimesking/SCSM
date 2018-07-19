using BLL;
using Entity;
using System;
using System.Windows.Forms;

namespace SCSM
{
    public partial class UserManageFrm : Form
    {
        public UserManageFrm()
        {
            InitializeComponent();
        }

        private bool checkInput()
        {

            if (textBox1.Text.Trim() == "")
            {
                textBox1.Focus();
                label5.Text = "请输入用户名！";
                return false;
            }

            if (textBox2.Text.Trim() == "")
            {
                textBox2.Focus();
                label5.Text = "请输入密码！";
                return false;
            }

            if (textBox3.Text.Trim() == "")
            {
                textBox3.Focus();
                label5.Text = "请输入重复密码！";
                return false;
            }

            if (textBox2.Text.Trim() != textBox3.Text.Trim())
            {
                textBox2.Focus();
                label5.Text = "2次输入的密码不一致！";
                return false;
            }

            int role;

            try
            {
                role = int.Parse(comboBox1.Text.Trim());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
                throw;
            }
            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (true == checkInput())
            {
                UserBLL userBLL = new UserBLL();

                User user = new User(textBox1.Text.Trim(), textBox2.Text.Trim(), int.Parse(comboBox1.Text.Trim()));

                int ret = 0;
                ret = userBLL.Add(user);

                if (ret == 1) {
                    listBox1.Items.Add(user.Name);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString().Trim() != "")
            {
                MessageBoxButtons megBtns = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要删除吗？", "删除用户", megBtns);
                int ret = 0;
                if (dr == DialogResult.OK)
                {
                    UserBLL userBll = new UserBLL();
                    User user = new User(listBox1.SelectedItem.ToString().Trim());
                    ret = userBll.Delete(user);                   
                }
                if (ret == 1) {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString().Trim() != "" && true == checkInput())
            {
                string name = textBox1.Text.Trim();
                string password = textBox2.Text.Trim();
                string rePassword = textBox3.Text.Trim();
                int role = int.Parse(comboBox1.Text.Trim());

                UserBLL userBll = new UserBLL();

                User oldUser = (User)userBll.GetObjById(listBox1.SelectedItem.ToString().Trim());
                User newUser = new User(name, password, role);

                userBll.Modify(oldUser, newUser);
            }
        }

        private void UserManage_Load(object sender, EventArgs e)
        {
            GetUsersAndDisplay();
        }
        private void GetUsersAndDisplay() {
            UserBLL userBLL = new UserBLL();
            listBox1.Items.Clear();

            if (userBLL.GetAllObjs().Count > 0)
            {
                foreach (object obj in userBLL.GetAllObjs())
                {
                    User user = (User)obj;
                    listBox1.Items.Add(user.Name);
                }
            }
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (listBox1.Items.Count > 0)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (i == index)
                    {
                        listBox1.SelectedIndex = index;
                        string userName = listBox1.Items[index].ToString().Trim();
                        UserBLL userBLL = new UserBLL();
                        User user = (User)userBLL.GetObjById(userName);
                        textBox1.Text = user.Name;
                        textBox2.Text = user.Password;
                        textBox3.Text = user.Password;
                        comboBox1.SelectedIndex = user.Role - 1;
                    }                    
                }
            }
        }
    }
}
