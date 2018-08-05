using BLL;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SCSM
{
    public partial class StationConfigFrm : Form
    {
        MainFrm mainFrm;
        private TreeNode oldNode = null;

        private List<Station> oldStations = null;
        private List<Module> oldModules = null;
        private List<AnalogSensor> oldAnaSensors = null;
        private List<DigitalSensor> oldDigSensors = null;

        private List<Station> newStations = null;
        private List<Module> newModules = null;
        private List<AnalogSensor> newAnaSensors = null;
        private List<DigitalSensor> newDigSensors = null;
        public StationConfigFrm(MainFrm mainFrm)
        {
            InitializeComponent();

            this.mainFrm = mainFrm;
        }

        public void AddStationItem(string name, string description) {
            int index = treeView1.Nodes["User"].Index;

            treeView1.Nodes[index].Nodes.Add(name);
        }
        private void StationConfig_Load(object sender, EventArgs e)
        {
            StationBLL stationBll = new StationBLL(new StationsDAL());
            oldStations = stationBll.GetStationsByUser(mainFrm.User);

            oldNode = treeView1.Nodes[this.mainFrm.User.Name];

            DisplayStation(oldStations);            
        }
        private void DisplayStation(List<Station> stations) {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("name", "Station Name");
            dataGridView1.Columns.Add("address", "address");
            dataGridView1.Columns.Add("description", "description");   
                     
            foreach (Station station in stations) {
                string[] row = { station.Name, station.Address.ToString(), station.Description }; 
                dataGridView1.Rows.Add();
            }
        }

        private List<Module> GetCurrentStationModules(Station station) {
            List<Module> modules = new List<Module>();
            ModuleBLL moduleBll = new ModuleBLL(new ModuleDAL());
            List<object> objects= moduleBll.GetAllObjs();
            foreach (object obj in objects) {
                modules.Add((Module)obj);
            }
            return modules;
        }
        private void DisplayModule(List<Module> modules) {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("name", "Module Name");
            dataGridView1.Columns.Add("address", "address");
            dataGridView1.Columns.Add("description", "description");

            if (modules.Count > 0) {
                foreach (Module module in modules)
                {
                    string[] row = { module.Name, module.Address.ToString(), module.Description };
                    dataGridView1.Rows.Add();
                }
            }
        }
        private List<AnalogSensor> GetCurrentModuleAnaSensors(Module module) {
 
            AnaSensorBLL anaSensorBLL = new AnaSensorBLL(new AnaSensorDAL());
            List<AnalogSensor> anaSensors= new List<AnalogSensor>();
  
            return anaSensors;
        }
        private List<DigitalSensor> GetCurrentModuleDigSensors(Module module) {
            DigSensorBLL digSensorBLL = new DigSensorBLL(new DigSensorDAL());
            List<DigitalSensor> digitalSensors = new List<DigitalSensor>();

            return digitalSensors;
        }
        private void DisplayCurrentModuleAnaSensors(List<AnalogSensor> sensors)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("name", "Sensor Name");
            dataGridView1.Columns.Add("address", "address");
            dataGridView1.Columns.Add("description", "description");

            foreach(AnalogSensor sensor in sensors)
            {
                string[] row = { sensor.Name,sensor.Address.ToString(),sensor.Description};
            }
        }
        private void DisplayCurrentModuleDigSensors(List<DigitalSensor> sensors)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("name", "Sensor Name");
            dataGridView1.Columns.Add("address", "address");
            dataGridView1.Columns.Add("description", "description");

            foreach (DigitalSensor sensor in sensors)
            {
                string[] row = { sensor.Name, sensor.Address.ToString(), sensor.Description };
            }
        }

        private void UpdataConfigInfomation() {
            //根据dataGridView中的数据判断实体类型
            if (dataGridView1.ColumnCount > 0)
            {
                string entityType = dataGridView1.Columns[0].HeaderText.Trim();
                switch (entityType)
                {
                    case "Station Name":
                        StationsUpdate(oldStations, GetStationsFromDataGridView());
                        break;
                    case "Module Name":
                        ModulesUpdate(oldModules, GetModulesFromDataGridView());
                        break;
                    case "AnaSensor Name":
                        AnaSensorsUpdate(oldAnaSensors, GetAnaSensorsFromDataGridView());
                        break;
                    case "DigSensor Name":
                        DigSensorsUpdate(oldDigSensors, GetDigSensorsFromDataGridView());
                        break;
                    default:
                        break;
                }
            }
        }
        private int StationsUpdate(List<Station> oldStations,List<Station> newStations) {
            if (oldStations == newStations)
            {
                return 0;
            }
            else {
                CheckStationInput();

                return 0;
            }
        }
        private int ModulesUpdate(List<Module> oldModules, List<Module> newModules)
        {
            if (oldModules != newModules)
            {
                return 0;
            }
            else
            {
                CheckModuleInput();
                return 0;
            }
        }
        private int AnaSensorsUpdate(List<AnalogSensor> oldSensors, List<AnalogSensor> newSensors)
        {
            if (oldSensors != newSensors)
            {
                return 0;
            }
            else
            {
                if (this.CheckAnaSensorInput() == true)
                {
                    string sqlstr = "";
                    AnaSensorBLL bll = new AnaSensorBLL(new AnaSensorDAL());
                    return bll.ExcuteSqlStr(sqlstr);
                }
                else {
                    return 0;
                }              
            }
        }
        private int DigSensorsUpdate(List<DigitalSensor> oldSensors, List<DigitalSensor> newSensors)
        {
            if (oldSensors != newSensors)
            {
                return 0;
            }
            else
            {
                this.CheckDigSensorInput();
                return 0;
            }
        }
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point clickPoint = new Point(e.X, e.Y);
                TreeNode currentNode = treeView1.GetNodeAt(clickPoint);
            }
        }
        private List<Station> GetStationsFromDataGridView() {
            List<Station> stations = new List<Station>();
            return stations;
        }
        private List<Module> GetModulesFromDataGridView()
        {
            List<Module> modules = new List<Module>();
            return modules;
        }
        private List<AnalogSensor> GetAnaSensorsFromDataGridView()
        {
            List<AnalogSensor> sensors = new List<AnalogSensor>();
            return sensors;
        }
        private List<DigitalSensor> GetDigSensorsFromDataGridView()
        {
            List<DigitalSensor> sensors = new List<DigitalSensor>();
            return sensors;
        }

        private void StationConfigFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("配置信息已发生改变，是否要保存？", "保存提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                e.Cancel = true;
                UpdataConfigInfomation();
            } else {

            }
        }
        private bool CheckStationInput() {
            bool ret = true ;
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                string name = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                string address = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                string description = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();

                if (name == "" || address.ToString() == "") {
                    ret = false;
                    break;
                }
            }
            return ret;
        }
        private bool CheckModuleInput()
        {
            bool ret = true;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string name = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                string address = dataGridView1.Rows[i].Cells[1].Value.ToString().Trim();
                string description = dataGridView1.Rows[i].Cells[2].Value.ToString().Trim();

                if (name == "" || address.ToString() == "")
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }
        private bool CheckAnaSensorInput()
        {
            return true;
        }
        private bool CheckDigSensorInput()
        {
            return true;
        }
    }
}
