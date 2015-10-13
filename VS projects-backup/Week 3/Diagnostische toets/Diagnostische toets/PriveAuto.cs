using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostische_toets
{
    class PriveAuto : Auto
    {
        private int brandstofverbruik;

        public PriveAuto(string merk, string type, string omschrijving, int prijs, DateTime bouwdatum,brandstof stof, int brandstofverbruik) : base(merk, type, omschrijving, prijs, bouwdatum, stof)
        {
            this.brandstofverbruik = brandstofverbruik;
        }
        public override double berekenJaarKosten(double aantalKm)
        {
            return 0.04 * prijs ?? 100000 + aantalKm * brandstofverbruik * 0.02;
        }

        public override string ToString()
        {
            return string.Format("merk: {0}, type: {1}, prijs: {2},leeftijd: {3} jaar en {4} dagen, kosten bij 15000 Km {5}", merk, type, omschrijving, leeftijd.Days / 365, leeftijd.Days % 365, berekenJaarKosten(15000));
        }
    }

}
