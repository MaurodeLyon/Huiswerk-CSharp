using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Diagnostische_toets
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoMarkt autoMarkt = new AutoMarkt();
            autoMarkt.fillAutos();
            foreach (Auto auto in autoMarkt.autos)
            {
                Console.WriteLine(auto.ToString());
            }

            string path = "C:/Users/mauro/Desktop/test.txt";

            List<string> list = new List<string>();
            for (int i = 0; i < autoMarkt.autos.Count; i++)
            {
                list.Add(autoMarkt.autos[i].ToString());
            }
            string[] array = list.ToArray<string>();
            File.WriteAllLines(path, array);
            string[] data = File.ReadAllLines(path);
            foreach (string item in data)
            {
                Console.WriteLine(item);
            }
            Console.Read();
        }
        /*
        object is T controleert of een object een bepaalde type is 
        object as T verandert het object in een ander object checked conversion
        */
    }
}
