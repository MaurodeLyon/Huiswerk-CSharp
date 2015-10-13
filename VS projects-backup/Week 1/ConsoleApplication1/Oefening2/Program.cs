using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections;

namespace Oefening2
{
    class Program
    {
        static void Main(string[] args)
        {
            BerekenControleGetal("INGB0001234567", "NL");

        }

        public static string BerekenControleGetal(string rekeningIdentificatie, string landcode)
        {
            //stap 1 + 2
            string controleGetal = rekeningIdentificatie + landcode;
            var stringBuilder = new StringBuilder(controleGetal);
            
            //stap 3
            int x = 0;
            for (int i = 0; i < controleGetal.Length; i++)
            {
                int index = char.ToUpper(controleGetal[i]) - 55;
                if (index > 0)
                {
                    stringBuilder.Remove(x, 1);
                    stringBuilder.Insert(x, index);
                    x++;
                }
                x++;
            }
            controleGetal = stringBuilder.ToString();
            //stap 4
            controleGetal += "00";
            BigInteger berekening = BigInteger.Parse(controleGetal);
            //stap 5
            berekening = berekening % 97;
            //stap 6
            berekening= 98 - berekening;
            controleGetal = berekening.ToString();

            Console.WriteLine(controleGetal);
            Console.Read();
            return controleGetal;
        }
    }
}
