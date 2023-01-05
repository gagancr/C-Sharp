using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Assignment02
    {
        static void Main(string[] args)
        {
            
            bool cond = true;
            while (cond)
            {
                Console.WriteLine("enter the first value for calculation");

                int firstVal = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter the second value for calculation");
                int secondVal = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("ENTER THE OPERATOR OF WHICH OPERATION YOU WANT TO PERFORM");
                switch (Console.ReadLine())
                {
                    case "+":
                        Console.WriteLine("the sum of entered values is "+(firstVal + secondVal));
                        break;

                    case "-":
                        Console.WriteLine("the difference of entered values is "+(firstVal - secondVal));
                        break;

                    case "*":
                        Console.WriteLine("the product of entered values is "+(firstVal * secondVal));
                        break;

                    case "/":
                        Console.WriteLine("the division of entered values is "+(firstVal / secondVal));
                        break;

                    default:
                        Console.WriteLine("enter valid symbol");
                        break;


                }
                Console.WriteLine("*********************************");
                Console.WriteLine("enter 0 to abort calculation");
                Console.WriteLine("type any number to continue");
                int opt= Convert.ToInt32(Console.ReadLine());
                if (opt == 0)
                    cond = false;
            }
            Console.WriteLine("*********************************");
            Console.WriteLine("calculation ended");
        }
    }
}
