using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1_Delegates
{
    class Program
    {
        // Delegate = Method Type.  
        //	So a Delegate is type-safe function pointer.
        public delegate int Calculate(int value1, int value2);
        // a method, that will be assigned to delegate objects 
        // having the EXACT signature of the delegate
        public int add(int value1, int value2)
        { return value1 + value2; }
        //another method, matching the same delegate: 
        public int sub(int value1, int value2)
        { return value1 - value2; }


        static void Main(string[] args)
        {
            //creating the class which contains the methods 
            //that will be assigned to delegate objects 
            Program mc = new Program();

            //creating delegate objects and assigning appropriate methods //having the EXACT signature of the delegate 
            Calculate add = new Calculate(mc.add);
            Calculate sub = new Calculate(mc.sub);
            //using the delegate objects to call the assigned methods
            Console.WriteLine("Adding two values: " + add(10, 6));
            Console.WriteLine("Subtracting two values: " + sub(10, 4));
            Console.ReadKey();

        }
    }
}

