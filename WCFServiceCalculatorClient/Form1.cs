using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFServiceCalculatorClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WCFCalculator.CalculatorClient client = new WCFCalculator.CalculatorClient();

            int a = (int)this.numericUpDown1.Value;
            int b = (int)this.numericUpDown2.Value;
            float result = client.Add(a, b);
            this.label3.Text = result.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
