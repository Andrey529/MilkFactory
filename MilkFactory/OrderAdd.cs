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
    public partial class OrderAdd : Form
    {
        public OrderAdd()
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

                string productName = textBox5.Text.ToString();
                string productType = textBox6.Text.ToString();
                string productCount = textBox7.Text.ToString();

                if (!string.IsNullOrEmpty(fio) && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(phoneNumber) &&
                    !string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(productType) && !string.IsNullOrEmpty(productCount))
                {
                    string connectionString = "Host=localhost;Username=postgres;Password=01082020;Database=MilkFactory";

                    var con = new NpgsqlConnection(connectionString);
                    con.Open();


                    string sql = "SELECT COUNT(*) " +
                                 "FROM mf.\"Product\" " +
                                 "WHERE \"ProductName\" = '" + productName + "' AND \"Type\" = '" + productType + "'";

                    var cmd1 = new NpgsqlCommand(sql, con);
                    NpgsqlDataReader dr = cmd1.ExecuteReader();

                    dr.Read();
                    int countProducts = dr.GetInt32(0);

                    if (countProducts > 0)
                    {
                        sql = "SELECT \"ProductID\" " +
                              "FROM mf.\"Product\" " +
                              "WHERE \"ProductName\" = '" + productName + "' AND \"Type\" = '" + productType + "'";

                        var cmd2 = new NpgsqlCommand(sql, con);
                        dr = cmd2.ExecuteReader();
                        dr.Read();
                        int productID = dr.GetInt32(0);


                        sql = "SELECT COUNT(\"FIO\") AS count " +
                                     "FROM mf.\"Client\" " +
                                     "WHERE \"FIO\" = '" + fio + "' AND \"Address\" = '" + address + "' " +
                                        "AND \"PhoneNumber\" = '" + phoneNumber + "'";

                        var cmd3 = new NpgsqlCommand(sql, con);
                        dr = cmd3.ExecuteReader();
                        dr.Read();
                        int countClients = dr.GetInt32(0);

                        if (countClients > 0)
                        {
                            sql = "SELECT \"ClientID\" " +
                                  "FROM mf.\"Client\" " +
                                  "WHERE \"FIO\" = '" + fio + "' AND \"Address\" = '" + address + "' " +
                                    "AND \"PhoneNumber\" = '" + phoneNumber + "'";
                            var cmd4 = new NpgsqlCommand(sql, con);
                            dr = cmd4.ExecuteReader();
                            dr.Read();
                            int clientID = dr.GetInt32(0);

                            sql = "INSERT INTO mf.\"Order\" (" +
                                  "\"ClientID\", \"ProductID\", \"ProductCount\", \"DateTime\") " +
                                  "VALUES(" + clientID + ", " + productID + ", " + productCount + ", date_trunc('second', now()::timestamp)); ";
                            var cmd5 = new NpgsqlCommand(sql, con);
                            cmd5.ExecuteNonQuery();
                        }
                        else
                        {
                            sql = "INSERT INTO mf.\"Client\"(" +
                                    "\"FIO\", \"Address\", \"PhoneNumber\") " +
                                  "VALUES('" + fio + "', '" + address + "', '" + phoneNumber + "'); ";
                            var cmd4 = new NpgsqlCommand(sql, con);
                            cmd4.ExecuteReader();

                            sql = "SELECT \"ClientID\" " +
                                  "FROM mf.\"Client\" " +
                                  "WHERE \"FIO\" = '" + fio + "' AND \"Address\" = '" + address + "' " +
                                    "AND \"PhoneNumber\" = '" + phoneNumber + "'";

                            var cmd5 = new NpgsqlCommand(sql, con);
                            dr = cmd5.ExecuteReader();
                            dr.Read();
                            int clientID = dr.GetInt32(0);

                            sql = "INSERT INTO mf.\"Order\" (" +
                                  "\"ClientID\", \"ProductID\", \"ProductCount\", \"DateTime\") " +
                                  "VALUES(" + clientID + ", " + productID + ", " + productCount + ", date_trunc('second', now()::timestamp)); ";
                            var cmd6 = new NpgsqlCommand(sql, con);
                            cmd6.ExecuteNonQuery();
                        }
                        textBox4.Text = "Entry successfully added";

                    }
                    else
                    {
                        textBox4.Text = "Cannot add an order because the selected product does not exist";
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
