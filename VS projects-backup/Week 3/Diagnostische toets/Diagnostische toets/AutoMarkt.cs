using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostische_toets
{
    class AutoMarkt
    {
        public List<Auto> autos { get; } = new List<Auto>();

        public void fillAutos()
        {
            autos.Add(new Auto("Volvo", "A", "goeie auto", 1500, new DateTime(1990, 9, 30),Auto.brandstof.elektrisch));
            autos.Add(new PriveAuto("Audi", "c", "Dure auto", 1337, new DateTime(2010, 2, 20), Auto.brandstof.diesel, 10));
            autos.Add(new LeaseAuto("Renault", "Frans", "Franse auto", 32145, new DateTime(1939, 10, 2), Auto.brandstof.gas, 123, 50));
            autos.Add(new PriveAuto("DAudi", "Dc", "Goedkope auto", 1234, new DateTime(2010, 2, 20), Auto.brandstof.gas, 10));
            autos.Add(new LeaseAuto("Saab", "Baas", "de baas zijn auto", 32145, new DateTime(1993, 11, 2), Auto.brandstof.Benzine, 321, 25));
        }

        public delegate Auto zoekAutosDelegate(Auto auto);
        public Auto oudDuur(Auto auto)
        {
            if (auto.leeftijd.Days / 365 > 10 && auto.prijs > 6000)
                return auto;
            else
                return null;

        }
        public Auto verdachteDieselAuto(Auto auto)
        {
            if (auto.stof == Auto.brandstof.diesel && auto.merk == "Volkswagen")
                return auto;
            else
                return null;

        }
        /*public Auto elektrischeLease(Auto auto)
        {
            if (auto is LeaseAuto)
                return auto;
            else
                return null;
        }*/
        public void zoekAutos(zoekAutosDelegate zoekfunctie)
        {
            foreach (Auto auto in autos)
            {

            }

        }
    }
}
