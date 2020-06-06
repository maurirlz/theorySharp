using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculator
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {

            if (box_Content.Text == "0")
            {
                box_Content.Clear();
            }

            Button buttonPressed = (Button)sender;
            box_Content.Text = box_Content.Text + buttonPressed.Text;
        }
    }
}
