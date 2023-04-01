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
    public partial class DeliveryAdd : Form
    {
        private string Username_;
        private string Password_;
        public DeliveryAdd(string Username, string Password)
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
                string address = textBox2.Text.ToString();
                string phoneNumber = textBox3.Text.ToString();

                string productName = textBox5.Text.ToString();
                string productType = textBox6.Text.ToString();
                string productCount = textBox7.Text.ToString();

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(phoneNumber) &&
                    !string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(productType) && !string.IsNullOrEmpty(productCount))
                {
                    string connectionString = "Host=localhost;Username=" + Username_ + ";Password=" + Password_ + ";Database=MilkFactory";

                    var con = new NpgsqlConnection(connectionString);
                    con.Open();

                    var cmd = new NpgsqlCommand();
                    cmd.Connection = con;

                    // check count products
                    string sql = "SELECT COUNT(*) " +
                                 "FROM mf.\"Product\" " +
                                 "WHERE \"ProductName\" = '" + productName + "' AND \"Type\" = '" + productType + "'";
                    cmd.CommandText = sql;
                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    dr.Read();
                    int countProducts = dr.GetInt32(0);

                    dr.Close();

                    // product with selected parameters is exist
                    if (countProducts > 0)
                    {

                        // get product id
                        sql = "SELECT \"ProductID\" " +
                              "FROM mf.\"Product\" " +
                              "WHERE \"ProductName\" = '" + productName + "' AND \"Type\" = '" + productType + "'";
                        cmd.CommandText = sql;
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        int productID = dr.GetInt32(0);
                        dr.Close();

                        // check count vendors with selected parameters
                        sql = "SELECT COUNT(\"Name\") AS count " +
                                     "FROM mf.\"Vendor\" " +
                                     "WHERE \"Name\" = '" + name + "' AND \"Address\" = '" + address + "' " +
                                        "AND \"PhoneNumber\" = '" + phoneNumber + "'";

                        cmd.CommandText = sql;
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        int countVendors = dr.GetInt32(0);
                        dr.Close();

                        // if vendor with selected parameters is exist
                        if (countVendors > 0)
                        {
                            // get vendor id
                            sql = "SELECT \"VendorID\" " +
                                  "FROM mf.\"Vendor\" " +
                                  "WHERE \"Name\" = '" + name + "' AND \"Address\" = '" + address + "' " +
                                    "AND \"PhoneNumber\" = '" + phoneNumber + "'";

                            cmd.CommandText = sql;
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            int vendorID = dr.GetInt32(0);
                            dr.Close();


                            // insert new delivery
                            sql = "INSERT INTO mf.\"Delivery\" (" +
                                  "\"VendorID\", \"ProductID\", \"ProductCount\", \"DateTime\") " +
                                  "VALUES(" + vendorID + ", " + productID + ", " + productCount + ", date_trunc('second', now()::timestamp)); ";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();

                        }
                        else
                        {
                            // insert new vendor with selected parameters
                            sql = "INSERT INTO mf.\"Vendor\"(" +
                                    "\"Name\", \"Address\", \"PhoneNumber\") " +
                                  "VALUES('" + name + "', '" + address + "', '" + phoneNumber + "'); ";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();


                            // get vendor id 
                            sql = "SELECT \"VendorID\" " +
                                  "FROM mf.\"Vendor\" " +
                                  "WHERE \"Name\" = '" + name + "' AND \"Address\" = '" + address + "' " +
                                    "AND \"PhoneNumber\" = '" + phoneNumber + "'";
                            cmd.CommandText = sql;
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            int vendorID = dr.GetInt32(0);
                            dr.Close();

                            // insert new delivery
                            sql = "INSERT INTO mf.\"Delivery\" (" +
                                  "\"VendorID\", \"ProductID\", \"ProductCount\", \"DateTime\") " +
                                  "VALUES(" + vendorID + ", " + productID + ", " + productCount + ", date_trunc('second', now()::timestamp)); ";
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                        textBox4.Text = "Entry successfully added";

                    }
                    else
                    {
                        textBox4.Text = "Cannot add an delivery because the selected product does not exist";
                    }
                    con.Close();
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
