using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exampleApp
{
    public partial class Form1 : Form
    {
        checkClass cc = new checkClass();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int get = cc.checkUser(textBox1.Text, textBox2.Text);
            if (get == 1)
            {
                label3.Visible = true;
                label3.Text = "You have successfully logged in.";
            }else if (get == 0)
            {
                label3.Visible = true;
                label3.Text = "There is an error in the entered information.";
            }
            else
            {
                label3.Visible = true;
                label3.Text = "An error occurred.";
            }
        }
    }
}
