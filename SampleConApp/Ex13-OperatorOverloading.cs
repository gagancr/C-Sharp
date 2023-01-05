using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{

    class Student
    {
        public int id { get; set; }
        public int Fees { get; set; }
        public string name { get; set; }

        public static Student operator + (Student s ,int amount)
        {
            s.Fees += amount;
            return s;
        }
        public static Student operator -(Student s, int amount)
        {
            s.Fees -= amount;
            return s;
        }
        public static bool operator <(Student s, int amount)
        {

            return s.Fees < amount;
        }
        public static bool operator >(Student s, int amount)
        {

            return s.Fees > amount;
        }
        public static bool operator ==(Student s1, Student s2)
        {

            return s1.Fees == s2.Fees;
        }
        public static bool operator !=(Student s1, Student s2)
        {

            return s1.Fees == s2.Fees;
        }
    }
    class Ex13_OperatorOverloading
    {
        static void Main(string[] args)
        {
            Student student = new Student { id = 112, name = "Ump9", Fees = 25000 };
            Student student1 = new Student { id = 113, name = "Ump45", Fees = 20000 };
            Student student2 = new Student { id = 112, name = "Ump36", Fees = 20000 };
            student += 500;
            Console.WriteLine(student.Fees);
            student -= 5000;
            Console.WriteLine(student.Fees);
            Console.WriteLine(student>20000);
            Console.WriteLine(student<21000);

            Console.WriteLine(student2==student1);


        }
    }
}
