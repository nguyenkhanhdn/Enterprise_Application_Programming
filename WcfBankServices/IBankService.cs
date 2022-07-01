using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfBankServices
{
    [ServiceContract]
    public interface IBankService
    {
        [OperationContract]
        double GetBalance();
        [OperationContract]
        double Withdraw(double amt);
        [OperationContract]
        double Deposite(double amt);
        [OperationContract]
        double Transfer(string toAcc, double amt);

    }
}
