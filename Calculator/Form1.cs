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
        private decimal result = 0;
        private String operationToPerform = "";
        private List<decimal> results;
        bool isOperationPerformed = false;

        public mainForm()
        {
            InitializeComponent();
            results = new List<decimal>();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((box_Content.Text == "0") || (isOperationPerformed))
            {
                box_Content.Clear();
            }

            Button buttonPressed = (Button)sender;
            isOperationPerformed = false;

            if (buttonPressed.Text == ".")
            {
                if (!box_Content.Text.Contains("."))
                {
                    box_Content.Text = box_Content.Text + buttonPressed.Text;
                }
            }
            else
            {
                box_Content.Text = box_Content.Text + buttonPressed.Text;
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (result != 0)
            {
                equalsSignBtn.PerformClick();

            }

            operationToPerform = btn.Text;
            result = decimal.Parse(box_Content.Text);
            lblCurrentOperation.Text = result + " " + operationToPerform;
            isOperationPerformed = true;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            box_Content.Text = "0";
            lblCurrentOperation.Text = "";
        }

        private void clearEntryBtn_Click(object sender, EventArgs e)
        {
            box_Content.Text = "0";
            result = 0;
        }

        private void equalsSignBtn_Click(object sender, EventArgs e)
        {
            decimal operation;

            switch (operationToPerform)
            {
                case "+":
                    operation = (result + decimal.Parse(box_Content.Text));
                    box_Content.Text = operation.ToString();
                    results.Add(operation);
                    break;
                case "-":
                    operation = (result - decimal.Parse(box_Content.Text));
                    box_Content.Text = operation.ToString();
                    results.Add(operation);
                    break;
                case "*":
                    operation = (result * decimal.Parse(box_Content.Text));
                    box_Content.Text = operation.ToString();
                    results.Add(operation);
                    break;
                case "/":
                    operation = (result / decimal.Parse(box_Content.Text));
                    box_Content.Text = operation.ToString();
                    results.Add(operation);
                    break;
                case "%":
                    operation = (result % decimal.Parse(box_Content.Text));
                    box_Content.Text = operation.ToString();
                    results.Add(operation);
                    break;
                default:
                    break;
            }

            result = decimal.Parse(box_Content.Text);
            lblCurrentOperation.Text = "";
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            box_Content.Text = box_Content.Text.Remove(box_Content.Text.Length - 1);
        }
    }
}
