using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostische_toets
{
    class LeaseAuto : Auto
    {
        private int leaseKosten;
        private int bijtellingspercentage;

        public LeaseAuto(string merk, string type, string omschrijving, int prijs, DateTime bouwdatum,brandstof stof, int leaseKosten, int bijtellingspercentage) : base(merk, type, omschrijving, prijs, bouwdatum,stof)
        {
            this.leaseKosten = leaseKosten;
            this.bijtellingspercentage = bijtellingspercentage;
        }
        public Tuple<decimal, int> geefKosten()
        {
            return Tuple.Create((decimal)leaseKosten, bijtellingspercentage);
        }

        public void geefKosten(out decimal leaseKosten, out int bijtellingspercentage)
        {
            leaseKosten = this.leaseKosten;
            bijtellingspercentage = this.bijtellingspercentage;
        }

        public void testGeefkosten()
        {
            Tuple<decimal, int> kosten = geefKosten();
            Console.WriteLine($"kosten: {kosten.Item1} bijtellingspercentage: {kosten.Item2}");

            decimal bedrag;
            int percentage;
            geefKosten(out bedrag, out percentage);
            Console.WriteLine($"kosten: {bedrag} bijtellingspercentageL {kosten}");
            Console.Read();
        }

        public override double berekenJaarKosten(double aantalKm)
        {
            return bijtellingspercentage / 100 * prijs ?? 100000 * 0.42;
        }
        public override string ToString()
        {
            return string.Format("merk: {0}, type: {1}, prijs: {2},leeftijd: {3} jaar en {4} dagen, kosten bij 15000 Km {5}", merk, type, omschrijving, leeftijd.Days / 365, leeftijd.Days % 365, berekenJaarKosten(15000));
        }
    }
}
