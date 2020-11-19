using System;

namespace lel
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] kast = new int[5];
            int[] låst = new int[kast.Length];
            string[] input = new string[kast.Length];
            bool locked = false;
            for (int i = 0; i < låst.Length; i++) låst[i] = 0;
            while (!locked) {
            int antalLåst = 0;
            for (int i = 0; i < kast.Length; i++) kast[i] = rnd.Next(1, 7);
            for (int i = 0; i < kast.Length; i++) if(låst[i] == 0) System.Console.WriteLine($"Kast {(i+1)}: {kast[i]}");
            input = Console.ReadLine().Split(' ');
            for (int i = 0; i < kast.Length; i++) for (int k = 0; k < input.Length; k++) if ((int.Parse(input[k]) - 1) == i) låst[i] = kast[i];
            for (int i = 0; i < låst.Length; i++) if (låst[i] != 0) antalLåst++;
            if (antalLåst == låst.Length) locked = true;
            }
            System.Console.WriteLine($"Slutgiltiga kast");
            foreach (int i in låst) System.Console.WriteLine(i);
        }
    }
}
