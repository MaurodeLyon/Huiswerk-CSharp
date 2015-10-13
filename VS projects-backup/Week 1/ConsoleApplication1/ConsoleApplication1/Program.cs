using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening1_1
{
    public struct Time
    {
        private readonly int minutes;

        public Time(int hh, int mm)
        {
            this.minutes = 60 * hh + mm;
        }

        public override String ToString()
        {
            return minutes.ToString();
        }
    }

    class TestTime
    {

        public static void Main()
        {
            Time time1 = new Time(12, 34);
            Time time2 = new Time(23, 41);
            Time time3 = new Time(13, 52);
            Console.WriteLine(time1.ToString() +" "+ time2.ToString() + " " + time3.ToString());
            Console.Read();
        }
    }
}