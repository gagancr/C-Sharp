using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class Ex02_DataTypes
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"the range of byte is between {byte.MinValue} and {byte.MaxValue}");
            Console.WriteLine($"the range of long is between {long.MinValue} and {long.MaxValue}");
            Console.WriteLine($"the range of int is between {int.MinValue} and {int.MaxValue}");

            int ivalue = 223;
          //  long value = int.MaxValue; // implicit casting
            long lvalue = long.MaxValue;

            ivalue = (int)(lvalue);  //explicit casting


            //checked
            //{
            //    ivalue = (int)(lvalue);  //explicit casting

            //}

            Console.WriteLine("THE INT VALUE NOW IS "+ivalue);
        }
    }
}
