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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductShow productShow = new ProductShow();
            productShow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductAdd productAdd = new ProductAdd();
            productAdd.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductDelete productDelete = new ProductDelete();
            productDelete.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductUpdate productUpdate = new ProductUpdate(); 
            productUpdate.Show();
        }
    }
}
