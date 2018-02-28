using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace InventoryManagementSystem
{
    public partial class generate_bill : Form
    {
        public static MySqlConnection con = new MySqlConnection("server=localhost; uid=root; password=; database=inventory");
        int j;
        int tot = 0;
        public generate_bill()
        {
            InitializeComponent();
        }
        public void get_value(int i)
        {
            j = i;
        }
        private void generate_bill_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            
            inventoryDataSet ds = new inventoryDataSet();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from order_user where id='"+ j +"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds.DataTable1);

            MySqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "Select * from order_item where order_id='" + j + "'";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
            da2.Fill(ds.DataTable2);
            da2.Fill(dt2);

            tot = 0;
            foreach(DataRow dr2 in dt2.Rows)
            {
                tot = tot + Convert.ToInt32(dr2["total"].ToString());
            }
            
            CrystalReport2 myreport = new CrystalReport2();
            myreport.SetDataSource(ds);
            myreport.SetParameterValue("total", tot.ToString());
            crystalReportViewer1.ReportSource = myreport;
            
        }
    }
}
