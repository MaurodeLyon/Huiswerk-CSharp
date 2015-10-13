using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostische_toets
{
    class Auto
    {
        public string merk { get; }
        public string type { get; }
        public string omschrijving { get; }
        public int? prijs;
        public DateTime bouwdatum {get; }
        public TimeSpan leeftijd { get; }
        public brandstof stof { get; }

        public enum brandstof
        {
            Benzine, diesel, gas, elektrisch
        }

        public Auto(string merk, string type, string omschrijving, int prijs, DateTime bouwdatum, brandstof stof)
        {
            this.merk = merk;
            this.type = type;
            this.omschrijving = omschrijving;
            this.prijs = prijs;
            this.bouwdatum = bouwdatum;
            leeftijd = bouwdatum - DateTime.Now;
            this.stof = stof;
        }

        //berekenJaarkosten moet virtual zijn omdat auto geen abstracte klassen is en er daardoor dus wel een functionele methode moet zijn
        public virtual double berekenJaarKosten(double aantalKm)
        {
            return (double)prijs;
        }

        public override string ToString()
        {
            return $"merk: {merk}, type: {type}, prijs: {prijs},leeftijd: {leeftijd.Days / 365} jaar en {leeftijd.Days % 365} dagen ";
        }
    }
}
