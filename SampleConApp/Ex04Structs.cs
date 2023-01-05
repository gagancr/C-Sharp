using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    struct Employee
    {
       public int EmpId { get; set; }
       public string EmpName { get; set;}
       public string EmpAddress { get; set; }
       public double EmpSalary { get; set; }

        public string GetDetails()
        {
            return $"Name is {EmpName} from {EmpAddress} with salary of {EmpSalary}";
        }


    }
   
    class Ex04Structs
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee { EmpId = 3310, EmpAddress = "mysuru", EmpName = "Gagan", EmpSalary = 28000 };

            Console.WriteLine(emp.GetDetails());
        }
    }
}
