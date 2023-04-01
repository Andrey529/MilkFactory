using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MilkFactory
{
    public partial class UserAdmin : Form
    {
        private string Username_;
        private string Password_;
        public UserAdmin(string Username, string Password)
        {
            Username_ = Username;
            Password_ = Password;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client(Username_, Password_);
            client.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product product = new Product(Username_, Password_);
            product.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vendor vendor = new Vendor(Username_, Password_);
            vendor.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Order order = new Order(Username_, Password_);
            order.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery(Username_, Password_);
            delivery.Show();
        }
    }
}
