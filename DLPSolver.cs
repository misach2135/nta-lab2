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

        public static BigInteger PoligHellman(BigInteger alpha, BigInteger beta, BigInteger n)
        {
            // Canonical Factorization

            var factN = Utils.Factor(n - 1);

            List<List<BigInteger>> table1 = [];

            foreach (var p in factN.Keys)
            {
                table1.Add([]);
                for (BigInteger i = 0; i < p; i++)
                {
                    BigInteger r = BigInteger.ModPow(alpha, ((n-1) * i) / p, n);
                    table1[^1].Add(r);
                }
            }

            List<List<BigInteger>> xis = [];

            var factNKeysList = factN.Keys.ToList();

            foreach (var p in factN.Keys)
            {
                List<BigInteger> pXis = [];
                for (int i = 0; i < factN[p]; i++)
                {

                    BigInteger alphaExponent = 0;

                    for (int j = 0; j < pXis.Count; j++)
                    {
                        alphaExponent -= pXis[j] * BigInteger.Pow(p, j);
                    }
                    var expAlpha = BigInteger.ModPow(alpha, -alphaExponent, n);
                    Utils.ExtendedGCD(expAlpha, n, out expAlpha);
                    var expBeta = BigInteger.ModPow(beta * expAlpha, (n - 1) / BigInteger.Pow(p, i + 1), n);

                    pXis.Add(table1[factNKeysList.FindIndex(x => x == p)].FindIndex(x => x == expBeta));

                }
                xis.Add(pXis);
            }

            List<BigInteger> xs = [];
            List<BigInteger> mods = [];

            for (int j = 0; j < xis.Count; j++)
            {
                BigInteger X = 0;
                var p = factNKeysList[j];
                for (int i = 0; i < xis[j].Count; i++)
                {
                    X += xis[j][i] * BigInteger.Pow(p, i);
                }
                var mod = BigInteger.Pow(p, factN[p]);
                X = Utils.Mod(X, mod);
                xs.Add(X);
                mods.Add(mod);
            }

            return Utils.CongruencesSolver(xs, mods);
        }

    }
}
