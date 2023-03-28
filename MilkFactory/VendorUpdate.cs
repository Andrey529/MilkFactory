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
    public partial class VendorUpdate : Form
    {
        public VendorUpdate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nameOld = textBox1.Text.ToString();
                string addressOld = textBox2.Text.ToString();
                string phoneNumberOld = textBox3.Text.ToString();

                string nameNew = textBox5.Text.ToString();
                string addressNew = textBox6.Text.ToString();
                string phoneNumberNew = textBox7.Text.ToString();

                if (!string.IsNullOrEmpty(nameOld) && !string.IsNullOrEmpty(addressOld) && !string.IsNullOrEmpty(phoneNumberOld) &&
                    !string.IsNullOrEmpty(nameNew) && !string.IsNullOrEmpty(addressNew) && !string.IsNullOrEmpty(phoneNumberNew))
                {
                    string connectionString = "Host=localhost;Username=postgres;Password=01082020;Database=MilkFactory";

                    var con = new NpgsqlConnection(connectionString);
                    con.Open();


                    string sql = "UPDATE mf.\"Vendor\" SET \"Name\"='" + nameNew + "', \"Address\"='" + addressNew + "', \"PhoneNumber\"='" + phoneNumberNew + "' " +
                        "WHERE \"Name\" = '" + nameOld + "' AND \"Address\" = '" + addressOld + "' AND \"PhoneNumber\" = '" + phoneNumberOld + "'; ";


                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    textBox4.Text = "Entry successfully updated";
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
    }
}
