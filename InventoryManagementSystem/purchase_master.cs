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
    public partial class purchase_master : Form
    {
        public static MySqlConnection con = new MySqlConnection("server=localhost; uid=root; password=; database=inventory");
        public purchase_master()
        {
            InitializeComponent();
        }

        private void purchase_master_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            fill_product_name();
            fill_dealer_name();
        }
        public void fill_product_name()
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
                foreach (DataRow dr in dt.Rows) {
                    comboBox1.Items.Add(dr["product_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void fill_dealer_name()
        {
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from dealer_info";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox2.Items.Add(dr["dealer_name"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from product_name where product_name='"+ comboBox1.Text +"'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    label3.Text = dr["units"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(Convert.ToInt32(textBox3.Text) * Convert.ToInt32(textBox2.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                MySqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "Select * from stock where product_name='" + comboBox1.Text + "'";
                cmd1.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
                da1.Fill(dt1);
                i = Convert.ToInt32(dt1.Rows.Count.ToString());

                if (i == 0)
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into purchase_master(product_name, product_qty, product_unit, product_price, product_total, purchase_date, purchase_party_name, purchase_type, expiry_date, profit) values('" + comboBox1.Text + "','" + textBox2.Text + "','" + label3.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + dateTimePicker2.Value.ToString("dd-MM-yyyy") + "','" + textBox1.Text + "')";
                    cmd.ExecuteNonQuery();

                    MySqlCommand cmd3 = con.CreateCommand();
                    cmd3.CommandType = CommandType.Text;
                    cmd3.CommandText = "insert into stock(product_name, product_qty, product_unit) values('" + comboBox1.Text + "','" + textBox2.Text + "','" + label3.Text + "')";
                    cmd3.ExecuteNonQuery();

                }
                else {
                    MySqlCommand cmd2 = con.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "insert into purchase_master(product_name, product_qty, product_unit, product_price, product_total, purchase_date, purchase_party_name, purchase_type, expiry_date, profit) values('" + comboBox1.Text + "','" + textBox2.Text + "','" + label3.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + dateTimePicker2.Value.ToString("dd-MM-yyyy") + "','" + textBox1.Text + "')";
                    cmd2.ExecuteNonQuery();

                    MySqlCommand cmd5 = con.CreateCommand();
                    cmd5.CommandType = CommandType.Text;
                    cmd5.CommandText = "update stock set product_qty=product_qty + "+ textBox2.Text +" where product_name='"+ comboBox1.Text +"'";
                    cmd5.ExecuteNonQuery();
                }

                
                MessageBox.Show("Record Inserted Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
