using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfBankServices
{
    public class BankServices : IBankService
    {
        //private string fromAccount = "Acc01";
        //private string toAccount = "Acc02";
        private double balance = 100000;
        public double Deposite(double amt)
        {
            balance = balance + amt;
            return balance;
        }
        public double GetBalance()
        {
            return balance;
        }
        public double Transfer(string toAcc, double amt)
        {
            balance = balance - amt;
            return balance;

        }
        public double Withdraw(double amt)
        {
            balance = balance - amt;
            return balance;
        }
    }
}
