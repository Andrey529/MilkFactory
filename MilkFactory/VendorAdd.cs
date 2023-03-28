﻿using System;
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
    public partial class VendorAdd : Form
    {
        public VendorAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text.ToString();
                string address = textBox2.Text.ToString();
                string phoneNumber = textBox3.Text.ToString();

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(phoneNumber))
                {
                    string connectionString = "Host=localhost;Username=postgres;Password=01082020;Database=MilkFactory";

                    var con = new NpgsqlConnection(connectionString);
                    con.Open();


                    string sql = "INSERT INTO mf.\"Vendor\"( \"Name\", \"Address\", \"PhoneNumber\") " +
                                 "VALUES('" + name + "', '" + address + "', '" + phoneNumber + "');";

                    var cmd = new NpgsqlCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    textBox4.Text = "New entry successfully added";
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
