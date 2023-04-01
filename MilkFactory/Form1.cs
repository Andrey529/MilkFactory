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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 69);
            this.button1.TabIndex = 6;
            this.button1.Text = "Зайти как админ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(298, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 69);
            this.button2.TabIndex = 7;
            this.button2.Text = "Зайти как обычный пользователь";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(560, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserAdmin userAdmin = new UserAdmin("postgres", "01082020");
            userAdmin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserDefault userDefault = new UserDefault("MilkFactoryUser", "MilkFactory");
            userDefault.Show();
        }
    }
}
