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
    public partial class Order : Form
    {
        private string Username_;
        private string Password_;
        public Order(string Username, string Password)
        {
            Username_ = Username;
            Password_ = Password;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderShow orderShow = new OrderShow(Username_, Password_);
            orderShow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderAdd orderAdd = new OrderAdd(Username_, Password_);
            orderAdd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OrderDelete orderDelete = new OrderDelete(Username_, Password_);
            orderDelete.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrderUpdate orderUpdate = new OrderUpdate(Username_, Password_);
            orderUpdate.Show();
        }
    }
}
