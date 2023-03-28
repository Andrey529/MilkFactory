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
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 69);
            this.button1.TabIndex = 0;
            this.button1.Text = "Клиенты";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(375, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 69);
            this.button2.TabIndex = 1;
            this.button2.Text = "Продукты";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(621, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 69);
            this.button3.TabIndex = 2;
            this.button3.Text = "Поставщики";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(218, 273);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(156, 69);
            this.button4.TabIndex = 3;
            this.button4.Text = "Заказы";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(516, 273);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(156, 69);
            this.button5.TabIndex = 4;
            this.button5.Text = "Поставки";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(914, 459);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Vendor vendor = new Vendor();
            vendor.Show();
        }
    }
}
