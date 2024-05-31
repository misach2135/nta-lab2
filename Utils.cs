using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Utils
    {
        public static BigInteger Mod(BigInteger a, BigInteger n)
        {
            if (a < 0)
            {
                a = -a * (n - 1);
            }

            BigInteger res = a % n;
            return res;
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

        //public static long PowMod(long a, long n, long p)
        //{
        //    if (a == 0) return 0;

        //    long res = 1;

        //    while (n != 0)
        //    {
        //        if ((n & 1) == 1)
        //        {
        //            res *= a;
        //            res = Mod(res, p);
        //        }

        //        a *= a;
        //        a = Mod(a, p);
        //        n >>= 1;
        //    }

        //    return res;
        //}

        public static BigInteger ExtendedGCD(BigInteger x, BigInteger n, out BigInteger xReverse)
        {
            xReverse = 0;

            BigInteger rPrev = x;
            BigInteger r = n;
            BigInteger q = 0;

            BigInteger u1 = 1;
            BigInteger u2 = 0;
            BigInteger u3 = 0;

            BigInteger v1 = 0;
            BigInteger v2 = 1;
            BigInteger v3 = 0;

            while (true)
            {
                (q, BigInteger rNext) = BigInteger.DivRem(rPrev, r);

                u3 = u1 - (u2 * q);
                v3 = v1 - (v2 * q);

                if (rNext == 0) break;

                // Preparing for the next iteration
                rPrev = r;
                r = rNext;
                u1 = u2;
                u2 = u3;
                v1 = v2;
                v2 = v3;
            }

            if (r == 1) xReverse = Mod(u2, n);

            return r;
        }
        
        public static BigInteger CongruencesSolver(List<BigInteger> ys, List<BigInteger> mods)
        {
            BigInteger N = 1;
            BigInteger X = 0;

            foreach(var n in mods)
            {
                N *= n;
            }

            for(int i = 0; i < ys.Count; i++)
            {
                BigInteger N_i = N / mods[i];
                BigInteger N_iReverse = 0;
                ExtendedGCD(N_i, mods[i], out N_iReverse);
                X += N_i * N_iReverse * ys[i];
            }

            return Mod(X, N);

        }

    }
}
