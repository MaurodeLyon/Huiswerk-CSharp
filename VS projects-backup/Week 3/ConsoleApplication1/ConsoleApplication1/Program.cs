using System;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApplication1d
{
    class Program
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Newtonsoft.Json.Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("CPU");
                writer.WriteValue("Intel");
                writer.WritePropertyName("PSU");
                writer.WriteValue("500W");
                writer.WritePropertyName("Drives");
                writer.WriteStartArray();
                writer.WriteValue("DVD read/writer");
                writer.WriteComment("(broken)");
                writer.WriteValue("500 gigabyte hard drive");
                writer.WriteValue("200 gigabype hard drive");
                writer.WriteEnd();
                writer.WriteEndObject();
            }
            File.WriteAllText(Environment.CurrentDirectory + "/rhcdata.json", sw.ToString());
            Console.WriteLine(sw.ToString());
            Console.ReadLine();
        }


        public Program()
        {

        }
    }
}