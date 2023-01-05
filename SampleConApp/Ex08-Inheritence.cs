using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
   
    
    class Accounts
    {
        public int AccountNumber { get; set; }
        public double Balance { get; set; } = 5000;
        public string AccountName { get; set; }
    }

    class SbiAccount :Accounts
    {
        public void Credit(int amount) => Balance += amount;
        public void Debit(int amount) => Balance -= amount;
    }
    class RdAccount : Accounts
    {
        int amount = 5000;
        public void MakePayment()
        {
            Balance += amount;
            Console.WriteLine($"payment successfull of RS : {amount} \nAvailable Balance is Rs: {Balance}");
        }
    }
    class Ex08_Inheritence
    {
        static void Main(string[] args)
        {
            RdAccount rd = new RdAccount();
            rd.MakePayment();
            SbiAccount sbi = new SbiAccount();
             Console.WriteLine(sbi.Balance);
            sbi.Credit(2000);
            sbi.Debit(6000);
            Console.WriteLine(sbi.Balance);

        }
    }
}
