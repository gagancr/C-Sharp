using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{

    class Business
    {
        public virtual void makePayment(string mode, double amount)
        {
            if (mode == "card")
                Console.WriteLine("payment mode not accepted");
            else Console.WriteLine($"payment mode accepted by {mode} for Rs: {amount}");
        }
    }
    class TechBusiness : Business
    {
        public override void makePayment(string mode, double amount)
        {
            if (mode == "cheque")
                Console.WriteLine("payment mode not accepted");
            else Console.WriteLine($"payment mode accepted by {mode} for Rs: {amount}");
        }
    }
    class BusinessFactory
    {
        public static Business GetObject(string arg)
        {
            if (arg.ToUpper() == "BUSINESS")
                return new Business();
            else if (arg.ToUpper() == "TECHBUSINESS")
                return new TechBusiness();
            else
                throw new Exception("Entered Business is not available with us !!!");
        }
    }
    class Ex09_MethodOverriding
    {
        string BusinessType = Utilities.Prompt("enter the business name");
      //  Business b = BusinessFactory.GetObject(BusinessType);
    }
}

