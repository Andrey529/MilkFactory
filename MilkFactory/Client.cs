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
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientShow clientShow = new ClientShow();
            clientShow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientAdd clientAdd = new ClientAdd();
            clientAdd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientDelete clientDelete = new ClientDelete();
            clientDelete.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClientUpdate clientUpdate = new ClientUpdate();
            clientUpdate.Show();
        }
    }
}
