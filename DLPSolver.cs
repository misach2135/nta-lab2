using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    static class DLPSolver
    {

        public static BigInteger BruteForce(BigInteger alpha, BigInteger beta, BigInteger p)
        {
            var res = alpha;
            for (BigInteger x = 1; x <= p - 2; x++)
            {
                res = BigInteger.ModPow(alpha, x, p);
                if (res == beta) return x;
            }

            return -1;
        }

        public static BigInteger SilverGelman(BigInteger alpha, BigInteger beta, BigInteger n)
        {
            // Canonical Factorization

            var factN = Utils.Factor(n - 1);

            List<List<BigInteger>> table1 = [];

            foreach (var p in factN.Keys)
            {
                table1.Add([]);
                for (BigInteger i = 0; i < p; i++)
                {
                    BigInteger r = BigInteger.ModPow(alpha, (n * i) / p, n);
                    table1[^1].Add(r);
                }
            }

            List<BigInteger> xs = [];

            foreach (var p in factN.Keys)
            {
                var x = BruteForce(alpha, beta, BigInteger.Pow(p, factN[p]));
                xs.Add(x);
            }

            return 0;
        }

    }
}
