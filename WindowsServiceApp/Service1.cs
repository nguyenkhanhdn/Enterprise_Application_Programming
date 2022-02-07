using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceModel;

namespace WindowsServiceApp
{
    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
    }
    // Implement the ICalculator service contract in a service class.
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2; return result;
        }
        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2; return result;
        }
        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            return result;
        }
        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            return result;
        }
    }
    public partial class ServiceHostApp : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public ServiceHostApp()
        {
            InitializeComponent();
            
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            serviceHost = new ServiceHost(typeof(CalculatorService));
            serviceHost.Open();
            Console.WriteLine("Service is running ...");
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart on: " + DateTime.Today.ToLongTimeString());
        
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop.");
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }
    }
}
