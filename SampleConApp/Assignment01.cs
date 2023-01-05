using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Assignment01
    {
       static bool isPrimeNumber(int num)
        {
            // do stuff here
            int prime = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                    prime++;

            }
            if (prime > 2)
                return false;

            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("enter the number of Numbers you want to enter");
            int count = Convert.ToInt16(Console.ReadLine());
            int[] numbersArray = new int[count];
            Console.WriteLine("Enter the numbers ");
            for (int i = 0; i < count; i++)
            {
                numbersArray[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("even numbers");
            for (int i = 0; i < count; i++)
            {
                if (numbersArray[i] % 2 == 0)
                {
                    Console.WriteLine(numbersArray[i]);
                }

            }
            Console.WriteLine("odd numbers");
            for (int i = 0; i < count; i++)
            {
                if (numbersArray[i] % 2 != 0)
                {
                    Console.WriteLine(numbersArray[i]);
                }

            }

            
            Console.WriteLine(isPrimeNumber(Utilities.GetNumber("enter a number to check its prime or not")));

        }

    }
}
