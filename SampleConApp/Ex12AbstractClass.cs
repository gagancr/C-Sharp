using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    
    abstract class Account
    {
        public int Balannce { get; private set; } = 5000;
        public string Name { get; set; }
        public int AccountNo { get; set; }

        public void Credit(int amount) => Balannce += amount;

        public void Debit(int amount)
        {
            if (amount > Balannce)
                throw new Exception("Insufficient funds");

            Balannce -= amount;
        }
        public abstract void Interest();
    }

    class SbAccount : Account
    {
        public override void Interest()
        {
            var p = Balannce;
            var t = 0.25;
            var r = 0.1;

            var interest = p * t * r;
            Credit((int)interest);
            Console.WriteLine(interest);
        }
    }

    class RDAccount : Account
    {
        public override void Interest()
        {
            var principal = 300;
            var rate = 9;
            var time = 4;
            var numOfRec = time * 12;
          //var temp = (1 + (rate / 100));
            var interest = principal * Math.Pow((1 + (rate / 100)), (numOfRec * time));
            Console.WriteLine(interest);
            Credit((int)interest);
        }
    }
    class FdAccount : Account
    {
        public override void Interest()
        {
            var p = Balannce;
            var t = 0.25;
            var r = 0.1;

            var interest =  Math.Pow((p * (1 + r)), t);
            Console.WriteLine(interest);
            Credit((int)interest);
        }
    }
    enum AccountType { SB=1, RD, FD };
    class UI
    {

        static bool x = true;
       
        public static void run()
        {
            do
            {
                Console.WriteLine("Enter 1 to create SB Account\nEnter 2 to create RD Account\nEnter 3 to create FD Account");
                // bool processing = true;
                int input = Utilities.GetNumber("enter a number");
                if (input > 3 || input < 1)
                    x = false;



                AccountType acc = (AccountType)input;

                Account a = FactoryAccount.CreateAccount(acc);
                a.Name = Utilities.Prompt("Enter Name");
                a.AccountNo = Utilities.GetNumber("enter account number");
                Console.WriteLine("Your Balance is " + a.Balannce);
                Console.WriteLine("Your Interest is ");
                a.Interest();
                Console.WriteLine($"Name is{a.Name} Account number is {a.AccountNo} Your Balance is {a.Balannce} ");
            } while (x);
        }
    }
    class FactoryAccount
    {
        public static Account CreateAccount(AccountType acc)
        {
            switch (acc)
            {
                case AccountType.SB:
                    Console.WriteLine("You have chosen SB Account");
                    return new SbAccount();
                    break;
                case AccountType.RD:
                    Console.WriteLine("You have chosen RD Account");
                    return new RDAccount();
                    break;
                case AccountType.FD:
                    Console.WriteLine("You have chosen FD Account");
                    return new FdAccount();
                    break;
                default:
                   
                    throw new Exception("invalid choice");
                    break;
            }
        }

    }
    class Ex12AbstractClass
    {
        static void Main(string[] args)
        {
           
            UI.run();
            
          
        }
    }
}
