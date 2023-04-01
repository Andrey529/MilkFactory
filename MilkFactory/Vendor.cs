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
    public partial class Vendor : Form
    {
        private string Username_;
        private string Password_;
        public Vendor(string Username, string Password)
        {
            Username_ = Username;
            Password_ = Password;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VendorShow vendorShow = new VendorShow(Username_, Password_);
            vendorShow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VendorAdd vendorAdd = new VendorAdd(Username_, Password_);
            vendorAdd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VendorDelete vendorDelete = new VendorDelete(Username_, Password_);
            vendorDelete.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VendorUpdate vendorUpdate = new VendorUpdate(Username_, Password_);
            vendorUpdate.Show();
        }
    }
}
