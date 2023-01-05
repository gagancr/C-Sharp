using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{

    class BaseClass

    {
        public void BaseFunc() => Console.WriteLine("Base Func ");

    }
    class DerivedClass : BaseClass
    {
        public new void BaseFunc() => Console.WriteLine("Base func implemented in Derived");// new keyword is just to avoid warning
        public void DerivedFunc() => Console.WriteLine("Derived Func Implementation");
    }
    class Ex11_MethodHiding
    {
        static void Main(string[] args)
        {
            //BaseClass instance = new BaseClass();
            //instance.BaseFunc();

            //DerivedClass derived = new DerivedClass();
            //derived.

            BaseClass instance2 = new DerivedClass();
            instance2.BaseFunc();   //even instance2 is object of DerivedClass you cannot access DerivedClass's function.  
            

           
            if(instance2 is DerivedClass)  // after downcasting you can implement it 
            {
                DerivedClass copy = instance2 as DerivedClass;
                //or you can do it in java way .. it will also work the same
               // DerivedClass d2 = (DerivedClass)instance2;
                copy.DerivedFunc();
                copy.BaseFunc();
            }
        }
    }
}
