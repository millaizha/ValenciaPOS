using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValenciaMidterms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public float Total;
        public float Payment;

        private void Order(object sender, EventArgs e)
        {
            string food = ((Button)sender).Text;
            int i = food.IndexOf('P');
            int j = food.Length;
            string name = food.Substring(j - j, i - 1);
            string foodPrice = food.Substring(i + 1, (j - i) - 1);
            float price = float.Parse(foodPrice);
            lstOrder.Items.Add($"{name}\tP{price}");
            Total += price;
        }

        private void TotalAmount(object sender, EventArgs e)
        {
            txtMoney.Text = string.Format("P{0:0.00}", Total);
            lblLabel.Location = new Point(1083, 794);
            lblLabel.Text = "Total Amount:";
            fplFood.Enabled = false;
            btnPayment.Enabled = true;
            btnTotal.Enabled = false;
        }

        private void EnterPayment(object sender, EventArgs e)
        {
            lblLabel.Location = new Point(1083, 794);
            lblLabel.Text = "Enter Payment:";
            btnPayment.Enabled = false;
            btnChange.Enabled = true;
            txtMoney.Text = string.Empty;
            txtMoney.Focus();
        }

        private void ShowChange(object sender, EventArgs e)
        {
            lblLabel.Text = "Change:";
            lblLabel.Location = new Point(1182, 794);
            Payment = float.Parse(txtMoney.Text);
            btnChange.Enabled = false;
            btnNextCustomer.Enabled = true;
            float change = Payment - Total;
            txtMoney.Text = $"P{change}";
        }

        private void nextCustomer(object sender, EventArgs e)
        {
            fplFood.Enabled = true;
            lstOrder.Items.Clear();
            lblLabel.Text = string.Empty;
            txtMoney.Text = string.Empty;
            Payment = 0;
            Total = 0;
            btnTotal.Enabled = true;
            btnNextCustomer.Enabled = false;
        }
    }
}
