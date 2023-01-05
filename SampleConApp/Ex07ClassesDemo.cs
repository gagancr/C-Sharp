using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public double Balance { get; private set; } = 5000; //initializing balance while creating the account

        public void credit(int amount) => Balance += amount;
        public void debit(int amount)
        {
            if (amount > Balance)
                throw new Exception("insufficient funds");

            Balance -= amount;
        }
    }

    class AccountManager
    {
        private Account[] _accounts = null;
        private int _size = 0;
        public AccountManager(int size)
        {
            _size = size;
            _accounts = new Account[_size];
        }

        public void AddNewAccount(Account acc)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_accounts[i]==null)
                {
                    _accounts[i] = new Account { AccountId = acc.AccountId, Name = acc.Name };
                    _accounts[i].credit((int)acc.Balance);
                    return;

                }
            }
        }
        public void UpdateAccountDetails(Account acc)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_accounts[i] != null && _accounts[i].AccountId == acc.AccountId)
                {
                    _accounts[i].Name = acc.Name;
                    return;
                }
            }
            throw new Exception("Account not found to update");
        }

        public void DeleteAccount(int id)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_accounts[i] != null && _accounts[i].AccountId == id)
                {
                    //.NET does not allow to delete an object. 
                    _accounts[i] = null; 
                    return;
                }
            }
            throw new Exception("No Account found to delete");

        }
        public Account FindAccount(int id)
        {
            foreach (Account acc in _accounts)
            {
                if (acc != null && acc.AccountId == id)
                    return acc;
            }
            throw new Exception("No Account found");
        }


    }

    class Employee
    {
        int id;
        string name, address;
        double salary;

        public int empId
        {
            get { return id; }
            set { id = value; }
        }
        public string empName
        {
            get => name;
            set => name = value;
        }
        public string empAddress
        {
            get => address;
            set => address = value;
        }
        public double empSalary
        {
            get => salary;
            set => salary = value;
        }
    }
    class Ex07ClassesDemo
    {
        static void Main(string[] args)
        {
            //employee emp = new employee { empaddress = "germany", empid = 6996, empname = "hitler", empsalary = 22000 };
            //console.writeline("the name is" + emp.empname);
            //account acc = new account { accountid = 111, name = "raskutti" };
            //Console.WriteLine("the balance is " + acc.Balance);
            //acc.credit(2500);
            //Console.WriteLine("credited RS " + 2500);
            //Console.WriteLine("the balance is " + acc.Balance);

            //try
            //{
            //    acc.debit(8500);

            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e.Message);
            //}

            //Console.WriteLine("the balance is " + acc.Balance);
            Console.WriteLine("enter the account count u want to create");
            int count = Convert.ToInt32(Console.ReadLine());
            AccountManager mgr = new AccountManager(count);
            try
            {
                mgr.FindAccount(123);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
