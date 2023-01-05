using System;
//using System.Diagnostics;
namespace SampleConApp
{

    class Ex01FirstProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("testing the right code");

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("enter the age");
           int age =  Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter the name");
            string name  = Console.ReadLine();

            Console.WriteLine("enter the salary");
            int sal = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter the address");
            string address = Console.ReadLine();

            System.Diagnostics.Debug.WriteLine("the entered address is "+address);

            Console.WriteLine("the input results are :\nName : "+name+"\nAddress : "+address+"\nSalary : "+sal);

            Console.WriteLine($"the name is {name} of age {age} from {address} earning salary {sal}");



            //if (age > 21)
            //{
            //    Console.WriteLine("eligible");
            //}
            //else Console.WriteLine("no");
        }
    }
}