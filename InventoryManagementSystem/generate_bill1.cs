using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class generate_bill1 : Form
    {
        public generate_bill1()
        {
            InitializeComponent();
        }

        private void generate_bill1_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = CrystalReport11;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
