using System;

namespace Uppgift_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Ange tal1: ");
            int tal1 = int.Parse(args[0]);

            //Console.Write("Ange tal2: ");
            int tal2 = int.Parse(args[1]);

            int summa = tal1 + tal2;
            int produkt = tal1 * tal2;

            Console.WriteLine($"Summan är {summa} \nprodukten är {produkt}.");
        }
    }
}
