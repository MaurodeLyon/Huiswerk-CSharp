using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTime
{
    public struct Time //: IFormattable
    {
        private readonly int hours;
        private readonly int minutes;

        public Time(int hh, int mm)
        {
            this.hours = hh;
            this.minutes = mm;
        }

        public override String ToString()
        {
            return String.Format("{0}:{1}", hours, minutes) + " " + $"{hours:00}:{minutes:00}"; ;
        }

       /* public string ToString(string format, IFormatProvider formatProvider)
        {
            if(String.IsNullOrEmpty(format))
            switch()
            throw new NotImplementedException();
            
        }*/
    }
        class TestTime
        {
            public static void Main()
            {
                Time time1 = new Time(12, 34);
                Time time2 = new Time(23, 41);
                Time time3 = new Time(13, 52);
                Console.WriteLine(time1 + " " + time2 + " " + time3);
                Console.Read();
            }
        }
    }

