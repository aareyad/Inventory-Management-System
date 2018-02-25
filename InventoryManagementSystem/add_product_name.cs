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
    public partial class add_product_name : Form
    {
        public static MySqlConnection con = new MySqlConnection("server=localhost; uid=root; password=; database=inventory");
        public add_product_name()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_product_name_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_dd();
            fill_dg();
        }
        public void fill_dd() {
            try
            {
                comboBox1.Items.Clear();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from units";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows) {
                    comboBox1.Items.Add(dr["unit"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void fill_dg()
        {
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from product_name";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into product_name(product_name, units) values('"+ textBox1.Text +"', '"+ comboBox1.SelectedItem.ToString() +"')";
                cmd.ExecuteNonQuery();
                textBox1.Text = "";
                fill_dg();
                MessageBox.Show("Record Inserted Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                panel2.Visible = true;
                int i;
                i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                comboBox2.Items.Clear();

                MySqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "Select * from units";
                cmd2.ExecuteNonQuery();
                DataTable dt2 = new DataTable();
                MySqlDataAdapter da2 = new MySqlDataAdapter(cmd2);
                da2.Fill(dt2);
                foreach (DataRow dr2 in dt2.Rows)
                {
                    comboBox2.Items.Add(dr2["unit"].ToString());
                }

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from product_name where id = '" + i + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["product_name"].ToString();
                    comboBox2.SelectedItem = dr["units"].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update product_name set product_name = '"+ textBox2.Text +"', units = '"+ comboBox2.SelectedItem.ToString() +"' where id = '" + i + "'";
            cmd.ExecuteNonQuery();
            panel2.Visible = false;
            fill_dg();
        }
    }
}
