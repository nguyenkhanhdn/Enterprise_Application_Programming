using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceCalculator
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Calculator : ICalculator
    {
        public float Add(int a, int b)
        {
            return a +b;
        }
        public float Div(int a, int b)
        {
            return a / b;
        }
        public float Mul(int a, int b)
        {
            return a * b; ;
        }
        public float Sub(int a, int b)
        {
            return a - b;
        }
    }
}
