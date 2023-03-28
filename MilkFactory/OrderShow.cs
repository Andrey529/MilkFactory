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
    public partial class OrderShow : Form
    {
        public OrderShow()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Host=localhost;Username=postgres;Password=01082020;Database=MilkFactory";

                var con = new NpgsqlConnection(connectionString);
                con.Open();


                string sql = "SELECT \"OrderID\", \"ClientID\", \"ProductID\", \"ProductCount\", \"DateTime\" " +
                             "FROM mf.\"Order\"; ";

                var cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader dr = cmd.ExecuteReader();

                int i = 1;
                while (dr.Read())
                {
                    string text = dr[0].ToString() + "\t" + dr[1].ToString() + "\t" + 
                                  dr[2].ToString() + "\t" + dr[3].ToString() + "\t" + dr[4].ToString();
                    Brush brush = new SolidBrush(Color.Black);
                    Font font = new System.Drawing.Font("Times New Roman", 9, FontStyle.Bold);
                    Graphics graphics = pictureBox1.CreateGraphics();
                    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    graphics.DrawString(text, font, brush, 50, 20 * i);
                    i++;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
