using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Text;

namespace SCSM
{
    public partial class RegisterFrm : Form
    {
        public RegisterFrm()
        {

            InitializeComponent();

            this.textBox1.Text = generateMachineCode();
        }
        private string generateMachineCode() {
            string machineCode = getCPUId();
            //getMACAdress();
            //getMainBoardId();
            //getDiskID();
            if (machineCode != "") {
                machineCode = "shengchuan" + machineCode;

                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(machineCode);
                byte[] outputBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < outputBytes.Length; i++) {
                    sb.Append(outputBytes[i].ToString("X2"));
                }

                machineCode = sb.ToString();
            }

            return machineCode;
        }

        private string getCPUId() {
            try
            {
                string strCpuID = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    strCpuID = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc = null;
                mc = null;
                return strCpuID;
            }
            catch
            {
                return "";
            }
        }
        private string getMACAdress()
        {
            try
            {
                string strMac = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool)mo["IPEnabled"] == true)
                    {
                        strMac = mo["MacAddress"].ToString();
                    }
                }
                moc = null;
                mc = null;
                return strMac;
            }
            catch
            {
                return "";
            }
        }
        private string getMainBoardId()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_BaseBoard");
                ManagementObjectCollection moc = mc.GetInstances();
                string strID = null;
                foreach (ManagementObject mo in moc)
                {
                    strID = mo.Properties["SerialNumber"].Value.ToString();
                    break;
                }
                return strID;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>  
        /// 获取硬盘序号  
        /// </summary>  
        /// <returns>硬盘序号</returns>  
        public static string getDiskID()
        {
            try
            {
                string strDiskID = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    strDiskID = mo.Properties["Model"].Value.ToString();
                }
                moc = null;
                mc = null;
                return strDiskID;
            }
            catch
            {
                return "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
