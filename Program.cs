using System;
using System.Numerics;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(string.Join(',', Utils.Factor(new BigInteger(1024))));

            DLPSolver.SilverGelman(5, 11, 97);

        }
    }
}
