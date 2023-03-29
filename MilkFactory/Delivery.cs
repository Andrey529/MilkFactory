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
        public Delivery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeliveryShow deliveryShow = new DeliveryShow();
            deliveryShow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeliveryAdd deliveryAdd = new DeliveryAdd();
            deliveryAdd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeliveryDelete deliveryDelete = new DeliveryDelete();
            deliveryDelete.Show();
        }
    }
}
