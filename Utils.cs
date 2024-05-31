using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Utils
    {
        public static long Mod(Int128 a, long n)
        {
            if (a < 0)
            {
                a = -a * (n - 1);
            }

            Int128 res = a % n;
            return (Int64)res;
        }

        // Взято з лаби 1
        public static BigInteger Sqrt(BigInteger value)
        {
            if (value < 0)
                throw new Exception("Cannot compute square root of a negative number.");

            if (value == 0)
                return 0;

            BigInteger low = 0;
            BigInteger high = value;
            BigInteger mid;

            while (low < high)
            {
                mid = (low + high) / 2;
                BigInteger midSquared = mid * mid;

                if (midSquared == value)
                    return mid;
                else if (midSquared < value)
                    low = mid + 1;
                else
                    high = mid;
            }

            return (low - 1);
        }

        private static Int64 TrialDivisions(BigInteger n)
        {
            for (Int64 d = 2; d <= Sqrt(n); d++)
            {
                if (n % d == 0) return d;
            }
            return 1;
        }

        public static Dictionary<BigInteger, int> Factor(BigInteger n)
        {
            Dictionary<BigInteger, int> res = [];
            BigInteger d = n;
            while (true)
            {
                d = TrialDivisions(n);
                if (d == 1) break;
                if (!res.ContainsKey(d)) res.Add(d, 0);
                res[d]++;
                n /= d;
            }
            if (!res.ContainsKey(n)) res.Add(n, 1);
            else res[n]++;
            return res;

        }
        
        public static long PowMod(long a, long n, long p)
        {
            if (a == 0) return 0;

            long res = 1;

            while (n != 0)
            {
                if ((n & 1) == 1)
                {
                    res *= a;
                    res = Mod(res, p);
                }

                a *= a;
                a = Mod(a, p);
                n >>= 1;
            }

            return res;
        }

        public static BigInteger ExtendedGCD(BigInteger x, BigInteger n, out BigInteger xReverse)
        {
            xReverse = 0;

            (BigInteger q, BigInteger r) = BigInteger.DivRem(x, n);
            BigInteger s1 = 1;
            BigInteger s2 = 0;
            BigInteger s3 = 1;
            BigInteger t1 = 0;
            BigInteger t2 = 1;
            BigInteger t3 = t1 - q * t2;

            while (r >= 0)
            {

            }

            return 0;
        }

    }
}
