using System.Windows.Forms;

namespace SCSM
{
    public partial class AddStationFrm : Form
    {
        private StationConfigFrm parentForm;
        public AddStationFrm(StationConfigFrm parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                parentForm.AddStationItem(textBox1.Text.Trim(), textBox2.Text.Trim());
            }            
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
