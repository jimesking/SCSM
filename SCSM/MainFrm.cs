using BLL;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SCSM
{
    public partial class MainFrm : Form
    {
        private User user;

        public User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public void InitMainFrm() {

            this.title.Location = new System.Drawing.Point(this.Width / 2 - this.title.Width / 2, this.menuStrip1.Height);

            if (user != null) {

                if (user.Role == 1)
                {
                    this.menuStrip1.Items.Add("用户管理", null, delegate (object sender, EventArgs e)
                    {
                        UserManageFrm usFrm = new UserManageFrm();
                        usFrm.Show();
                    });
                    this.menuStrip1.Items.Add("站点配置", null, (object sender, EventArgs e) => {
                        StationConfigFrm scFrm = new StationConfigFrm(this);
                        scFrm.Show();
                    });
                }

                UiInformationBLL uiBll = new UiInformationBLL(new UiInformationDAL());

                List<UIInfomation> uiInfos = uiBll.GetUiInformationsByUser(user);
                if (uiInfos.Count > 0) {
                    this.Text = uiInfos[0].Caption;
                    this.title.Text = uiInfos[0].Title;
                }

                List<Station> stations = new List<Station>();

                StationBLL stationBLl = new StationBLL(new StationsDAL());

                stations = stationBLl.GetStationsByUser(this.User);

                ShowStation(stations);
            }
        }

        public int GetNewSensorsData() {

            return 0;
        }

        public void ShowStation(List<Station> modules) {

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("stationName", "站点名称");
            dataGridView1.Columns.Add("address", "站点地址");
            dataGridView1.Columns.Add("description", "站点描述");
            dataGridView1.Columns.Add("moduleCount", "模块数量");

            if (modules.Count > 0)
            {
                for (int i = 0; i < modules.Count; i++) {
                    string[] row = { modules[i].Name, modules[i].Address.ToString(), modules[i].Description, modules[i].ModuleCount.ToString() };

                    dataGridView1.RowHeadersWidth = 70;

                    dataGridView1.Rows.Add(row);

                    dataGridView1.Rows[i].HeaderCell.Value = "No." + (i + 1).ToString() ;
                }
            }

        }
        public void ShowModules(List<Module> modules) {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("moduleName", "模块名称");
            dataGridView1.Columns.Add("address", "模块地址");
            dataGridView1.Columns.Add("description", "模块描述");
            dataGridView1.Columns.Add("AnaSensorCount", "模拟量数量");
            dataGridView1.Columns.Add("DigSensorCount", "开关量数量");

            if (modules.Count > 0)
            {
                for (int i = 0; i < modules.Count; i++)
                {
                    string[] row = {
                        modules[i].Name,
                        modules[i].Address.ToString(),
                        modules[i].Description,
                        modules[i].AnaSensorCount.ToString(),
                        modules[i].DigSensorCount.ToString() };

                    dataGridView1.RowHeadersWidth = 70;

                    dataGridView1.Rows.Add(row);

                    dataGridView1.Rows[i].HeaderCell.Value = "No." + (i + 1).ToString();
                }
            }
        }

        public void ShowSensors(List<AnalogSensor> anaSensors ,List<DigitalSensor> digSensors,
            List<AnaSensorData> anasData,List<DigSensorData> digData) {

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("name", "传感器名称");
            dataGridView1.Columns.Add("address", "传感器地址");
            dataGridView1.Columns.Add("description", "传感器描述");            
            dataGridView1.Columns.Add("interval", "采样周期");
            dataGridView1.Columns.Add("md", "上限");
            dataGridView1.Columns.Add("mu", "下限");
            dataGridView1.Columns.Add("mt", "单位");
            dataGridView1.Columns.Add("time", "时间");
            dataGridView1.Columns.Add("q", "质量位");
            dataGridView1.Columns.Add("value", "当前值");
            if (anaSensors.Count > 0) {
                for (int i = 0; i < anaSensors.Count; i++) {
                    string[] arr = { anaSensors[i].Name, anaSensors[i].Address.ToString(), anaSensors[i].Description,
                            anaSensors[i].Interval.ToString(),
                            anaSensors[i].Md.ToString(anaSensors[i].Format.Trim()),
                            anaSensors[i].Mu.ToString(anaSensors[i].Format.Trim()),
                            anaSensors[i].Ut,
                            anasData[i].Time.ToString(),
                            anasData[i].Q.ToString(),                           
                            anasData[i].Av.ToString(anaSensors[i].Format.Trim()) };
                }
            }
        }

        public MainFrm()
        {
            InitializeComponent();

            this.dataGridView1.ReadOnly = true;
        }
        
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }

            if (this.Height > 150) {
                this.splitContainer1.Height = this.Height - 150;
            }

            if (this.splitContainer1.Height > 600) {
                this.dataGridView1.Height = 205;
                this.tabControl1.Height = this.splitContainer1.Height - this.dataGridView1.Height;
            }  
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Show();            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (this.user == null) {
                LoginFrm login = new LoginFrm(this);
                login.TopMost = true;
                login.Show();
            }
            this.webBrowser1.Width = tabControl1.TabPages[0].Width;
            this.webBrowser1.Height = tabControl1.TabPages[0].Height;
            this.webBrowser1.Navigate(@"E:\Project\CSharp\SCSM\Map\baidu.html");

            this.pictureBox1.Width = this.pictureBox1.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void login_Click(object sender, EventArgs e)
        {
            LoginFrm login = new LoginFrm(this);
            login.TopMost = true;
            login.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            if (this.menuStrip1.Items.Count > 2)
            {
                this.user = null;
                this.menuStrip1.Items.RemoveAt(1);
                this.menuStrip1.Items.RemoveAt(1);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (chart1.ChartAreas[0].Area3DStyle.Rotation <= 177)
                chart1.ChartAreas[0].Area3DStyle.Rotation += 3;
            else
                chart1.ChartAreas[0].Area3DStyle.Rotation = -180;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int index = this.treeView1.SelectedNode.Index;
            int leval = this.treeView1.SelectedNode.Level;

            if (leval == 3&& this.dataGridView1.Rows.Count>0) {
                 for(int i = 0; i < this.dataGridView1.Rows.Count; i++)
                {
                    if (index == i)
                    {
                        this.dataGridView1.Rows[i].Selected = true;
                    }else {
                        this.dataGridView1.Rows[i].Selected = false;
                    }
                }
            }
            
        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.notifyIcon1.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    LogBLL logBLL = new LogBLL(new LogDAL());
                    string strSQL = "select * from loginfo limit 20;";
                    //MySqlParameter[] parms = new MySqlParameter[] { };
                    List<object> logs = logBLL.GetObjsBySQL(strSQL,null);
                    if (logs.Count > 0)
                    {
                        displayLogsInlisView(logs);
                    }
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
        private void displayLogsInlisView(List<object> logs) {
            listView2.Items.Clear();
            for (int i = 0; i < logs.Count; i++) {
                Log log = (Log)logs[i];
                ListViewItem item = new ListViewItem();
                item.SubItems.Clear();
                item.SubItems[0].Text = log.Id.ToString();
                item.SubItems.Add(log.Type.ToString());
                item.SubItems.Add(log.Address.ToString());
                item.SubItems.Add(log.Time.ToString());
                item.SubItems.Add(log.Description);
                listView2.Items.Add(item);
            }
        }
    }
}
