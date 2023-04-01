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
    public partial class Delivery : Form
    {
        private string Username_;
        private string Password_;
        public Delivery(string Username, string Password)
        {
            Username_ = Username;
            Password_ = Password;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeliveryShow deliveryShow = new DeliveryShow(Username_, Password_);
            deliveryShow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeliveryAdd deliveryAdd = new DeliveryAdd(Username_, Password_);
            deliveryAdd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeliveryDelete deliveryDelete = new DeliveryDelete(Username_, Password_);
            deliveryDelete.Show();
        }
    }
}
