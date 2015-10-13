using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace opdracht_3
{
    class Program
    {
        static void Main(string[] args)
        {
            MeetSessie meetSessie = new MeetSessie();
            meetSessie.addMeting(new Meting(1, 2, 3));
            Thread.Sleep(200);
            meetSessie.addMeting(new Meting(4, 5, 6));
            Thread.Sleep(200);
            meetSessie.addMeting(new Meting(7, 8, 9));
            Thread.Sleep(200);
            meetSessie.addMeting(new Meting(10, 11, 12));
            Meting[] array = meetSessie.getMeting().ToArray();
            for (int i = 0; i < meetSessie.getMeting().Count; i++)
            {
                Console.WriteLine(array[i].ToString());
            }
            meetSessie.saveToTxt();
            Console.Read();
        }
    }

    // Meetgegevens van fiets :
    // Snelheid-Afstand-Hartslag
    // Km/h    -Km     -bpm 
    class Meting : IComparable
    {
        private double snelheid { get; set; }
        private double afstand { get; set; }
        private int hartslag { get; set; }
        private DateTime meetMoment { get; } = DateTime.Now;

        public Meting(double snelheid, double afstand, int hartslag)
        {
            this.snelheid = snelheid;
            this.afstand = afstand;
            this.hartslag = hartslag;
        }

        public override string ToString()
        {
            return snelheid + " Km/u - " + afstand + " Km - " + hartslag + " bpm - " + meetMoment.ToLocalTime();
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Meting otherMeting = obj as Meting;
            if (otherMeting != null)
                return this.snelheid.CompareTo(otherMeting.snelheid);
            else
                throw new ArgumentException("Object is not a Mating");
        }
    }

    // Bevat een sessie Metingen
    class MeetSessie
    {
        private List<Meting> metingen;

        public MeetSessie()
        {
            metingen = new List<Meting>();
        }

        public void addMeting(Meting meting)
        {
            metingen.Add(meting);
        }

        public List<Meting> getMeting()
        {
            return metingen;
        }

        public void saveToTxt()
        {
            string path = System.Environment.CurrentDirectory;
            string txtFile = Path.Combine(path, "fietsMetingen.txt");

            List<string> stringList = new List<string>();
            for (int i = 0; i < metingen.Count; i++)
            {
                stringList.Add(metingen[i].ToString());
            }

            File.WriteAllLines(txtFile,stringList);
            Console.WriteLine(File.ReadAllText(txtFile));
        }
    }
}
