using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Belsessie Test
            /* BelSessie sessie = new BelSessie(DateTime.Now.TimeOfDay, 123456);
            System.Threading.Thread.Sleep(5000);
            sessie.stopSessie();
            Console.WriteLine(sessie.getSessieTijd());
            Console.Read();*/
        }
    }

    class BelSessie
    {
        private Tuple<TimeSpan, TimeSpan, TimeSpan, int> startStop { get; set; }
        private TimeSpan start;
        private TimeSpan stop;
        private TimeSpan sessieTijd { get; set; }
        int gebeldeNummer;

        public BelSessie(TimeSpan start, int gebeldeNummer)
        {
            this.start = start;
            this.gebeldeNummer = gebeldeNummer;
        }

        public void stopSessie()
        {
            stop = DateTime.Now.TimeOfDay;
            sessieTijd = stop - start;
            startStop = new Tuple<TimeSpan, TimeSpan, TimeSpan, int>(start, stop, sessieTijd, gebeldeNummer);
        }

        public Tuple<TimeSpan, TimeSpan, TimeSpan, int> getStartStop()
        {
            return startStop;
        }
    }

    class Factuur
    {
        double totaalPrijs;
        List<BelSessie> sessies;
        public Factuur()
        {
        }
        public void stuur()
        {
        }

    }

    class Abonnement
    {
        private int vrijeBelminuten;
        private double dalTarief, piekTarief, prijsAbonnement;
        public Abonnement(int vrijeBelminuten, double dalTarief, double piekTarief, double prijsAbonnement)
        {
            this.vrijeBelminuten = vrijeBelminuten;
            this.dalTarief = dalTarief;
            this.piekTarief = piekTarief;
            this.prijsAbonnement = prijsAbonnement;
        }
    }

    enum soortAbonnement { goedkoop, voordeel, premium }

    class FacturenSysteem
    {
        TimeSpan tijd;
        TimeSpan veranderingInTijd;
        TimeSpan periode;

        public FacturenSysteem(TimeSpan periode)
        {
            this.periode = periode;
            tijd = new TimeSpan();
            veranderingInTijd = new TimeSpan();
        }

        public void Tick()
        {
            veranderingInTijd = DateTime.Now.TimeOfDay - tijd;
            if (veranderingInTijd > periode)
            {
                new Factuur().stuur();
            }
        }


    }

}
