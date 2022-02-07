using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceChanelFactoryDemo;

namespace WCFServiceChanelClient
{
    public partial class Form1 : Form
    {
        ICalculator cal;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = cal.Add(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            NetTcpBinding binding = new NetTcpBinding();
            EndpointAddress addr = new EndpointAddress("net.tcp://localhost:5000/cal");
            ChannelFactory<ICalculator> chn = new ChannelFactory<ICalculator>(binding, addr);
            cal = chn.CreateChannel();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.label1.Text = cal.Sub(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress addr = new EndpointAddress("http://localhost:5050/cal");
            ChannelFactory<ICalculator> chn = new ChannelFactory<ICalculator>(binding, addr);
            ICalculator cal2= chn.CreateChannel();

            MessageBox.Show(cal2.Add(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString());
        }
    }
}

