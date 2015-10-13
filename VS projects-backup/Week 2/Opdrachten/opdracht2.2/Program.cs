using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace opdracht2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            // ga na of je toegang hebt naar statische proporties
            /*Console.WriteLine(System.Environment.MachineName);
            Console.WriteLine(System.Environment.OSVersion);
            Console.WriteLine(System.Environment.ProcessorCount);
            Console.WriteLine(System.Environment.UserName);
            Console.WriteLine(System.Environment.CurrentDirectory);
            Console.WriteLine(System.Environment.SpecialFolder.MyPictures);
           */

            List<string> list = new List<string>();
            list.Add(System.Environment.MachineName);
            list.Add(System.Environment.OSVersion.ToString());
            list.Add(System.Environment.ProcessorCount.ToString());
            list.Add(System.Environment.UserName);
            list.Add(System.Environment.CurrentDirectory);
            list.Add(System.Environment.SpecialFolder.MyPictures.ToString());
            //list.ForEach(Console.WriteLine);

            string path = System.Environment.CurrentDirectory;
            string txtFile = Path.Combine(path, "test.txt");
            File.WriteAllLines(txtFile, list);
            File.ReadAllLines(txtFile).ToList().ForEach(Console.WriteLine);

            string path2 = System.Environment.CurrentDirectory;
            string txtFile2 = Path.Combine(path2, "test2.txt");
            string stringList = string.Join(", ", list.ToArray());
            File.WriteAllText(txtFile2, stringList);
            Console.WriteLine(File.ReadAllText(txtFile2));


            Console.Read();
        }
    }
}
