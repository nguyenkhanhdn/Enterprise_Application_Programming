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

namespace WCFServiceChanelFactoryHost
{
    public partial class Form1 : Form
    {
        ServiceHost host;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(Calculator));
            NetTcpBinding binding = new NetTcpBinding();
            host.AddServiceEndpoint(typeof(ICalculator), binding, new Uri("net.tcp://localhost:5000/Cal"));

            BasicHttpBinding binding2 = new BasicHttpBinding();
            host.AddServiceEndpoint(typeof(ICalculator), binding2, new Uri("http://localhost:5050/Cal"));

            host.Open();
            label1.Text = "started";
            button1.Enabled = false;
            button2.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            host.Close();
            this.label1.Text = "Close.";
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
