using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Ex05Arrays
    {
        static void Main(string[] args)
        {
            //  string[] names = { "qq", "ww", "ee", "rr", "tt", "yy" };

            Console.WriteLine("enter the number of names you want to enter ");
            int count =Convert.ToInt16( Console.ReadLine());

            string []names = new string[count];

            Console.WriteLine("enter the names to traverse ");
            for (int i = 0; i<count; i++)
            {
                names[i] = Console.ReadLine();
            }

            Console.WriteLine(names.Length);
            Console.WriteLine("the dimensions of array :"+ names.Rank);
            Console.WriteLine("the length of the first dimension :"+names.GetLength(0));

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

           
        }
    }
}
