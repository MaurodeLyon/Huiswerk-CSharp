using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTime
{
    public struct Time
    {
        private readonly int hours;
        public int minutes;

        public Time(int hh, int mm)
        {
            this.hours = hh;
            this.minutes = mm;
        }

        public override String ToString()
        {
            return  $"{hours:00}:{minutes:00}";
        }
    }
    class TestTime
    {
        public static void Main()
        {
            Time t1 = new Time(12,0);
            Time t2 = t1;
            t1.minutes = 100;
            Console.WriteLine("t1={0} and t2={1}" , t1, t2);
            Console.Read();
        }
    }
}

