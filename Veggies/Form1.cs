using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Reflection.Metadata;

namespace Veggies
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button_Click(string s)
        {
            SqlConnection connect = new SqlConnection(@"Initial Catalog=Veggies;Data Source=DESKTOP-A3O7OP4;Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = s;
                SqlDataReader reader = command.ExecuteReader();
                int count = reader.FieldCount;
                listBox1.DataSource = null;
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    string? res = "", temp = "";
                    for (int i = 0; i < count; i++)
                    {
                        temp = reader[i].ToString();
                        res += temp + "  ";
                    }
                    listBox1.Items.Add(res);
                    res = "";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Initial Catalog=Veggies;Data Source=DESKTOP-A3O7OP4;Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                connect.Open();
                command.Connection = connect;
                MessageBox.Show("Connection opened succesfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                command.Dispose();
                connect.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Initial Catalog=Veggies;Data Source=DESKTOP-A3O7OP4;Integrated Security=SSPI");
            SqlCommand command = new SqlCommand();
            try
            {
                command.Dispose();
                connect.Close();
                MessageBox.Show("Connection closed succesfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button_Click("SELECT * FROM Veggies");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button_Click("SELECT name FROM Veggies");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button_Click("SELECT color FROM Veggies");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button_Click("SELECT MAX([Calorie content]) FROM Veggies");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button_Click("SELECT MIN([Calorie content]) FROM Veggies");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button_Click("SELECT AVG([Calorie content]) FROM Veggies");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button_Click("SELECT COUNT(TYPE) from Veggies WHERE TYPE = 'VEGETABLE';");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button_Click("SELECT COUNT(TYPE) from Veggies WHERE TYPE = 'FRUIT';");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button_Click("SELECT COUNT(COLOR) from Veggies WHERE COLOR = 'RED'");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button_Click("SELECT color, count(type) AS [pieces] FROM Veggies GROUP BY color;");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button_Click("SELECT Name, [Calorie content] FROM Veggies WHERE [Calorie content] < 300;");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button_Click("SELECT Name, [Calorie content] FROM Veggies WHERE [Calorie content] > 300;");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button_Click("SELECT Name, [Calorie content] FROM Veggies WHERE [Calorie content] > 200 AND [Calorie content] < 300;");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button_Click("SELECT Name, color FROM Veggies WHERE color = 'red' OR color = 'yellow';");
        }
    }
}