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
    public partial class ProductDelete : Form
    {
        private string Username_;
        private string Password_;
        public ProductDelete(string Username, string Password)
        {
            Username_ = Username;
            Password_ = Password;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text.ToString();
                string type = textBox2.Text.ToString();

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(type))
                {
                    string connectionString = "Host=localhost;Username=" + Username_ + ";Password=" + Password_ + ";Database=MilkFactory";

                    var con = new NpgsqlConnection(connectionString);
                    con.Open();


                    string sql = "DELETE FROM mf.\"Product\" " +
                                 "WHERE \"ProductName\" = '" + name + "' AND \"Type\" = '" + type + "'; ";

                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    textBox3.Text = "Entry successfully deleted";
                }
                else
                {
                    textBox3.Text = "The data must not be empty";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                textBox3.Text = "Error, something wrong";
            }
        }
    }
}
