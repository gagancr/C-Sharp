using System;
namespace SampleConApp
{
    enum WeekDay { Mon, Tue, Wed, Thu, Fri };
    class EnumEx
    {
        static void Main(string[] args)
        {
            WeekDay day = WeekDay.Mon;
            Console.WriteLine($"selected day is {day}");

            Console.WriteLine("enter the day you want to come to office from below possible days ");

            Array possileDay = Enum.GetValues(typeof(WeekDay));

            for(int i=0;i<possileDay.Length;i++)
                Console.WriteLine(possileDay.GetValue(i));

            object inputval = Enum.Parse(typeof(WeekDay), Console.ReadLine(), true);

            WeekDay selectedDay = (WeekDay)inputval;
            Console.WriteLine($"the selected day is {selectedDay}");

        }
    }
}