using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Npgsql;

namespace MilkFactory
{
    public partial class ClientDelete : Form
    {
        public ClientDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fio = textBox1.Text.ToString();
                string address = textBox2.Text.ToString();
                string phoneNumber = textBox3.Text.ToString();

                if (!string.IsNullOrEmpty(fio) && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(phoneNumber))
                {
                    string connectionString = "Host=localhost;Username=postgres;Password=01082020;Database=MilkFactory";

                    var con = new NpgsqlConnection(connectionString);
                    con.Open();


                    string sql = "DELETE FROM mf.\"Client\" WHERE \"FIO\" = '" + fio + "' AND \"Address\" = '" + address + "' AND \"PhoneNumber\" = '" + phoneNumber + "'; ";

                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    textBox4.Text = "Entry successfully deleted";
                }
                else
                {
                    textBox4.Text = "The data must not be empty";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                textBox4.Text = "Error, something wrong";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
