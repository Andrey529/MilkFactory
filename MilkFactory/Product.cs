﻿using System;
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
        private string Username_;
        private string Password_;
        public Product(string Username, string Password)
        {
            Username_ = Username;
            Password_ = Password;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductShow productShow = new ProductShow(Username_, Password_);
            productShow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductAdd productAdd = new ProductAdd(Username_, Password_);
            productAdd.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductDelete productDelete = new ProductDelete(Username_, Password_);
            productDelete.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductUpdate productUpdate = new ProductUpdate(Username_, Password_); 
            productUpdate.Show();
        }
    }
}
