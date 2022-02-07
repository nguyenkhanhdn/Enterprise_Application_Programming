using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceCalculator
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        float Add(int a, int b);
        [OperationContract]
        float Sub(int a, int b);
        [OperationContract]
        float Mul(int a, int b);
        [OperationContract]
        float Div(int a, int b);

    }

}
