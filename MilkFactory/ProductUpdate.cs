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
    public partial class ProductUpdate : Form
    {
        private string Username_;
        private string Password_;
        public ProductUpdate(string Username, string Password)
        {
            Username_ = Username;
            Password_ = Password;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nameOld = textBox1.Text.ToString();
                string typeOld = textBox2.Text.ToString();

                string nameNew = textBox4.Text.ToString();
                string typeNew = textBox5.Text.ToString();

                if (!string.IsNullOrEmpty(nameOld) && !string.IsNullOrEmpty(typeOld) &&
                    !string.IsNullOrEmpty(nameNew) && !string.IsNullOrEmpty(typeNew))
                {
                    string connectionString = "Host=localhost;Username=" + Username_ + ";Password=" + Password_ + ";Database=MilkFactory";

                    var con = new NpgsqlConnection(connectionString);
                    con.Open();


                    string sql = "UPDATE mf.\"Product\" " +
                                 "SET \"ProductName\" = '" + nameNew + "', \"Type\" = '" + typeNew + "'" +
                                 "WHERE \"ProductName\" = '" + nameOld + "' AND \"Type\" = '" + typeOld + "'; ";


                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    textBox3.Text = "Entry successfully updated";
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
