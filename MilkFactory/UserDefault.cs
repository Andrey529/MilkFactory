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
    public partial class UserDefault : Form
    {
        private string Username_;
        private string Password_;
        public UserDefault(string Username, string Password)
        {
            Username_ = Username;
            Password_ = Password;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Order order = new Order(Username_, Password_);
            order.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery(Username_ , Password_);
            delivery.Show();
        }
    }
}
