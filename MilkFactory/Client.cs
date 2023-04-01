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
        private string Username_;
        private string Password_;
        public Client(string Username, string Password)
        {
            Username_ = Username;
            Password_ = Password;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientShow clientShow = new ClientShow(Username_, Password_);
            clientShow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClientAdd clientAdd = new ClientAdd(Username_, Password_);
            clientAdd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientDelete clientDelete = new ClientDelete(Username_, Password_);
            clientDelete.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClientUpdate clientUpdate = new ClientUpdate(Username_, Password_);
            clientUpdate.Show();
        }
    }
}
