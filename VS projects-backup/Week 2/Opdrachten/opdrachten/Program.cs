using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdrachten
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(3, 4);
            Console.WriteLine(f1 == f1);
            Console.WriteLine(f1 != f2);
            Console.WriteLine(f1 < f2);
            Console.WriteLine(f2 > f1);
            Console.Read();

        }
    }
    class Fraction
    {

        // num(erator) (teller) en (den)umerator(noemer):
        int num, den;

        public Fraction(int num, int den)
        {
            this.num = num;
            this.den = den;
        }

        // overload operator +  
        // all operator overload definitions should be: public static  
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);
        }
        // overload operator *
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.num * b.num, a.den * b.den);
        }
        public static bool operator <(Fraction a, Fraction b)
        {
            double fractionA = a.num * a.den;
            double fractionB = b.num * b.den;

            if (fractionA < fractionB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >(Fraction a, Fraction b)
        {
            double fractionA = a.num * a.den;
            double fractionB = b.num * b.den;

            if (fractionA > fractionB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            double fractionA = a.num * a.den;
            double fractionB = b.num * b.den;

            if (fractionA == fractionB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            double fractionA = a.num * a.den;
            double fractionB = b.num * b.den;

            if (fractionA != fractionB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // user-defined conversion from Fraction to double
        //  In general, implicit conversion operators should:
        //	- never throw exceptions and 
        //	- never lose information
        public static implicit operator double (Fraction f)
        {
            return (double)f.num / f.den;
        }

        // override object.Equals
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Fraction f = (Fraction)obj;
            double fractionA = this.num * this.den;
            double fractionB = f.num * f.den;
            if (fractionA == fractionB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format($"({num} / {den})");
        }
    }
}
