using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1_Eigen_Delegate
{
    class Program
    {
        delegate void Abonnement();
        static void Main(string[] args)
        {


            AbonnementOpties abonnementOpties = new AbonnementOpties();

            Abonnement abonnement = null;

            Console.WriteLine("Huidige Abonnement veranderen? j/n");
            var antwoord = Console.ReadLine();
            if (antwoord.Equals("j"))
            {
                Console.WriteLine("Wilt u bel mogelijkheden");
                antwoord = Console.ReadLine();
                if (antwoord.Equals("j"))
                {
                    abonnement += abonnementOpties.addBellen;
                }
                Console.WriteLine("Wilt u SMS mogelijkheden");
                antwoord = Console.ReadLine();
                if (antwoord.Equals("j"))
                {
                    abonnement += abonnementOpties.addSMS;
                }
                Console.WriteLine("Wilt u 3G mogelijkheden");
                antwoord = Console.ReadLine();
                if (antwoord.Equals("j"))
                {
                    abonnement += abonnementOpties.add3G;
                }
                Console.WriteLine("Wilt u 4G mogelijkheden");
                antwoord = Console.ReadLine();
                if (antwoord.Equals("j"))
                {
                    abonnement += abonnementOpties.add4G;
                }
                Console.WriteLine("u huidige Abonnement is:");
                abonnement.Invoke();
            }
            else
            {
                Console.WriteLine("U heeft u abonnement niet gewijzigd");
            }
            Console.ReadLine();
        }
    }

    public class AbonnementOpties
    {
        public void addBellen()
        {
            Console.WriteLine("Bellen");
        }

        public void addSMS()
        {
            Console.WriteLine("SMS");
        }

        public void add3G()
        {
            Console.WriteLine("3G");
        }

        public void add4G()
        {
            Console.WriteLine("4G");
        }
    }
}
