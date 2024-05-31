using System;
using System.Collections.Generic;
using System.Numerics;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(string.Join(',', Utils.Factor(new BigInteger(1024))));

            Console.WriteLine(DLPSolver.PoligHellman(547417, 110474, 670303));

            BigInteger rev = 0;

            Console.WriteLine(Utils.ExtendedGCD(7, 29, out rev));

            Console.WriteLine("Reverse: {0}", rev);

            List<BigInteger> ys = [1, 2, 3];
            List<BigInteger> mods = [2, 3, 7];

            //Console.WriteLine(Utils.CongruencesSolver(ys, mods));

        }
    }
}
