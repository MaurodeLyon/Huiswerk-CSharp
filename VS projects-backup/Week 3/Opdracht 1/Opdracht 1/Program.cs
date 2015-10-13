using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //new TestDelegate();
            new TestDelegate2();
        }
    }

    public delegate int Calculate(int value1, int value2);

    class TestDelegate
    {
        public TestDelegate()
        {
            MyCalc mc = new MyCalc();
            Calculate add = mc.add;
            Calculate sub = mc.sub;
            Console.WriteLine("Adding two values: " + add(10, 6));
            Console.WriteLine("Subtracting two values: " + sub(10, 4));
            Console.Read();
        }
    }

    class MyCalc
    {
        public int add(int value1, int value2)
        {
            return value1 + value2;
        }

        public int sub(int value1, int value2)
        {
            return value1 - value2;
        }
    }

    class 
}

