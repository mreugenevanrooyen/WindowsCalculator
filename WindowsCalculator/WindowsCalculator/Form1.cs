using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsCalculator
{
    public partial class Form1 : Form
    {
        double value = 0;
        string operation = "";
        bool operationPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (result.Text == "0" || operationPressed)
                result.Clear();
            operationPressed = false;
            Button b = (Button)sender;

            if (b.Text == ".")
            {

                if (!result.Text.Contains("."))
                    result.Text = result.Text + b.Text;
            }
            else
                 result.Text = result.Text + b.Text;
            lblEquation.Focus();
        }

        private void ClearAll_Click(object sender, EventArgs e)
        {
            result.Clear();
            result.Text = "0";
            value = 0;
            lblEquation.Text = "";
            
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (result.Text == "Cannot divide by zero ")
            {
                result.Text = "0";
                return;
            }
            if (value != 0)
            {
                PerformCheck(b);
            }
            else if (b.Text == "√")
            {
                try
                {
                    result.Text = Calculate.SquareRoot(double.Parse(result.Text, CultureInfo.CurrentCulture)).ToString();
                    value = Calculate.SquareRoot(double.Parse(result.Text, CultureInfo.CurrentCulture));

                }
                catch (Exception)
                {
                    
                    throw;
                }

            }
            else if (b.Text == "×²")
            {
                result.Text = Calculate.Squared(double.Parse(result.Text, CultureInfo.InstalledUICulture)).ToString();
            }
            else if (b.Text == "←")
            {
                if (result.Text.Length - 1 == 0)
                {
                    result.Text = "0";
                }
                else
                {
                    result.Text = double.Parse(result.Text.Remove(result.Text.Length - 1),CultureInfo.InvariantCulture).ToString();
                }

            }
            else if (b.Text == "¹/×")
                if (result.Text == "0")
                {
                    result.Text = "Cannot divide by zero ";
                }
                else
                {
                    result.Text = Calculate.Reciprocal(double.Parse(result.Text)).ToString();
                }
            else
            {
                operation = b.Text;
                value = double.Parse(result.Text, CultureInfo.InvariantCulture);
                operationPressed = true;
                lblEquation.Text = value + " " + operation;

            }
            lblEquation.Focus();

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            result.Text = "0";
            value = 0;
            lblEquation.Text = "";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            lblEquation.Text = "";
            if (result.Text == ".")
            {
                result.Text = "0.0";
            }
            switch (operation)
            {
                case "+":
                    result.Text = Calculate.Add(value,double.Parse(result.Text, CultureInfo.InvariantCulture)).ToString();
                    break;
                case "-":
                    result.Text = Calculate.Minus(value,double.Parse(result.Text, CultureInfo.InvariantCulture)).ToString();
                    break;
                case "×":
                    result.Text = Calculate.Multiply(value,double.Parse(result.Text, CultureInfo.InvariantCulture)).ToString();
                    break;
                case "/":
                    if (result.Text == "0")
                    {
                        result.Text = "Cannot divide by zero ";
                    }
                    else
                    {
                        result.Text = Calculate.Divide(value, double.Parse(result.Text, CultureInfo.CurrentCulture)).ToString();
                    }
                    break;
                case "√":
                    result.Text = Calculate.SquareRoot(double.Parse(result.Text, CultureInfo.CurrentCulture)).ToString();
                    break;
                case "←":
                    if (result.Text.Length -1 == 0)
                    {
                        result.Text = "0";
                    }
                    else
                    {
                        result.Text = Calculate.BackSpace(double.Parse(result.Text)).ToString();
                    }
                    break;
                case "×²":
                        result.Text = Calculate.Squared(double.Parse(result.Text, CultureInfo.CurrentCulture)).ToString();
                    break;
                case "¹/×":
                    if (result.Text == "0")
                    {
                        result.Text = "Cannot divide by zero ";
                    }
                    else
                    {
                        result.Text = Calculate.Reciprocal(double.Parse(result.Text, CultureInfo.CurrentCulture)).ToString();
                    }
                    break;
                default:
                    break;
            }
            if (result.Text != "Cannot divide by zero ")
            {
                value = double.Parse(result.Text);
            }
            else
            {
                value = 0;
            }
            operation = "";
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                result.Text = "0";
                value = 0;
                lblEquation.Text = "";
            }

            switch (e.KeyChar.ToString())
            {
                case "0":
                    zero.PerformClick();
                    break;
                case "1":
                    one.PerformClick();
                    break;
                case "2":
                    two.PerformClick();
                    break;
                case "3":
                    three.PerformClick();
                    break;
                case "4":
                    four.PerformClick();
                    break;
                case "5":
                    five.PerformClick();
                    break;
                case "6":
                    six.PerformClick();
                    break;
                case "7":
                    seven.PerformClick();
                    break;
                case "8":
                    eight.PerformClick();
                    break;
                case "9":
                    nine.PerformClick();
                    break;
                case "+":
                    add.PerformClick();
                    break;
                case "-":
                    minus.PerformClick();
                    break;
                case "×":
                    multiply.PerformClick();
                    break;
                case "*":
                    multiply.PerformClick();
                    break;
                case "/":
                    divide.PerformClick();
                    break;
                case "=":
                    btnEqual.PerformClick();
                    break;
                case "√":
                    SquareRoot.PerformClick();
                    break;
                case "←":
                    backspace.PerformClick();
                    break;
                case "¹/×":
                    reciprocal.PerformClick();
                    break;
                case ".":
                    dec.PerformClick();
                    break;
                case "×²":
                    Squared.PerformClick();
                    break;
                default:
                    break;
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                backspace.PerformClick();
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnEqual.PerformClick();
            }
        }

        protected void PerformCheck(Button btn)
        {
            operation = "";
            if (btn.Text == "√")
                result.Text = Calculate.SquareRoot(double.Parse(result.Text, CultureInfo.CurrentCulture)).ToString();
            if (btn.Text == "←")
                if (result.Text.Length - 1 == 0)
                {
                    result.Text = "0";
                }
                else
                {
                     result.Text = double.Parse(result.Text.Remove(result.Text.Length - 1)).ToString();
                }
            if (btn.Text == "¹/×")
            if (result.Text == "0")
            {
                result.Text = "Cannot divide by zero ";
            }
            else
            {
                result.Text = Calculate.Reciprocal(double.Parse(result.Text)).ToString();
                    
            }
            if (btn.Text == "×²")
                result.Text = Calculate.Squared(double.Parse(result.Text, CultureInfo.CurrentCulture)).ToString();
            value = double.Parse(result.Text, CultureInfo.InvariantCulture);
            btnEqual.PerformClick();
            operationPressed = true;
            operation = btn.Text;
            lblEquation.Text = value + " " + operation;
        }


    }
}
